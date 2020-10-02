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
    /// Interaction logic for SubGroupNAView.xaml
    /// </summary>


    public partial class SubGroupNAView : Page
    {

        SubGroupNAViewModel subGroupNAViewModel;
        Student_SubGroupViewModel Student_SubGroupViewModel;
        SubGroupNAEntity subGroupNAEntity;

        List<SubGroupNAEntity> subGroupNAs;

        public SubGroupNAView()
        {
            InitializeComponent();
        }
        private void SubGroup_NA_Page_loaded(object sender, RoutedEventArgs e)
        {
            subGroupNAViewModel = new SubGroupNAViewModel();
            Student_SubGroupViewModel = new Student_SubGroupViewModel();
            subGroupNAs = subGroupNAViewModel.LoadSubGroupNAData();
            subgroup_combobx.ItemsSource = Student_SubGroupViewModel.LoadStudentData();
        }

        private void add_btn__Click(object sender, RoutedEventArgs e)
        {
            try
            {
                subGroupNAEntity = CreateGroupNAEntity();
                subGroupNAViewModel.SaveSubGroupNAData(subGroupNAEntity);
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
            subgroup_combobx.Text = "";
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
            SessionAddView sessionAddView = new SessionAddView();
            this.NavigationService.Navigate(sessionAddView);
        }

        private void parallelsession_btn_Click(object sender, RoutedEventArgs e)
        {
            SessionAddView sessionAddView = new SessionAddView();
            this.NavigationService.Navigate(sessionAddView);
        }

        private void subgroup_combobx_SelectionChanged(object sender, SelectionChangedEventArgs e)
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

        private SubGroupNAEntity CreateGroupNAEntity()
        {
            int SubGroupId;
            SubGroupId = subGroupNAs.Last().SubGroupId + 1;

            string SubGroupNumber = subgroup_combobx.Text;
            string Day = day_combobx.Text;
            string STime = starttime_combobx.Text;
            string ETime = endtime_combobx.Text;

            subGroupNAEntity = new SubGroupNAEntity(SubGroupId, SubGroupNumber, Day, STime, ETime);
            return subGroupNAEntity;
        }
    }
}
