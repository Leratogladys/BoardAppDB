using BoardAppDB.Models;
namespace BoardAppDB.Interfaces
{
    public interface IBoard
    {
        IEnumerable<Board> GetBoards();
        Board? GetBoard(string boardCode);    
        void AddBoard(Board board);
        void UpdateBoard(Board board);
        void DeleteBoard(string boardCode);
        void Save();

    }
}
