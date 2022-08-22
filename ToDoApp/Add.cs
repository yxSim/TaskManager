using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ToDoApp
{
    internal class Add
    {
        private readonly Window? _window = ((MainWindow)Application.Current.MainWindow).AddWindow;
        private TextBox? _nameBox = ((MainWindow)Application.Current.MainWindow).AddWindow?.nameTextBox;
        private TextBox? _descriptionBox = ((MainWindow)Application.Current.MainWindow).AddWindow?.desctiptionTextBox;
        private readonly DataGrid _dataGrid = ((MainWindow)Application.Current.MainWindow).DataGrid;

        public void Cancel()
        {
            _nameBox = null;
            _descriptionBox = null;
            _window?.Close();
        }

        public void AddNewTask()
        {
            DoAddNewTask();
        }

        //metoda prida novy ukol a ulozi ho do xml souboru
        private void DoAddNewTask()
        {
            var task = new Task(_nameBox?.Text!, _descriptionBox?.Text!);
            ((MainWindow)Application.Current.MainWindow).GetViewModel().DataGridItems.Add(task);
            var xmlHandler = new XmlHandler(MainWindow.Path);
            xmlHandler.Write(new List<Task>() { task });
            _dataGrid.Items.Refresh();
            _window?.Close();
        }
    }
}
