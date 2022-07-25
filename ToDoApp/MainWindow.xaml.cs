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
using Path = System.IO.Path;

namespace ToDoApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public AddWindow? AddWindow;
        public static List<Task> Tasks = new List<Task>();
        public static readonly string path = @Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\ToDoApp\\";

        public MainWindow()
        {
            InitializeComponent();
            var startInit = new StartInit(dataGrid);
            dataGrid.ItemsSource = Tasks;
        }



        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddWindow = new AddWindow();
            AddWindow.Show();
        }

        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            var row = sender as DataGridRow;
            if (row == null) return;
            AddWindow = new AddWindow
            {
                nameTextBox =
                {
                    Text = ((Task)row.Item).Name
                },
                desctiptionTextBox =
                {
                    Text = ((Task)row.Item).GetDescription()
                }
            };

            AddWindow.Show();
        }
    }
}
