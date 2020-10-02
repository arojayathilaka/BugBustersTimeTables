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
    /// Interaction logic for Room.xaml
    /// </summary>
    public partial class RoomView : Page
    {
        RoomViewModel _roomViewModel;
        BuildingViewModel _buildingViewModel;
        RoomEntity roomEntity;
        Regex roomIdRegex = new Regex(@"\b\d{6}\b");
        bool updateMode = false;

        public RoomView()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            _roomViewModel = new RoomViewModel();
            _buildingViewModel = new BuildingViewModel();
            room_data_grid.ItemsSource = _roomViewModel.LoadRoomData();
            building_combobx.ItemsSource = _buildingViewModel.LoadBuildingData();
            //roomtype_combobx.ItemsSource = _roomViewModel.LoadRoomData();
            roomid_txtbx.Text = "Eg: 001001";
            add_btn_.IsEnabled = false;
            update_btn_.IsEnabled = false;
            delete_btn_.IsEnabled = false;

        }

        private void add_btn__Click(object sender, RoutedEventArgs e)
        {
            try
            {
                roomEntity = CreateRoomEntity();
                _roomViewModel.SaveRoomData(roomEntity);
                room_data_grid.ItemsSource = _roomViewModel.LoadRoomData();
                ClearAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void update_btn__Click(object sender, RoutedEventArgs e)
        {
            try
            {
                roomEntity = CreateRoomEntity();
                _roomViewModel.UpdateRoomData(roomEntity);
                room_data_grid.ItemsSource = _roomViewModel.LoadRoomData();
                ClearAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void delete_btn__Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int RoomId = int.Parse(roomid_txtbx.Text);

                _roomViewModel.DeleteRoomData(RoomId);
                room_data_grid.ItemsSource = _roomViewModel.LoadRoomData();
                ClearAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ClearAll()
        {
            roomid_txtbx.Text = "Eg: 001001";
            room_txtbx.Text = "";
            capacity_txtbx.Text = "";
            building_combobx.Text = "";
            roomtype_combobx.Text = "";
            updateMode = false;
            add_btn_.IsEnabled = false;
            update_btn_.IsEnabled = false;
            delete_btn_.IsEnabled = false;
        }

        private void room_data_grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            updateMode = true;
            delete_btn_.IsEnabled = true;
            DataGrid dataGrid = (DataGrid)sender;
            RoomEntity room = dataGrid.SelectedItem as RoomEntity;

            if (room != null)
            {
                roomid_txtbx.Text = room.RoomId.ToString();
                room_txtbx.Text = room.RoomName;
                building_combobx.Text = room.Building;
                roomtype_combobx.Text = room.RoomType;
                capacity_txtbx.Text = room.Capacity.ToString();
             }
        }

        private void clear_all_btn__Click(object sender, RoutedEventArgs e)
        {
            ClearAll();
        }

        private RoomEntity CreateRoomEntity()
        {
            string Building = building_combobx.Text;
            int RoomId = int.Parse(roomid_txtbx.Text);
            string RoomName = room_txtbx.Text;
            string RoomType = roomtype_combobx.Text;
            int Capacity = int.Parse(capacity_txtbx.Text);

            roomEntity = new RoomEntity(RoomId, RoomName, Building, RoomType, Capacity);
            return roomEntity;
        }

        private void CheckValidations()
        {
            int maximum_capacity = 0;

            if (roomtype_combobx.Text == "Lecture hall")
            {
                maximum_capacity = 250;

            }
            else
            {
                maximum_capacity = 60;

            }

            if (

                !String.IsNullOrEmpty(roomid_txtbx.Text) &&
                !String.IsNullOrEmpty(room_txtbx.Text) &&
                !String.IsNullOrEmpty(building_combobx.Text) &&
                !String.IsNullOrEmpty(roomtype_combobx.Text) &&
                !String.IsNullOrEmpty(capacity_txtbx.Text) &&
                !(int.Parse(capacity_txtbx.Text) > maximum_capacity) &&
                roomIdRegex.IsMatch(roomid_txtbx.Text)

                )

            {
                if (updateMode)
                {
                    update_btn_.IsEnabled = true;
                }
                else
                {
                    add_btn_.IsEnabled = true;
                }
            }
            else
            {
                if (updateMode)
                {
                    update_btn_.IsEnabled = false;
                }
                else
                {
                    add_btn_.IsEnabled = false;
                }
            }
        }

         private void roomid_txtbx_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckValidations();
        }

        private void room_txtbx_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckValidations();
        }

        private void building_combobx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CheckValidations();
        }


        private void roomtype_combobx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CheckValidations();

            ComboBoxItem item = roomtype_combobx.SelectedItem as ComboBoxItem;
            if (item != null)
            {
                string roomType = item.Content.ToString();

            }
        }


        private void capacity_txtbx_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckValidations();
        }

        private void roomid_txtbx_GotFocus(object sender, RoutedEventArgs e)
        {
            roomid_txtbx.Text = "";
        }

          private void add_preffered_location_click(object sender, RoutedEventArgs e)
        {

            PrefferedRoomForTagView prefferedRoomForTagView = new PrefferedRoomForTagView();
            this.NavigationService.Navigate(prefferedRoomForTagView);
        }

        private void add_building_click(object sender, RoutedEventArgs e)
        {
              
           BuildingView buildingView =  new BuildingView();
           this.NavigationService.Navigate(buildingView);

            }


    }
}
