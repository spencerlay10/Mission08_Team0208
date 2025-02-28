using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission08_Team0208.Models;
using AspNetCoreGeneratedDocument;
using Microsoft.EntityFrameworkCore;

namespace Mission08_Team0208.Controllers
{

    public class HomeController : Controller
    {
        private IMission8 _repo;
        public HomeController(IMission8 someName) //Constructor
        {
            _repo = someName;
        }



        //Make index view appear
        public IActionResult Index()
        {
            return RedirectToAction("Quadrants");
        }


        //Gather categories for addTask menu
        [HttpGet]

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult AddTask()
        {
            ViewBag.Categories = _repo.Categories
                .OrderBy(x => x.CategoryName).ToList();

            return View();
        }

        //Make AddTask view appear

        [HttpPost]
        public IActionResult AddTask(Mission08_Team0208.Models.Task response)
        {
            _repo.AddTask(response);

            return View("Confirmation", response);
        }



        //Create quadrants view by joining tables
        public IActionResult Quadrants()
        {
            var tasks = _repo.Tasks
                .OrderBy(x => x.TaskTitle)
                .ToList(); // Executes the query

            return View(tasks);
        }


        //Find task by its taskid, retrieves category, returns addtask view but prefilled
        [HttpGet]
        public IActionResult Edit(int Id)
        {

            var recordToEdit = _repo.Tasks
                .Single(x => x.TaskId == Id);

            ViewBag.Categories = _repo.Categories
            .OrderBy(x => x.CategoryName)
            .ToList();

            return View("AddTask", recordToEdit);
        }

        //Receives updated movie, updates movie record, saves changes, redirects to quadrants view
        [HttpPost]
        public IActionResult Edit(Mission08_Team0208.Models.Task updatedInfo)
        {
            _repo.UpdateInfo(updatedInfo);

            return RedirectToAction("Quadrants");
        }


        //Retrieve task by task id
        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var recordToDelete = _repo.Tasks
                .Single(x => x.TaskId == Id);

            return View(recordToDelete);
        }


        //Receives movie object, removes it from context. Tasks, saves changes, redirects to Quadrants
        [HttpPost]
        public IActionResult Delete(Mission08_Team0208.Models.Task movie)
        {
            _repo.DeleteTask(movie);

            return RedirectToAction("Quadrants");
        }

        [HttpPost]
        public IActionResult MarkComplete(int id)
        {
            _repo.MarkComplete(id);
            return RedirectToAction("Quadrants");
        }
    }

}