
using System;
using System.Collections.Immutable;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Quobject.EngineIoClientDotNet.Client.Transports;
using Quobject.SocketIoClientDotNet.Client;
using StreamLabsDotNet.Client.Models;
namespace StreamLabsDotNet.Client
{

    public class Client
    {
        private readonly ILogger<Client> _logger;
        private readonly System.Timers.Timer _pingTimer;
        private Socket _socket;
        public Client(ILogger<Client> logger = null)
        {
            _logger = logger;
            //Create ping timer to keep connection open
            _pingTimer = new System.Timers.Timer(59000)
            {
                AutoReset = true
            };
            _pingTimer.Elapsed += _pingTimer_Elapsed;
        }

        public void Connect(string socketToken, bool enableLogging = false)
        {
            _logger?.LogDebug("SocketSetup: Started");
            SocketSetup(socketToken);
            _logger?.LogDebug("SocketSetup: Ended");
            _logger?.LogDebug("Connecting...");
            _socket.Connect();
        }
        public void Disconnect()
        {
            _logger?.LogDebug("Disconnecting...");
            _socket.Disconnect();
        }

        private void SocketSetup(string socketToken)
        {
            _socket = IO.Socket($"wss://sockets.streamlabs.com",
                new IO.Options
                {
                    AutoConnect = false,
                    // Upgrade = true,
                    Transports = ImmutableList.Create(WebSocket.NAME),
                    QueryString = $"token={socketToken}"
                });
            _socket.On(Socket.EVENT_CONNECT, () =>
            {
                _logger?.LogDebug("Connected");
                _pingTimer.Start();
                OnConnected?.Invoke(this, true);

            });
            _socket.On(Socket.EVENT_DISCONNECT, (data) =>
            {
                _logger?.LogDebug($"Disonnected: {data}");
                _pingTimer.Stop();
                OnDisconnected?.Invoke(this, true);
            });
            _socket.On(Socket.EVENT_ERROR, (data) =>
            {
                _logger?.LogDebug($"ErrorData: {data}");
                OnError?.Invoke(this, (string)data);

            });
            _socket.On("event", (eventData) =>
            {
                _logger?.LogTrace($"EventData: {eventData}");
                var streamlabsEvent = JsonConvert.DeserializeObject<StreamlabsEvent>(eventData.ToString());

                _logger?.LogTrace($"Type: {streamlabsEvent.Type}");
                if (string.IsNullOrEmpty(streamlabsEvent.For))
                {
                    _logger?.LogTrace($"For: Empty or null");
                    if (streamlabsEvent.Type == "streamlabels")
                    {
                        var streamlabels = JsonConvert.DeserializeObject<StreamlabelsEvent>(eventData.ToString());
                        _logger?.LogDebug($"Streamlabels deserialized successfully");
                        OnStreamlabels?.Invoke(this, streamlabels);
                    }

                    if (streamlabsEvent.Type == "streamlabels" && streamlabsEvent.Type == "donation")
                    {
                        //Undocumented
                        OnUndocumented?.Invoke(this, eventData.ToString());
                    }
                }
                else
                {
                    _logger?.LogTrace($"For: {streamlabsEvent.For}");
                    ForMessage(streamlabsEvent, eventData);
                }
            });
            _socket.On("pong", (data) =>
            {
                _logger?.LogTrace($"Pong");
            });
        }

        private void _pingTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            _socket.Emit("ping");
        }

