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

namespace Time_Table_Generator.View
{
    /// <summary>
    /// Interaction logic for SessionView.xaml
    /// </summary>
    public partial class SessionView : Page
    {
        SessionEntity session;
        List<LecturerEntity> lecturers;
        LecturerViewModel _lecturerViewModel;
        SubjectViewModel _subjectViewModel;
        List<LecturerEntity> selectedLecturers = new List<LecturerEntity>();
        List<string> selectedLecturerNames = new List<string>();

        public SessionView()
        {
            InitializeComponent();
        }

        private void Session_Page_Loaded(object sender, RoutedEventArgs e)
        {
            _lecturerViewModel = new LecturerViewModel();
            _subjectViewModel = new SubjectViewModel();
            lecturers = _lecturerViewModel.LoadLecturerData();
            lecturer_combobx.ItemsSource = lecturers;
            subject_combobx.ItemsSource = _subjectViewModel.LoadSubjectData();
            code_combobx.ItemsSource = _subjectViewModel.LoadSubjectData();
        }

        private void create_btn__Click(object sender, RoutedEventArgs e)
        {
            session = CreateSessionEntity();
        }

        private SessionEntity CreateSessionEntity()
        {
            //int EmployeeId = int.Parse(emp_id_txtbx.Text);
            //string Name = name_txtbx.Text;
            //string Faculty = faculty_combobx.Text;
            //string Department = department_combobx.Text;
            //string Center = center_combobx.Text;
            //string Building = building_combobx.Text;
            //int Level = int.Parse(level_combobx.Text);
            //double Rank = double.Parse(rank_txtbx.Text);

            session = new SessionEntity();
            return session;
        }

        private void addlec_btn__Click(object sender, RoutedEventArgs e)
        {
            string lecturerName = lecturer_combobx.Text;
            foreach (LecturerEntity l in lecturers)
            {
                if (l.Name == lecturerName)
                {
                    selectedLecturers.Add(l);
                    selectedLecturerNames.Add(l.Name);
                    lec_listbx.ItemsSource = selectedLecturerNames.ToList();
                }
            }
        }

        private void lecturer_combobx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
