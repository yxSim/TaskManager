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
    internal class StartInit
    {
        private readonly string _path = @Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\ToDoApp\\";
        public StartInit(DataGrid dataGrid)
        {
            CreateDirectory();
            LoadData();
        }

        private void CreateDirectory()
        {
            try
            {
                if (!Directory.Exists(_path))
                    Directory.CreateDirectory(_path);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception in CreateDirectory() method: " + ex);
            }
        }

        private void LoadData()
        {
            var xmlHandler = new XmlHandler(_path);
            var tasks = xmlHandler.Read();
            if (tasks == null) return;
            var viewModel = ((MainWindow)Application.Current.MainWindow).GetViewModel().DataGridItems = tasks;
        }
    }
}
