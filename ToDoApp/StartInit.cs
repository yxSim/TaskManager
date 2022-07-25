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
        private readonly string path = @Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\ToDoApp\\";
        public StartInit(DataGrid dataGrid)
        {
            CreateDirectory();
            LoadData();
        }

        private void CreateDirectory()
        {
            try
            {
                if(!Directory.Exists(path))
                    Directory.CreateDirectory(path);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception in CreateDirectory() method: " + ex);
            }
        }

        private void LoadData()
        {
            var xmlHandler = new XmlHandler(path);
            var tasks = xmlHandler.Read();
            if (tasks == null) return;
            MainWindow.Tasks = tasks;
        }
    }
}
