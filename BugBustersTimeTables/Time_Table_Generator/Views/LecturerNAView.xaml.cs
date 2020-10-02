using BBTG.Entities.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using Time_Table_Generator.View;
using Time_Table_Generator.ViewModel;

namespace Time_Table_Generator.Views
{
    /// <summary>
    /// Interaction logic for LecturerNAView.xaml
    /// </summary>


    public partial class LecturerNAView : Page
    {

        LecturerNAViewModel lecturerNAViewModel;
        LecturerNAEntity lecturerNAEntity;
        LecturerViewModel lecturerViewModel;
        LecturerEntity lecturerEntity;
        List<LecturerNAEntity> lecturerNAs;
        List<LecturerEntity> lecturers;

        public LecturerNAView()
        {
            InitializeComponent();
        }
        private void Lecturer_NA_Page_loaded(object sender, RoutedEventArgs e)
        {
            lecturerNAViewModel = new LecturerNAViewModel();
            lecturerViewModel = new LecturerViewModel();

            lecturers = lecturerViewModel.LoadLecturerData();
            lecturer_combobx.ItemsSource = lecturers;
            lecturerNAs = lecturerNAViewModel.LoadLecturerNAData();
        }

        private void add_btn__Click(object sender, RoutedEventArgs e)
        {
            try
            {
                lecturerNAEntity = CreateLectureNAEntity();
                lecturerNAViewModel.SaveLecturerNAData(lecturerNAEntity);
                MessageBoxResult result = MessageBox.Show("Successfully Added!", "BBTG");
                ClearAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ClearAll()
        {
            lecturer_combobx.Text = "";
            day_combobx.Text = "";
            starttime_combobx.Text = "";
            endtime_combobx.Text = "";
        }

        private LecturerNAEntity CreateLectureNAEntity()
        {
            int LecturerId;
            LecturerId = lecturerNAs.Last().LecturerId + 1;

            string Lecturer = lecturer_combobx.Text;
            string Day = day_combobx.Text;
            string STime = starttime_combobx.Text;
            string ETime = endtime_combobx.Text;

            lecturerNAEntity = new LecturerNAEntity(LecturerId, Lecturer, Day, STime, ETime);
            return lecturerNAEntity;
        }

        private void sessionAdd_btn_Click(object sender, RoutedEventArgs e)
        {
            SessionAddView sessionAddView = new SessionAddView();
            this.NavigationService.Navigate(sessionAddView);
        }

        private void allocatna_btn_Click(object sender, RoutedEventArgs e)
        {
            AllocateNATimeView allocateNATimeView = new AllocateNATimeView();
            this.NavigationService.Navigate(allocateNATimeView);
        }

        private void consecutivesession_btn_Click(object sender, RoutedEventArgs e)
        {
            ConsecutiveSessionView consecutiveSessionView = new ConsecutiveSessionView();
            this.NavigationService.Navigate(consecutiveSessionView);
        }

        private void parallelsession_btn_Click(object sender, RoutedEventArgs e)
        {
            ParallelSessionView parallelSessionView = new ParallelSessionView();
            this.NavigationService.Navigate(parallelSessionView);
        }
    }
}
