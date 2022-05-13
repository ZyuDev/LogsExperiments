using System;
using System.Collections.Generic;
using LogsExperiments.Helpers;
using LogsExperiments.Models;
using Microsoft.AspNetCore.Components;
using Nest;


namespace LogsExperiments.Pages
{
    
    public partial class ElasticTestPage: ComponentBase
    {
        private ElasticClient _client;
        
        private EventModel _eventModel;

        private IList<string> _availableUsers;
        private IList<string> _availableDocuments;
        private IList<string> _availableEvents;

        private List<string> _messagesSend;
        
        
        protected override void OnInitialized()
        {
            var node = new Uri("https://endpoint");
            var settings = new ConnectionSettings(node);
            
            _client = new ElasticClient(settings);
            
            _eventModel = new EventModel();

            _availableDocuments = EventModelBuilder.AvailableDocuments();
            _availableEvents = EventModelBuilder.AvailableEvents();
            _availableUsers = EventModelBuilder.AvailableUsers();

            _messagesSend = new List<string>();
        }

        private void OnSendClick()
        {
            var response = _client.Index(_eventModel, idx => idx.Index("test_index"));

            if (response.IsValid)
            {
                var message = $"{DateTime.Now}: {_eventModel}";
                _messagesSend.Add(message);
            }
            else
            {
                _messagesSend.Add(response.ToString());
            }
            
           
        }
    }
}
