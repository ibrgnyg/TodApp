using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodApp.Models
{
    public class Todo
    {
        public int Id { get; set; }
        public string TodoName { get; set; }
        public bool Done { get; set; }
    }
}
