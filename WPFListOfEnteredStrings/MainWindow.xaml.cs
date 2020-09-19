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

        private bool IsValidToStr()
        {
            if ( TextInputField.Text.Length != 0 )
                return true;
            else
                MessageBox.Show("Поле для ввода текста пустое!");

            return false;
        }

        private bool IsValidNullString()
        {
            if (ListOfStrings.SelectedItem == null)
                return false;

            else
                return true;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if ( IsValidToStr() )
                ListOfStrings.Items.Add(TextInputField.Text);

            TextInputField.Clear();
        }


        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }


        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (IsValidNullString())
            {
                TextBoxDetailForm textBoxEdit = new TextBoxDetailForm();
                textBoxEdit.txtInput.AppendText((string)ListOfStrings.SelectedItem);
                textBoxEdit.ShowDialog();

                if( textBoxEdit.DialogResult == true )
                {
                    ListOfStrings.Items[ListOfStrings.SelectedIndex] = textBoxEdit.ModifiedString;
                }
                
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            ListOfStrings.Items.RemoveAt(ListOfStrings.SelectedIndex);
        }
        
    }
}
