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
    /// Логика взаимодействия для MeetingAdd.xaml
    /// </summary>
    public partial class MeetingAdd : Window
    {
        private Meetings _meeting = null;
        private bool _isEdit = false;
        public MeetingAdd(Meetings meeting = null)
        {
            InitializeComponent();
            DoctorsCB.ItemsSource = App.Entities.Doctors.ToArray();
            PatientsCB.ItemsSource = App.Entities.Patients.ToArray();

            if (meeting != null)
            {
                _isEdit = true;
                _meeting = meeting;
                DoctorsCB.SelectedItem = meeting.Doctors;
                PatientsCB.SelectedItem = meeting.Patients;
                DateDP.SelectedDate = meeting.Meeting_Date;
            }
        }

        public bool IsValid()
        {
            if (DoctorsCB.SelectedItem as Doctors != null && PatientsCB.SelectedItem as Patients != null && DateDP.SelectedDate != null)
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
                _meeting.Doctors = DoctorsCB.SelectedItem as Doctors;
                _meeting.Patients = PatientsCB.SelectedItem as Patients;
                _meeting.Meeting_Date = DateDP.SelectedDate;
                App.Entities.SaveChanges();
                App.UpdateDB();
                this.Close();
            }
            else
            {
                var meeting = new Meetings();
                meeting.Doctors = DoctorsCB.SelectedItem as Doctors;
                meeting.Patients = PatientsCB.SelectedItem as Patients;
                meeting.Meeting_Date = DateDP.SelectedDate;
                App.Entities.Meetings.Add(meeting);
                App.Entities.SaveChanges();
                App.UpdateDB();
                this.Close();
            }
        }
    }
}
