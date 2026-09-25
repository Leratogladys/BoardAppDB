// Programmer name : BoardApp Group
// Student nr      : 222049725;223022994;225007032;220024412;225004492
// Assignment nr   : Practical Assessment 2
// Purpose         : Domain model representing a microcontroller
//                   development board, including validation rules for
//                   each property

using BoardAppDB.Infrastructure;
using System.ComponentModel.DataAnnotations;

namespace BoardAppDB.Models;

public class Board
{
    [Key]
    [Required(ErrorMessage = "The board code is required.")]
    [StringLength(4, MinimumLength = 4, ErrorMessage = "The board code must have a length of 4.")]
    [Display(Name = "Board code")]
    public string BoardCode
    {
        get; set;

        //
        //Name              : property string BoardCode
        //Purpose           : Automatic public property giving access
        //                    to the corresponding compiler generated
        //                    field; also acts as this board's primary
        //                    key
        //Re-use            : none
        //Input Parameter   : string value
        //                  - new value for the corresponding
        //                    compiler generated field
        //Output Type       : string
        //                  - value stored in the corresponding
        //                    compiler generated field
        //
    } // end property


    [Required(ErrorMessage = "The board manufacturer is required.")]
    [Display(Name = "Manufacturer")]
    public string Make
    {

        //
        //Name              : property string Make
        //Purpose           : Automatic public property giving access
        //                    to the corresponding compiler generated
        //                    field
        //Re-use            : none
        //Input Parameter   : string value
        //                  - new value for the corresponding
        //                    compiler generated field
        //Output Type       : string
        //                  - value stored in the corresponding
        //                    compiler generated field
        //

        get; set;
    } //end property

    [Required(ErrorMessage = "The board model is required.")]
    [Display(Name = "Model")]
    public string Model
    {
        get; set;

        //
        //Name              : property string Model
        //Purpose           : Automatic public property giving access
        //                    to the corresponding compiler generated
        //                    field
        //Re-use            : none
        //Input Parameter   : string value
        //                  - new value for the corresponding
        //                    compiler generated field
        //Output Type       : string
        //                  - value stored in the corresponding
        //                    compiler generated field
        //
    } // end property

    [Required(ErrorMessage = "The flash size is required.")]
    [VerifyFlashSize]
    // [Range(minimum: 16, maximum: 4096,
    //	ErrorMessage = "The flash size must be between 16 and 4096 inclusive.")]
    [Display(Name = "Flash (KB)")]
    public int? FlashKb
    { //
      //Name              : property int? FlashKb
      //Purpose           : Automatic public property giving access
      //                    to the corresponding compiler generated
      //                    field; nullable so that a missing input
      //                    can be distinguished from a genuine zero
      //Re-use            : none
      //Input Parameter   : int? value
      //                  - new value for the corresponding
      //                    compiler generated field
      //Output Type       : int?
      //                  - value stored in the corresponding
      //                    compiler generated field
      //
        get; set;
    } // end property

    [Required(ErrorMessage = "The price is required.")]
    [Range(minimum: 1.00, maximum: 5000.00,
        ErrorMessage = "The price must be between R1.00 and R5000.00 inclusive.")]
    [Display(Name = "Price (R)")]
    [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
    public decimal? Price
    {  //
       //Name              : property decimal? Price
       //Purpose           : Automatic public property giving access
       //                  to the corresponding compiler generated
       //                  field; nullable so that a missing input
       //                  can be distinguished from a genuine zero
       //Re-use            : none
       //Input Parameter   : decimal? value
       //                  - new value for the corresponding
       //                  compiler generated field
       //Output Type       : decimal?
       //                  - value stored in the corresponding
       //                  compiler generated field
       //
        get; set;
    } // end property

    public Board()
    {  //
       //Name              : Board()
       //Purpose           : Default empty constructor
       //Re-use            : None
       //Method Parameters : None
       //Output Type       : None
       //
    } // end method

    public Board(string boardCode, string make, string model, int flashKb, decimal price)
    {
        //
        //Name              : Board(string boardCode, string make,
        //                  string model, int flashKb, decimal price)
        //Purpose           : Overloaded constructor used to set all
        //                  instance fields via properties
        //Re-use            : None
        //Method Parameters : string boardCode
        //                  - new value for BoardCode property
        //                  string make
        //                  - new value for Make property
        //                  string model
        //                  - new value for Model property
        //                  int flashKb
        //                  - new value for FlashKb property
        //                  decimal price
        //                  - new value for Price property
        //Output Type       : None
        //
        BoardCode = boardCode;
        Make = make;
        Model = model;
        FlashKb = flashKb;
        Price = price;
    }// end method


    public override string ToString()
    {
        //
        //Name              : string ToString()
        //Purpose           : Overridden method that builds a
        //                  human-readable summary of this board
        //Re-use            : None
        //Method Parameters : None
        //Output Type       : string
        //                  - a formatted summary of the board's
        //                  code, make, model, flash size and price
        //
        return $"{BoardCode}: {Make} {Model} with {FlashKb} KB flash at R{Price:0.00}";
    }// end method
}// end class Board