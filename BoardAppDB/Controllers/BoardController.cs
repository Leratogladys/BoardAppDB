// Programmer name : BoardAppDB Group
// Student nr      : 222049725;223022994;225007032;220024412;225004492
// Assignment nr   : Practical Assessment 2
// Purpose         : Controller used to perform Board maintenance operations.

using BoardAppDB.Interfaces;
using BoardAppDB.Models;
using Microsoft.AspNetCore.Mvc;

namespace BoardAppDB.Controllers
{
    public class BoardController : Controller
    {
        private readonly IBoard boardRepo;

        //
        // Name              : BoardController(IBoard boardRepo)
        // Purpose           : Creates the controller using the injected
        //                     Board repository
        // Re-use            : None
        // Method Parameters : IBoard boardRepo
        //                     - repository used by the controller
        // Output Type       : None
        //
        public BoardController(IBoard boardRepo)
        {
            this.boardRepo = boardRepo;
        } // end constructor BoardController

        //
        // Name              : IActionResult Index()
        // Purpose           : Displays all Board records
        // Re-use            : GetBoards()
        // Method Parameters : None
        // Output Type       : IActionResult
        //                     - Index view containing all Boards
        //
        public IActionResult Index()
        {
            return View(boardRepo.GetBoards());
        } // end method Index

        //
        // Name              : IActionResult Details(string boardCode)
        // Purpose           : Displays one Board record
        // Re-use            : Details(string boardCode)
        // Method Parameters : string boardCode
        //                     - board code of the Board to display
        // Output Type       : IActionResult
        //                     - Details view containing the selected Board
        //
        public IActionResult Details(string boardCode)
        {
            return View(boardRepo.Details(boardCode));
        } // end method Details

        //
        // Name              : IActionResult Create()
        // Purpose           : Displays the Create view
        // Re-use            : None
        // Method Parameters : None
        // Output Type       : IActionResult
        //                     - empty Create view
        //
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.ShowAdd = true;

            return View();
        } // end method Create

        //
        // Name              : IActionResult Create(Board board)
        // Purpose           : Validates and creates a Board record
        // Re-use            : IsExist(string boardCode), Create(Board board)
        // Method Parameters : Board board
        //                     - Board populated from the submitted form
        // Output Type       : IActionResult
        //                     - Create view containing the Board
        //
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(
            [Bind("BoardCode,Make,Model,FlashKb,Price")] Board board)
        {
            ViewBag.ShowAdd = true;

            if (boardRepo.IsExist(board.BoardCode))
            {
                ModelState.AddModelError(
                    "BoardCode",
                    "A board with that board code already exists.");
            } // end if

            if (ModelState.IsValid)
            {
                boardRepo.Create(board);
                ViewBag.SuccessMessage = $"Board {board.BoardCode} was added.";
                ViewBag.ShowAdd = false;
            } // end if

            return View(board);
        } // end method Create

        //
        // Name              : IActionResult Edit(string boardCode)
        // Purpose           : Displays the Edit view for one Board
        // Re-use            : Details(string boardCode)
        // Method Parameters : string boardCode
        //                     - board code of the Board to edit
        // Output Type       : IActionResult
        //                     - Edit view containing the selected Board
        //
        [HttpGet]
        public IActionResult Edit(string boardCode)
        {
            ViewBag.ShowSave = true;

            return View(boardRepo.Details(boardCode));
        } // end method Edit

        //
        // Name              : IActionResult Edit(string boardCode, Board board)
        // Purpose           : Validates and updates a Board record
        // Re-use            : Edit(Board board)
        // Method Parameters : string boardCode
        //                     - board code of the Board being edited
        //                     Board board
        //                     - Board populated from the submitted form
        // Output Type       : IActionResult
        //                     - Edit view containing the Board
        //
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string boardCode,
            [Bind("BoardCode,Make,Model,FlashKb,Price")] Board board)
        {
            ViewBag.ShowSave = true;

            if (ModelState.IsValid)
            {
                boardRepo.Edit(board);
                ViewBag.SuccessMessage = $"Board {board.BoardCode} was updated.";
                ViewBag.ShowSave = false;
            } // end if

            return View(board);
        } // end method Edit

        //
        // Name              : IActionResult Delete(string boardCode)
        // Purpose           : Displays the Delete view for one Board
        // Re-use            : Details(string boardCode)
        // Method Parameters : string boardCode
        //                     - board code of the Board to delete
        // Output Type       : IActionResult
        //                     - Delete view containing the selected Board
        //
        [HttpGet]
        public IActionResult Delete(string boardCode)
        {
            ViewBag.ShowDelete = true;

            return View(boardRepo.Details(boardCode));
        } // end method Delete

        //
        // Name              : IActionResult Delete(string boardCode, Board board)
        // Purpose           : Deletes the Board identified by boardCode
        // Re-use            : Details(string boardCode), Delete(Board board)
        // Method Parameters : string boardCode
        //                     - board code of the Board to delete
        //                     Board board
        //                     - Board associated with the submitted form
        // Output Type       : IActionResult
        //                     - Delete view containing the selected Board
        //
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(string boardCode, Board board)
        {
            ViewBag.ShowDelete = true;
            board = boardRepo.Details(boardCode);

            if (board != null)
            {
                boardRepo.Delete(board);
                ViewBag.SuccessMessage = $"Board {board.BoardCode} was deleted.";
                ViewBag.ShowDelete = false;
            } // end if

            return View(board);
        } // end method Delete
    } // end class BoardController
} // end namespace BoardAppDB.Controllers
