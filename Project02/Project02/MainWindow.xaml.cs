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

namespace Project02
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Close(object sender, RoutedEventArgs e)
        {
            Close();
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
    }
}
