
namespace BBCommon.Contracts
{
    public interface IBookBorrowing
    {
        int Id { get; }
        IBook BorrowedBook { get;}
        int BookId { get; set; }
        DateTime BorrowingDate { get; set; }
        DateTime DueDate { get; set; }
        string BorrowerName { get; set; }
      

    }
}
