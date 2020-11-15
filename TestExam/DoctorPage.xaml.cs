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
    /// Логика взаимодействия для DoctorPage.xaml
    /// </summary>
    public partial class DoctorPage : Page
    {
        public DoctorPage()
        {
            InitializeComponent();
            UpdateList();
            App.OnUpdated += UpdateList;
        }

        ~DoctorPage()
        {
            App.OnUpdated -= UpdateList;
        }

        public void UpdateList()
        {
            ListDoctors.ItemsSource = null;
            ListDoctors.ItemsSource = App.Entities.Doctors.ToArray();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // добавить
            var form = new DoctorAdd();
            form.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var doctor = ListDoctors.SelectedItem as Doctors;
            if (doctor != null)
            {
                var form = new DoctorAdd(doctor);
                form.Show();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var doctor = ListDoctors.SelectedItem as Doctors;
            if (doctor != null)
            {
                if (doctor.Meetings.Count > 0)
                {
                    MessageBox.Show("Нельзя удалить доктора, если он уже учавстовал во встречах", "Ошибка!");
                    return;
                }
                App.Entities.Doctors.Remove(doctor);
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
