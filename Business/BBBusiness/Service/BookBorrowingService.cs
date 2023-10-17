
using BBCommon.Contracts;
using BBCommon.Repository;
using BBCommon.Service;

namespace BBBusiness.Service
{
    public class BookBorrowingService : IBookBorrowingService
    {
        private readonly IBookBorrowingRepository _bookBorrowingRepository;
        private readonly ICountryRepository _countryRepository;

        public BookBorrowingService(IBookBorrowingRepository bookBorrowingRepository, ICountryRepository countryRepository)
        {
            _bookBorrowingRepository = bookBorrowingRepository;
            _countryRepository = countryRepository;

        }

        public async Task<bool> AddBookBorrowing(IBookBorrowing bookBorrowing)
        {
         return  await _bookBorrowingRepository.Add(bookBorrowing);
        }

        public async Task<IBookBorrowing> GetBookBorrowings(int id)
        {
            return await _bookBorrowingRepository.GetById(id);
        }

        public async Task<IEnumerable<IBookBorrowing>> GetBookBorrowings()
        {
            return await _bookBorrowingRepository.GetAll();
        }
        public async Task<ICountry> GetCountry(int id)
        {
            return await _countryRepository.GetById(id);
        }
    }
}
