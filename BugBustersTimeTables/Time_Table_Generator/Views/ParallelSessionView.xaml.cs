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
    /// Interaction logic for ParallelSessionView.xaml
    /// </summary>
    public partial class ParallelSessionView : Page
    {
        ParallelSessionViewModel _parallelSessionViewModel;
        ParallelSessionEntity parallelSession;

        bool updateMode = false;
        List<ParallelSessionEntity> parallelSessions;
        List<int> parallelSessionIds = new List<int>();

        public ParallelSessionView()
        {
            InitializeComponent();
        }

        private void ParallelSession_Page_Loaded(object sender, RoutedEventArgs e)
        {
            _parallelSessionViewModel = new ParallelSessionViewModel();

            parallelSessions = _parallelSessionViewModel.LoadParallelSessionData();
            parallelSession_data_grid.ItemsSource = parallelSessions;

            foreach (ParallelSessionEntity l in parallelSessions)
            {
                parallelSessionIds.Add(l.ParallelSessionId);
            }

            add_btn_.IsEnabled = false;
            update_btn_.IsEnabled = false;
            delete_btn_.IsEnabled = false;
        }

        private void add_btn__Click(object sender, RoutedEventArgs e)
        {
            try
            {
                parallelSession = CreateParallelSessionEntity();
                parallelSessionIds.Add(parallelSession.ParallelSessionId);
                _parallelSessionViewModel.SaveParallelSessionData(parallelSession);
                parallelSession_data_grid.ItemsSource = _parallelSessionViewModel.LoadParallelSessionData();
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
                parallelSession = CreateParallelSessionEntity();
                _parallelSessionViewModel.UpdateParallelSessionData(parallelSession);
                parallelSession_data_grid.ItemsSource = _parallelSessionViewModel.LoadParallelSessionData();
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
                    int ParallelSessionId = parallelSession.ParallelSessionId;
                    _parallelSessionViewModel.DeleteParallelSessionData(ParallelSessionId);
                    parallelSession_data_grid.ItemsSource = _parallelSessionViewModel.LoadParallelSessionData();
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
            lecturer_txtbx.Text = "";
            groupId_txtbx.Text = "";
            subGroupId_txtbx.Text = "";
            session_txtbx.Text = "";
            updateMode = false;
            add_btn_.IsEnabled = false;
            update_btn_.IsEnabled = false;
            delete_btn_.IsEnabled = false;
        }

        private void parallelSession_data_grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            updateMode = true;
            delete_btn_.IsEnabled = true;
            DataGrid dataGrid = (DataGrid)sender;
            parallelSession = dataGrid.SelectedItem as ParallelSessionEntity;

            if (parallelSession != null)
            {
                lecturer_txtbx.Text = parallelSession.Lecturer;
                groupId_txtbx.Text = parallelSession.GroupId;
                subGroupId_txtbx.Text = parallelSession.SubGroupId;
                session_txtbx.Text = parallelSession.Session;
            }
        }

        private void clear_all_btn__Click(object sender, RoutedEventArgs e)
        {
            ClearAll();
        }

        private ParallelSessionEntity CreateParallelSessionEntity()
        {
            int ParallelSessionId;
            if (updateMode)
            {
                ParallelSessionId = parallelSession.ParallelSessionId;
            }
            else
            {
                ParallelSessionId = parallelSessions.Last().ParallelSessionId + 1;
            }
            string Lecturer = lecturer_txtbx.Text;
            string GroupId = groupId_txtbx.Text;
            string SubGroupId = subGroupId_txtbx.Text;
            string Session = session_txtbx.Text;


            parallelSession = new ParallelSessionEntity(ParallelSessionId, Lecturer, GroupId, SubGroupId, Session);
            return parallelSession;
        }

        private void CheckValidations()
        {

            if (
                updateMode &&
                !String.IsNullOrEmpty(lecturer_txtbx.Text) &&
                !String.IsNullOrEmpty(groupId_txtbx.Text) &&
                !String.IsNullOrEmpty(subGroupId_txtbx.Text) &&
                !String.IsNullOrEmpty(session_txtbx.Text)
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
                !String.IsNullOrEmpty(lecturer_txtbx.Text) &&
                !String.IsNullOrEmpty(groupId_txtbx.Text) &&
                !String.IsNullOrEmpty(subGroupId_txtbx.Text) &&
                !String.IsNullOrEmpty(session_txtbx.Text
                    )
                )
            {
                add_btn_.IsEnabled = true;
            }
            else
            {
                add_btn_.IsEnabled = false;
            }

        }

        private void lecturer_txtbx_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckValidations();
        }

        private void groupId_txtbx_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckValidations();
        }

        private void subGroupId_txtbx_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckValidations();
        }

        private void session_txtbx_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckValidations();
        }
    }
}
