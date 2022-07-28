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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ToDoApp
{
    /// <summary>
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : UserControl
    {
        public Menu()
        {
            InitializeComponent();
            var task = GetRow().Item as Task;
            ChangeStatusButton.Content = !task.GetStatus() ? "✔" : "✘";
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            var row = GetRow();
            var editWindow = new EditWindow(row, ((MainWindow)Application.Current.MainWindow).FindTaskIndex(row))
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
            editWindow.Show();
            Close();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var row = GetRow();
            var remove = new Remove(row, (row.Item as Task).GetId());
            remove.RemoveTask();
            Close();
        }

        private void ChangeStatusButton_Click(object sender, RoutedEventArgs e)
        {
            var task = GetRow().Item as Task;
            task?.ChangeStatus();
            var handler = new XmlHandler(MainWindow.Path);
            handler.Edit(task);
            Close();
        }

        private static void Close()
        {
            ((MainWindow)Application.Current.MainWindow).ContextWindow.Close();
        }

        private static DataGridRow GetRow()
        {
            return ((MainWindow)Application.Current.MainWindow).GetRow();
        }
    }
}
