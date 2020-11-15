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
using TestExam.DB;

namespace TestExam
{
    /// <summary>
    /// Логика взаимодействия для PatientAdd.xaml
    /// </summary>
    public partial class PatientAdd : Window
    {
        private Patients _patient = null;
        private bool _isEdit = false; // 
        public PatientAdd(Patients patient = null)
        {
            InitializeComponent();

            if (patient != null)
            {
                _isEdit = true;
                _patient = patient;
                // заполняем формочки данными из бд
                FirstNameTextBox.Text = patient.First_Name;
                FamiliaTextBox.Text = patient.Second_Name;
                Middle_NameTextBox.Text = patient.Middle_Name;
                Birth_DayTextBox.Text = patient.Birth_day.ToString();
                AddressTextBox.Text = patient.Address;
                IllnessTextBox.Text = patient.Illness;
            }
        }

        //валидация
        public bool IsValid()
        {
            //if (!string.IsNullOrWhiteSpace(FirstNameTextBox.Text) && !string.IsNullOrWhiteSpace(FamiliaTextBox.Text) && !string.IsNullOrWhiteSpace(Middle_NameTextBox.Text) && int.TryParse(AgeTextBox.Text, out int age) && double.TryParse(Cost_MeetTextBox.Text, out double cost) && !string.IsNullOrWhiteSpace(ProfessionTextBox.Text) && double.TryParse(Percent_to_SalaryTextBox.Text, out double per))
                return true;
            //return false;
        }

        private void Submit(object sender, RoutedEventArgs e)
        {
            if (IsValid() == false)
            {
                MessageBox.Show("Вы не заполнили все поля");
                return;
            }

            if (_isEdit)
            {
                _patient.First_Name = FirstNameTextBox.Text;
                _patient.Second_Name = FamiliaTextBox.Text;
                _patient.Middle_Name = Middle_NameTextBox.Text;
                _patient.Birth_day = Birth_DayTextBox.SelectedDate;
                _patient.Address = AddressTextBox.Text;
                _patient.Illness = IllnessTextBox.Text;
                App.Entities.SaveChanges();
                App.UpdateDB();
                this.Close();
            }
            else
            {
                var patient = new Patients();
                patient.First_Name = FirstNameTextBox.Text;
                patient.Second_Name = FamiliaTextBox.Text;
                patient.Middle_Name = Middle_NameTextBox.Text;
                patient.Birth_day = Birth_DayTextBox.SelectedDate;
                patient.Address = AddressTextBox.Text;
                patient.Illness = IllnessTextBox.Text;
                App.Entities.Patients.Add(patient);
                App.Entities.SaveChanges();
                App.UpdateDB();
                this.Close();
            }
        }
    }
}
