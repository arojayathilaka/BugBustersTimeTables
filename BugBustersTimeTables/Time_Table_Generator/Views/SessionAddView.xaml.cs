using BBTG.Entities;
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
        LecturerViewModel _lecturerViewModel;
        SubjectViewModel _subjectViewModel;
        TagViewModel _tagViewModel;
        SessionViewModel _sessionViewModel;
        string[] selectedLecturersIds = new string[5];
        int idCount = 0;
        List<string> selectedLecturerNames = new List<string>();
        List<SessionEntity> sessions;
        List<Session> sessionList;

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
            lecturers = _lecturerViewModel.LoadLecturerData();
            lecturer_combobx.ItemsSource = lecturers;
            subject_combobx.ItemsSource = _subjectViewModel.LoadSubjectData();
            code_combobx.ItemsSource = _subjectViewModel.LoadSubjectData();
            tag_combobx.ItemsSource = _tagViewModel.LoadTagData();
            sessions = _sessionViewModel.LoadSessionData();
            //session_data_grid.ItemsSource = sessions;
            sessionList = new List<Session>();
            foreach(SessionEntity s in sessions)
            {
                string[] slctdLecturersNames = new string[s.LecturerIdsArr.Length];
                for (int i = 0; i < s.LecturerIdsArr.Length; i++)
                {
                    slctdLecturersNames[i] = lecturers.Find(l => l.EmployeeId == s.LecturerIdsArr[i]).Name;
                }

                sessionList.Add(new Session
                {
                    Lecturers = string.Join(",", slctdLecturersNames),
                    SubjectName = s.SubjectName,
                    SubjectCode = s.SubjectCode,
                    Tag = s.Tag,
                    GroupId = s.GroupId,
                    Count = s.Count,
                    Duration = s.Duration
                });
            }
            session_data_grid.ItemsSource = sessionList;
        }

        private void create_btn__Click(object sender, RoutedEventArgs e)
        {
            session = CreateSessionEntity();
            _sessionViewModel.SaveSessionData(session);
        }

        private SessionEntity CreateSessionEntity()
        {
            int SessionId;
            //if (updateMode)
            //    SubjectId = subject.SubjectId;
            //else
            if (sessions.Count == 0) 
                SessionId = 1;
            else 
                SessionId = sessions.Last().SessionId + 1; 
            
            session = new SessionEntity {

                SessionId = SessionId,
                LecturerIds = string.Join(",", selectedLecturersIds),
                SubjectName = subject_combobx.Text,
                SubjectCode = code_combobx.Text,
                Tag = tag_combobx.Text,
                GroupId = grp_combobx.Text,
                Count = int.Parse(count_txtbx.Text),
                Duration = int.Parse(duration_combobx.Text)

            };
            return session;
        }

        private void addlec_btn__Click(object sender, RoutedEventArgs e)
        {
            string lecturerName = lecturer_combobx.Text;
            foreach (LecturerEntity l in lecturers)
            {
                if (l.Name == lecturerName)
                {
                    try
                    {
                        selectedLecturersIds[idCount] = l.EmployeeId.ToString();
                        idCount++;
                        selectedLecturerNames.Add(l.Name);
                        lec_listbx.ItemsSource = selectedLecturerNames.ToList();
                    }
                    catch (IndexOutOfRangeException)
                    {
                        MessageBox.Show("You can add only upto 5 lectureres", "BBTG", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        private void lecturer_combobx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void view_sessions_btn_Click(object sender, RoutedEventArgs e)
        {
            SessionsView sessionsView = new SessionsView();
            this.NavigationService.Navigate(sessionsView);
        }

        private void session_data_grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
