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
    /// Interaction logic for ConsecutiveSessionView.xaml
    /// </summary>
    public partial class ConsecutiveSessionView : Page
    {

        ConsecutiveSessionViewModel consecutiveSessionViewModel;
        ConsecutiveSessionEntity consecutiveSessionEntity;
        SessionViewModel sessionViewModel;
        SessionEntity sessionEntity;
        List<ConsecutiveSessionEntity> consecutiveSessions;

        public ConsecutiveSessionView()
        {
            InitializeComponent();
        }

        private void Consecutive_Session_Page_loaded(object sender, RoutedEventArgs e)
        {
            consecutiveSessionViewModel = new ConsecutiveSessionViewModel();
            sessionViewModel = new SessionViewModel();

            consecutive_session1_combobx.ItemsSource = sessionViewModel.LoadSessionData();
            consecutive_session2_combobx.ItemsSource = sessionViewModel.LoadSessionData();
            consecutiveSessions = consecutiveSessionViewModel.LoadConsecutiveSessionData();
        }

        private void add_btn__Click(object sender, RoutedEventArgs e)
        {
            try
            {
                consecutiveSessionEntity = CreateConsecutiveSessionEntity();
                consecutiveSessionViewModel.SaveConsecutiveSessionData(consecutiveSessionEntity);
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
            consecutive_session1_combobx.Text = "";
            consecutive_session2_combobx.Text = "";
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

        private void consecutive_session1_combobx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void consecutive_session2_combobx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private ConsecutiveSessionEntity CreateConsecutiveSessionEntity()
        {
            int ConsId;
            ConsId = consecutiveSessions.Last().ConsId + 1;

            string Ses1 = consecutive_session1_combobx.Text;
            string Ses2 = consecutive_session2_combobx.Text;

            consecutiveSessionEntity = new ConsecutiveSessionEntity(ConsId, Ses1, Ses2);
            return consecutiveSessionEntity;
        }
    }
}
