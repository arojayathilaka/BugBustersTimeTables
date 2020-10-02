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
    /// Interaction logic for GroupNAView.xaml
    /// </summary>


    public partial class GroupNAView : Page
    {

        GroupNAViewModel groupNAViewModel;
        GroupNAEntity groupNAEntity;
        Student_GroupView student_GroupViewModel;
        Student_GroupEntity student_GroupEntity;
        List<GroupNAEntity> groupNAs;
        Student_GroupViewModel Student_GroupViewModel;

        public GroupNAView()
        {
            InitializeComponent();
        }
        private void Group_NA_Page_loaded(object sender, RoutedEventArgs e)
        {
            groupNAViewModel = new GroupNAViewModel();
            Student_GroupViewModel = new Student_GroupViewModel();
            groupNAs = groupNAViewModel.LoadGroupNAData();
            group_combobx.ItemsSource = Student_GroupViewModel.LoadStudentData();
        }

        private void add_btn__Click(object sender, RoutedEventArgs e)
        {
            try
            {
                groupNAEntity = CreateGroupNAEntity();
                groupNAViewModel.SaveGroupNAData(groupNAEntity);
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
            group_combobx.Text = "";
            day_combobx.Text = "";
            starttime_combobx.Text = "";
            endtime_combobx.Text = "";
        }

        private GroupNAEntity CreateGroupNAEntity()
        {
            int GroupId;
            GroupId = groupNAs.Last().GroupId + 1;

            string GroupNumber = group_combobx.Text;
            string Day = day_combobx.Text;
            string STime = starttime_combobx.Text;
            string ETime = endtime_combobx.Text;

            groupNAEntity = new GroupNAEntity(GroupId, GroupNumber, Day, STime, ETime);
            return groupNAEntity;
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
            SessionAddView sessionAddView = new SessionAddView();
            this.NavigationService.Navigate(sessionAddView);
        }

        private void parallelsession_btn_Click(object sender, RoutedEventArgs e)
        {
            SessionAddView sessionAddView = new SessionAddView();
            this.NavigationService.Navigate(sessionAddView);
        }

        private void group_combobx_SelectionChanged(object sender, SelectionChangedEventArgs e)
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
