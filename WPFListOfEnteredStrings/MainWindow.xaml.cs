using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.IO;

namespace WPFListOfEnteredStrings
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private class DayAndWorkout
        {
            public DateTime Date { get;private set; }
            public string TrainingСontent { get;private set; }

            public DayAndWorkout(DateTime date, string trainingContent)
            {
                Date = date;
                TrainingСontent = trainingContent;
            }

            public void TrainingEdit(string training)
            {
                TrainingСontent = training;
            }
        }


        private ObservableCollection<DayAndWorkout> DaysAndWorkouts { get; set; } = new ObservableCollection<DayAndWorkout>();

        private bool AvailableDate(DateTime date)
        {
            foreach(DayAndWorkout checkDay in DaysAndWorkouts)
            {
                if ( checkDay.Date == date )
                {
                    MessageBox.Show("Дата занята!");
                    return false;
                }                    
            }

            return true;
        }        

        public MainWindow()
        {
            InitializeComponent();

            DataContext = this;

            ListOfStrings.ItemsSource = DaysAndWorkouts;

            ValidDiaryFolder();
        }

        private void ValidDiaryFolder()
        {
            string path = @"C:\Diary";
            DirectoryInfo directoryInfo = new DirectoryInfo(path);

            if ( !directoryInfo.Exists )
            {
                directoryInfo.Create();
            }
        }

        private void SaveRecording(DateTime date, string trainingСontent)
        {
            string nameTextFile = $@"C:\Diary\{date.ToString("dd.MM.yyyy")}.txt";
            
            using (StreamWriter streamWriter = new StreamWriter(nameTextFile, false, Encoding.Default))
            {
                streamWriter.WriteLine(trainingСontent);
            }
        }


        private bool IsValidNullString()
        {
            if (ListOfStrings.SelectedItem == null)
                return false;

            else
                return true;
        }

        private void SortElements()
        {
            var sortDiary = DaysAndWorkouts.
                OrderBy(s => s.Date);

            var sortedList = sortDiary.ToList();

            DaysAndWorkouts.Clear();

            foreach (var day in sortedList)
                DaysAndWorkouts.Add(day);
        }


        private void Add_Click(object sender, RoutedEventArgs e)
        {
            FormToAdd formToAdd = new FormToAdd();
            formToAdd.ShowDialog();

            if ( AvailableDate(formToAdd.Day) )
            {
                SaveRecording(formToAdd.Day, formToAdd.Training);
                DaysAndWorkouts.Add(new DayAndWorkout(formToAdd.Day, formToAdd.Training));
                SortElements();
            }
        }


        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }


        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            FormToEditDayTraining formToEdit = new FormToEditDayTraining();

            var indexDayTrainingEdit = ListOfStrings.SelectedIndex;
            
            formToEdit.TextEditTraining.AppendText(DaysAndWorkouts[indexDayTrainingEdit].TrainingСontent);
            
            formToEdit.ShowDialog();

            if( formToEdit.DialogResult == true )
            {
                var WorkoutModifiedList = DaysAndWorkouts.ToList();

                DaysAndWorkouts.Clear();

                foreach (var items in WorkoutModifiedList)
                {
                    if( items.Date == WorkoutModifiedList[indexDayTrainingEdit].Date)
                    {
                        DaysAndWorkouts.Add(new DayAndWorkout(items.Date, formToEdit.Training));
                    }
                    else
                    {
                        DaysAndWorkouts.Add(new DayAndWorkout(items.Date, items.TrainingСontent));
                    }

                }
                SaveRecording(DaysAndWorkouts[indexDayTrainingEdit].Date, formToEdit.Training);
            }
        }


        private void Open_Click(object sender, RoutedEventArgs e)
        {
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var list = DaysAndWorkouts.ToList();

            var dataDelete = ListOfStrings.SelectedItem;
            
            DaysAndWorkouts.Clear();

            foreach (var items in list)
            {
                if( items != dataDelete)
                {
                    DaysAndWorkouts.Add(new DayAndWorkout(items.Date, items.TrainingСontent));
                }
                else
                {                    
                    File.Delete($@"C:\Diary\{items.Date.ToString("dd.MM.yyyy")}.txt");
                }
            }
            /*var dataDelete = ListOfStrings.SelectedItem;
            DaysAndWorkouts.Remove();            
            File.Delete($@"C:\Diary\{DaysAndWorkouts[indexItems].Date.ToString("dd.MM.yyyy")}.txt");*/
        }

    }
}
