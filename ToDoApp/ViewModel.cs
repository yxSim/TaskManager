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
            var DataGridItems=new List<Task>();
        }

        public ViewModel(IList<Task> dataGridItems)
        {
            DataGridItems = dataGridItems;
        }


        //metoda vrati pozici ukolu podle zadaneho ID 
        public int GetIndexByID(int ID)
        {
            var index = 0;
            foreach (var item in DataGridItems)
            {
                if (item.GetId() == ID)
                    return index;
                index++;
            }
            return -1;
        }

    }
}
