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
    /// Interaction logic for SubjectView.xaml
    /// </summary>
    public partial class SubjectView : Page
    {
        SubjectViewModel _subjectViewModel;
        SubjectEntity subject;
        //int subjectId;
        bool updateMode = false;
        bool updateModeSelected = false;
        List<SubjectEntity> subjects;
        List<string> subjectNames = new List<string>();
        List<string> subjectCodes = new List<string>();
        string lec_combobx_val, tute_combobx_val, lab_combobx_val, eval_combobx_val, year_combobx_val, sem_combobx_val;
        //Regex empIdRegex = new Regex(@"\b\d{6}\b");

        public SubjectView()
        {
            InitializeComponent();
        }

        private void Subject_Page_Loaded(object sender, RoutedEventArgs e)
        {
            _subjectViewModel = new SubjectViewModel();

            subjects = _subjectViewModel.LoadSubjectData();
            subject_data_grid.ItemsSource = subjects;

            foreach (SubjectEntity s in subjects)
            {
                subjectNames.Add(s.SubjectName);
                subjectCodes.Add(s.SubjectCode);
            }

            add_btn_.IsEnabled = false;
            update_btn_.IsEnabled = false;
            delete_btn_.IsEnabled = false;
            code_txtbx.Text = "Eg: IT1050";
        }

        private void add_btn__Click(object sender, RoutedEventArgs e)
        {
            try
            {
                subject = CreateSubjectEntity();
                subjectNames.Add(subject.SubjectName);
                subjectCodes.Add(subject.SubjectCode);
                _subjectViewModel.SaveSubjectData(subject);
                subjects = _subjectViewModel.LoadSubjectData();
                subject_data_grid.ItemsSource = subjects;
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
                subjectNames.Remove(subject.SubjectName);
                subjectCodes.Remove(subject.SubjectCode);
                subject = CreateSubjectEntity();
                subjectNames.Add(subject.SubjectName);
                subjectCodes.Add(subject.SubjectCode);
                _subjectViewModel.UpdateSubjectData(subject);
                subject_data_grid.ItemsSource = _subjectViewModel.LoadSubjectData();
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
                    subjectNames.Remove(subject.SubjectName);
                    subjectCodes.Remove(subject.SubjectCode);
                    int SubjectId = subject.SubjectId;
                    _subjectViewModel.DeleteSubjectData(SubjectId);
                    subjects = _subjectViewModel.LoadSubjectData();
                    subject_data_grid.ItemsSource = subjects;
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
            code_txtbx.Text = "Eg: IT1050";
            name_txtbx.Text = "";
            year_combobx.Text = "";
            sem_combobx.Text = "";
            lec_combobx.Text = "";
            tutorial_combobx.Text = "";
            lab_combobx.Text = "";
            eval_combobx.Text = "";
            lec_combobx_val = "";
            tute_combobx_val = "";
            lab_combobx_val = "";
            eval_combobx_val = "";
            year_combobx_val = "";
            sem_combobx_val = "";
            updateMode = false;
            add_btn_.IsEnabled = false;
            update_btn_.IsEnabled = false;
            delete_btn_.IsEnabled = false;
        }

        private void subject_data_grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            updateMode = true;
            delete_btn_.IsEnabled = true;

            DataGrid dataGrid = (DataGrid)sender;
            subject = dataGrid.SelectedItem as SubjectEntity;

            if (subject != null)
            {
                name_txtbx.Text = subject.SubjectName;
                code_txtbx.Text = subject.SubjectCode;
                year_combobx.Text = subject.Year.ToString();
                sem_combobx.Text = subject.Semester.ToString();
                lec_combobx.Text = subject.NoOfLecHrs.ToString();
                tutorial_combobx.Text = subject.NoOfTuteHrs.ToString();
                lab_combobx.Text = subject.NoOfLabHrs.ToString();
                eval_combobx.Text = subject.NoOfEvalHrs.ToString();

                lec_combobx_val = subject.NoOfLecHrs.ToString();
                tute_combobx_val = subject.NoOfTuteHrs.ToString();
                lab_combobx_val = subject.NoOfLabHrs.ToString();
                eval_combobx_val = subject.NoOfEvalHrs.ToString();
                year_combobx_val = subject.Year.ToString();
                sem_combobx_val = subject.Semester.ToString();
            }
        }

        private void clear_all_btn__Click(object sender, RoutedEventArgs e)
        {
            ClearAll();
        }

        private SubjectEntity CreateSubjectEntity()
        {
            int SubjectId;
            if (updateMode)
            {
                SubjectId = subject.SubjectId;
            }
            else
            {
                SubjectId = subjects.Last().SubjectId + 1;
            }

            string SubjectCode = code_txtbx.Text;
            string SubjectName = name_txtbx.Text;
            int Year = int.Parse(year_combobx.Text);
            int Semester = int.Parse(sem_combobx.Text);
            int NoOfLecHrs = int.Parse(lec_combobx.Text);
            int NoOfTuteHrs = int.Parse(tutorial_combobx.Text);
            int NoOfLabHrs = int.Parse(lab_combobx.Text);
            int NoOfEvalHrs = int.Parse(eval_combobx.Text);

            subject = new SubjectEntity(SubjectId, SubjectCode, SubjectName, Year, Semester, NoOfLecHrs, NoOfTuteHrs, NoOfLabHrs, NoOfEvalHrs);
            return subject;
        }

        private void CheckValidations()
        {
            //if (
            //    //code_txtbx.Text != "Eg: IT1050" &&
            //    //!subjectNames.Contains(name_txtbx.Text) &&
            //    //!subjectCodes.Contains(code_txtbx.Text) &&
            //    //!String.IsNullOrEmpty(year_combobx_val) &&
            //    //!String.IsNullOrEmpty(sem_combobx_val) &&
            //    //!String.IsNullOrEmpty(lec_combobx_val) &&
            //    //!String.IsNullOrEmpty(tute_combobx_val) &&
            //    //!String.IsNullOrEmpty(lab_combobx_val) &&
            //    //!String.IsNullOrEmpty(eval_combobx_val) &&
            //    //!String.IsNullOrEmpty(name_txtbx.Text) &&
            //    //!String.IsNullOrEmpty(code_txtbx.Text) 
            //    )
            //{
            //    if (updateMode) update_btn_.IsEnabled = true;
            //    else add_btn_.IsEnabled = true;
            //}
            //else
            //{
            //    if (updateMode) update_btn_.IsEnabled = false;
            //    else add_btn_.IsEnabled = false;
            //}


            if (
                updateMode &&
                code_txtbx.Text != "Eg: IT1050" &&
                !String.IsNullOrEmpty(year_combobx_val) &&
                !String.IsNullOrEmpty(sem_combobx_val) &&
                !String.IsNullOrEmpty(lec_combobx_val) &&
                !String.IsNullOrEmpty(tute_combobx_val) &&
                !String.IsNullOrEmpty(lab_combobx_val) &&
                !String.IsNullOrEmpty(eval_combobx_val) &&
                !String.IsNullOrEmpty(name_txtbx.Text) &&
                !String.IsNullOrEmpty(code_txtbx.Text)
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
                code_txtbx.Text != "Eg: IT1050" &&
                !subjectCodes.Contains(code_txtbx.Text) &&
                !String.IsNullOrEmpty(year_combobx_val) &&
                !String.IsNullOrEmpty(sem_combobx_val) &&
                !String.IsNullOrEmpty(lec_combobx_val) &&
                !String.IsNullOrEmpty(tute_combobx_val) &&
                !String.IsNullOrEmpty(lab_combobx_val) &&
                !String.IsNullOrEmpty(eval_combobx_val) &&
                !String.IsNullOrEmpty(name_txtbx.Text) &&
                !String.IsNullOrEmpty(code_txtbx.Text)
            )
            {
                add_btn_.IsEnabled = true;
            }
            else
            {
                add_btn_.IsEnabled = false;
            }
        }

        private void code_txtbx_GotFocus(object sender, RoutedEventArgs e)
        {
            if (code_txtbx.Text == "Eg: IT1050") code_txtbx.Text = "";

        }

        private void name_txtbx_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckValidations();
        }

        private void code_txtbx_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox codeTextBox = sender as TextBox;
            CheckValidations();
            if (updateMode)
            {
                updateModeSelected = true;
            }
            if (updateModeSelected && subjectCodes.Contains(codeTextBox.Text))
            {
                update_btn_.IsEnabled = false;
            }
        }

        private void year_combobx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem item = year_combobx.SelectedItem as ComboBoxItem;
            if (item != null) year_combobx_val = item.Content.ToString();
            CheckValidations();
        }

        private void sem_combobx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem item = sem_combobx.SelectedItem as ComboBoxItem;
            if (item != null) sem_combobx_val = item.Content.ToString();
            CheckValidations();
        }

        private void lec_combobx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem item = lec_combobx.SelectedItem as ComboBoxItem;
            if (item != null) lec_combobx_val = item.Content.ToString();
            CheckValidations();
        }

        private void tutorial_combobx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem item = tutorial_combobx.SelectedItem as ComboBoxItem;
            if (item != null) tute_combobx_val = item.Content.ToString();
            CheckValidations();
        }

        private void lab_combobx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem item = lab_combobx.SelectedItem as ComboBoxItem;
            if (item != null) lab_combobx_val = item.Content.ToString();
            CheckValidations();
        }

        private void eval_combobx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem item = eval_combobx.SelectedItem as ComboBoxItem;
            if (item != null) eval_combobx_val = item.Content.ToString();
            CheckValidations();
        }
    }
}
