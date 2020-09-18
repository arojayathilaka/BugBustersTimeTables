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
    /// Interaction logic for StudentView.xaml
    /// </summary>
    public partial class StudentView : Page
    {
        Student_SubGroupViewModel _studentViewModel;
        Student_SubGroupEntity student;

        bool updateMode = false;
        List<Student_SubGroupEntity> students;
        List<int> studentIds = new List<int>();

        public StudentView()
        {
            InitializeComponent();
        }

        private void Student_Page_Loaded(object sender, RoutedEventArgs e)
        {
            _studentViewModel = new Student_SubGroupViewModel();

            students = _studentViewModel.LoadStudentData();
            student_data_grid.ItemsSource = students;

            foreach (Student_SubGroupEntity l in students)
            {
                studentIds.Add(l.StudentId);
            }

            add_btn_.IsEnabled = false;
            update_btn_.IsEnabled = false;
            delete_btn_.IsEnabled = false;
        }

        private void add_btn__Click(object sender, RoutedEventArgs e)
        {
            try
            {
                student = CreateStudentEntity();
                studentIds.Add(student.StudentId);
                _studentViewModel.SaveStudentData(student);
                student_data_grid.ItemsSource = _studentViewModel.LoadStudentData();
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
                student = CreateStudentEntity();
                _studentViewModel.UpdateStudentData(student);
                student_data_grid.ItemsSource = _studentViewModel.LoadStudentData();
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

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    int StudentId = student.StudentId;
                    _studentViewModel.DeleteStudentData(StudentId);
                    student_data_grid.ItemsSource = _studentViewModel.LoadStudentData();
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
            academicYrSem_combobx.Text = "";
            programme_combobx.Text = "";
            groupNumber_combobx.Text = "";
            groupId_txtbx.Text = "";
            subGroupNumber_combobx.Text = "";
            subGroupId_txtbx.Text = "";
            updateMode = false;
            add_btn_.IsEnabled = false;
            update_btn_.IsEnabled = false;
            delete_btn_.IsEnabled = false;
        }

        private void student_data_grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            updateMode = true;
            delete_btn_.IsEnabled = true;
            DataGrid dataGrid = (DataGrid)sender;
            student = dataGrid.SelectedItem as Student_SubGroupEntity;

            if (student != null)
            {
                academicYrSem_combobx.Text = student.AcademicYrSem;
                programme_combobx.Text = student.Programme;
                groupNumber_combobx.Text = student.GroupNumber.ToString();
                groupId_txtbx.Text = student.GroupId;
                subGroupNumber_combobx.Text = student.SubGroupNumber.ToString();
                subGroupId_txtbx.Text = student.SubGroupId;
            }
        }

        private void clear_all_btn__Click(object sender, RoutedEventArgs e)
        {
            ClearAll();
        }

        private Student_SubGroupEntity CreateStudentEntity()
        {
            int StudentId;
            if (updateMode)
            {
                StudentId = student.StudentId;
            }
            else
            {
                StudentId = students.Last().StudentId + 1;
            }
            string AcademicYrSem = academicYrSem_combobx.Text;
            string Programme = programme_combobx.Text;
            int GroupNumber = int.Parse(groupNumber_combobx.Text);
            string GroupId = groupId_txtbx.Text;
            int SubGroupNumber = int.Parse(subGroupNumber_combobx.Text);
            string SubGroupId = subGroupId_txtbx.Text;


            student = new Student_SubGroupEntity(StudentId, AcademicYrSem, Programme, GroupNumber, GroupId, SubGroupNumber, SubGroupId);
            return student;
        }

        private void CheckValidations()
        {
           
            if (
                updateMode &&
                !String.IsNullOrEmpty(academicYrSem_combobx.Text) &&
                !String.IsNullOrEmpty(programme_combobx.Text) &&
                !String.IsNullOrEmpty(groupNumber_combobx.Text) &&
                !String.IsNullOrEmpty(groupId_txtbx.Text) &&
                !String.IsNullOrEmpty(subGroupNumber_combobx.Text) &&
                !String.IsNullOrEmpty(subGroupId_txtbx.Text)
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
                !String.IsNullOrEmpty(academicYrSem_combobx.Text) &&
                !String.IsNullOrEmpty(programme_combobx.Text) &&
                !String.IsNullOrEmpty(groupNumber_combobx.Text) &&
                !String.IsNullOrEmpty(groupId_txtbx.Text) &&
                !String.IsNullOrEmpty(subGroupNumber_combobx.Text) &&
                !String.IsNullOrEmpty(subGroupId_txtbx.Text)
            )
            {
                add_btn_.IsEnabled = true;
            }
            else
            {
                add_btn_.IsEnabled = false;
            }

        }

        private void std_id_txtbx_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckValidations();
        }

        private void academicYrSem_combobx_TextChanged(object sender, SelectionChangedEventArgs e)
        {
            CheckValidations();
        }

        private void programme_combobx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CheckValidations();
        }

        private void groupNumber_combobx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CheckValidations();
            

            ComboBoxItem item = groupNumber_combobx.SelectedItem as ComboBoxItem;
            if (item != null)
            {
                string grpNumber = item.Content.ToString();
                
                    groupId_txtbx.Text = academicYrSem_combobx.Text + "." + programme_combobx.Text + "." + grpNumber;
                

            }
        }

        private void groupId_txtbx_SelectionChanged(object sender, TextChangedEventArgs e)
        {
            CheckValidations();
        }

        private void subGroupNumber_combobx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CheckValidations();
            
            ComboBoxItem item = subGroupNumber_combobx.SelectedItem as ComboBoxItem;
            if (item != null)
            {
                string subGrpNumber = item.Content.ToString();

                subGroupId_txtbx.Text = groupId_txtbx.Text + "." + subGrpNumber;


            }
        }

        private void subGroupId_txtbx_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckValidations();
        }

        private void group_btn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
