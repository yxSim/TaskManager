using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ToDoApp
{
    public class Task
    {
        private int Id { get; }
        public string Name { get; set; } = "";
        private string _description  = "";
        private bool _status = false;
        public static int GlobalTaskId;

        public Task()
        {
            Id = Interlocked.Increment(ref GlobalTaskId);
        }
        public Task(string name, string description)
        {
            Name = name;
            _description = description;
            Id = Interlocked.Increment(ref GlobalTaskId);
        }

        public string GetDescription()
        {
            return _description;
        }

        public int GetId()
        {
            return Id;
        }

        public void SetDescription(string description)
        {
            _description = description;
        }

        public bool GetStatus()
        {
            return _status;
        }

        public void SetStatus(bool status)
        {
            _status = status;
        }

        public void ChangeStatus()
        {
            _status = !_status;
        }
    }
}
