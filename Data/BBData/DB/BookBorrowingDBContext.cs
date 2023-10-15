using BBData.Model;
using Microsoft.EntityFrameworkCore;

namespace BBData.DB
{
    public class BookBorrowingDBContext : DbContext
    {
        public BookBorrowingDBContext(DbContextOptions<BookBorrowingDBContext> options) : base(options)
        {


        }
        public BookBorrowingDBContext() : base() { }
        public DbSet<Book> Books { get; set; }
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().ToTable("Book").HasKey(m => m.Id);
            //how do we extend the data model?
            modelBuilder.Entity<Book>()
        .HasDiscriminator<string>("Author")       
        .HasValue<Book>("Book")
        .HasValue<NewInfoForBook>("NewInfoForBook");


            

            modelBuilder.Seed();

        }
    }
}

