using InfluxDB.Client;
using InfluxDB.Client.Writes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogsExperiments.Services
{
    public class InfluxDbMetricService : IDisposable, IInfluxDbMetricService
    {
        private readonly InfluxDBClient _influx;
        private readonly string _bucket;
        private readonly string _org;

        private bool _disposedValue;

        public InfluxDbMetricService(InfluxDbConnectionParameters connectionParameters)
        {
            _influx = InfluxDBClientFactory.Create(connectionParameters.Host, connectionParameters.Token);

            _bucket = connectionParameters.Bucket;
            _org = connectionParameters.Org;
        }

        public void WritePoint(PointData point)
        {
            using (var writeApi = _influx.GetWriteApi())
            {
                writeApi.WritePoint(_bucket, _org, point);

            }
        }

        public async Task WritePointAsync(PointData point)
        {
            await Task.Run(() => WritePoint(point));
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    if (_influx != null)
                    {
                        _influx.Dispose();
                    }
                }

                _disposedValue = true;
            }
        }


        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
