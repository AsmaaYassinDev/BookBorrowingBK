using BBCommon.Contracts;
using System.Runtime.Serialization;

namespace BBAPI.Wrappers
{
    public class BookBorrowingRequest : IBookBorrowing
    {
        public int BookId { get; set; }
        public string BorrowerName { get; set; }
        public DateTime BorrowingDate { get; set; }
        public DateTime DueDate { get; set; }

        public int Id { get; set; }
        [IgnoreDataMember]
        public IBook BorrowedBook { get; set; }

       
    }
}
