
namespace BBCommon.Contracts
{
    public interface IBookBorrowing
    {
        IBook BorrowedBook { get; set; }
        IBorrower Borrower { get; set; }
        DateTime BorrowingDate { get; set; }
        DateTime DueDate { get; set; }
    }
}
