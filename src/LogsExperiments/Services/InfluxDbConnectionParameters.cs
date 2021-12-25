using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogsExperiments.Services
{
    public class InfluxDbConnectionParameters
    {
        public string Host { get; set; }
        public string Token { get; set; }
        public string  Bucket { get; set; }
        public string Org { get; set; }

        public InfluxDbConnectionParameters()
        {

        }

        public InfluxDbConnectionParameters(IConfiguration configuration)
        {
            Token = configuration["influx_token"];
            Bucket = configuration["influx_bucket"];
            Org = configuration["influx_org"];
            Host = configuration["influx_host"];

        }
    }
}
