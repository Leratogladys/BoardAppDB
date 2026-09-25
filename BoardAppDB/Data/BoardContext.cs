// Programmer name : BoardAppDB Group
// Student nr      : 222049725;223022994;225007032;220024412;225004492
// Assignment nr   : Practical Assessment 2
// Purpose         : Database context class used by Entity Framework Core
//                   to access and configure Board data in the SQLite database.

using BoardAppDB.Models;
using Microsoft.EntityFrameworkCore;

namespace BoardAppDB.Data
{
    public class BoardContext : DbContext
    {
        //
        // Name              : BoardContext(DbContextOptions<BoardContext> options)
        // Purpose           : Creates a BoardContext using the database options
        //                     supplied through dependency injection
        // Re-use            : None
        // Method Parameters : DbContextOptions<BoardContext> options
        //                     - configuration settings for this database context
        // Output Type       : None
        //

        public BoardContext(DbContextOptions<BoardContext> options) : base(options) { }

        //
        // Name              : property DbSet<Board>? Boards
        // Purpose           : Provides Entity Framework Core access to Board
        //                     entities stored in the database
        // Re-use            : None
        // Input Parameter   : DbSet<Board>? value
        //                     - new value for the Board entity set
        // Output Type       : DbSet<Board>?
        //                     - the collection of Board entities managed by
        //                     Entity Framework Core
        //
        public DbSet<Board>? Boards { get; set; } //end property

        //
        // Name              : void OnModelCreating(ModelBuilder modelBuilder)
        // Purpose           : Configures the Board entity for storage in the
        //                     SQLite database
        // Re-use            : None
        // Method Parameters : ModelBuilder modelBuilder
        //                     - object used to configure the database model
        // Output Type       : void
        //                     - no value is returned
        //

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Board>().ToTable("Board");

            modelBuilder.Entity<Board>()
                .Property(b => b.Price)
                .HasConversion<double>();

        }// end method OnModelCreating

    } // end class BoardContext
}// end namespace BoardAppDB.Data
