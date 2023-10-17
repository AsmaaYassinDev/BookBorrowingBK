
using BBCommon.Contracts;
using BBCommon.Repository;
using BBData.DB;
using BBData.Model;
using Microsoft.EntityFrameworkCore;

namespace BBData.Repository
{
    public class CountryRepository : ICountryRepository
    {
        private readonly BookBorrowingDBContext _context;
        public CountryRepository(BookBorrowingDBContext context)
        {
            this._context = context;
        }

        

        public async Task<bool> Add(ICountry country)
        {
            try
            {
                var isSuccessed = false;           
                _context.Countries.Add(new Country(country));
                int returnNumber = await _context.SaveChangesAsync();
                if (returnNumber == 1)
                    isSuccessed = true;
                return isSuccessed;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        
        public async Task<ICountry> GetById(int id)
        {
            return await _context.Countries.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<IEnumerable<ICountry>> GetAll()
        {
            return await _context.Countries.ToListAsync();
        }
    }
}
