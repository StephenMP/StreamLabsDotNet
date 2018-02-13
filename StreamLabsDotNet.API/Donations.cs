﻿using System;
using System.Collections.Generic;
using System.Text;

namespace StreamLabsDotNet.API
{
    public class Donations : ApiBase
    {
        public async Task<DonationsResponse> GetDonationsAsync(string accessToken, int? limit = null, int? after = null, int? before = null, string currency = null, bool? verified = null)
        {
            if (string.IsNullOrWhiteSpace(accessToken)) throw new BadParameterException("The extension secret is not valid. It is not allowed to be null, empty or filled with whitespaces.");

            var url = "donations";
            var payload = new Dictionary<string, object> {
                { "access_token",accessToken}
            };

            if (limit.HasValue) payload.Add("limit", limit.Value);
            if (after.HasValue) payload.Add("after", after.Value);
            if (before.HasValue) payload.Add("before", before.Value);
            if (!string.IsNullOrEmpty(currency)) payload.Add("currency", currency);
            if (verified.HasValue) payload.Add("verified", verified.Value ? "1" : "0");

            return JsonConvert.DeserializeObject<DonationsResponse>((await GeneralRequestAsync(url, "GET", payload, RequestType.Query).ConfigureAwait(false)).Value);
        }
        public async Task<CreateDonationResponse> CreateDonationAsync(string accessToken, string name, string identifier, double amount, string currency, string message = null, DateTime? createdAt = null)
        {
            if (string.IsNullOrWhiteSpace(accessToken)) throw new BadParameterException("The extension secret is not valid. It is not allowed to be null, empty or filled with whitespaces.");
            if (string.IsNullOrWhiteSpace(name)) throw new BadParameterException("The extension secret is not valid. It is not allowed to be null, empty or filled with whitespaces.");
            if (string.IsNullOrWhiteSpace(identifier)) throw new BadParameterException("The extension secret is not valid. It is not allowed to be null, empty or filled with whitespaces.");
            if (string.IsNullOrWhiteSpace(currency)) throw new BadParameterException("The extension secret is not valid. It is not allowed to be null, empty or filled with whitespaces.");
            if (amount <= 0) throw new BadParameterException("The extension secret is not valid. It is not allowed to be null, empty or filled with whitespaces.");

            var url = "donations";
            var payload = new Dictionary<string, object> {
                { "access_token",accessToken},
                { "name",name},
                { "identifier",identifier},
                { "amount",amount},
                { "currency",currency}
            };

            if (!string.IsNullOrEmpty(message)) payload.Add("message", message);
            if (createdAt.HasValue) payload.Add("created_at", GetEpoch());

            return JsonConvert.DeserializeObject<CreateDonationResponse>((await GeneralRequestAsync(url, "POST", payload, RequestType.Query).ConfigureAwait(false)).Value);
        }
    }
}
