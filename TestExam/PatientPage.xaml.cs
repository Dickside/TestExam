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
using TestExam.DB;

namespace TestExam
{
    /// <summary>
    /// Логика взаимодействия для PatientPage.xaml
    /// </summary>
    public partial class PatientPage : Page
    {
        public PatientPage()
        {
            InitializeComponent();
            UpdateList();
            App.OnUpdated += UpdateList;
        }


        ~PatientPage()
        {
            App.OnUpdated -= UpdateList;
        }

        public void UpdateList()
        {
            ListPatient.ItemsSource = null;
            ListPatient.ItemsSource = App.Entities.Patients.ToArray();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // добавить
            var form = new PatientAdd();
            form.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var patients = ListPatient.SelectedItem as Patients;
            if (patients != null)
            {
                var form = new PatientAdd(patients);
                form.Show();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var patients = ListPatient.SelectedItem as Patients;
            if (patients != null)
            {
                if (patients.Meetings.Count > 0)
                {
                    MessageBox.Show("Нельзя удалить пациента, если он уже учавстовал во встречах", "Ошибка!");
                    return;
                }
                App.Entities.Patients.Remove(patients);
                App.Entities.SaveChanges();
            }
            UpdateList();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            UpdateList();
        } 
    }
}
