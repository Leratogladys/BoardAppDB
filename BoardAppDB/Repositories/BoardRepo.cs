using BoardAppDB.Data;
using BoardAppDB.Interfaces;
using BoardAppDB.Models;
using Microsoft.EntityFrameworkCore;

namespace BoardAppDB.Repositories
{
    public class BoardRepo : IBoard
    {
        private readonly BoardContext _context;

        // Constructor injection of BoardContext
        public BoardRepo(BoardContext context)
        {
            _context = context;
        }

        // Retrieves all boards
        public IEnumerable<Board> GetBoards()
        {
            return _context.Boards.AsNoTracking().ToList();
        }

        // Retrieves details of a board by boardCode
        public Board Details(string boardCode)
        {
            return _context.Boards
                .AsNoTracking()
                .FirstOrDefault(b => b.BoardCode == boardCode);
        }

        // Creates a new board entry
        public Board Create(Board board)
        {
            _context.Boards.Add(board);
            _context.SaveChanges();
            return board;
        }

        // Edits an existing board entry
        public Board Edit(Board board)
        {
            _context.Boards.Update(board);
            _context.SaveChanges();
            return board;
        }

        // Deletes an existing board