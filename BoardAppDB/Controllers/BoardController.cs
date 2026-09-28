using BoardAppDB.Interfaces;
using BoardAppDB.Models;
using Microsoft.AspNetCore.Mvc;

namespace BoardAppDB.Controllers
{
    public class BoardController : Controller
    {
        private readonly IBoard _boardRepo;
        public BoardController(IBoardRepository boardRepository)
        {
            _boardRepository = boardRepository;
        }
        public IActionResult Index()
        {
            IEnumerable<Board> boards = _boardRepository.GetBoards();
            ViewBag.ShowAdd = true; // Set the flag to show the "Add" button
            ViewBag.ShowSave = false; // Set the flag to hide the "Save" button
            ViewBag.ShowDelete = true; // Set the flag to show the "Delete" button
            return View(boards);
        }
        public IActionResult Details(string boardCode)
        {
          Board board = _boardRepository.Detail(boardCode);
            if(board == null)
            {
                return NotFound();
            }
            ViewBag.ShowAdd = false; // Set the flag to hide the "Add" button
            ViewBag.ShowSave = true; // Set the flag to show the "Save" button
            ViewBag.ShowDelete = false; // Set the flag to hide the "Delete" button

            return View(board);
        }
        public IActionResult Create()
        {
            ViewBag.ShowAdd = true; // Set the flag to show the "Add" button
            ViewBag.ShowSave = false; // Set the flag to hide the "Save" button
            ViewBag.ShowDelete = false; // Set the flag to hide the "Delete" button

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(
            [Bind("BoardCode,Manufacturer,Model,FlashSize,Price")] Board board)
        {
            if(_boardRepo.IsExist(board.BoardCode))
            {
                ModelState.AddModelError("BoardCode", "Board code already exists.");
            }
            if(ModelState.IsValid)
            {
                _boardRepo.Add(board);
                
                ViewBsg.SuccessMessage = $"Board{board.BoardCode} was added ";
                ViewBag.ShowAdd = true; // Set the flag to show the "Add" button
                ViewBag.ShowSave = false; // Set the flag to hide the "Save" button
                ViewBag.ShowDelete = false; // Set the flag to hide the "Delete" button

                return View(board);
            }
            ViewBag.ShowAdd = true; // Set the flag to show the "Add" button
            ViewBag.ShowSave = false; // Set the flag to hide the "Save" button
            ViewBag.ShowDelete = false; // Set the flag to hide the "Delete" button

            return View(board);
        }
        public IActionResult Edit(string boardCode)
        {
            Board board = _boardRepo.Detail(boardCode);
            if(board == null)
            {
                return NotFound();
            }
            ViewBag.ShowAdd = false; // Set the flag to hide the "Add" button
            ViewBag.ShowSave = true; // Set the flag to show the "Save" button
            ViewBag.ShowDelete = false; // Set the flag to hide the "Delete" button
            return View(board);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string boardCode, [Bind("BoardCode,Manufacturer,Model,FlashSize,Price")] Board board)
        {
            board.BoardCode = boardCode; // Ensure the BoardCode is set correctly
        }
            if(ModelState.IsValid)
            {
                _boardRepo.Edit(board);
                ViewBag.SuccessMessage = $"Board {board.BoardCode} was updated successfully.";
                ViewBag.ShowAdd = false; // Set the flag to hide the "Add" button
                ViewBag.ShowSave = true; // Set the flag to show the "Save" button
                ViewBag.ShowDelete = false; // Set the flag to hide the "Delete" button
                return View(board);
            }
            ViewBag.ShowAdd = false; // Set the flag to hide the "Add" button
            ViewBag.ShowSave = true; // Set the flag to show the "Save" button
            ViewBag.ShowDelete = false; // Set the flag to hide the "Delete" button
            return View(board);
        }
public IActionResult Delete(string boardCode)
        {
            Board board = _boardRepo.Detail(boardCode);
            if(board == null)
            {
                return NotFound();
            }
            _boardRepo.Delete(board);
            ViewBag.SuccessMessage = $"Board {board.BoardCode} was deleted successfully.";
            ViewBag.ShowAdd = true; // Set the flag to show the "Add" button
            ViewBag.ShowSave = false; // Set the flag to hide the "Save" button
            ViewBag.ShowDelete = false; // Set the flag to hide the "Delete" button
            return View(board);
}
[HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string boardCode)
        {
            Board board = _boardRepo.Detail(boardCode);
            if(board == null)
            {
                return NotFound();
            }
            _boardRepo.Delete(board);

            ViewBag.SuccessMessage = $"Board {board.BoardCode} was deleted successfully.";
            ViewBag.ShowAdd = true; // Set the flag to show the "Add" button
            ViewBag.ShowSave = false; // Set the flag to hide the "Save" button
            ViewBag.ShowDelete = false; // Set the flag to hide the "Delete" button

            return View("Delete",board);
}
}
}