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


    public partial class SessionNAView : Page
    {

        SessionNAViewModel sessionNAViewModel;
        SessionNAEntity sessionNAEntity;
        SessionViewModel sessionViewModel;
        SessionEntity sessionEntity;
        List<SessionNAEntity> sessionNAs;

        public SessionNAView()
        {
            InitializeComponent();
        }
        private void Session_NA_Page_loaded(object sender, RoutedEventArgs e)
        {
            sessionNAViewModel = new SessionNAViewModel();
            sessionViewModel = new SessionViewModel();

            session_combobx.ItemsSource = sessionViewModel.LoadSessionData();
            sessionNAs = sessionNAViewModel.LoadSessionNAData();
        }

        private void add_btn__Click(object sender, RoutedEventArgs e)
        {
            try
            {
                sessionNAEntity = CreateSessionNAEntity();
                sessionNAViewModel.SaveSessionNAData(sessionNAEntity);
                MessageBoxResult result = MessageBox.Show("Successfully Added!", "BBTG");
                ClearAll();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ClearAll()
        {
            session_combobx.Text = "";
            day_combobx.Text = "";
            starttime_combobx.Text = "";
            endtime_combobx.Text = "";
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


        private void session_combobx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private SessionNAEntity CreateSessionNAEntity()
        {
            int SessionId;
            SessionId = sessionNAs.Last().SessionId + 1;

            string Session = session_combobx.Text;
            string Day = day_combobx.Text;
            string STime = starttime_combobx.Text;
            string ETime = endtime_combobx.Text;

            sessionNAEntity = new SessionNAEntity(SessionId, Session, Day, STime, ETime);
            return sessionNAEntity;
        }

        private void day_combobx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void starttime_combobx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void endtime_combobx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
