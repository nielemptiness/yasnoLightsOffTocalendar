using Newtonsoft.Json;
using RestEase;
using scheduleOff.Domain;

namespace scheduleOff.Core
{
    public sealed class ScheduleService
    {
        private readonly IYasnoClient _client;
        private TimeSchedule _timeScheduleCache;
        public ScheduleService()
        {
            _client = RestClient.For<IYasnoClient>(Links.YasnoKyiv);
        }

        public async Task GetScheduleForHouse(string region, string streetName, string houseNumber, bool validateStreet = false)
        {
            _timeScheduleCache = await _client.GetSchedule();
            
            if (validateStreet)
            {
                var street = await _client.GetStreet(region, streetName);
                streetName = street.First().Street;
            }
            
            if (!string.IsNullOrEmpty(streetName))
            {
                var house = await _client.GetHouse(region, streetName, houseNumber);
                // TODO
                var yourHouse = house.First(h => h.House == "");
                MatchTime(yourHouse);
            }
        }
        

        private void MatchTime(StreetResponse house)
        {
            var group = _timeScheduleCache.MatchGroup(house.Group);
            var grpjsn = JsonConvert.SerializeObject(group);
            Console.WriteLine(grpjsn);
        }
    }
}