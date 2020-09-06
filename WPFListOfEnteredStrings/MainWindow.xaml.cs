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

namespace WPFListOfEnteredStrings
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

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (Text.Text.Length == 0)
            {
                MessageBox.Show("Поле для ввода текста пустое!");
            }
            else
            {
                List.Items.Add(Text.Text);
            }
        }


        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
