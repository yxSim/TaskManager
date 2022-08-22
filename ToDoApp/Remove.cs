using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ToDoApp
{
    internal class Remove
    {
        private DataGridRow row;
        private readonly int taskID;
        private readonly DataGrid _dataGrid = ((MainWindow)Application.Current.MainWindow).DataGrid;
        private readonly int index;

        public Remove(DataGridRow row, int taskID)
        {
            this.row = row;
            this.taskID = taskID;
            index = ((MainWindow)Application.Current.MainWindow).GetViewModel().GetIndexByID(taskID);
        }

        //metoda najde ukol v kolekci a odstrani ho
        public void RemoveTask()
        {
            Debug.WriteLine(taskID);
            try
            {
                Debug.WriteLine(index);
                ((MainWindow)Application.Current.MainWindow).GetViewModel().DataGridItems.RemoveAt(index);
                DoRemoveTask();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

        }

        //metoda odstrani oznaceny ukol a zmeny ulozi do xml souboru
        private void DoRemoveTask()
        {
            var handler = new XmlHandler(MainWindow.Path);
            handler.Remove(index);
            _dataGrid.Items.Refresh();
        }
    }
}
