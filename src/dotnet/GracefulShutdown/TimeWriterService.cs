using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace GracefulShutdown
{
    public class TimeWriterService : IHostedService
    {
        private readonly IHostApplicationLifetime _appLifetime;
        private readonly TimeWriter _timeWriter;

        public TimeWriterService(
            IHostApplicationLifetime appLifetime)
        {
            _appLifetime = appLifetime;
            _timeWriter = new TimeWriter();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _appLifetime.ApplicationStarted.Register(OnStarted);
            _appLifetime.ApplicationStopping.Register(OnStopping);
            _appLifetime.ApplicationStopped.Register(OnStopped);

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        private void OnStarted()
        {
            _timeWriter.Start();
        }

        private void OnStopping()
        {
            _timeWriter.Stop();
        }

        private void OnStopped()
        {
            _timeWriter.Dispose();
        }
    }
}