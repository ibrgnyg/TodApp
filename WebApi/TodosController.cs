using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodApp.Data;
using TodApp.Models;

namespace TodApp.WebApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TodosController(AppDbContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        public List<Todo> List()
        {
            return  _context.todos.ToList();
        }

      
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var todo = _context.todos.Find(id);
            if (todo == null)
            {
                BadRequest();

            }

            _context.Remove(todo);
            _context.SaveChanges();

        }



    }
}
