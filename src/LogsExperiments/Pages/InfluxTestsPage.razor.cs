using InfluxDB.Client;
using InfluxDB.Client.Api.Domain;
using InfluxDB.Client.Writes;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogsExperiments.Pages
{
    public partial class InfluxTestsPage: ComponentBase
    {
        private string _token;
        private string _host;
        private InfluxDBClient _influx;
        private string _bucket;
        private string _org;

        [Inject]
        public IConfiguration Configuration { get; set; }

        protected override void OnInitialized()
        {
            _token = Configuration["influx_token"];
            _bucket = Configuration["influx_bucket"];
            _org = Configuration["influx_org"];
            _host = Configuration["influx_host"];

            _influx = InfluxDBClientFactory.Create(_host, _token);

        }

        private void OnSendClick()
        {
            var point = PointData.Measurement("document_created")
                .Tag("name", "order")
                .Tag("usr","user_1")
                .Field("count", 1)
                .Timestamp(DateTime.UtcNow, WritePrecision.Ns);


            using (var writeApi = _influx.GetWriteApi())
            {
                writeApi.WritePoint(_bucket, _org, point);
                
            }
        }
    }
}
