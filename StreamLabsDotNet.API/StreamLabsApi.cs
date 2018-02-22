using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace StreamLabsDotNet.Api
{
    public class StreamLabsApi
    {
        private readonly ILogger<StreamLabsApi> _logger;
        public AlertProfiles AlertProfiles { get; private set; }
        public Alerts Alerts { get; private set; }
        public Authentication Authentication { get; private set; }
        public Credits Credits { get; private set; }
        public Donations Donations { get; private set; }
        public Jar Jar { get; private set; }
        public Other Other { get; private set; }
        public Sockets Sockets { get; private set; }
        public Users Users { get; private set; }
        public Wheel Wheel { get; private set; }
        public StreamLabsApi(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<StreamLabsApi>();
            AlertProfiles = new AlertProfiles(loggerFactory.CreateLogger<AlertProfiles>());
            Alerts = new Alerts(loggerFactory.CreateLogger<Alerts>());
            Authentication = new Authentication(loggerFactory.CreateLogger<Authentication>());
            Credits = new Credits(loggerFactory.CreateLogger<Credits>());
            Donations = new Donations(loggerFactory.CreateLogger<Donations>());
            Jar = new Jar(loggerFactory.CreateLogger<Jar>());
            Other = new Other(loggerFactory.CreateLogger<Other>());
            Sockets = new Sockets(loggerFactory.CreateLogger<Sockets>());
            Users = new Users(loggerFactory.CreateLogger<Users>());
            Wheel = new Wheel(loggerFactory.CreateLogger<Wheel>());
        }
    }
}
