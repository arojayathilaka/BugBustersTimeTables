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

namespace Time_Table_Generator.Views
{
    /// <summary>
    /// Interaction logic for TimetablesCategories.xaml
    /// </summary>
    public partial class TimetablesCategories : Page
    {
        public TimetablesCategories()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LecturerTimetable lecturerTimetable = new LecturerTimetable();
            this.NavigationService.Navigate(lecturerTimetable);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            StudentTimetable timetableView = new StudentTimetable();
            this.NavigationService.Navigate(timetableView);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            RoomTimetable roomTimetable = new RoomTimetable();
            this.NavigationService.Navigate(roomTimetable);
        }
    }
}
