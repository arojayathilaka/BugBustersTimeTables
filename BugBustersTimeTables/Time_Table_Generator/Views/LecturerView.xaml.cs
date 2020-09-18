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

namespace Time_Table_Generator.View
{
    /// <summary>
    /// Interaction logic for Lecture.xaml
    /// </summary>
    public partial class LecturerView : Page
    {
        LecturerViewModel _lecturerViewModel;
        CenterViewModel _centerViewModel;
        BuildingViewModel _buildingViewModel;
        FacultyViewModel _facultyViewModel;
        DepartmentViewModel _departmentViewModel;
        LecturerEntity lecturer;
        string level;

        bool updateMode = false;
        Regex empIdRegex = new Regex(@"\b\d{6}\b");
        List<int> lecturerIds = new List<int>();

        public LecturerView()
        {
            InitializeComponent();
        }

        private void Lecturer_Page_Loaded(object sender, RoutedEventArgs e)
        {
            _lecturerViewModel = new LecturerViewModel();
            _centerViewModel = new CenterViewModel();
            _buildingViewModel = new BuildingViewModel();
            _facultyViewModel = new FacultyViewModel();
            _departmentViewModel = new DepartmentViewModel();

            List<LecturerEntity> lecturers = _lecturerViewModel.LoadLecturerData();
            lecturer_data_grid.ItemsSource = lecturers;           
            center_combobx.ItemsSource = _centerViewModel.LoadCenterData();
            building_combobx.ItemsSource =  _buildingViewModel.LoadBuildingData();
            faculty_combobx.ItemsSource = _facultyViewModel.LoadFacultyData();
            department_combobx.ItemsSource = _departmentViewModel.LoadDepartmentData();

            foreach(LecturerEntity l in lecturers)
            {
                lecturerIds.Add(l.EmployeeId);
            }

            add_btn_.IsEnabled = false;
            update_btn_.IsEnabled = false;
            delete_btn_.IsEnabled = false;
            emp_id_txtbx.Text = "Eg: 000150";
        }

        private void add_btn__Click(object sender, RoutedEventArgs e)
        {
            try
            {
                lecturer = CreateLecturerEntity();
                lecturerIds.Add(lecturer.EmployeeId);
                _lecturerViewModel.SaveLecturerData(lecturer);
                lecturer_data_grid.ItemsSource = _lecturerViewModel.LoadLecturerData();
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
                lecturer = CreateLecturerEntity();
                _lecturerViewModel.UpdateLecturerData(lecturer);
                lecturer_data_grid.ItemsSource = _lecturerViewModel.LoadLecturerData();
                ClearAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }          
        }

        private void delete_btn__Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete?", "BBTG", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);

