using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using System.Xml;
using System.Xml.Linq;

namespace Project02
{
    /// <summary>
    /// Логика взаимодействия для Win_Add.xaml
    /// </summary>
    public partial class Win_Add : Window
    {
        public List<Scientists> listScientists = new List<Scientists>();

        public Win_Add()
        {
            InitializeComponent();
        }

        private void Button_Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void buttonHome_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();

            this.Close();
        }

        private void buttonInfo_Click(object sender, RoutedEventArgs e)
        {
            Win_Svedenia win_Svedenia = new Win_Svedenia();
            win_Svedenia.Show();

            this.Close();
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            Win_Add win_Add = new Win_Add();
            win_Add.Show();

            this.Close();
        }

        private void buttonAddS_Click(object sender, RoutedEventArgs e)
        {
            if (tbFullname.Text != "" || tbGender.Text != "" || tbAge.Text != "" || tbFamily.Text != "" || tbСhildren.Text != "" || tbPosition.Text != "" || tbAcademicD.Text != "" )
            {
                XmlDocument xDoc = new XmlDocument();
                if (File.Exists(@"C:\Scientists.xml"))
                {
                    xDoc.Load(@"C:\Scientists.xml");
                    XmlElement xRoot = xDoc.DocumentElement;
                    XmlElement userElem = xDoc.CreateElement("Scientist");
                    XmlAttribute fullnameAttr = xDoc.CreateAttribute("fullname");
                    XmlElement genderElem = xDoc.CreateElement("gender");
                    XmlElement ageElem = xDoc.CreateElement("age");
                    XmlElement familyElem = xDoc.CreateElement("family");
                    XmlElement childernElem = xDoc.CreateElement("children");
                    XmlElement positionElem = xDoc.CreateElement("position");
                    XmlElement academicElem = xDoc.CreateElement("academic");

                    XmlText nameText = xDoc.CreateTextNode($"{tbFullname.Text}");
                    XmlText genderText = xDoc.CreateTextNode($"{tbGender.Text}");
                    XmlText ageText = xDoc.CreateTextNode($"{tbAge.Text}");
                    XmlText familyText = xDoc.CreateTextNode($"{tbFamily.Text}");
                    XmlText childernText = xDoc.CreateTextNode($"{tbСhildren.Text}");
                    XmlText positionText = xDoc.CreateTextNode($"{tbPosition.Text}");
                    XmlText academicText = xDoc.CreateTextNode($"{tbAcademicD.Text}");

                    //добавляем узлы
                    fullnameAttr.AppendChild(nameText);
                    genderElem.AppendChild(genderText);
                    ageElem.AppendChild(ageText);
                    familyElem.AppendChild(familyText);
                    childernElem.AppendChild(childernText);
                    positionElem.AppendChild(positionText);
                    academicElem.AppendChild(academicText);

                    userElem.Attributes.Append(fullnameAttr);
                    userElem.AppendChild(genderElem);
                    userElem.AppendChild(ageElem);
                    userElem.AppendChild(familyElem);
                    userElem.AppendChild(childernElem);
                    userElem.AppendChild(positionElem);
                    userElem.AppendChild(academicElem);

                    xRoot.AppendChild(userElem);
                    xDoc.Save(@"C:\Scientists.xml");
                }
                else
                {

                    XDocument xdoc = new XDocument();
                    XElement scientist = new XElement("Scientist");
                    XAttribute scientistsFullNameAttr = new XAttribute("fullname", $"{tbFullname.Text}");
                    XElement scientistsGenderElem = new XElement("gender", $"{tbGender.Text}");
                    XElement scientistsAgeElem = new XElement("age", $"{tbAge.Text}");
                    XElement scientistsFamilyElem = new XElement("family", $"{tbFamily.Text}");
                    XElement scientistsChildernElem = new XElement("children", $"{tbСhildren.Text}");
                    XElement scientistsPositionElem = new XElement("position", $"{tbPosition.Text}");
                    XElement scientistsAcademicElem = new XElement("academic", $"{tbAcademicD.Text}");

                    scientist.Add(scientistsFullNameAttr);
                    scientist.Add(scientistsGenderElem);
                    scientist.Add(scientistsAgeElem);
                    scientist.Add(scientistsFamilyElem);
                    scientist.Add(scientistsChildernElem);
                    scientist.Add(scientistsPositionElem);
                    scientist.Add(scientistsAcademicElem);

                    XElement scientists = new XElement("Scientists");
                    scientists.Add(scientist);
                    xdoc.Add(scientists);
                    xdoc.Save(@"C:\Scientists.xml");
                }

                MessageBox.Show("Добавлено!");
            }
            else
            {
                MessageBox.Show("Не все поля заполнены!");
            }
        }
    }
}
