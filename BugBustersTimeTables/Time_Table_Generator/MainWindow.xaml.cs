using BBTG.Entities.Data;
using System;
using System.Collections.Generic;
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
using Time_Table_Generator.ViewModel;

namespace Time_Table_Generator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        LecturerViewModel _viewModel;
        LecturerEntity lecturerEntity;
        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new LecturerViewModel();
            var x = _viewModel.LoadData();

            //_viewModel.SaveData();
            //lecturerEntity = new LecturerEntity(4, "A", "S", "J", "H", "J", 3, 2);
            //_viewModel.SaveData(lecturerEntity);

        }

        private void add_btn_Click(object sender, RoutedEventArgs e)
        {
            int EmployeeId = int.Parse(emp_id_txtbx.Text);
            string Name = name_txtbx.Text;
            string Faculty = faculty_txtbx.Text;
            int Level = int.Parse(level_txtbx.Text);
            string Department = dept_txtbx.Text;
            string Center = center_txtbx.Text;
            string Building = building_txtbx.Text;
            double Rank = double.Parse(rank_txtbx.Text);

            
            lecturerEntity = new LecturerEntity(EmployeeId, Name, Faculty, Department, Center, Building, Level, Rank);
            _viewModel.SaveData(lecturerEntity);
        }
    }
}
