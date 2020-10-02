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
    /// Interaction logic for ParallelSessionView.xaml
    /// </summary>
    public partial class ParallelSessionView : Page
    {

        ParallelSessionViewModel parallelSessionViewModel;
        ParallelSessionEntity parallelSessionEntity;

        SessionViewModel sessionViewModel;
        SessionEntity sessionEntity;
        List<ParallelSessionEntity> parallelSessions;

        public ParallelSessionView()
        {
            InitializeComponent();
        }

        private void Parallel_Session_Page_loaded(object sender, RoutedEventArgs e)
        {
            parallelSessionViewModel = new ParallelSessionViewModel();
            sessionViewModel = new SessionViewModel();

            session1_combobx.ItemsSource = sessionViewModel.LoadSessionData();
            session2_combobx.ItemsSource = sessionViewModel.LoadSessionData();
            parallelSessions = parallelSessionViewModel.LoadParallelSessionData();
        }

        private void add_btn__Click(object sender, RoutedEventArgs e)
        {
            try
            {
                parallelSessionEntity = CreateParellelSessionEntity();
                parallelSessionViewModel.SaveParallelSessionData(parallelSessionEntity);
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
            session1_combobx.Text = "";
            session2_combobx.Text = "";
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

        private ParallelSessionEntity CreateParellelSessionEntity()
        {
            int ParallelSessionId;
            ParallelSessionId = parallelSessions.Last().ParallelSessionId + 1;

            string Ses1 = session1_combobx.Text;
            string Ses2 = session2_combobx.Text;
            string Day = day_combobx.Text;
            string STime = starttime_combobx.Text;
            string ETime = endtime_combobx.Text;

            parallelSessionEntity = new ParallelSessionEntity(ParallelSessionId, Ses1, Ses2, Day, STime, ETime);
            return parallelSessionEntity;
        }

        private void session1_combobx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void session2_combobx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

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
