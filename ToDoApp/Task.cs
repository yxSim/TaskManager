using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ToDoApp
{
    internal class Task
    {
        private int Id { get; }
        public string Name { get; set; }
        public string? Description { get; set; }

        public static int globalTaskID;

        public Task(string name, string description)
        {
            Name = name;
            Description = description;
            Id = Interlocked.Increment(ref globalTaskID);
        }
    }
}
