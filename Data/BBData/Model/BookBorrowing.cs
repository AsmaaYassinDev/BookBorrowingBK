
using BBCommon.Contracts;

namespace BBData.Model
{
    public class BookBorrowing
    {
        public required IBook BorrowedBook { get; set; }
        public required Borrower Borrower { get; set; }
        public DateTime BorrowingDate { get; set; }
        public DateTime DueDate { get; set; }
    }
}
