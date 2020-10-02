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
using Time_Table_Generator.View;

namespace Time_Table_Generator.Views
{
    /// <summary>
    /// Interaction logic for AllocateNATime.xaml
    /// </summary>
    public partial class AllocateNATimeView : Page
    {
        public AllocateNATimeView()
        {
            InitializeComponent();
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

        private void lecturer_btn_Click(object sender, RoutedEventArgs e)
        {
            LecturerNAView lecturerNAView = new LecturerNAView();
            this.NavigationService.Navigate(lecturerNAView);
        }

        private void session_btn_Click(object sender, RoutedEventArgs e)
        {
            SessionNAView sessionNaView = new SessionNAView();
            this.NavigationService.Navigate(sessionNaView);
        }

        private void group_btn_Click(object sender, RoutedEventArgs e)
        {
            GroupNAView groupNAView = new GroupNAView();
            this.NavigationService.Navigate(groupNAView);
        }

        private void subgroup_btn_Click(object sender, RoutedEventArgs e)
        {
            SubGroupNAView subGroupNAView = new SubGroupNAView();
            this.NavigationService.Navigate(subGroupNAView);
        }
    }
}
