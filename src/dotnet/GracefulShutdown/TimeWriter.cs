using System;
using System.Timers;

namespace GracefulShutdown
{
    public class TimeWriter : IDisposable
    {
        public void Dispose()
        {
            _timer?.Dispose();
        }

        private Timer _timer;

        public TimeWriter()
        {
            _timer = new System.Timers.Timer(2000);
            _timer.Elapsed += OnTimerElapsed;
        }

        private void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            var dateTimeTime = DateTime.UtcNow;
            Console.WriteLine($"UTC Date and Time:  {dateTimeTime:F}");
        }

        public void Start()
        {
            _timer.Start();
        }

        public void Stop()
        {
            _timer.Stop();
        }
    }
}