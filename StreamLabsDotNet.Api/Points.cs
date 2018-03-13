using Newtonsoft.Json;
using StreamLabsDotNet.Api.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace StreamLabsDotNet.Api
{
    public class Points : StreamLabsApiBase
    {
        public Points(ILogger<StreamLabsApiBase> logger) : base(logger)
        {

        }

        public async Task<PointsResponse> GetPointsAsync(string accessToken, string username, string channel)
        {
            if (string.IsNullOrWhiteSpace(accessToken)) throw new BadParameterException("Access token is not valid. It is not allowed to be null, empty or filled with whitespaces.");
            if (string.IsNullOrWhiteSpace(username)) throw new BadParameterException("Username is not valid. It is not allowed to be null, empty or filled with whitespaces.");
            if (string.IsNullOrWhiteSpace(channel)) throw new BadParameterException("Channel is not valid. It is not allowed to be null, empty or filled with whitespaces.");

            var url = "points";
            var payload = new Dictionary<string, object> {
                { "access_token",accessToken},
                { "username",username},
                { "channel",channel}
            };
            return JsonConvert.DeserializeObject<PointsResponse>((await GeneralRequestAsync(url, "GET", payload, RequestType.Query).ConfigureAwait(false)).Value);
        }

        public async Task<PointsResponse> SubtractPointsAsync(string accessToken, string username, string channel, int points)
        {
            if (string.IsNullOrWhiteSpace(accessToken)) throw new BadParameterException("Access token is not valid. It is not allowed to be null, empty or filled with whitespaces.");
            if (string.IsNullOrWhiteSpace(username)) throw new BadParameterException("Username is not valid. It is not allowed to be null, empty or filled with whitespaces.");
            if (string.IsNullOrWhiteSpace(channel)) throw new BadParameterException("Channel is not valid. It is not allowed to be null, empty or filled with whitespaces.");
            if (points <= 0) throw new BadParameterException("Points need to be a positive integer");

            var url = "points/subtract";
            var payload = new Dictionary<string, object> {
                { "access_token",accessToken},
                { "username",username},
                { "channel",channel},
                { "points",points}
            };
            return JsonConvert.DeserializeObject<PointsResponse>((await GeneralRequestAsync(url, "POST", payload, RequestType.Body).ConfigureAwait(false)).Value);
        }


        public async Task<PointsImportResponse> ImportPointsAsync(string accessToken, string channel, IDictionary<string, int> users)
        {
            if (string.IsNullOrWhiteSpace(accessToken)) throw new BadParameterException("Access token is not valid. It is not allowed to be null, empty or filled with whitespaces.");
            if (string.IsNullOrWhiteSpace(channel)) throw new BadParameterException("Channel is not valid. It is not allowed to be null, empty or filled with whitespaces.");

            var url = "points/import";
            var payload = new Dictionary<string, object> {
                { "access_token",accessToken},
                { "channel",channel}
            };

            foreach (var key in users.Keys)
            {
                payload.Add($"users[{key}]", users[key]);
            }


            return JsonConvert.DeserializeObject<PointsImportResponse>((await GeneralRequestAsync(url, "POST", payload, RequestType.Body).ConfigureAwait(false)).Value);
        }


        public async Task<GroupPointsResponse[]> GroupGetPointsAsync(string accessToken, string channel, IList<string> users)
        {
            if (string.IsNullOrWhiteSpace(accessToken)) throw new BadParameterException("Access token is not valid. It is not allowed to be null, empty or filled with whitespaces.");
            if (string.IsNullOrWhiteSpace(channel)) throw new BadParameterException("Channel is not valid. It is not allowed to be null, empty or filled with whitespaces.");

            var url = "points/group_get_points";
            var payload = new Dictionary<string, object> {
                { "access_token",accessToken},
                { "channel",channel}
            };
            foreach (var user in users)
            {
                payload.Add($"usernames[]", user);
            }
            return JsonConvert.DeserializeObject<GroupPointsResponse[]>((await GeneralRequestAsync(url, "GET", payload, RequestType.Query).ConfigureAwait(false)).Value);
        }


        public async Task<GroupPointsResponse[]> GroupSubtractPointsAsync(string accessToken, string channel, IDictionary<string, int> users)
        {
            if (string.IsNullOrWhiteSpace(accessToken)) throw new BadParameterException("Access token is not valid. It is not allowed to be null, empty or filled with whitespaces.");
            if (string.IsNullOrWhiteSpace(channel)) throw new BadParameterException("Channel is not valid. It is not allowed to be null, empty or filled with whitespaces.");

            var url = "points/import";
            var payload = new Dictionary<string, object> {
                { "access_token",accessToken},
                { "channel",channel}
            };

            foreach (var key in users.Keys)
            {
                payload.Add($"users[{key}]", users[key]);
            }


            return JsonConvert.DeserializeObject<GroupPointsResponse[]>((await GeneralRequestAsync(url, "POST", payload, RequestType.Body).ConfigureAwait(false)).Value);
        }


        public async Task<SuccessUsersResponse> AddPointsToAllAsync(string accessToken, string channel, int value)
        {
            if (string.IsNullOrWhiteSpace(accessToken)) throw new BadParameterException("Access token is not valid. It is not allowed to be null, empty or filled with whitespaces.");
            if (string.IsNullOrWhiteSpace(channel)) throw new BadParameterException("Channel is not valid. It is not allowed to be null, empty or filled with whitespaces.");

            var url = "points/add_to_all";
            var payload = new Dictionary<string, object> {
                { "access_token",accessToken},
                { "channel",channel},
                { "value",value}
            };
            return JsonConvert.DeserializeObject<SuccessUsersResponse>((await GeneralRequestAsync(url, "POST", payload, RequestType.Query).ConfigureAwait(false)).Value);
        }

        private List<string> sortBy = new List<string> { "username", "points", "time_watched" };

        public async Task<UserPointsResponse> GetUserPointsAsync(string accessToken, string username, string sort = "username", string order = "asc", int limit = 100, int page= 1)
        {
            if (string.IsNullOrWhiteSpace(accessToken)) throw new BadParameterException("Access token is not valid. It is not allowed to be null, empty or filled with whitespaces.");
            if (!sortBy.Contains(sort)) throw new BadParameterException("Sort must be one of the following: username, points or time_watched");
            if (string.IsNullOrWhiteSpace(order) &&  (order == "asc" | order == "desc")) throw new BadParameterException("Order must be asc or desc");
            if (page <= 0) throw new BadParameterException("Page need to be a positive integer");
            if (limit <= 0 && limit > 100) throw new BadParameterException("Limit must be in the range 1-100");
            
            var url = "points/user_points";
            var payload = new Dictionary<string, object> {
                { "access_token",accessToken},
                { "sort",sort},
                { "order",order},
                { "limit",limit},
                { "page",page}
            };

            if(!string.IsNullOrEmpty(username))
            {
                payload.Add("username", username);
            }

            return JsonConvert.DeserializeObject<UserPointsResponse>((await GeneralRequestAsync(url, "GET", payload, RequestType.Query).ConfigureAwait(false)).Value);
        }


        public async Task<PointsResponse> UserPointsEditAsync(string accessToken, string username, int points)
        {
            if (string.IsNullOrWhiteSpace(accessToken)) throw new BadParameterException("Access token is not valid. It is not allowed to be null, empty or filled with whitespaces.");
            if (string.IsNullOrWhiteSpace(username)) throw new BadParameterException("Username is not valid. It is not allowed to be null, empty or filled with whitespaces.");
            if (points <= 0) throw new BadParameterException("Points need to be a positive integer");

            var url = "points/user_point_edit";
            var payload = new Dictionary<string, object> {
                { "access_token",accessToken},
                { "username",username},
                { "points",points}
            };
            return JsonConvert.DeserializeObject<PointsResponse>((await GeneralRequestAsync(url, "POST", payload, RequestType.Query).ConfigureAwait(false)).Value);
        }


        public async Task<ResetPointsResponse> ResetPointsAsync(string accessToken)
        {
            if (string.IsNullOrWhiteSpace(accessToken)) throw new BadParameterException("Access token is not valid. It is not allowed to be null, empty or filled with whitespaces.");
       
            var url = "points/reset";
            var payload = new Dictionary<string, object> {
                { "access_token",accessToken}
            };

            return JsonConvert.DeserializeObject<ResetPointsResponse>((await GeneralRequestAsync(url, "POST", payload, RequestType.Query).ConfigureAwait(false)).Value);
        }
    }
}
