using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LeadManager.Api;
using LeadManager.Mappers;
using LeadManager.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace LeadManager.Schedulers
{
    public class ActivitiesSyncScheduler : IHostedService, IDisposable
    {
        private int executionCount = 0;
        private readonly ILogger<ActivitiesSyncScheduler> _logger;
        private Timer _timer;
        private readonly IServiceProvider _services;
        private readonly IHQApi _hqApi;

        public ActivitiesSyncScheduler(ILogger<ActivitiesSyncScheduler> logger, IServiceProvider services, IHQApi hqApi)
        {
            _logger = logger;
            _services = services;
            _hqApi = hqApi;
        }

        public Task StartAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Timed Hosted Service running.");

            _timer = new Timer(DoWork, null, TimeSpan.Zero,
                TimeSpan.FromDays(1));

            return Task.CompletedTask;
        }

        private async void DoWork(object state)
        {
            using (var scope = _services.CreateScope())
            {
                var activityService =
                    scope.ServiceProvider
                        .GetRequiredService<IActivityService>();

                try
                {
                    var count = Interlocked.Increment(ref executionCount);

                    var activities = await activityService.GetActivitiesToSync();
                    var response = await _hqApi.SyncActivities(activities.Select(a => a.ToActivityHQ()));
                    if (response.IsSuccessStatusCode)
                    {
                        await activityService.UpdateSyncDateTime(activities.ToList());
                        _logger.LogInformation($"{activities.Count} records synced!");
                    }
                    else
                    {
                        _logger.LogWarning("No records to sync!");
                    }

                    _logger.LogInformation(
                        "Timed Hosted Service is working. Count: {Count}", count);
                }
                catch (Exception e)
                {
                    _logger.LogError(e.ToString());
                }
            }
        }

        public Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Timed Hosted Service is stopping.");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}