// Programmer name : BoardAppDB Group
// Student nr      : 222049725;223022994;225007032;220024412;225004492
// Assignment nr   : Practical Assessment 2
// Purpose         : Model used to provide request information to the Error view.

namespace BoardAppDB.Models
{
    public class ErrorViewModel
    {
        //
        // Name              : property string? RequestId
        // Purpose           : Stores the identifier of the current request
        // Re-use            : None
        // Input Parameter   : string? value
        //                     - request identifier to store
        // Output Type       : string?
        //                     - the current request identifier
        //
        public string? RequestId
        {
            get; set;
        } // end property

        //
        // Name              : property bool ShowRequestId
        // Purpose           : Indicates whether a request identifier is available
        // Re-use            : RequestId
        // Input Parameter   : None
        // Output Type       : bool
        //                     - true when RequestId contains a value; otherwise false
        //
        public bool ShowRequestId
        {
            get
            {
                return !string.IsNullOrEmpty(RequestId);
            }
        } // end property
    } // end class ErrorViewModel
} // end namespace BoardAppDB.Models
