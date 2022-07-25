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
        private TextBox? _nameBox = ((MainWindow)Application.Current.MainWindow).AddWindow?.nameTextBox;
        private TextBox? _descriptionBox = ((MainWindow)Application.Current.MainWindow).AddWindow?.desctiptionTextBox;
        private readonly Window? _window = ((MainWindow)Application.Current.MainWindow).AddWindow;
        private DataGrid _dataGrid = ((MainWindow)Application.Current.MainWindow).dataGrid;

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

        private void DoAddNewTask()
        {
            var task = new Task(_nameBox?.Text, _descriptionBox?.Text);

            MainWindow.Tasks.Add(task);
            var xmlHandler = new XmlHandler(MainWindow.path);
            xmlHandler.Write(new List<Task>() { task });
            _dataGrid.ItemsSource = MainWindow.Tasks;
            _dataGrid.Items.Refresh();
            _window?.Close();
        }
    }
}
