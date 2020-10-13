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
    /// Логика взаимодействия для FormToAdd.xaml
    /// </summary>
    public partial class FormToAdd : Window
    {       
        public DateTime Day => (DateTime)DateSelection.SelectedDate;
        public string Training => RecordField.Text;

        public FormToAdd()
        {
            InitializeComponent();
        }

        private bool ValidLenghtStr()
        {
            if ( RecordField.Text.Length != 0 )
                return true;

            return false;
        }

        private bool ValidDataRecording()
        {
            DateTime dateTime = new DateTime() ;
            bool check = DateTime.TryParse(DateSelection.Text, out dateTime);

            if (!check)
                return false;

            return true;
        }        

        private void SaveRecordsDay_Click(object sender, RoutedEventArgs e)
        {
            if (ValidDataRecording())
            {
                if(ValidLenghtStr())
                {
                    Close();
                }
                else
                {
                    MessageBox.Show("Поле для записи дня пустое!");
                }
            }
            else
            {
                MessageBox.Show("Выберите дату, для записи текста");
            }
        }
        
        private void CancelRecording_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
