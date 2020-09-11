using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TodApp.Data;
using TodApp.Models;

namespace TodApp.Controllers
{
    public class TodoController : Controller
    {
        private readonly AppDbContext _context;
        public TodoController(AppDbContext context)
        {
            _context = context;
        }

      
        public IActionResult MyTodo()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ListTodo()
        {
            return Ok(_context.todos.ToList());
        }

       

        [HttpPost]
        public IActionResult CreateTodo(Todo todo)
        {
            _context.Add(todo);
            _context.SaveChanges();
            return Ok(todo);
        }


        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var FindTodo = _context.todos.Find( id);
            _context.Remove(FindTodo);
            _context.SaveChanges();
            return Ok("ok");

        }
        [HttpPut]
        public IActionResult Update(Todo todo, int id)
        {
            var tod = _context.todos.Find(id);
            tod.Done = todo.Done = true;
            _context.Update(tod);
            _context.SaveChanges();
            return Ok(tod);
        }

        public IActionResult A()
        {
            return Ok(_context.todos.ToList().OrderBy(x => x.TodoName));
        }

        public IActionResult Z()
        {
            return Ok(_context.todos.ToList().OrderByDescending(x => x.TodoName));
        }
        [HttpGet]
        public IActionResult CompList()
        {
            return Ok(_context.todos.ToList().Where(x => x.Done == true));
        }

    }
}