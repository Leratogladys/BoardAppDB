// Programmer name : BoardApp Group
// Student nr      : 222049725;223022994;225007032;220024412;225004492
// Assignment nr   : Practical Assessment 2
// Purpose         : Domain model representing a microcontroller
//                   development board, including validation rules for
//                   each property

using System.ComponentModel.DataAnnotations;

namespace BoardAppDB.Models
{
    public class Board
    {
        [Key]
        public string BoardCode { get; set; } = string.Empty;
   
        public string Manufacturer { get; set; } = string.Empty;
      
        public string Model { get; set; } = string.Empty;
            public int Flash { get; set; }
        public decimal Price { get; set; }
       
       
    }
}
