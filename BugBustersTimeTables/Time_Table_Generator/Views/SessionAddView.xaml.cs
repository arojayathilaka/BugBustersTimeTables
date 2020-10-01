using BBTG.Entities;
using BBTG.Entities.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
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
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Time_Table_Generator.ViewModel;
using Time_Table_Generator.Views;

namespace Time_Table_Generator.View
{
    /// <summary>
    /// Interaction logic for SessionView.xaml
    /// </summary>
    public partial class SessionAddView : Page
    {
        SessionEntity session;
        List<LecturerEntity> lecturers;
        //List<TagEntity> tags;
        LecturerViewModel _lecturerViewModel;
        SubjectViewModel _subjectViewModel;
        TagViewModel _tagViewModel;
        SessionViewModel _sessionViewModel;
        Student_GroupViewModel _Student_GroupViewModel;
        Student_SubGroupViewModel _Student_SubGroupViewModel;
        string[] slctdLecIds;
        List<string> slctdLecNames = new List<string>();
        List<SessionEntity> sessions;
        bool isGrpIdSet = false;
        bool isSerachBySet = false;
        string code_combobx_val, tag_combobx_val, grp_combobx_val, duration_combobx_val, search_lec_val;
        string tagName;
        bool isLecFilter = false;
        bool isSubFilter = false;
        bool isFilterAdded = false;

        public SessionAddView()
        {
            InitializeComponent();
        }

        private void Session_Page_Loaded(object sender, RoutedEventArgs e)
        {
            _lecturerViewModel = new LecturerViewModel();
            _subjectViewModel = new SubjectViewModel();
            _tagViewModel = new TagViewModel();
            _sessionViewModel = new SessionViewModel();
            _Student_GroupViewModel = new Student_GroupViewModel();
            _Student_SubGroupViewModel = new Student_SubGroupViewModel();
            lecturers = _lecturerViewModel.LoadLecturerData();
            lecturer_combobx.ItemsSource = lecturers;
            code_combobx.ItemsSource = _subjectViewModel.LoadSubjectData();
            tag_combobx.ItemsSource = _tagViewModel.LoadTagData(); 
            sessions = _sessionViewModel.LoadSessionData();
            //grp_combobx.ItemsSource = _Student_GroupViewModel.LoadStudentData();
            //session_data_grid.ItemsSource = sessions;
            SetDataGrid();
            create_btn_.IsEnabled = false;
        }

        private void SetDataGrid()
        {
            session_data_grid.ItemsSource = _sessionViewModel.GetSessionList(sessions);
        }

        private void create_btn__Click(object sender, RoutedEventArgs e)
        {
            session = CreateSessionEntity();
            _sessionViewModel.SaveSessionData(session);
            sessions = _sessionViewModel.LoadSessionData();
            SetDataGrid();
            ClearAll();
            count_req_tb.Visibility = Visibility.Hidden;
        }

