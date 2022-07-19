using System;
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
        private TextBox _nameBox = ((MainWindow)Application.Current.MainWindow).addWindow?.nameTextBox;
        private TextBox _descriptionBox = ((MainWindow)Application.Current.MainWindow).addWindow?.desctiptionTextBox;
        private readonly Window _window = ((MainWindow)Application.Current.MainWindow).addWindow;
        private Window _mainWindow = (MainWindow)Application.Current.MainWindow;
        private readonly DataGrid _dataGrid = ((MainWindow)Application.Current.MainWindow).dataGrid;
        private readonly string _path = @Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\ToDoApp\\";
        

        public Add()
        {
        }

        public void Cancel()
        {
            _nameBox = null;
            _descriptionBox = null;
            _window?.Close();
        }

        public void AddNewTask()
        {
            DoAddNewTask();
            //Save();
        }
        private void Save()
        {
            var fs = new FileStream(_path + "data", FileMode.Append);
            try
            {
                Save(fs);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception in Add.Save() method: " + ex);
            }
            finally
            {
                fs.Flush();
                fs.Close();
            }
        }

        private void Save(Stream fs)
        {
            var data = _nameBox?.Text + "\n" + _descriptionBox?.Text;
            var bytes = Encoding.UTF8.GetBytes(data);
            fs.Write(bytes, 0, bytes.Length);
        }

        private void DoAddNewTask()
        {
            var task = new Task(_nameBox.Text, _descriptionBox.Text);

            var tasks = _dataGrid?.Items.Cast<Task>().ToList();
            tasks.Add(task);

            _dataGrid.ItemsSource = tasks;
            _window?.Close();
        }
    }
}
