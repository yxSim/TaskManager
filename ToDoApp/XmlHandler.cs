using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ToDoApp
{
    internal class XmlHandler
    {
        private string path;
        private DataGrid dataGrid;

        public XmlHandler(string path, DataGrid dataGrid)
        {
            this.path = path;
            this.dataGrid = dataGrid;
        }

        public void Read()
        {
            //ReadFromXml();
        }

        public void Write()
        {
            WriteToXml();
        }

        private void ReadFromXml()
        {
            try
            {
                var ds = new DataSet();
                ds.ReadXml(path);
                var dv = new DataView(ds.Tables[0]);
                dataGrid.ItemsSource = dv;
            }
            catch (Exception ex)
            {

            }
        }

        private void Create()
        {
            if (!File.Exists(path))
            {
                new XDocument(new XElement("Items")).Save(path);
            }
        }

        private void WriteToXml()
        {
            Create();
        }
    }
}
