

// Student nr      : 222049725;223022994;225007032;220024412;225004492
// Programmer name : BoardAppDB Group
// Assignment nr   : Practical Assessment 2
// Purpose         : Repository class used to perform database operations
//                   for Board entities through Entity Framework Core.

using BoardAppDB.Data;
using BoardAppDB.Interfaces;
using BoardAppDB.Models;

namespace BoardAppDB.Repositories
{
    public class BoardRepo : IBoard
    {
        private readonly BoardContext boardContext;

        //
        // Name              : BoardRepo(BoardContext boardContext)
        // Purpose           : Creates the Board repository using a BoardContext
        //                     supplied through dependency injection
        // Re-use            : None
        // Method Parameters : BoardContext boardContext
        //                     - database context used to access Board data
        // Output Type       : None
        //
        public BoardRepo(BoardContext boardContext)
        {
            this.boardContext = boardContext;
        } // end constructor BoardRepo

        //
        // Name              : IEnumerable<Board> GetBoards()
        // Purpose           : Retrieves all Board records from the database
        // Re-use            : None
        // Method Parameters : None
        // Output Type       : IEnumerable<Board>
        //                     - collection of Board objects retrieved from the database
        //
        public IEnumerable<Board> GetBoards()
        {
            return boardContext.Boards;
        } // end method GetBoards

        //
        // Name              : Board Details(string boardCode)
        // Purpose           : Retrieves a Board record using its unique board code
        // Re-use            : None
        // Method Parameters : string boardCode
        //                     - unique code of the Board to retrieve
        // Output Type       : Board
        //                     - Board object matching the supplied board code
        //
        public Board Details(string boardCode)
        {
            var board = boardContext.Boards?
                .FirstOrDefault(x => x.BoardCode == boardCode);

            return board;
        } // end method Details

        //
        // Name              : Board Create(Board board)
        // Purpose           : Adds a new Board record to the database
        // Re-use            : None
        // Method Parameters : Board board
        //                     - Board object to be added to the database
        // Output Type       : Board
        //                     - the Board object that was added
        //
        public Board Create(Board board)
        {
            boardContext.Add(board);
            boardContext.SaveChanges();

            return board;
        } // end method Create

        //
        // Name              : Board Edit(Board board)
        // Purpose           : Updates an existing Board record in the database
        // Re-use            : None
        // Method Parameters : Board board
        //                     - Board object containing the updated values
        // Output Type       : Board
        //                     - the updated Board object
        //
        public Board Edit(Board board)
        {
            boardContext.Update(board);
            boardContext.SaveChanges();

            return board;
        } // end method Edit

        //
        // Name              : bool Delete(Board board)
        // Purpose           : Deletes an existing Board record from the database
        // Re-use            : IsExist(string boardCode)
        // Method Parameters : Board board
        //                     - Board object to be deleted
        // Output Type       : bool
        //                     - true if the Board was successfully deleted;
        //                     otherwise false
        //
        public bool Delete(Board board)
        {
            boardContext.Remove(board);
            boardContext.SaveChanges();

            return !IsExist(board.BoardCode);
        } // end method Delete

        //
        // Name              : bool IsExist(string boardCode)
        // Purpose           : Checks whether a Board with the specified board code exists
        // Re-use            : Details(string boardCode)
        // Method Parameters : string boardCode
        //                     - unique board code to search for
        // Output Type       : bool
        //                     - true if a matching Board exists;
        //                     otherwise false
        //
        public bool IsExist(string boardCode)
        {
            bool isExist = false;

            Board board = Details(boardCode);

            if (board != null)
            {
                isExist = true;
            } // end if

            return isExist;
        } // end method IsExist

    } // end class BoardRepo
} // end namespace BoardAppDB.Repositories