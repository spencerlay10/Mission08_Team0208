using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission08_Team0208.Models;
using AspNetCoreGeneratedDocument;
using Microsoft.EntityFrameworkCore;

namespace Mission08_Team0208.Controllers
{

    public class HomeController : Controller
    {
        private QuadrantContext _context;
        public HomeController(QuadrantContext someName) //Constructor
        {
            _context = someName;
        }



        //Make index view appear
        public IActionResult Index()
        {
            return View();
        }


        //Gather categories for addTask menu
        [HttpGet]

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult AddTask()
        {
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName).ToList();

            return View();
        }




        //Make AddTask view appear

        [HttpPost]
        public IActionResult AddTask(Mission08_Team0208.Models.Task response)
        {
            _context.Tasks.Add(response); //Add record to database
            _context.SaveChanges();

            return View("Confirmation", response);
        }



        //Create quadrants view by joining tables
        public IActionResult Quadrants()
        {
            //Linq
            var tasks = _context.Tasks.Include(m => m.Category).ToList()
                .OrderBy(x => x.TaskTitle).ToList();

            return View(tasks);
        }


        //Find task by its taskid, retrieves category, returns addtask view but prefilled
        [HttpGet]
        public IActionResult Edit(int Id)
        {

            var recordToEdit = _context.Tasks
                .Single(x => x.TaskId == Id);

            ViewBag.Categories = _context.Categories
            .OrderBy(x => x.CategoryName)
            .ToList();

            return View("AddTask", recordToEdit);
        }

        //Receives updated movie, updates movie record, saves changes, redirects to quadrants view
        [HttpPost]
        public IActionResult Edit(Mission08_Team0208.Models.Task updatedInfo)
        {
            _context.Update(updatedInfo);
            _context.SaveChanges();


            return RedirectToAction("Quadrants");
        }


        //Retrieve task by task id
        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var recordToDelete = _context.Tasks
                .Single(x => x.TaskId == Id);

            return View(recordToDelete);
        }


        //Receives movie object, removes it from context. Tasks, saves changes, redirects to Quadrants
        [HttpPost]
        public IActionResult Delete(Mission08_Team0208.Models.Task movie)
        {
            _context.Tasks.Remove(movie);
            _context.SaveChanges();

            return RedirectToAction("Quadrants");
        }
    }

}