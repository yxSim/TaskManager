using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace ToDoApp
{
    /// <summary>
    /// Interaction logic for EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        private DataGridRow? _row;
        private int _taskId;
        public EditWindow(DataGridRow? row, int taskId)
        {
            InitializeComponent();
            this._row = row; 
            this._taskId = taskId;
            ((MainWindow)Application.Current.MainWindow).EditWindow = this;
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            var edit = new Edit(_row, _taskId);
            edit.EditRow();
        }
    }
}
