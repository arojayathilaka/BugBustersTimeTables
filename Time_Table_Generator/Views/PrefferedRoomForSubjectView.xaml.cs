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
    public partial class PrefferedRoomForSubjectView : Page
    {

        PrefferedRoomForSubjectViewModel _prefferedRoomForSubjectViewModel;
        PrefferedRoomForSubjectEntity prefferedRoomForSubjectEntity;
        TagViewModel _tagViewModel;
        TagEntity tagEntity;
        SubjectViewModel _subjectViewModel;
        SubjectEntity subjectEntity;
        List<PrefferedRoomForSubjectEntity> prefferedRoomForSubjects;

        public PrefferedRoomForSubjectView()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            _prefferedRoomForSubjectViewModel = new PrefferedRoomForSubjectViewModel();
            _tagViewModel = new TagViewModel();
            _subjectViewModel = new SubjectViewModel();
            tagname_combobx.ItemsSource = _tagViewModel.LoadTagData();
            subjectname_combobx.ItemsSource = _subjectViewModel.LoadSubjectData();
            prefferedRoomForSubjects = _prefferedRoomForSubjectViewModel.LoadData();
        }

        private void add_btn__Click(object sender, RoutedEventArgs e)
        {
            try
            {
                prefferedRoomForSubjectEntity = CreatePrefferedRoomForSubjectEntity();
                _prefferedRoomForSubjectViewModel.SavePrefferedRoomForSubjectData(prefferedRoomForSubjectEntity);
                 MessageBoxResult result = MessageBox.Show("Successfully Added!", "BBTG");
                ClearAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void subjectname_combobx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void tagname_combobx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void roomname_txtbx_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

      private void add_preffered_location_click(object sender, RoutedEventArgs e)
        {

            PrefferedRoomForTagView prefferedRoomForTagView = new PrefferedRoomForTagView();
            this.NavigationService.Navigate(prefferedRoomForTagView);
        }

          private void  add_preffered_locationforlecturer_click(object sender, RoutedEventArgs e)
        {
              
           PrefferedRoomForLecturerView prefferedRoomForLecturerView = new PrefferedRoomForLecturerView();
           this.NavigationService.Navigate(prefferedRoomForLecturerView);

           }

         private void  add_preffered_locationforgroup_click(object sender, RoutedEventArgs e)
        {
              
           PrefferedRoomForGroupView prefferedRoomForGroupView = new PrefferedRoomForGroupView();
           this.NavigationService.Navigate(prefferedRoomForGroupView);

           }

         private void   add_preffered_locationforsession_click(object sender, RoutedEventArgs e)
        {
              
           PrefferedRoomForSessionView prefferedRoomForSessionView = new PrefferedRoomForSessionView();
           this.NavigationService.Navigate(prefferedRoomForSessionView);

            }
      
          private PrefferedRoomForSubjectEntity CreatePrefferedRoomForSubjectEntity()
        {
            int id;
            string SubjectName = subjectname_combobx.Text;
            string TagName = tagname_combobx.Text;
            string RoomName = roomname_txtbx.Text;
            id = prefferedRoomForSubjects.Last().id + 1;

            prefferedRoomForSubjectEntity = new PrefferedRoomForSubjectEntity(id,SubjectName, TagName,RoomName);
            return prefferedRoomForSubjectEntity;
        }

       
          private void ClearAll()
        {
           
            subjectname_combobx.Text = "";
            tagname_combobx.Text = "";
            roomname_txtbx.Text = "";
            
        }

    }
}
