
using BBCommon.Contracts;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace BBData.Model
{
    public class BookBorrowing:IBookBorrowing
    {
        private IBookBorrowing bookBorrowing;
        public BookBorrowing()
        {

        }
      
        public BookBorrowing(IBookBorrowing bookBorrowing)
        {
            BorrowerName = bookBorrowing.BorrowerName;
            DueDate = bookBorrowing.DueDate;
            BorrowingDate = bookBorrowing.BorrowingDate;
           
            this.bookBorrowing = bookBorrowing;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
          
        public DateTime BorrowingDate { get; set; }
        public DateTime DueDate { get; set; }
        public  string BorrowerName { get; set; } = "";
   
      

        // Foreign key to Book
        [ForeignKey("Book")]
        public int BookId { get; set; }


        [NotMapped]
        public IBook BorrowedBook
        {
            get
            {
                return Book;
            }
        }
        public virtual  Book Book { get; set; } 
    }
}
