
using BBCommon.Contracts;

namespace BBBusiness.Model
{
    public class BookBorrowing : IBookBorrowing
    {
       public int Id { get; }
        public DateTime BorrowingDate { get; set; }
        public DateTime DueDate { get; set; }
        public int BookId { get; set; }
        public required IBook BorrowedBook { get; set; }

        public required string BorrowerName { get; set; }
       

    }
}
