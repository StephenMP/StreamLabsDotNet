using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace StreamLabsDotNet.Api
{
    public class Api : StreamLabsApiBase
    {
     //   private readonly ILogger<StreamLabsApiBase> _logger;
        public AlertProfiles AlertProfiles { get; private set; }
        public Alerts Alerts { get; private set; }
        public Authentication Authentication { get; private set; }
        public Credits Credits { get; private set; }
        public Donations Donations { get; private set; }
        public Jar Jar { get; private set; }
        public Other Other { get; private set; }
        public Points Points { get; private set; }
        public Sockets Sockets { get; private set; }
        public Users Users { get; private set; }
        public Wheel Wheel { get; private set; }
        public Api(ILogger<StreamLabsApiBase> logger = null) : base(logger)
        {
           // _logger = logger;
            AlertProfiles = new AlertProfiles(logger);
            Alerts = new Alerts(logger);
            Authentication = new Authentication(logger);
            Credits = new Credits(logger);
            Donations = new Donations(logger);
            Jar = new Jar(logger);
            Other = new Other(logger);
            Points = new Points(logger);
            Sockets = new Sockets(logger);
            Users = new Users(logger);
            Wheel = new Wheel(logger);
        }
    }
}
