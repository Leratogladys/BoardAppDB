// Programmer name : BoardAppDB Group
// Student nr      : 222049725;223022994;225007032;220024412;225004492
// Assignment nr   : Practical Assessment 2
// Purpose         : Repository used to create and seed the Board database.

using BoardAppDB.Data;
using BoardAppDB.Interfaces;
using BoardAppDB.Models;

namespace BoardAppDB.Repositories
{
    public class DBInitializerRepo : IDBInitializer
    {
        private readonly BoardContext boardContext;

        //
        // Name              : DBInitializerRepo(BoardContext boardContext)
        // Purpose           : Creates the database initializer using the
        //                     injected BoardContext
        // Re-use            : None
        // Method Parameters : BoardContext boardContext
        //                     - database context used during initialization
        // Output Type       : None
        //
        public DBInitializerRepo(BoardContext boardContext)
        {
            this.boardContext = boardContext;
        } // end constructor DBInitializerRepo

        //
        // Name              : void Initialize()
        // Purpose           : Creates the database when required and seeds
        //                     the ten required Board records only when empty
        // Re-use            : None
        // Method Parameters : None
        // Output Type       : void
        //                     - no value is returned
        //
        public void Initialize()
        {
            boardContext.Database.EnsureCreated();

            if (boardContext.Boards != null && !boardContext.Boards.Any())
            {
                var boards = new List<Board>()
                {
                    new Board("1001", "Espressif", "ESP32-WROOM-32", 4096, 129.00m),
                    new Board("1002", "Espressif", "ESP32-C3-MINI-1", 4096, 99.00m),
                    new Board("1003", "STMicroelectronics", "STM32F103C8T6", 64, 75.00m),
                    new Board("1004", "STMicroelectronics", "STM32F411CEU6", 512, 145.00m),
                    new Board("1005", "Microchip", "ATmega328P", 32, 89.00m),
                    new Board("1006", "Microchip", "ATmega2560", 256, 199.00m),
                    new Board("1007", "WCH", "CH32V003F4P6", 16, 29.00m),
                    new Board("1008", "Raspberry Pi", "Pico", 2048, 89.00m),
                    new Board("1009", "Espressif", "ESP-01S", 1024, 65.00m),
                    new Board("1010", "CUTfree", "CV32-BFN-01", 128, 49.00m)
                };

                boardContext.AddRange(boards);
                boardContext.SaveChanges();
            } // end if
        } // end method Initialize
    } // end class DBInitializerRepo
} // end namespace BoardAppDB.Repositories
