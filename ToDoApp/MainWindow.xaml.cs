using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ToDoApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public AddWindow? addWindow;
        public MainWindow()
        {
            InitializeComponent();
            CreateDirectory();
        }

        private void CreateDirectory()
        {
            try
            {
                Directory.CreateDirectory(@Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\ToDoApp\\");
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception in CreateDirectory() method: " + ex);
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            addWindow = new AddWindow();
            addWindow.Show();
        }
    }
}
