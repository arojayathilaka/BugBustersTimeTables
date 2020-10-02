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
    public partial class BuildingView : Page
    {

        BuildingViewModel _buildingViewModel;
        BuildingEntity buildingEntity;
        Regex buildingIdRegex = new Regex(@"\b\d{3}\b");
        bool updateMode = false;

        public BuildingView()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            
            _buildingViewModel = new BuildingViewModel();
             building_data_grid.ItemsSource = _buildingViewModel.LoadBuildingData();

            add_btn_.IsEnabled = false;
            update_btn_.IsEnabled = false;
            delete_btn_.IsEnabled = false;
            buildingid_txtbx.Text = "Eg: 001";
 }

        private void add_btn__Click(object sender, RoutedEventArgs e)
        {
            try
            {
                buildingEntity = CreateBuildingEntity();
                _buildingViewModel.SaveBuildingData(buildingEntity);
                building_data_grid.ItemsSource = _buildingViewModel.LoadBuildingData();
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
                buildingEntity = CreateBuildingEntity();
                _buildingViewModel.UpdateBuildingData(buildingEntity);
                building_data_grid.ItemsSource = _buildingViewModel.LoadBuildingData();
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
                int BuildingId = int.Parse(buildingid_txtbx.Text);
                _buildingViewModel.DeleteBuildingData(BuildingId);
                building_data_grid.ItemsSource = _buildingViewModel.LoadBuildingData();
                ClearAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ClearAll()
        {
            buildingid_txtbx.Text = "Eg: 001";
            buildingname_txtbx.Text = "";
            updateMode = false;
            add_btn_.IsEnabled = false;
            update_btn_.IsEnabled = false;
            delete_btn_.IsEnabled = false;
        }

        private void building_data_grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            updateMode = true;
            delete_btn_.IsEnabled = true;
            DataGrid dataGrid = (DataGrid)sender;
            BuildingEntity building = dataGrid.SelectedItem as BuildingEntity;

            if (building != null)
            {
                buildingid_txtbx.Text = building.BuildingId.ToString();
                buildingname_txtbx.Text = building.BuildingName;
               }
        }

        private void clear_all_btn__Click(object sender, RoutedEventArgs e)
        {
            ClearAll();
        }

        private BuildingEntity CreateBuildingEntity()
        {
            
            int BuildingId = int.Parse(buildingid_txtbx.Text);
            string BuildingName = buildingname_txtbx.Text;
           
            buildingEntity = new BuildingEntity(BuildingId, BuildingName);
            return buildingEntity;
        }

        private void CheckValidations()
        {
             if (

                !String.IsNullOrEmpty(buildingid_txtbx.Text) &&
                !String.IsNullOrEmpty(buildingname_txtbx.Text) &&
                buildingIdRegex.IsMatch(buildingid_txtbx.Text)

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

        private void buildingid_txtbx_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckValidations();
        }

        private void buildingname_txtbx_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckValidations();
        }

        private void buildingid_txtbx_GotFocus(object sender, RoutedEventArgs e)
        {
            buildingid_txtbx.Text = "";
        }

         private void add_preffered_location_click(object sender, RoutedEventArgs e)
        {

            PrefferedRoomForTagView prefferedRoomForTagView = new PrefferedRoomForTagView();
            this.NavigationService.Navigate(prefferedRoomForTagView);
        }

        private void add_room_click(object sender, RoutedEventArgs e)
        {
              
           RoomView roomView = new RoomView();
           this.NavigationService.Navigate(roomView);
         }


    }
}
