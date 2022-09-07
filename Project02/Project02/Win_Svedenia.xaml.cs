using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Xml.Linq;

namespace Project02
{
    /// <summary>
    /// Логика взаимодействия для Win_Svedenia.xaml
    /// </summary>
    public partial class Win_Svedenia : Window
    {
        public List<Scientists> listScientists = new List<Scientists>();

        public Win_Svedenia()
        {
            InitializeComponent();

            Init();
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

        private void Init()
        {
            ReadXml();

            int j = 0;

            for (int i = 0; i < listScientists.Count; i++)
            {
                Grid grid = new Grid();

                RowDefinitionCollection rd = grid.RowDefinitions;

                grid.ShowGridLines = false;
                grid.RowDefinitions.Add(new RowDefinition());
                grid.RowDefinitions.Add(new RowDefinition());
                grid.RowDefinitions.Add(new RowDefinition());
                grid.RowDefinitions.Add(new RowDefinition());
                grid.RowDefinitions.Add(new RowDefinition());
                grid.RowDefinitions.Add(new RowDefinition());
                grid.RowDefinitions.Add(new RowDefinition());

                var bc = new BrushConverter();

                Border border = new Border
                {
                    Width = 750,
                    //border.Height = 400;
                    BorderThickness = new Thickness(3),
                    CornerRadius = new CornerRadius(20, 20, 20, 20),
                    BorderBrush = (Brush)bc.ConvertFrom("#8383b3"),
                    Margin = new Thickness(0, 20, 0, 0)
                };

                var cb = new BrushConverter();

                TextBlock fnText = new TextBlock
                {
                    FontFamily = new FontFamily("SFPRODISPLAYMEDIUM.OTF"),
                    Foreground = (Brush)cb.ConvertFrom("#1b1464"),
                    Margin = new Thickness(0, 20, 0, 0),
                    Width = 700,
                    FontSize = 20,
                    Text = "ФИО: " + listScientists[i].fullName + "\n"
                };

                TextBlock genderText = new TextBlock
                {
                    FontFamily = new FontFamily("SFPRODISPLAYMEDIUM.OTF"),
                    Foreground = (Brush)cb.ConvertFrom("#1b1464"),
                    Margin = new Thickness(22, 0, 0, 0),
                    FontSize = 20,
                    Text = "Пол: " + listScientists[i].gender + "\n"
                };
                TextBlock ageText = new TextBlock
                {
                    FontFamily = new FontFamily("SFPRODISPLAYMEDIUM.OTF"),
                    Foreground = (Brush)cb.ConvertFrom("#1b1464"),
                    Margin = new Thickness(22, 0, 0, 0),
                    FontSize = 20,
                    Text = "Возраст: " + listScientists[i].age + "\n"
                };
                TextBlock familyText = new TextBlock
                {
                    FontFamily = new FontFamily("SFPRODISPLAYMEDIUM.OTF"),
                    Foreground = (Brush)cb.ConvertFrom("#1b1464"),
                    Margin = new Thickness(22, 0, 0, 0),
                    FontSize = 20,
                    Text = "Семейное положение: " + listScientists[i].family + "\n"
                };
                TextBlock childrenText = new TextBlock
                {
                    FontFamily = new FontFamily("SFPRODISPLAYMEDIUM.OTF"),
                    Foreground = (Brush)cb.ConvertFrom("#1b1464"),
                    Margin = new Thickness(22, 0, 0, 0),
                    FontSize = 20,
                    Text = "Налачие детей: " + listScientists[i].children + "\n"
                };
                TextBlock positionText = new TextBlock
                {
                    FontFamily = new FontFamily("SFPRODISPLAYMEDIUM.OTF"),
                    Foreground = (Brush)cb.ConvertFrom("#1b1464"),
                    Margin = new Thickness(22, 0, 0, 0),
                    FontSize = 20,
                    Text = "Должность: " + listScientists[i].position + "\n"
                };
                TextBlock academicText = new TextBlock
                {
                    FontFamily = new FontFamily("SFPRODISPLAYMEDIUM.OTF"),
                    Foreground = (Brush)cb.ConvertFrom("#1b1464"),
                    Margin = new Thickness(22, 0, 0, 0),
                    FontSize = 20,
                    Text = "Учёная степень: " + listScientists[i].academic + "\n"
                };

                border.Height = fnText.Height + genderText.Height + ageText.Height + familyText.Height + childrenText.Height + positionText.Height + academicText.Height + 100;

                wrap.Height += border.Height;

                Grid.SetRow(fnText, 0);
                grid.Children.Add(fnText);
                Grid.SetRow(genderText, 1);
                grid.Children.Add(genderText);
                Grid.SetRow(ageText, 2);
                grid.Children.Add(ageText);
                Grid.SetRow(familyText, 3);
                grid.Children.Add(familyText);
                Grid.SetRow(childrenText, 4);
                grid.Children.Add(childrenText);
                Grid.SetRow(positionText, 5);
                grid.Children.Add(positionText);
                Grid.SetRow(academicText, 6);
                grid.Children.Add(academicText);

                border.Child = grid;

                wrap.Children.Add(border);

                j++;
            }
        }

        public void ReadXml()
        {
            if (File.Exists(@"C:\Scientists.xml"))
            {
                XDocument xdoc = XDocument.Load(@"C:\Scientists.xml");
                foreach (XElement dir in xdoc.Element("Scientists").Elements("Scientist"))
                {
                    Scientists scientists = new Scientists
                    {
                        fullName = dir.Attribute("fullname").Value,
                        gender = dir.Element("gender").Value,
                        age = dir.Element("age").Value,
                        family = dir.Element("family").Value,
                        children = dir.Element("children").Value,
                        position = dir.Element("position").Value,
                        academic = dir.Element("academic").Value
                    };

                    listScientists.Add(scientists);
                }
            }
            else
            {
                MessageBox.Show("База пустая\nДобавьте сотрудников!");
            }
        }

        
    }
}
