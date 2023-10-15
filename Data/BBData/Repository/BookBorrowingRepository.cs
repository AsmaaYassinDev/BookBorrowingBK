
using BBCommon.Contracts;
using BBCommon.Repository;
using BBData.DB;
using BBData.Model;
using Microsoft.EntityFrameworkCore;


namespace EmployeeCrud.Data.Repository
{
    public class BookBorrowingRepository : IRepository<IBook>
    {
        private readonly BookBorrowingDBContext _context;
        public BookBorrowingRepository(BookBorrowingDBContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<IBook>> GetAll()
        {
            return await _context.Books.ToListAsync();
        }
        public async Task<IBook> GetById(int id)
        {
            return await _context.Books.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<bool> Add(IBook book)
        {
            try
            {
                var isSuccessed = false;           
                _context.Books.Add(new Book(book));
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
        public async Task<bool> Update(IBook updatedEmployee)
        {
            var isSuccessed = false;
            var oldEmployee = await _context.Books.SingleOrDefaultAsync(i => i.Id == updatedEmployee.Id);
            if (oldEmployee == null)
                return isSuccessed;
            //oldEmployee.UpdateProperties(updatedEmployee);
            int returnNumber = await _context.SaveChangesAsync();

            if (returnNumber == 1)
                isSuccessed = true;

            return isSuccessed;
        }
        public async Task<bool> Delete(int deletedEmployeeID)
        {
            var isSuccessed = false;

            var deletedShip = _context.Books.SingleOrDefaultAsync(i => i.Id == deletedEmployeeID).Result;
            if (deletedShip == null)
                return isSuccessed;

            _context.Remove(deletedShip);
            int returnNumber = await _context.SaveChangesAsync();

            if (returnNumber == 1)
                isSuccessed = true;
            return isSuccessed;
        }
    }
}
