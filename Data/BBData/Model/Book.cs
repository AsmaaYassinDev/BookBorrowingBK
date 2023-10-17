
using BBCommon.Contracts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BBData.Model
{
    public class Book : IBook
    {

        public Book()
        {

        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        public string Title { get; set; } = "";

        public string ISBN { get; set; } = "";
        public bool IsAvailable { get; set; } = true;


        [NotMapped]
        public IEnumerable<IBookBorrowing> BookBorrowings => BookBookBorrowings;

        public virtual ICollection<BookBorrowing> BookBookBorrowings { get; set; }
    }
}
