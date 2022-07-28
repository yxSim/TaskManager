using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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
        private readonly string _fileName;

        public XmlHandler(string fileName)
        {
            _fileName = fileName + "\\data.xml";
        }


        public List<Task>? Read()
        {
            if (!File.Exists(_fileName)) return null;
            var tasks = new List<Task>();
            var doc = new XmlDocument();
            doc.Load(_fileName);
            var nodeList = doc.GetElementsByTagName("Task");
            foreach (XmlNode node in nodeList)
            {
                var task = new Task();
                foreach (XmlNode childNode in node.ChildNodes)
                {
                    switch (childNode.Name)
                    {
                        case "description":
                            task.SetDescription(childNode.InnerText);
                            break;
                    }
                }

                if (node.Attributes != null)
                    foreach (XmlAttribute att in node.Attributes)
                    {
                        task.Name = att.InnerText;
                    }

                tasks.Add(task);
            }

            return tasks;
        }

        public void Write(List<Task> tasks)
        {
            Create();
            foreach (var task in tasks)
            {
                Write(task);
            }

        }

        private void Write(Task task)
        {
            try
            {
                var doc = XDocument.Load(_fileName);
                var root = new XElement("Task");

                root.Add(new XAttribute("name", task.Name));
                root.Add(new XElement("description", task.GetDescription()));
                doc.Element("Items")?.Add(root);
                doc.Save(_fileName);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

        }

        private void Create()
        {
            try
            {
                if (!File.Exists(_fileName))
                {
                    new XDocument(new XElement("Items")).Save(_fileName);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public void Edit(Task task)
        {
            var index = task.GetId();
            var doc = new XmlDocument();
            doc.Load(_fileName);
            var nodeList = doc.GetElementsByTagName("Task");
            foreach (XmlNode node in nodeList)
            {
                index--;
                if (index != 0) continue;
                if (node.Attributes != null) node.Attributes[0].InnerText = task.Name;
                node.ChildNodes[0].InnerText = task.GetDescription();
            }
            doc.Save(_fileName);
        }

        public void Remove(int index)
        {
            var doc = new XmlDocument();
            doc.Load(_fileName);
            var nodeList = doc.GetElementsByTagName("Task");
            var node = nodeList[index - 1];
            node.ParentNode.RemoveChild(node);
            doc.Save(_fileName);
         
        }
    }
}