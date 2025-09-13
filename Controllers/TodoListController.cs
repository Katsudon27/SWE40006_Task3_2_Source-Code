using Microsoft.AspNetCore.Mvc;
using SWE_Task_3_2.Models;

namespace SWE_Task_3_2.Controllers
{
    public class TodoListController : Controller
    {
        //A list to hold all items for the to-do list
        private static List<listItem> _todoList = [];

        //A counter to be incremented as the item ID
        private static int _nextId = 1;

        //Displays all items on the home page
        public IActionResult Index()
        {
            return View(_todoList);
        }

        //GET endpoint that renders the Create page
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        //POST endpoint for adding a new item to the to-do list
        [HttpPost]
        public IActionResult Create(listItem item)
        {
            //Validates the model, adds it to the in-memory list and redirects user to home page
            if (ModelState.IsValid)
            {
                item.Id = _nextId++;
                _todoList.Add(item);
                return RedirectToAction(nameof(Index));
            }
            return View(item);
        }

        //GET endpoint that displays the Edit page
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var todo = _todoList.FirstOrDefault(t => t.Id == id);
            if (todo == null) return NotFound();
            return View(todo);
        }

        //POST endpoint to update an existing item on the to-do list
        [HttpPost]
        public IActionResult Edit(listItem updated)
        {
            var todo = _todoList.FirstOrDefault(t => t.Id == updated.Id);
            if (todo == null) return NotFound();

            todo.Title = updated.Title;
            todo.Done = updated.Done;
            return RedirectToAction(nameof(Index));
        }

        //GET endpoint to display the Delete page
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var todo = _todoList.FirstOrDefault(t => t.Id == id);
            if (todo == null) return NotFound();
            return View(todo);
        }

        //POST endpoint to delete an existing item on the to-do list
        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var todo = _todoList.FirstOrDefault(t => t.Id == id);
            if (todo != null) _todoList.Remove(todo);
            return RedirectToAction(nameof(Index));
        }
    }
}
