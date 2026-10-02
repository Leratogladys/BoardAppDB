This is what my BoardController.cs looks like, compare it with yours 

// Student nr      : 222049725;223022994;225007032;220024412;225004492
// Programmer name : BoardAppDB Group
// Assignment nr   : Practical Assessment 2
// Purpose         : Controller class used to manage Board views and
//                   coordinate Board operations through the repository.

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
        // Purpose           : Creates the Board controller using an IBoard
        //                     repository supplied through dependency injection
        // Re-use            : None
        // Method Parameters : IBoard boardRepo
        //                     - repository used to perform Board operations
        // Output Type       : None
        //

        public BoardController(IBoard boardRepo)
        {
            this.boardRepo = boardRepo;

        } // end method BoardController

        //
        // Name              : IActionResult Index()
        // Purpose           : Displays the current list of Board records
        // Re-use            : GetBoards()
        // Method Parameters : None
        // Output Type       : IActionResult
        //                     - Index view containing the current Board list
        //

        public IActionResult Index()
        {
            return View(boardRepo.GetBoards());
        } // end method Index

        //
        // Name              : IActionResult Details(string boardCode)
        // Purpose           : Displays the details of the Board with the specified board code
        // Re-use            : Details(string boardCode)
        // Method Parameters : string boardCode
        //                     - unique code of the Board to display
        // Output Type       : IActionResult
        //                     - Details view containing the selected Board
        //

        public IActionResult Details(string boardCode)
        {
            return View(boardRepo.Details(boardCode));

        } // end method Details

        //
        // Name              : IActionResult Create()
        // Purpose           : Displays the Create view for adding a new Board
        // Re-use            : None
        // Method Parameters : None
        // Output Type       : IActionResult
        //                     - Create view used to enter Board details
        //
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.ShowAdd = true;

            return View();
        } // end method Create

        //
        // Name              : IActionResult Create(Board board)
        // Purpose           : Validates and creates a new Board record
        // Re-use            : IsExist(string boardCode), Create(Board board)
        // Method Parameters : Board board
        //                     - Board object populated from submitted form data
        // Output Type       : IActionResult
        //                     - Create view containing the submitted Board
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
        // Purpose           : Displays the Edit view for the Board with the specified board code
        // Re-use            : Details(string boardCode)
        // Method Parameters : string boardCode
        //                     - unique code of the Board to edit
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
        // Purpose           : Validates and updates an existing Board record
        // Re-use            : Edit(Board board)
        // Method Parameters : string boardCode
        //                     - unique code identifying the Board being edited
        //                     Board board
        //                     - Board object populated with the submitted changes
        // Output Type       : IActionResult
        //                     - Edit view containing the submitted Board
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
        // Purpose           : Displays the Delete view for the Board with the specified board code
        // Re-use            : Details(string boardCode)
        // Method Parameters : string boardCode
        //                     - unique code of the Board to delete
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
        // Purpose           : Deletes the Board identified by the specified board code
        // Re-use            : Details(string boardCode), Delete(Board board)
        // Method Parameters : string boardCode
        //                     - unique code identifying the Board to delete
        //                     Board board
        //                     - Board object associated with the submitted form
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
