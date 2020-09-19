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

        private string modifiedString;

        public string ModifiedString
        {
            get
            {
                return txtInput.Text;
            }
            set
            {
                modifiedString = txtInput.Text;
            }
        }

        private bool IsValid()
        {
            if ( txtInput.Text.Length > 0 )
            {
                return true;
            }
            MessageBox.Show("Строка не может быть пустой!!");
            return false;
        }


        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if( IsValid() )
            {
                DialogResult = true;
                Close();
            }
            return;
        }


        private void Cancle_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
