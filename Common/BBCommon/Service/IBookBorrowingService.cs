

using BBCommon.Contracts;

namespace BBCommon.Service
{
    public interface IBookBorrowingService
    {
        Task<IEnumerable<IBookBorrowing>> GetBookBorrowings();
        Task<bool> AddBookBorrowing(IBookBorrowing bookBorrowing);
        Task<ICountry> GetCountry(int id);
        Task<IBookBorrowing> GetBookBorrowings(int id);

    }
}