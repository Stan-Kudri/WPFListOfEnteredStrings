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
    /// Логика взаимодействия для FormToEditDayTraining.xaml
    /// </summary>
    public partial class FormToEditDayTraining : Window
    {
        public string Training => TextEditTraining.Text;

        public FormToEditDayTraining()
        {
            InitializeComponent();
            
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if( TextEditTraining.Text.Length > 0)
            {
                DialogResult = true;
                Close();
            }
            else
            {
                MessageBox.Show("Тренеровка не записана!");
            }
        }

        private void Cancle_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
