using ClassesWebsite.Data;
using ClassesWebsite.Models;

namespace ClassesWebsite.Services
{
    public interface ILocationService
    {
        IEnumerable<State> GetStatesByCountryId(int countryId);
        IEnumerable<City> GetCitiesByStateId(int stateId);
        IEnumerable<Country> GetGetAllCountries();
    }

    public class LocationService : ILocationService
    {
        private readonly ClassesDbContext _dbContext;

        public LocationService(ClassesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Country> GetGetAllCountries()
        {
            // Fetch all countries from the database
            return _dbContext.Countries.ToList();
        }

        public IEnumerable<State> GetStatesByCountryId(int countryId)
        {
            // Fetch states based on the provided countryId
            return _dbContext.States
                .Where(s => s.CountryId == countryId)
                .ToList();
        }

        public IEnumerable<City> GetCitiesByStateId(int stateId)
        {
            // Fetch cities based on the provided stateId
            return _dbContext.Cities
                .Where(c => c.StateId == stateId)
                .ToList();
        }
    }


}
