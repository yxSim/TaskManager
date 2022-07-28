using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ToDoApp
{
    internal class Edit
    {
        private readonly Window? _window = ((MainWindow)Application.Current.MainWindow).EditWindow;
        private TextBox? _nameBox = ((MainWindow)Application.Current.MainWindow).EditWindow?.nameTextBox;
        private TextBox? _descriptionBox = ((MainWindow)Application.Current.MainWindow).EditWindow?.desctiptionTextBox;
        private DataGrid _dataGrid = ((MainWindow)Application.Current.MainWindow).DataGrid;
        private int _taskId;
        public DataGridRow? Row { get; }

        public Edit(DataGridRow? row, int taskId)
        {
            Row = row;
            _taskId = taskId;
        }

        public void EditRow()
        {
            DoEditRow();
        }

        //metoda najde ukol, upravi objekt, zmeny promitne do data grid a aktualizuje xml soubor
        private void DoEditRow()
        {
            var index = _taskId;
            var task = ((MainWindow)Application.Current.MainWindow).GetViewModel().DataGridItems[index];
            task.Name = _nameBox.Text;
            task.SetDescription(_descriptionBox.Text);
            _dataGrid.Items.Refresh();
            SaveToXml(task);
            _window.Close();
        }

        //metoda ulozi upraveny objekt do souboru
        private void SaveToXml(Task task)
        {
            var handler = new XmlHandler(MainWindow.Path);
            handler.Edit(task);
        }
    }
}
