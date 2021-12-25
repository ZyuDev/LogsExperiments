using InfluxDB.Client.Writes;
using System.Threading.Tasks;

namespace LogsExperiments.Services
{
    public interface IInfluxDbMetricService
    {
        void Dispose();
        void WritePoint(PointData point);
        Task WritePointAsync(PointData point);
    }
}