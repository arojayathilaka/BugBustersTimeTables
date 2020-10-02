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
   
    public partial class PrefferedRoomForLecturerView : Page
    {

        PrefferedRoomForLecturerViewModel _prefferedRoomForLecturerViewModel;
        PrefferedRoomForLecturerEntity prefferedRoomForLecturerEntity;
        LecturerViewModel _lecturerViewModel;
        LecturerEntity lecturerEntity;
         List<PrefferedRoomForLecturerEntity> prefferedRoomForLecturers;
        

        public PrefferedRoomForLecturerView()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

            _prefferedRoomForLecturerViewModel = new PrefferedRoomForLecturerViewModel();
            _lecturerViewModel = new LecturerViewModel();
            lecturername_combobx.ItemsSource = _lecturerViewModel.LoadLecturerData();
            prefferedRoomForLecturers = _prefferedRoomForLecturerViewModel.LoadData();
            }

        private void add_btn__Click(object sender, RoutedEventArgs e)
        {
            try
            {
                prefferedRoomForLecturerEntity = CreatePrefferedRoomForLecturerEntity();
                _prefferedRoomForLecturerViewModel.SavePrefferedRoomForLecturerData(prefferedRoomForLecturerEntity);
                 MessageBoxResult result = MessageBox.Show("Successfully Added!", "BBTG");
                ClearAll();
             }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lecturername_combobx_SelectionChanged(object sender, SelectionChangedEventArgs e)
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

          private void  add_preffered_locationforsubject_click(object sender, RoutedEventArgs e)
        {
              
           PrefferedRoomForSubjectView prefferedRoomForSubjectView = new PrefferedRoomForSubjectView();
           this.NavigationService.Navigate(prefferedRoomForSubjectView);
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
      
          private PrefferedRoomForLecturerEntity CreatePrefferedRoomForLecturerEntity()
        {
            int id;
            string LecturerName = lecturername_combobx.Text;
            string RoomName = roomname_txtbx.Text;
            id = prefferedRoomForLecturers.Last().id + 1;

            prefferedRoomForLecturerEntity = new PrefferedRoomForLecturerEntity(id,LecturerName, RoomName);
            return prefferedRoomForLecturerEntity;
        }

          private void ClearAll()
        {
           
            lecturername_combobx.Text = "";
            roomname_txtbx.Text = "";
            
        }
     }
}
