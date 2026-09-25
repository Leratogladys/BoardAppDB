// Programmer name : BoardAppDB Group
// Student nr      : 222049725;223022994;225007032;220024412;225004492
// Assignment nr   : Practical Assessment 2
// Purpose         : Custom validation attribute enforcing that a flash
//                   size is one of a fixed list of real-world values,
//                   a rule the built-in Range attribute cannot express

using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace BoardAppDB.Infrastructure
{
    public class VerifyFlashSizeAttribute : Attribute, IModelValidator
    {
        public bool IsRequired
        {
            //
            //Name              : property bool IsRequired
            //Purpose           : Read-only property required by legacy
            //                    usage of IModelValidator; has no effect
            //                    in the current version of the interface,
            //                    kept only for consistency
            //Re-use            : none
            //Input Parameter   : None
            //Output Type       : bool
            //                  - always true
            //
            get { return true; } // end get
        } // end property

        public string ErrorMessage { get; set; } = "Valid flash sizes in KB are: " +
                                      "16, 32, 64, 128, 256, 512, 1024, 2048, 4096";
        //
        //Name              : property string ErrorMessage
        //Purpose           : Automatic public property holding the
        //                    message shown when a flash size fails
        //                    validation
        //Re-use            : none
        //Input Parameter   : string value
        //                  - new value for the corresponding compiler
        //                    generated field
        //Output Type       : string
        //                  - value stored in the corresponding compiler
        //                    generated field
        //

        // Valid flash sizes in KB
        private readonly List<int> validFlashSizes = new List<int>
        {
            16, 32, 64, 128, 256, 512, 1024, 2048, 4096
        };
        public IEnumerable<ModelValidationResult> Validate(ModelValidationContext context)
        {
            //
            //Name              : IEnumerable<ModelValidationResult>
            //                  Validate(ModelValidationContext context)
            //Purpose           : Checks whether the submitted value is a
            //                  valid flash size; returns a validation
            //                  error if it is null or not one of the
            //                  values in validFlashSizes
            //Re-use            : None
            //Method Parameters : ModelValidationContext context
            //                  - supplies the submitted value to be
            //                  validated, via context.Model
            //Output Type       : IEnumerable<ModelValidationResult>
            //                  - empty if the value is valid; otherwise
            //                  a collection containing one
            //                  ModelValidationResult carrying
            //                  ErrorMessage
            //

            int? value = context.Model as int?;

            //Fail if null or not int the allowed set
            if (value == null || !validFlashSizes.Contains(value.Value))
            {
                return new List<ModelValidationResult>
                {
                    new ModelValidationResult("", ErrorMessage)
                }; //end if
            }
            //Pass if valid
            return Enumerable.Empty<ModelValidationResult>();
        } //end method
    } //end class VerifyFlashSizeAttribute
} // end namespace BoardApp.Infrastructure
