// Programmer name : BoardAppDB Group
// Student nr      : 222049725;223022994;225007032;220024412;225004492
// Assignment nr   : Practical Assessment 2
// Purpose         : Repository used to perform CRUD operations on Board records.

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
        // Purpose           : Creates the Board repository using the injected
        //                     BoardContext
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
        // Purpose           : Retrieves all Board records
        // Re-use            : None
        // Method Parameters : None
        // Output Type       : IEnumerable<Board>
        //                     - collection of Board records
        //
        public IEnumerable<Board> GetBoards()
        {
            return boardContext.Boards!;
        } // end method GetBoards

        //
        // Name              : Board Details(string boardCode)
        // Purpose           : Retrieves a Board using its unique board code
        // Re-use            : None
        // Method Parameters : string boardCode
        //                     - board code used to find the Board
        // Output Type       : Board
        //                     - matching Board record
        //
        public Board Details(string boardCode)
        {
            return boardContext.Boards!
                .FirstOrDefault(x => x.BoardCode == boardCode)!;
        } // end method Details

        //
        // Name              : Board Create(Board board)
        // Purpose           : Adds a new Board record
        // Re-use            : None
        // Method Parameters : Board board
        //                     - Board record to add
        // Output Type       : Board
        //                     - created Board record
        //
        public Board Create(Board board)
        {
            boardContext.Add(board);
            boardContext.SaveChanges();

            return board;
        } // end method Create

        //
        // Name              : Board Edit(Board board)
        // Purpose           : Updates an existing Board record
        // Re-use            : None
        // Method Parameters : Board board
        //                     - Board record containing the changes
        // Output Type       : Board
        //                     - updated Board record
        //
        public Board Edit(Board board)
        {
            boardContext.Update(board);
            boardContext.SaveChanges();

            return board;
        } // end method Edit

        //
        // Name              : bool Delete(Board board)
        // Purpose           : Deletes an existing Board record
        // Re-use            : IsExist(string boardCode)
        // Method Parameters : Board board
        //                     - Board record to delete
        // Output Type       : bool
        //                     - true if deletion was successful; otherwise false
        //
        public bool Delete(Board board)
        {
            boardContext.Remove(board);
            boardContext.SaveChanges();

            return !IsExist(board.BoardCode);
        } // end method Delete

        //
        // Name              : bool IsExist(string boardCode)
        // Purpose           : Checks whether a Board code exists
        // Re-use            : Details(string boardCode)
        // Method Parameters : string boardCode
        //                     - board code to check
        // Output Type       : bool
        //                     - true if the Board exists; otherwise false
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