        private void ForMessage(StreamlabsEvent streamlabsEvent, object eventData)
        {
            switch (streamlabsEvent.For)
            {
                case "streamlabs":
                    if (streamlabsEvent.Type == "donation")
                    {
                        var donation = JsonConvert.DeserializeObject<StreamlabsEvent<DonationMessage>>(eventData.ToString());
                        _logger?.LogDebug($"Donation deserialized successfully");
                        OnDonation?.Invoke(this, donation);
                    }
                    break;
                case "twitch_account":
                    {
                        switch (streamlabsEvent.Type)
                        {
                            case "follow":
                                {
                                    var follow = JsonConvert.DeserializeObject<StreamlabsEvent<TwitchFollowMessage>>(eventData.ToString());
                                    _logger?.LogDebug($"Twitch Follow deserialized successfully");
                                    OnTwitchFollow?.Invoke(this, follow);
                                }
                                break;
                            case "subscription":
                                {
                                    var sub = JsonConvert.DeserializeObject<StreamlabsEvent<TwitchSubscriptionMessage>>(eventData.ToString());
                                    _logger?.LogDebug($"Twitch Sub deserialized successfully");
                                    OnTwitchSubscription?.Invoke(this, sub);
                                }
                                break;
                            case "host":
                                {
                                    var host = JsonConvert.DeserializeObject<StreamlabsEvent<TwitchHostMessage>>(eventData.ToString());
                                    _logger?.LogDebug($"Twitch Host deserialized successfully");
                                    OnTwitchHost?.Invoke(this, host);
                                }
                                break;
                            case "bits":
                                {
                                    var cheer = JsonConvert.DeserializeObject<StreamlabsEvent<TwitchCheerMessage>>(eventData.ToString());
                                    _logger?.LogDebug($"Twitch Cheer deserialized successfully");
                                    OnTwitchCheer?.Invoke(this, cheer);
                                }
                                break;
                        }
                    }
                    break;
                case "youtube_account":
                    {
                        switch (streamlabsEvent.Type)
                        {
                            case "follow":
                                {
                                    var follow = JsonConvert.DeserializeObject<StreamlabsEvent<YouTubeSubscriptionMessage>>(eventData.ToString());
                                    _logger?.LogDebug($"YouTube Sub deserialized successfully");
                                    OnYouTubeSubscription?.Invoke(this, follow);
                                }
                                break;
                            case "subscription":
                                {
                                    var sub = JsonConvert.DeserializeObject<StreamlabsEvent<YouTubeSponsorMessage>>(eventData.ToString());
                                    _logger?.LogDebug($"YouTube Sponsor deserialized successfully");
                                    OnYouTubeSponsor?.Invoke(this, sub);
                                }
                                break;
                            case "superchat":
                                {
                                    var super = JsonConvert.DeserializeObject<StreamlabsEvent<YouTubeSuperchatMessage>>(eventData.ToString());
                                    _logger?.LogDebug($"YouTube Superchat deserialized successfully");
                                    OnYouTubeSuperchat?.Invoke(this, super);
                                }
                                break;
                        }
                    }
                    break;
                case "mixer_account":
                    {
                        switch (streamlabsEvent.Type)
                        {
                            case "follow":
                                {
                                    var follow = JsonConvert.DeserializeObject<StreamlabsEvent<MixerFollowMessage>>(eventData.ToString());
                                    _logger?.LogDebug($"Mixer Follow deserialized successfully");
                                    OnMixerFollow?.Invoke(this, follow);
                                }
                                break;
                            case "subscription":
                                {
                                    var sub = JsonConvert.DeserializeObject<StreamlabsEvent<MixerSubscriptionMessage>>(eventData.ToString());
                                    _logger?.LogDebug($"Mixer Sub deserialized successfully");
                                    OnMixerSubscription?.Invoke(this, sub);
                                }
                                break;
                            case "host":
                                {
                                    var host = JsonConvert.DeserializeObject<StreamlabsEvent<MixerHostMessage>>(eventData.ToString());
                                    _logger?.LogDebug($"Mixer Host deserialized successfully");
                                    OnMixerHost?.Invoke(this, host);
                                }
                                break;
                        }
                    }
                    break;

            }
        }

        #region EVENTS        
        public event EventHandler<bool> OnConnected;

        public event EventHandler<bool> OnDisconnected;

        public event EventHandler<string> OnError;

        public event EventHandler<string> OnUndocumented;

        public event EventHandler<StreamlabsEvent<DonationMessage>> OnDonation;
        public event EventHandler<StreamlabelsEvent> OnStreamlabels;

        public event EventHandler<StreamlabsEvent<TwitchFollowMessage>> OnTwitchFollow;
        public event EventHandler<StreamlabsEvent<TwitchSubscriptionMessage>> OnTwitchSubscription;
        public event EventHandler<StreamlabsEvent<TwitchHostMessage>> OnTwitchHost;
        public event EventHandler<StreamlabsEvent<TwitchCheerMessage>> OnTwitchCheer;

        public event EventHandler<StreamlabsEvent<YouTubeSubscriptionMessage>> OnYouTubeSubscription;
        public event EventHandler<StreamlabsEvent<YouTubeSponsorMessage>> OnYouTubeSponsor;
        public event EventHandler<StreamlabsEvent<YouTubeSuperchatMessage>> OnYouTubeSuperchat;

        public event EventHandler<StreamlabsEvent<MixerFollowMessage>> OnMixerFollow;
        public event EventHandler<StreamlabsEvent<MixerSubscriptionMessage>> OnMixerSubscription;
        public event EventHandler<StreamlabsEvent<MixerHostMessage>> OnMixerHost;

        #endregion
    }
}
