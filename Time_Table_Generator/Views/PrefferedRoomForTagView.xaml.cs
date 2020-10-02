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
    /// <summary>
    /// Interaction logic for Building.xaml
    /// </summary>
    public partial class PrefferedRoomForTagView : Page
    {

        PrefferedRoomForTagViewModel _prefferedRoomForTagViewModel;
        PrefferedRoomForTagEntity prefferedRoomForTagEntity;
        TagViewModel _tagViewModel;
        TagEntity tagEntity;
        List<PrefferedRoomForTagEntity> prefferedRoomForTags;

       public PrefferedRoomForTagView()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

            _prefferedRoomForTagViewModel = new PrefferedRoomForTagViewModel();
            _tagViewModel = new TagViewModel();

            tagname_combobx.ItemsSource = _tagViewModel.LoadTagData();
            prefferedRoomForTags = _prefferedRoomForTagViewModel.LoadData();
             }

        private void add_btn__Click(object sender, RoutedEventArgs e)
        {
            try
            {
                prefferedRoomForTagEntity = CreatePrefferedRoomForTagEntity();
                _prefferedRoomForTagViewModel.SavePrefferedRoomForTagData(prefferedRoomForTagEntity);
                MessageBoxResult result = MessageBox.Show("Successfully Added!", "BBTG");
                ClearAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

       private void tagname_combobx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }

        private void roomname_txtbx_TextChanged(object sender, TextChangedEventArgs e)
        {
            
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
      
         private PrefferedRoomForTagEntity CreatePrefferedRoomForTagEntity()
        {
            int id;
            string TagName = tagname_combobx.Text;
            string RoomName = roomname_txtbx.Text;
            id = prefferedRoomForTags.Last().id + 1;

            prefferedRoomForTagEntity = new PrefferedRoomForTagEntity(id,TagName, RoomName);
            return prefferedRoomForTagEntity;
        }

          private void ClearAll()
        {
           
            tagname_combobx.Text = "";
            roomname_txtbx.Text = "";
            
        }





    }
}
