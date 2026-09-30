using BoardAppDB.Interfaces;
using BoardAppDB.Models;
using Microsoft.AspNetCore.Mvc;

namespace BoardAppDB.Controllers
{
    public class BoardController : Controller
    {
        private readonly IBoard _boardRepo;

        public BoardController(IBoard boardRepository)
        {
            _boardRepo = boardRepository;
        }

        // GET: Board
        public IActionResult Index()
        {
            IEnumerable<Board> boards = _boardRepo.GetBoards();

            return View(boards);
        }

        // GET: Board/Details?boardCode=1001
        public IActionResult Details(string boardCode)
        {
            Board board = _boardRepo.Details(boardCode);

            return View(board);
        }

        // GET: Board/Create
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.ShowAdd = true;

            return View();
        }

        // POST: Board/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(
            [Bind("BoardCode,Manufacturer,Model,FlashSize,Price")] Board board)
        {
            if (_boardRepo.IsExist(board.BoardCode))
            {
                ModelState.AddModelError(
                    "BoardCode",
                    "A board with that board code already exists.");
            }

            if (ModelState.IsValid)
            {
                _boardRepo.Create(board);

                ViewBag.SuccessMessage =
                    $"{board.BoardCode} was added.";

                ViewBag.ShowAdd = false;
            }
            else
            {
                ViewBag.ShowAdd = true;
            }

            return View(board);
        }

        // GET: Board/Edit?boardCode=1001
        [HttpGet]
        public IActionResult Edit(string boardCode)
        {
            Board board = _boardRepo.Details(boardCode);

            ViewBag.ShowSave = true;

            return View(board);
        }

        // POST: Board/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(
            string boardCode,
            [Bind("Manufacturer,Model,FlashSize,Price")] Board board)
        {
            board.BoardCode = boardCode;

            if (ModelState.IsValid)
            {
                _boardRepo.Edit(board);

                ViewBag.SuccessMessage =
                    $"{boardCode} was updated.";

                ViewBag.ShowSave = false;
            }
            else
            {
                ViewBag.ShowSave = true;
            }

            return View(board);
        }

        // GET: Board/Delete?boardCode=1001
        [HttpGet]
        public IActionResult Delete(string boardCode)
        {
            Board board = _boardRepo.Details(boardCode);

            ViewBag.ShowDelete = true;

            return View(board);
        }

        // POST: Board/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(string boardCode, Board board)
        {
            Board existingBoard = _boardRepo.Details(boardCode);

            if (existingBoard != null)
            {
                _boardRepo.Delete(existingBoard);

                board = existingBoard;

                ViewBag.SuccessMessage =
                    $"{boardCode} was deleted.";
            }

            ViewBag.ShowDelete = false;

            return View(board);
        }
    }
}