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
    /// Логика взаимодействия для DoctorAdd.xaml
    /// </summary>
    public partial class DoctorAdd : Window
    {
        private Doctors _doctor = null;
        private bool _isEdit = false; // 
        public DoctorAdd(Doctors doctor = null)
        {
            InitializeComponent();

            if (doctor != null)
            {
                _isEdit = true;
                _doctor = doctor;
                // заполняем формочки данными из бд
                FirstNameTextBox.Text = doctor.First_Name;
                FamiliaTextBox.Text = doctor.Second_Name;
                Middle_NameTextBox.Text = doctor.Middle_Name;
                AgeTextBox.Text = doctor.Age.ToString();
                Cost_MeetTextBox.Text = doctor.Cost_Meet.ToString();
                Percent_to_SalaryTextBox.Text = doctor.Percent_to_Salary.ToString();
                ProfessionTextBox.Text = doctor.Profession;
            }
        }

        //валидация
        public bool IsValid()
        {
            if (!string.IsNullOrWhiteSpace(FirstNameTextBox.Text) && !string.IsNullOrWhiteSpace(FamiliaTextBox.Text) && !string.IsNullOrWhiteSpace(Middle_NameTextBox.Text) && int.TryParse(AgeTextBox.Text, out int age) && double.TryParse(Cost_MeetTextBox.Text, out double cost) && !string.IsNullOrWhiteSpace(ProfessionTextBox.Text) && double.TryParse(Percent_to_SalaryTextBox.Text, out double per))
                return true;
            return false;
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
                _doctor.First_Name = FirstNameTextBox.Text;
                _doctor.Second_Name = FamiliaTextBox.Text;
                _doctor.Middle_Name = Middle_NameTextBox.Text;
                _doctor.Age = int.Parse(AgeTextBox.Text);
                _doctor.Cost_Meet = double.Parse(Cost_MeetTextBox.Text);
                _doctor.Profession = ProfessionTextBox.Text;
                _doctor.Percent_to_Salary = double.Parse(Percent_to_SalaryTextBox.Text);
                App.Entities.SaveChanges();
                App.UpdateDB();
                this.Close();
            }
            else
            {
                var doctor = new Doctors();
                doctor.First_Name = FirstNameTextBox.Text;
                doctor.Second_Name = FamiliaTextBox.Text;
                doctor.Middle_Name = Middle_NameTextBox.Text;
                doctor.Age = int.Parse(AgeTextBox.Text);
                doctor.Cost_Meet = double.Parse(Cost_MeetTextBox.Text);
                doctor.Profession = ProfessionTextBox.Text;
                doctor.Percent_to_Salary = double.Parse(Percent_to_SalaryTextBox.Text);
                App.Entities.Doctors.Add(doctor);
                App.Entities.SaveChanges();
                App.UpdateDB();
                this.Close();
            }
        }

        private void Percent_to_SalaryTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
          
        }
    }
}
