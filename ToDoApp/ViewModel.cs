using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ToDoApp
{
    public class ViewModel
    {
        public IList<Task> DataGridItems { get; set; }

        public ViewModel()
        {

        }

        public ViewModel(IList<Task> dataGridItems)
        {
            DataGridItems = dataGridItems;
        }


    }
}
