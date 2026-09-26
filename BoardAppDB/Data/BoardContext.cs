using BoardAppDB.Models;
using
    Microsoft.EntityFrameworkCore;

namespace BoardAppDB.Data
{
    public class BoardContext : DbContext
    {
        public BoardContext(DbContextOptions<BoardContext> options) :
            base(options)
        {
        } // end constructor
        public DbSet<Board> Boards { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Board>().ToTable("Boards");
        } // end method
    } // end class
} // end namespace