        private SessionEntity CreateSessionEntity()
        {
            try
            {
                int SessionId;
                if (sessions.Count == 0)
                    SessionId = 1;
                else
                    SessionId = sessions.Last().SessionId + 1;

                session = new SessionEntity
                {

                    SessionId = SessionId,
                    LecturerIds = string.Join(",", slctdLecIds),
                    SubjectName = subject_txtbx.Text,
                    SubjectCode = code_combobx.Text,
                    Tag = tag_combobx.Text,
                    GroupId = grp_combobx.Text,
                    Count = int.Parse(count_txtbx.Text),
                    Duration = int.Parse(duration_combobx.Text)

                };
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
            return session;
        }

        private void addlec_btn__Click(object sender, RoutedEventArgs e)
        {
            int size = 1;
            if (slctdLecIds != null) 
                size = slctdLecIds.Length + 1;

            string[] newSlctdLecIds = new string[size];

            if(slctdLecIds != null)
            {
                for (int i = 0; i < slctdLecIds.Length; i++)
                {
                    newSlctdLecIds[i] = slctdLecIds[i];
                }
            }

            string lecturerName = lecturer_combobx.Text;
            foreach (LecturerEntity l in lecturers)
            {
                if (l.Name == lecturerName)
                {
                    try
                    {
                        newSlctdLecIds[newSlctdLecIds.Length-1] = l.EmployeeId.ToString();
                        slctdLecIds = newSlctdLecIds;
                        slctdLecNames.Add(l.Name);
                        lec_listbx.ItemsSource = slctdLecNames.ToList();
                    }
                    catch (IndexOutOfRangeException ex)
                    {
                        //MessageBox.Show("You can add only upto 5 lectureres", "BBTG", MessageBoxButton.OK, MessageBoxImage.Error);
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            CheckValidations();
        }

        private void tag_combobx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox tagComboBx = sender as ComboBox;
            if(tagComboBx.SelectedItem != null)
            {
                TagEntity selectedTag = tagComboBx.SelectedItem as TagEntity;
                tagName = selectedTag.TagName;
                if (tagName == "Lab")
                {
                    grp_combobx.DisplayMemberPath = "SubGroupId";
                    grp_combobx.ItemsSource = _Student_SubGroupViewModel.LoadStudentData();
                }
                else
                {
                    grp_combobx.DisplayMemberPath = "GroupId";
                    grp_combobx.ItemsSource = _Student_GroupViewModel.LoadStudentData();
                }
                tag_combobx_val = tagName;
                CheckValidations();
                isGrpIdSet = true;
            }
        }

        private void grp_combobx_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!isGrpIdSet)
                MessageBox.Show("Please select tag first.", "BBTG", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void add_filter_btn_Click(object sender, RoutedEventArgs e)
        {
            isFilterAdded = true;
            if (searchby_combobx.Text == "Lecturer")
            {
                isLecFilter = true;
                search_lec_val = search_combobx.Text;
            }
            else if (searchby_combobx.Text == "Subject")
            {
                isSubFilter = true;
            }
            MessageBox.Show("Filter Added", "BBTG", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void search_btn_Click(object sender, RoutedEventArgs e)
        {
            if (isFilterAdded)
            {
                int lecturerId;
                if (isLecFilter && isSubFilter)
                {
                    lecturerId = lecturers.Find(l => l.Name == search_lec_val).EmployeeId;
                    sessions = _sessionViewModel.LoadSessionDataByLecturer(lecturerId);
                    List<SessionEntity> lecSubFilteredList = new List<SessionEntity>();
                    lecSubFilteredList = sessions.FindAll(s => s.SubjectCode == search_combobx.Text);
                    sessions = lecSubFilteredList;
                    isLecFilter = false;
                    isSubFilter = false;
                }
                else if (searchby_combobx.Text == "Subject")
                {
                    sessions = _sessionViewModel.LoadSessionDataBySubject(search_combobx.Text);
                }
                else if (searchby_combobx.Text == "Group")
                {
                    sessions = _sessionViewModel.LoadSessionDataByGroup(search_combobx.Text);
                }
                else if (searchby_combobx.Text == "Sub Group")
                {
                    sessions = _sessionViewModel.LoadSessionDataBySubGroup(search_combobx.Text);
                }
                else if (searchby_combobx.Text == "Tag")
                {
                    sessions = _sessionViewModel.LoadSessionDataByTag(search_combobx.Text);
                }
                else if (searchby_combobx.Text == "Lecturer")
                {
                    lecturerId = lecturers.Find(l => l.Name == search_combobx.Text).EmployeeId;
                    sessions = _sessionViewModel.LoadSessionDataByLecturer(lecturerId);
                }
                SetDataGrid();
                isFilterAdded = false;
            }
            else
            {
                MessageBox.Show("Add filter first.", "BBTG", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            
        }

        private void searchby_combobx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            isSerachBySet = true;
            ComboBox searchByComboBx = sender as ComboBox;
            ComboBoxItem searchByComboBxItem = searchByComboBx.SelectedItem as ComboBoxItem;
            string searchByVal = searchByComboBxItem.Content.ToString();

            if (searchByVal == "Subject")
            {
                search_combobx.DisplayMemberPath = "SubjectCode";
                search_combobx.ItemsSource = _subjectViewModel.LoadSubjectData();
            }
            else if(searchByVal == "Group")
            {
                search_combobx.DisplayMemberPath = "GroupId";
                search_combobx.ItemsSource = _Student_GroupViewModel.LoadStudentData();
            } 
            else if (searchByVal == "Sub Group")
            {
                search_combobx.DisplayMemberPath = "SubGroupId";
                search_combobx.ItemsSource = _Student_SubGroupViewModel.LoadStudentData();
            } 
            else if (searchByVal == "Tag")
            {
                search_combobx.DisplayMemberPath = "TagName";
                search_combobx.ItemsSource = _tagViewModel.LoadTagData();
            }
            else
            {
                search_combobx.DisplayMemberPath = "Name";
                search_combobx.ItemsSource = _lecturerViewModel.LoadLecturerData();
            }
        }

        private void search_combobx_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!isSerachBySet) 
                MessageBox.Show("Please select filter first.", "BBTG", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void load_all_btn_Click(object sender, RoutedEventArgs e)
        {
            sessions = _sessionViewModel.LoadSessionData();
            SetDataGrid();
        }

        private void CheckValidations()
        {
            Regex regex = new Regex(@"^\d+$"); 
            if (
                lec_listbx.Items.Count != 0 &&
                !String.IsNullOrEmpty(code_combobx_val) &&
                !String.IsNullOrEmpty(tag_combobx_val) &&
                !String.IsNullOrEmpty(grp_combobx_val) &&
                !String.IsNullOrEmpty(count_txtbx.Text) &&
                !String.IsNullOrEmpty(duration_combobx_val) &&
                regex.IsMatch(count_txtbx.Text)
                )
            {
                create_btn_.IsEnabled = true;
            }
            else
                create_btn_.IsEnabled = false;


            if (lec_listbx.Items.Count == 0) lec_tb.Visibility = Visibility.Visible;
            else lec_tb.Visibility = Visibility.Hidden;

            if (String.IsNullOrEmpty(code_combobx_val)) code_tb.Visibility = Visibility.Visible;
            else code_tb.Visibility = Visibility.Hidden;

            if (String.IsNullOrEmpty(tag_combobx_val)) tag_tb.Visibility = Visibility.Visible;
            else tag_tb.Visibility = Visibility.Hidden; 
                        
            if (String.IsNullOrEmpty(grp_combobx_val)) grp_tb.Visibility = Visibility.Visible;
            else grp_tb.Visibility = Visibility.Hidden; 

            if (String.IsNullOrEmpty(count_txtbx.Text)) count_req_tb.Visibility = Visibility.Visible;
            else count_req_tb.Visibility = Visibility.Hidden;

            if (!regex.IsMatch(count_txtbx.Text) && !String.IsNullOrEmpty(count_txtbx.Text)) count_no_tb.Visibility = Visibility.Visible;
            else count_no_tb.Visibility = Visibility.Hidden;

            if (String.IsNullOrEmpty(duration_combobx_val)) duration_tb.Visibility = Visibility.Visible;
            else duration_tb.Visibility = Visibility.Hidden;
        }

        private void ClearAll()
        {
            code_combobx.Text = "";
            tag_combobx.Text = "";
            grp_combobx.Text = "";
            duration_combobx.Text = "";
            count_txtbx.Text = "";
            lecturer_combobx.Text = "";
            lec_listbx.ItemsSource = null;

            code_combobx_val = "";
            tag_combobx_val = "";
            grp_combobx_val = "";
            duration_combobx_val = "";

            isGrpIdSet = false;
        }

        private void code_combobx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox subComboBx = sender as ComboBox;
            if(subComboBx.SelectedItem != null)
            {
                SubjectEntity selectedSub = subComboBx.SelectedItem as SubjectEntity;
                subject_txtbx.Text = selectedSub.SubjectName;
                code_combobx_val = selectedSub.SubjectCode;
                CheckValidations();
            }
        }

        private void grp_combobx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox grpComboBx = sender as ComboBox;
            if(grpComboBx.SelectedItem != null)
            {
                if (tagName == "Lab")
                {
                    Student_SubGroupEntity selectedGrp = grpComboBx.SelectedItem as Student_SubGroupEntity;
                    grp_combobx_val = selectedGrp.SubGroupId;
                }
                else
                {
                    Student_GroupEntity selectedGrp = grpComboBx.SelectedItem as Student_GroupEntity;
                    grp_combobx_val = selectedGrp.GroupId;
                }
                CheckValidations();
            }
        }

        private void count_txtbx_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckValidations();
        }

        private void duration_combobx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox durationComboBx = sender as ComboBox;
            if(durationComboBx.SelectedItem != null)
            {
                ComboBoxItem selectedSub = durationComboBx.SelectedItem as ComboBoxItem;
                duration_combobx_val = selectedSub.Content.ToString();
                CheckValidations();
            }
        }
    }
}
