using Microsoft.Extensions.Hosting;
using scheduleOff.Core;

namespace scheduleOff
{
    public class Offhost : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var srvc = new ScheduleService();
            //TODO
            await srvc.GetScheduleForHouse("kiev", "", "");
        }
    }
}