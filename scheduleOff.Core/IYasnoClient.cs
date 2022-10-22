using RestEase;
using scheduleOff.Domain;

namespace scheduleOff.Core;

public interface IYasnoClient
{
    [Get("/schedule")]
    Task<TimeSchedule> GetSchedule();
    [Get("/street")]
    Task<StreetResponse[]> GetStreet(string region, string query);
    
    [Get("/house")]
    Task<StreetResponse[]> GetHouse(string region, string street, string query);
}