using BoardAppDB.Models;

namespace BoardAppDB.Interfaces

    {
        public interface IBoard
        {
            // Retrieves a collection of Boards.
            IEnumerable<Board> GetBoards();

            // Retrieves details of a board based on its board code.
            // Parameters:
            // - boardCode: The unique board code of the board to retrieve details for.
            Board Details(string boardCode);

            // Creates a new board entry.
            // Parameters:
            // - board: The Board object representing the new board to be created.
            Board Create(Board board);

            // Edits an existing board entry.
            // Parameters:
            // - board: The Board object representing the modified board.
            Board Edit(Board board);

            // Deletes an existing board entry.
            // Parameters:
            // - board: The Board object representing the board to be deleted.
            // Returns:
            // - True if the deletion was successful, false otherwise.
            bool Delete(Board board);

            // Checks if a board with the specified board code exists.
            // Parameters:
            // - boardCode: The board code to check for existence.
            // Returns:
            // - True if a board with the given board code exists, false otherwise.
            bool IsExist(string boardCode);
        }
    }



