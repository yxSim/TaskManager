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
    /// Interaction logic for DetailsWindow.xaml
    /// </summary>
    public partial class DetailsWindow : Window
    {
        private int _taskId;
        public DetailsWindow(int taskId)
        {
            InitializeComponent();
            _taskId = taskId;
            Init();
        }

        private void Init()
        {
            var index = _taskId;
            var task = ((MainWindow)Application.Current.MainWindow).GetViewModel().DataGridItems;
            NameLabel.Content = task[index].Name;
            DescriptionLabel.Content = task[index].GetDescription();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
