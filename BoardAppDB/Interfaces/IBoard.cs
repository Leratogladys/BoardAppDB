// Programmer name : BoardAppDB Group
// Student nr      : 222049725;223022994;225007032;220024412;225004492
// Assignment nr   : Practical Assessment 2
// Purpose         : Interface defining the repository operations required
//                   to maintain Board records.

using BoardAppDB.Models;

namespace BoardAppDB.Interfaces
{
    public interface IBoard
    {
        //
        // Name              : IEnumerable<Board> GetBoards()
        // Purpose           : Retrieves all Board records
        // Re-use            : None
        // Method Parameters : None
        // Output Type       : IEnumerable<Board>
        //                     - collection of Board records
        //
        IEnumerable<Board> GetBoards();

        //
        // Name              : Board Details(string boardCode)
        // Purpose           : Retrieves one Board using its board code
        // Re-use            : None
        // Method Parameters : string boardCode
        //                     - unique board code to find
        // Output Type       : Board
        //                     - matching Board record
        //
        Board Details(string boardCode);

        //
        // Name              : Board Create(Board board)
        // Purpose           : Creates a new Board record
        // Re-use            : None
        // Method Parameters : Board board
        //                     - Board record to create
        // Output Type       : Board
        //                     - created Board record
        //
        Board Create(Board board);

        //
        // Name              : Board Edit(Board board)
        // Purpose           : Updates an existing Board record
        // Re-use            : None
        // Method Parameters : Board board
        //                     - Board record containing the changes
        // Output Type       : Board
        //                     - updated Board record
        //
        Board Edit(Board board);

        //
        // Name              : bool Delete(Board board)
        // Purpose           : Deletes an existing Board record
        // Re-use            : None
        // Method Parameters : Board board
        //                     - Board record to delete
        // Output Type       : bool
        //                     - true if deletion was successful; otherwise false
        //
        bool Delete(Board board);

        //
        // Name              : bool IsExist(string boardCode)
        // Purpose           : Checks whether a Board code already exists
        // Re-use            : None
        // Method Parameters : string boardCode
        //                     - board code to check
        // Output Type       : bool
        //                     - true if the Board exists; otherwise false
        //
        bool IsExist(string boardCode);
    } // end interface IBoard
} // end namespace BoardAppDB.Interfaces
