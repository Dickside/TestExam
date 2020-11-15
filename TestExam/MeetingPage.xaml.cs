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
    /// Логика взаимодействия для MeetingPage.xaml
    /// </summary>
    public partial class MeetingPage : Page
    {
        public MeetingPage()
        {
            InitializeComponent();
            UpdateList();
            App.OnUpdated += UpdateList;
        }

        ~MeetingPage()
        {
            App.OnUpdated -= UpdateList;
        }

        public void UpdateList()
        {
            ListMeetings.ItemsSource = null;
            ListMeetings.ItemsSource = App.Entities.Meetings.ToArray();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // добавить
            var form = new MeetingAdd();
            form.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var meeting = ListMeetings.SelectedItem as Meetings;
            if (meeting != null)
            {
                var form = new MeetingAdd(meeting);
                form.Show();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var meeting = ListMeetings.SelectedItem as Meetings;
            if (meeting != null)
            {
                App.Entities.Meetings.Remove(meeting);
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
