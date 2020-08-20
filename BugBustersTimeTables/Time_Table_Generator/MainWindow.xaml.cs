using BBTG.Entities.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
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

namespace Time_Table_Generator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        public MainWindow()
        {
            InitializeComponent();

            this.WindowState = WindowState.Maximized;

           
            //lecturerEntity = new LecturerEntity(4, "A", "S", "J", "H", "J", 3, 2);
            //_viewModel.SaveData(lecturerEntity);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new LecturerView();
        }

        private void Button_Click_room(object sender, RoutedEventArgs e)
        {
            Main.Content = new RoomView();
        }

        private void Button_Click_building(object sender, RoutedEventArgs e)
        {
            Main.Content = new BuildingView();
        }

        //private void add_btn_Click(object sender, RoutedEventArgs e)
        //{
        //    //int EmployeeId = int.Parse(emp_id_txtbx.Text);
        //    //string Name = name_txtbx.Text;
        //    //string Faculty = faculty_txtbx.Text;
        //    //int Level = int.Parse(level_txtbx.Text);
        //    //string Department = dept_txtbx.Text;
        //    //string Center = center_txtbx.Text;
        //    //string Building = building_txtbx.Text;
        //    //double Rank = double.Parse(rank_txtbx.Text);


        //    //lecturerEntity = new LecturerEntity(EmployeeId, Name, Faculty, Department, Center, Building, Level, Rank);
        //    //_viewModel.SaveData(lecturerEntity);
        //    //lecture_data_grid.ItemsSource = _viewModel.LoadData();
        //}

        //private void lecture_data_grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    //datagrid datagrid = sender as datagrid;
        //    //datarowview datarowview = datagrid.selecteditem as datarowview;


        //    //emp_id_txtbx.Text = dataRowView["EmployeeId"].ToString();
        //    //name_txtbx.Text = dataRowView["Name"].ToString();
        //    //faculty_txtbx.Text = dataRowView["Faculty"].ToString();
        //    //dept_txtbx.Text = dataRowView["Department"].ToString();
        //    //center_txtbx.Text = dataRowView["Center"].ToString();
        //    //building_txtbx.Text = dataRowView["Building"].ToString();
        //    //level_txtbx.Text = dataRowView["Level"].ToString();
        //    //rank_txtbx.Text = dataRowView["Rank"].ToString();

        //    //DataGrid dataGrid = (DataGrid)sender;
        //    //LecturerEntity lecturer = dataGrid.SelectedItem as LecturerEntity;

        //    //if (lecturer != null)
        //    //{
        //    //    emp_id_txtbx.Text = lecturer.EmployeeId.ToString();
        //    //    name_txtbx.Text = lecturer.Name;
        //    //    faculty_txtbx.Text = lecturer.Faculty;
        //    //    dept_txtbx.Text = lecturer.Department;
        //    //    center_txtbx.Text = lecturer.Center;
        //    //    building_txtbx.Text = lecturer.Building;
        //    //    level_txtbx.Text = lecturer.Level.ToString();
        //    //    rank_txtbx.Text = lecturer.Rank.ToString();
        //    //}
        //}
    }
}
