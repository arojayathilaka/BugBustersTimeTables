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
using Time_Table_Generator.ViewModel;
using Time_Table_Generator.Views;


namespace Time_Table_Generator.View
{
    public partial class PrefferedRoomForGroupView : Page
    {

        PrefferedRoomForGroupViewModel _prefferedRoomForGroupViewModel;
        PrefferedRoomForGroupEntity prefferedRoomForGroupEntity;
        Student_GroupViewModel _studentgroupViewModel;
        Student_GroupEntity studentgroupEntity;
        List<PrefferedRoomForGroupEntity> prefferedRoomForGroups;
        int Group,SubGroup;

        public PrefferedRoomForGroupView()
        {
               InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
             _prefferedRoomForGroupViewModel = new PrefferedRoomForGroupViewModel();
            _studentgroupViewModel = new Student_GroupViewModel();
            //group_combobx.ItemsSource =  _studentgroupViewModel.LoadStudentData();
            prefferedRoomForGroups = _prefferedRoomForGroupViewModel.LoadData();
        }

        private void add_btn__Click(object sender, RoutedEventArgs e)
        {
            try
            {
                prefferedRoomForGroupEntity = CreatePrefferedRoomForGroupEntity();
                _prefferedRoomForGroupViewModel.SavePrefferedRoomForGroupData(prefferedRoomForGroupEntity);
                 MessageBoxResult result = MessageBox.Show("Successfully Added!", "BBTG");
                ClearAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

         private void group_combobx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
              ComboBox group_combobx = sender as ComboBox;
            ComboBoxItem selectedgroup = group_combobx.SelectedItem as ComboBoxItem;
           
                Group = int.Parse(selectedgroup.Content.ToString());
        }
        private void subgroup_combobx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
              ComboBox subgroup_combobx = sender as ComboBox;
              ComboBoxItem selectedsubgroup = subgroup_combobx.SelectedItem as ComboBoxItem;
              SubGroup = int.Parse(selectedsubgroup.Content.ToString());
        }

       private void roomname_txtbx_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void add_preffered_location_click(object sender, RoutedEventArgs e)
        {

            PrefferedRoomForTagView prefferedRoomForTagView = new PrefferedRoomForTagView();
            this.NavigationService.Navigate(prefferedRoomForTagView);
        }

          private void  add_preffered_locationforsubject_click(object sender, RoutedEventArgs e)
        {
              
           PrefferedRoomForSubjectView prefferedRoomForSubjectView = new PrefferedRoomForSubjectView();
           this.NavigationService.Navigate(prefferedRoomForSubjectView);

           }

         private void  add_preffered_locationforlecturer_click(object sender, RoutedEventArgs e)
        {
              
           PrefferedRoomForLecturerView prefferedRoomForLecturerView = new PrefferedRoomForLecturerView();
           this.NavigationService.Navigate(prefferedRoomForLecturerView);

           }

         private void   add_preffered_locationforsession_click(object sender, RoutedEventArgs e)
        {
              
           PrefferedRoomForSessionView prefferedRoomForSessionView = new PrefferedRoomForSessionView();
           this.NavigationService.Navigate(prefferedRoomForSessionView);

            }
      
           private PrefferedRoomForGroupEntity CreatePrefferedRoomForGroupEntity()
        {
            int id;
            int Group = int.Parse(group_combobx.Text);
            int SubGroup =  int.Parse(subgroup_combobx.Text) ;
            string RoomName = roomname_txtbx.Text;
            id = prefferedRoomForGroups.Last().id + 1;

            prefferedRoomForGroupEntity = new PrefferedRoomForGroupEntity(id,Group,SubGroup, RoomName);
            return prefferedRoomForGroupEntity;
        }

          private void ClearAll()
        {
           
            group_combobx.Text = "";
            subgroup_combobx.Text = "";
            roomname_txtbx.Text = "";
            
        }
    }
}
