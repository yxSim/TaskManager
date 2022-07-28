using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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
        public EditWindow? EditWindow { get; set; }
        public DetailsWindow? DetailsWindow;
        public static readonly string Path = @Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\ToDoApp\\";
        public Window ContextWindow;
        private DataGridRow? _row;

        private readonly ViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();

            this._viewModel = new ViewModel();
            this.DataContext = this._viewModel;
            var startInit = new StartInit(DataGrid);
        }

        public DataGridRow? GetRow()
        {
            return _row;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddWindow = new AddWindow();
            AddWindow.Show();
        }

        private void Row_RightMouseDown(object sender, MouseButtonEventArgs e)
        {
         
            _row = sender as DataGridRow;
            var location = e.GetPosition(this);
            
            ContextWindow = new Window
            {
                Title = "Context Menu",
                Content = new Menu(),
                SizeToContent = SizeToContent.WidthAndHeight,
                ResizeMode = ResizeMode.NoResize,
                Left = location.X,
                Top = location.Y
            };
            ContextWindow.ShowDialog();
        }

        private void Row_MouseDown(object sender, MouseButtonEventArgs e)
        {
            _row = sender as DataGridRow;
            DetailsWindow = new DetailsWindow(FindTaskIndex(_row));
            DetailsWindow.Show();
        }

        public int FindTaskIndex(DataGridRow? row)
        {
            var taskId = ((row?.Item as Task)!).GetId();
            return this._viewModel.DataGridItems.TakeWhile(t => t.GetId() != taskId).Count();
        }

        public ViewModel GetViewModel()
        {
            return _viewModel;
        }
    }
}
