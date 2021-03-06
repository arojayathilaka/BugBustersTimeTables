﻿using BBTG.Entities.Data;
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
        bool updateMode = false;
        bool updateModeSelected = false;
        List<SubjectEntity> subjects;
        List<string> subjectNames = new List<string>();
        List<string> subjectCodes = new List<string>();
        string lec_combobx_val, tute_combobx_val, lab_combobx_val, eval_combobx_val, year_combobx_val, sem_combobx_val;

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
            name_tb.Visibility = Visibility.Hidden;
            code_tb.Visibility = Visibility.Hidden;
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
            if (subjects.Count == 0)
                SubjectId = 1;
            else if (updateMode)
                SubjectId = subject.SubjectId;
            else
                SubjectId = subjects.Last().SubjectId + 1;

            subject = new SubjectEntity{

                SubjectId = SubjectId, 
                SubjectCode = code_txtbx.Text, 
                SubjectName = name_txtbx.Text, 
                Year = int.Parse(year_combobx.Text), 
                Semester = int.Parse(sem_combobx.Text), 
                NoOfLecHrs = int.Parse(lec_combobx.Text), 
                NoOfTuteHrs = int.Parse(tutorial_combobx.Text), 
                NoOfLabHrs = int.Parse(lab_combobx.Text), 
                NoOfEvalHrs = int.Parse(eval_combobx.Text)

            };
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
                update_btn_.IsEnabled = false;

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
                add_btn_.IsEnabled = false;

            if (String.IsNullOrEmpty(year_combobx_val)) year_tb.Visibility = Visibility.Visible;
            else year_tb.Visibility = Visibility.Hidden;

            if (String.IsNullOrEmpty(sem_combobx_val)) sem_tb.Visibility = Visibility.Visible;
            else sem_tb.Visibility = Visibility.Hidden;

            if (String.IsNullOrEmpty(lec_combobx_val)) lec_tb.Visibility = Visibility.Visible;
            else lec_tb.Visibility = Visibility.Hidden;

            if (String.IsNullOrEmpty(tute_combobx_val)) tute_tb.Visibility = Visibility.Visible;
            else tute_tb.Visibility = Visibility.Hidden;

            if (String.IsNullOrEmpty(lab_combobx_val)) lab_tb.Visibility = Visibility.Visible;
            else lab_tb.Visibility = Visibility.Hidden;

            if (String.IsNullOrEmpty(eval_combobx_val)) eval_tb.Visibility = Visibility.Visible;
            else eval_tb.Visibility = Visibility.Hidden;

            if (String.IsNullOrEmpty(name_txtbx.Text)) name_tb.Visibility = Visibility.Visible;
            else name_tb.Visibility = Visibility.Hidden;

            if (String.IsNullOrEmpty(code_txtbx.Text)) code_tb.Visibility = Visibility.Visible;
            else code_tb.Visibility = Visibility.Hidden;
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
            if(code_txtbx.Text != "Eg: IT1050")
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
            ComboBox yearCombobx = sender as ComboBox;
            if(yearCombobx.SelectedItem != null)
            {
                ComboBoxItem selectedYr = yearCombobx.SelectedItem as ComboBoxItem;
                year_combobx_val = selectedYr.Content.ToString();
                CheckValidations();
            }
        }

        private void sem_combobx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox semCombobx = sender as ComboBox;
            if (semCombobx.SelectedItem != null)
            {
                ComboBoxItem selectedSem = semCombobx.SelectedItem as ComboBoxItem;
                sem_combobx_val = selectedSem.Content.ToString();
                CheckValidations();
            }
            
        }

        private void lec_combobx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox lecCombobx = sender as ComboBox;
            if (lecCombobx.SelectedItem != null)
            {
                ComboBoxItem selectedLec = lecCombobx.SelectedItem as ComboBoxItem;
                lec_combobx_val = selectedLec.Content.ToString();
                CheckValidations();
            }
        }

        private void tutorial_combobx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox tuteCombobx = sender as ComboBox;
            if(tuteCombobx.SelectedItem != null)
            {
                ComboBoxItem selectedTute = tuteCombobx.SelectedItem as ComboBoxItem;
                tute_combobx_val = selectedTute.Content.ToString();
                CheckValidations();
            }
        }

        private void lab_combobx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox labCombobx = sender as ComboBox;
            if (labCombobx.SelectedItem != null)
            {
                ComboBoxItem selectedLab = labCombobx.SelectedItem as ComboBoxItem;
                lab_combobx_val = selectedLab.Content.ToString();
                CheckValidations();
            } 
        }

        private void eval_combobx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox evalCombobx = sender as ComboBox;
            if (evalCombobx.SelectedItem != null)
            {
                ComboBoxItem selectedEval = evalCombobx.SelectedItem as ComboBoxItem;
                eval_combobx_val = selectedEval.Content.ToString();
                CheckValidations();
            }
        }
    }
}
