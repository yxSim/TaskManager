using System;
using System.Collections.Generic;
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

        public Remove(DataGridRow row, int taskID)
        {
            this.row = row;
            this.taskID = taskID - 1;
        }

        public void RemoveTask()
        {
            ((MainWindow)Application.Current.MainWindow).GetViewModel().DataGridItems.RemoveAt(taskID);
            DoRemoveTask();
        }

        private void DoRemoveTask()
        {
            var handler = new XmlHandler(MainWindow.Path);
            handler.Remove(taskID);
            _dataGrid.Items.Refresh();
        }
    }
}
