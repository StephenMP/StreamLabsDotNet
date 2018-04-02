using StreamLabsDotNet.Client.Models;
using System;
using UnityEngine;

namespace StreamLabsDotNet.Unity
{
    public class Client : StreamLabsDotNet.Client.Client
    {
        private readonly GameObject _threadDispatcher;

        #region EVENTS        
        public new event EventHandler<bool> OnConnected;

        public new event EventHandler<bool> OnDisconnected;

        public new event EventHandler<string> OnError;

        public new event EventHandler<string> OnUndocumented;

        public new event EventHandler<StreamlabsEvent<DonationMessage>> OnDonation;
        public new event EventHandler<StreamlabelsEvent> OnStreamlabels;

        public new event EventHandler<StreamlabsEvent<TwitchFollowMessage>> OnTwitchFollow;
        public new event EventHandler<StreamlabsEvent<TwitchSubscriptionMessage>> OnTwitchSubscription;
        public new event EventHandler<StreamlabsEvent<TwitchHostMessage>> OnTwitchHost;
        public new event EventHandler<StreamlabsEvent<TwitchCheerMessage>> OnTwitchCheer;

        public new event EventHandler<StreamlabsEvent<YouTubeSubscriptionMessage>> OnYouTubeSubscription;
        public new event EventHandler<StreamlabsEvent<YouTubeSponsorMessage>> OnYouTubeSponsor;
        public new event EventHandler<StreamlabsEvent<YouTubeSuperchatMessage>> OnYouTubeSuperchat;

        public new event EventHandler<StreamlabsEvent<MixerFollowMessage>> OnMixerFollow;
        public new event EventHandler<StreamlabsEvent<MixerSubscriptionMessage>> OnMixerSubscription;
        public new event EventHandler<StreamlabsEvent<MixerHostMessage>> OnMixerHost;

        #endregion

        public Client() : base()
        {
            _threadDispatcher = new GameObject($"StreamLabsClientUnityDispatcher-{Guid.NewGuid()}");
            _threadDispatcher.AddComponent<ThreadDispatcher>();
            UnityEngine.Object.DontDestroyOnLoad(_threadDispatcher);

            base.OnConnected += ((object sender, bool e) => { ThreadDispatcher.Instance().Enqueue(() => OnConnected?.Invoke(sender, e)); });
            base.OnDisconnected += ((object sender, bool e) => { ThreadDispatcher.Instance().Enqueue(() => OnDisconnected?.Invoke(sender, e)); });
            base.OnError += ((object sender, string e) => { ThreadDispatcher.Instance().Enqueue(() => OnError?.Invoke(sender, e)); });
            base.OnUndocumented += ((object sender, string e) => { ThreadDispatcher.Instance().Enqueue(() => OnUndocumented?.Invoke(sender, e)); });

            base.OnDonation += ((object sender, StreamlabsEvent<DonationMessage> e) => { ThreadDispatcher.Instance().Enqueue(() => OnDonation?.Invoke(sender, e)); });
            base.OnStreamlabels += ((object sender, StreamlabelsEvent e) => { ThreadDispatcher.Instance().Enqueue(() => OnStreamlabels?.Invoke(sender, e)); });

            base.OnTwitchFollow += ((object sender, StreamlabsEvent<TwitchFollowMessage> e) => { ThreadDispatcher.Instance().Enqueue(() => OnTwitchFollow?.Invoke(sender, e)); });
            base.OnTwitchSubscription += ((object sender, StreamlabsEvent<TwitchSubscriptionMessage> e) => { ThreadDispatcher.Instance().Enqueue(() => OnTwitchSubscription?.Invoke(sender, e)); });
            base.OnTwitchHost += ((object sender, StreamlabsEvent<TwitchHostMessage> e) => { ThreadDispatcher.Instance().Enqueue(() => OnTwitchHost?.Invoke(sender, e)); });
            base.OnTwitchCheer += ((object sender, StreamlabsEvent<TwitchCheerMessage> e) => { ThreadDispatcher.Instance().Enqueue(() => OnTwitchCheer?.Invoke(sender, e)); });

            base.OnYouTubeSubscription += ((object sender, StreamlabsEvent<YouTubeSubscriptionMessage> e) => { ThreadDispatcher.Instance().Enqueue(() => OnYouTubeSubscription?.Invoke(sender, e)); });
            base.OnYouTubeSponsor += ((object sender, StreamlabsEvent<YouTubeSponsorMessage> e) => { ThreadDispatcher.Instance().Enqueue(() => OnYouTubeSponsor?.Invoke(sender, e)); });
            base.OnYouTubeSuperchat += ((object sender, StreamlabsEvent<YouTubeSuperchatMessage> e) => { ThreadDispatcher.Instance().Enqueue(() => OnYouTubeSuperchat?.Invoke(sender, e)); });

            base.OnMixerFollow += ((object sender, StreamlabsEvent<MixerFollowMessage> e) => { ThreadDispatcher.Instance().Enqueue(() => OnMixerFollow?.Invoke(sender, e)); });
            base.OnMixerSubscription += ((object sender, StreamlabsEvent<MixerSubscriptionMessage> e) => { ThreadDispatcher.Instance().Enqueue(() => OnMixerSubscription?.Invoke(sender, e)); });
            base.OnMixerHost += ((object sender, StreamlabsEvent<MixerHostMessage> e) => { ThreadDispatcher.Instance().Enqueue(() => OnMixerHost?.Invoke(sender, e)); });
        
        }

    }
}
