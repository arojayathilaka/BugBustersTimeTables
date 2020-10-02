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
   
    public partial class PrefferedRoomForSessionView : Page
    {
        PrefferedRoomForSessionViewModel _prefferedRoomForSessionViewModel;
        PrefferedRoomForSessionEntity prefferedRoomForSessionEntity;
        SessionViewModel _sessionViewModel;
        SessionEntity sessionEntity;
        List<PrefferedRoomForSessionEntity> prefferedRoomForSessions;

        public PrefferedRoomForSessionView()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            _prefferedRoomForSessionViewModel = new PrefferedRoomForSessionViewModel();
            _sessionViewModel = new SessionViewModel();
            session_combobx.ItemsSource = _sessionViewModel.LoadSessionData();
            prefferedRoomForSessions = _prefferedRoomForSessionViewModel.LoadData();

        }

        private void add_btn__Click(object sender, RoutedEventArgs e)
        {
            try
            {
                prefferedRoomForSessionEntity = CreatePrefferedRoomForSessionEntity();
                _prefferedRoomForSessionViewModel.SavePrefferedRoomForSessionData(prefferedRoomForSessionEntity);
                 MessageBoxResult result = MessageBox.Show("Successfully Added!", "BBTG");
                ClearAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void session_combobx_SelectionChanged(object sender, SelectionChangedEventArgs e)
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

        private void add_preffered_locationforsubject_click(object sender, RoutedEventArgs e)
        {

            PrefferedRoomForSubjectView prefferedRoomForSubjectView = new PrefferedRoomForSubjectView();
            this.NavigationService.Navigate(prefferedRoomForSubjectView);
        }

        private void add_preffered_locationforgroup_click(object sender, RoutedEventArgs e)
        {

            PrefferedRoomForGroupView prefferedRoomForGroupView = new PrefferedRoomForGroupView();
            this.NavigationService.Navigate(prefferedRoomForGroupView);
        }

        private void add_preffered_locationforLecturer_click(object sender, RoutedEventArgs e)
        {

            PrefferedRoomForLecturerView prefferedRoomForLecturerView = new PrefferedRoomForLecturerView();
            this.NavigationService.Navigate(prefferedRoomForLecturerView);
        }


        private PrefferedRoomForSessionEntity CreatePrefferedRoomForSessionEntity()
        {
            int id;
            int Session = int.Parse(session_combobx.Text);
            string RoomName = roomname_txtbx.Text;
            id = prefferedRoomForSessions.Last().id + 1;

            prefferedRoomForSessionEntity = new PrefferedRoomForSessionEntity(id, Session, RoomName);
            return prefferedRoomForSessionEntity;
        }

        private void ClearAll()
        {

            session_combobx.Text = "";
            roomname_txtbx.Text = "";

        }
    }
}