            if(result == MessageBoxResult.Yes)
            {
                try
                {
                    int EmployeeId = int.Parse(emp_id_txtbx.Text);

                    _lecturerViewModel.DeleteLecturerData(EmployeeId);
                    lecturer_data_grid.ItemsSource = _lecturerViewModel.LoadLecturerData();
                    ClearAll();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void ClearAll()
        {
            emp_id_txtbx.Text = "Eg: 000150";
            name_txtbx.Text = "";
            faculty_combobx.Text = "";
            department_combobx.Text = "";
            center_combobx.Text = "";
            building_combobx.Text = "";
            level_combobx.Text = "";
            rank_txtbx.Text = "";
            emp_id_txtbx.IsEnabled = true;
            updateMode = false;
            add_btn_.IsEnabled = false;
            update_btn_.IsEnabled = false;
            delete_btn_.IsEnabled = false;
        }

        private void lecture_data_grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //datagrid datagrid = sender as datagrid;
            //datarowview datarowview = datagrid.selecteditem as datarowview;


            //emp_id_txtbx.Text = dataRowView["EmployeeId"].ToString();
            //name_txtbx.Text = dataRowView["Name"].ToString();
            //faculty_txtbx.Text = dataRowView["Faculty"].ToString();
            //dept_txtbx.Text = dataRowView["Department"].ToString();
            //center_combobx.Text = dataRowView["Center"].ToString();
            //building_txtbx.Text = dataRowView["Building"].ToString();
            //level_txtbx.Text = dataRowView["Level"].ToString();
            //rank_txtbx.Text = dataRowView["Rank"].ToString();
            updateMode = true;          
            delete_btn_.IsEnabled = true;
            DataGrid dataGrid = (DataGrid)sender;
            LecturerEntity lecturer = dataGrid.SelectedItem as LecturerEntity;

            if (lecturer != null)
            {
                emp_id_txtbx.Text = lecturer.EmployeeId.ToString();
                name_txtbx.Text = lecturer.Name;
                faculty_combobx.Text = lecturer.Faculty;
                department_combobx.Text = lecturer.Department;
                center_combobx.Text = lecturer.Center;
                building_combobx.Text = lecturer.Building;
                level_combobx.Text = lecturer.Level.ToString();
                rank_txtbx.Text = lecturer.Rank.ToString();
                emp_id_txtbx.IsEnabled = false;     
            }
        }

        private void clear_all_btn__Click(object sender, RoutedEventArgs e)
        {
            ClearAll();
        }

        private LecturerEntity CreateLecturerEntity()
        {
            int EmployeeId = int.Parse(emp_id_txtbx.Text);
            string Name = name_txtbx.Text;
            string Faculty = faculty_combobx.Text;        
            string Department = department_combobx.Text;
            string Center = center_combobx.Text;
            string Building = building_combobx.Text;
            int Level = int.Parse(level_combobx.Text);
            double Rank = double.Parse(rank_txtbx.Text);

            lecturer = new LecturerEntity(EmployeeId, Name, Faculty, Department, Center, Building, Level, Rank);
            return lecturer;
        }

        private void CheckValidations()
        {
            // Regex rankRegex = new Regex(@"^[0-9]*\.[0-9]{6}$");
            
                if (
                    updateMode &&
                    emp_id_txtbx.Text != "Eg: 000150" &&
                    empIdRegex.IsMatch(emp_id_txtbx.Text) &&
                    !String.IsNullOrEmpty(emp_id_txtbx.Text) &&
                    !String.IsNullOrEmpty(name_txtbx.Text) &&
                    !String.IsNullOrEmpty(faculty_combobx.Text) &&
                    !String.IsNullOrEmpty(department_combobx.Text) &&
                    !String.IsNullOrEmpty(center_combobx.Text) &&
                    !String.IsNullOrEmpty(building_combobx.Text) &&
                    !String.IsNullOrEmpty(level) &&
                    !String.IsNullOrEmpty(rank_txtbx.Text)
                )
                {
                    update_btn_.IsEnabled = true;
                }
                else
                {
                    update_btn_.IsEnabled = false;
                }
            
                if (
                    !updateMode &&
                    emp_id_txtbx.Text != "Eg: 000150" &&
                    empIdRegex.IsMatch(emp_id_txtbx.Text) &&
                    !lecturerIds.Contains(int.Parse(emp_id_txtbx.Text)) &&
                    !String.IsNullOrEmpty(emp_id_txtbx.Text) &&
                    !String.IsNullOrEmpty(name_txtbx.Text) &&
                    !String.IsNullOrEmpty(faculty_combobx.Text) &&
                    !String.IsNullOrEmpty(department_combobx.Text) &&
                    !String.IsNullOrEmpty(center_combobx.Text) &&
                    !String.IsNullOrEmpty(building_combobx.Text) &&
                    !String.IsNullOrEmpty(level) &&
                    !String.IsNullOrEmpty(rank_txtbx.Text)
                )
                {
                    add_btn_.IsEnabled = true;
                }
                else 
                { 
                    add_btn_.IsEnabled = false;
                }
            
        }

        private void emp_id_txtbx_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckValidations();

            if (empIdRegex.IsMatch(emp_id_txtbx.Text) && level_combobx.Text != "" && emp_id_txtbx.Text != "Eg: 000150" && !lecturerIds.Contains(int.Parse(emp_id_txtbx.Text)))
            {
                rank_txtbx.Text = level_combobx.Text + "." + emp_id_txtbx.Text;
            }
        }

        private void name_txtbx_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckValidations();
        }

        private void faculty_combobx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CheckValidations();
        }

        private void department_combobx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CheckValidations();
        }

        private void center_combobx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CheckValidations();
        }

        private void building_combobx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CheckValidations();
        }

        private void level_combobx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CheckValidations();
            ComboBoxItem item = level_combobx.SelectedItem as ComboBoxItem;
            if(item != null)
            {
                level = item.Content.ToString();
                if (empIdRegex.IsMatch(emp_id_txtbx.Text) && emp_id_txtbx.Text != "Eg: 000150" && !lecturerIds.Contains(int.Parse(emp_id_txtbx.Text)) && !updateMode)
                {
                    rank_txtbx.Text = level + "." + emp_id_txtbx.Text;
                }
                if (empIdRegex.IsMatch(emp_id_txtbx.Text) && emp_id_txtbx.Text != "Eg: 000150" && updateMode)
                {
                    rank_txtbx.Text = level + "." + emp_id_txtbx.Text;
                }
            }
        }

        private void rank_txtbx_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckValidations();
        }

        private void emp_id_txtbx_GotFocus(object sender, RoutedEventArgs e)
        {
            if(emp_id_txtbx.Text == "Eg: 000150") emp_id_txtbx.Text = "";
        }
    }
}
