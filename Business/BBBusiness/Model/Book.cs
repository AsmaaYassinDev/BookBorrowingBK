

using BBCommon.Contracts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BBBusiness.Model
{
    public class Book : IBook
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";  
        public string ISBN { get; set; } = "";
        public bool IsAvailable { get; set; } = true;
        public IEnumerable<IBookBorrowing> BookBorrowings { get; }

    }
}
