using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogsExperiments.Models
{
    public class EventModel
    {
        public string EventName { get; set; }
        public string ObjectName { get; set; }
        public string UserName { get; set; }

        public override string ToString()
        {
            return $"{EventName}-{ObjectName}-{UserName}";
        }
    }
}
