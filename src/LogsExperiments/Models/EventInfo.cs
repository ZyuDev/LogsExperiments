using InfluxDB.Client.Writes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogsExperiments.Models
{
    public class EventInfo<T>
    {
        public string EventName { get; set; }
        public Dictionary<string, string> Tags { get; set; } = new Dictionary<string, string>();
        public Dictionary<string, T> Values { get; set; } = new Dictionary<string, T>();

        public PointData ToPoint()
        {
            var point = PointData.Measurement(EventName);

            foreach(var kvp in Tags)
            {
                point = point.Tag(kvp.Key, kvp.Value);
            }

            foreach(var kvp in Values)
            {
                if (kvp.Value is int intValue)
                {
                    point = point.Field(kvp.Key, intValue);
                }
                else if (kvp.Value is decimal decimalValue)
                {
                    point = point.Field(kvp.Key, decimalValue);
                }
            }

            return point;
        }
    }
}
