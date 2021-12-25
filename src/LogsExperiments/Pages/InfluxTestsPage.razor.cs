using InfluxDB.Client;
using InfluxDB.Client.Api.Domain;
using InfluxDB.Client.Writes;
using LogsExperiments.Helpers;
using LogsExperiments.Models;
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

        private EventModel _eventModel;

        private IList<string> _availableUsers;
        private IList<string> _availableDocuments;
        private IList<string> _availableEvents;

        private List<string> _messagesSend;

        [Inject]
        public IConfiguration Configuration { get; set; }

        protected override void OnInitialized()
        {
            _token = Configuration["influx_token"];
            _bucket = Configuration["influx_bucket"];
            _org = Configuration["influx_org"];
            _host = Configuration["influx_host"];

            _influx = InfluxDBClientFactory.Create(_host, _token);

            _eventModel = new EventModel();

            _availableDocuments = EventModelBuilder.AvailableDocuments();
            _availableEvents = EventModelBuilder.AvailableEvents();
            _availableUsers = EventModelBuilder.AvailableUsers();

            _messagesSend = new List<string>();

        }

        private void OnSendClick()
        {
            var point = PointData.Measurement(_eventModel.EventName)
                .Tag("name", _eventModel.ObjectName)
                .Tag("usr",_eventModel.UserName)
                .Field("count", 1)
                .Timestamp(DateTime.UtcNow, WritePrecision.Ns);


            using (var writeApi = _influx.GetWriteApi())
            {
                writeApi.WritePoint(_bucket, _org, point);
                
            }

            var message = $"{DateTime.Now}: {_eventModel}";
            _messagesSend.Add(message);
        }
    }
}
