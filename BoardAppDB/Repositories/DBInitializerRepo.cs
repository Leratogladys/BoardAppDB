using BoardAppDB.Data;
using BoardAppDB.Interfaces;
using BoardAppDB.Models;

namespace BoardAppDB.Repositories
{
    public class DBInitializerRepo 
    {
        public static void Initialize (BoardContext context)
        {
            context.Database.EnsureCreated();
            if (context.Boards.Any())
                return;
            var boards = new Board[]
                {
        new Board
            {
                BoardCode = "1001",
                Manufacturer = "Espressif",
                Model = "ESP32-WROOM-32",
                Flash = 4096,
                Price = 99.00m
            },
            new Board
            {
                BoardCode = "1002",
                Manufacturer = "Espressif",
                Model = "ESP32-C3-MINI-1",
                Flash = 4096,
                Price = 99.00m
            },
            new Board
            {
                BoardCode = "1003",
                Manufacturer = "STMicroelectronics",
                Model = "STM32F103C8T6",
                Flash = 64,
                Price = 79.00m
            },
            new Board
            {
                BoardCode = "1004",
                Manufacturer = "STMicroelectronics",
                Model = "STM32F407VGT6",
                Flash = 512,
                Price = 149.00m
            },
            new Board
            {
                BoardCode = "1005",
                Manufacturer = "Microchip",
                Model = "ATMega328P",
                Flash = 32,
                Price = 89.00m
            },
            new Board
            {
                BoardCode = "1006",
                Manufacturer = "Microchip",
                Model = "SAMD21G18A",
                Flash = 256,
                Price = 119.00m
            },
            new Board
            {
                BoardCode = "1007",
                Manufacturer = "NXP",
                Model = "LPC1768",
                Flash = 512,
                Price = 199.00m
            },
            new Board
            {
                BoardCode = "1008",
                Manufacturer = "Raspberry",
                Model = "Pico",
                Flash = 2048,
                Price = 89.00m
            },
            new Board
            {
                BoardCode = "1009",
                Manufacturer = "Espressif",
                Model = "ESP-01S",
                Flash = 1024,
                Price = 69.00m
            },
            new Board
            {
                BoardCode = "1010",
                Manufacturer = "OLIMEX",
                Model = "CVO-MINI-01",
                Flash = 128,
                Price = 49.00m
            }
                };
            
            context.AddRange(boards);
            context.SaveChanges();
            }


        }   
    }

