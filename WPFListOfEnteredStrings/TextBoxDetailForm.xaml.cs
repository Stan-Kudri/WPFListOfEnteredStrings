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

namespace WPFListOfEnteredStrings
{
    /// <summary>
    /// Логика взаимодействия для TextBoxDetailForm.xaml
    /// </summary>
    public partial class TextBoxDetailForm : Window
    {
        public TextBoxDetailForm()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if(TextEdit.Text.Length!=0)
            {
                DialogResult = true;
                Close();
            }
            else
            {
                MessageBox.Show("Строка не может быть пустой!");
            }
        }

        public string ModifiedLine()
        {
            return TextEdit.Text;
        }

        private void Cancle_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
