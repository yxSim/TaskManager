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
        private TextBox? nameBox;
        private TextBox? descriptionBox;
        private Window? Window;
        private Window? mainWindow = (MainWindow)Application.Current.MainWindow;
        private string path = @Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\ToDoApp\\";

        public Add()
        {
            nameBox = ((MainWindow)Application.Current.MainWindow).addWindow?.nameTextBox;
            descriptionBox = ((MainWindow)Application.Current.MainWindow).addWindow?.desctiptionTextBox;
            Window = ((MainWindow)Application.Current.MainWindow).addWindow;
        }

        public void Cancel()
        {
            nameBox = null;
            descriptionBox = null;
            Window?.Close();
        }

        public void AddNewTask()
        {
            Save();
        }
        private void Save()
        {
            var fs = new FileStream(path + "data", FileMode.Append);
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
            var data = nameBox?.Text + "\n" + descriptionBox?.Text;
            var bytes = Encoding.UTF8.GetBytes(data);
            fs.Write(bytes, 0, bytes.Length);
        }

        private void DoAddNewTask()
        {
            var name = nameBox?.Text;
            var description = descriptionBox?.Text;

        }
    }
}
