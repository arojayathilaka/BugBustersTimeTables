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
using BBTG.Entities.Data;
using System.Collections;

namespace Time_Table_Generator.Views
{
    /// <summary>
    /// Interaction logic for ManageWorkView.xaml
    /// </summary>
    public partial class ManageWorkView : Page
    {
        WorkViewModel _viewModel;
        WorkEntity workEntity;

        public ManageWorkView()
        {
            InitializeComponent();
            _viewModel = new WorkViewModel();
            var x = _viewModel.LoadData();
            //DataTable dataTable = new System.Data.DataTable();
            view_grid.ItemsSource = x;
        }

        public void clear()
        {
            workId_txt.Clear();
            batch_txt.Clear();
            working_days_no_txt.Clear();
            working_hours_no_txt.Clear();
            chk_mon.IsChecked = false;
            chk_tue.IsChecked = false;
            chk_wed.IsChecked = false;
            chk_thr.IsChecked = false;
            chk_fri.IsChecked = false;
            chk_sat.IsChecked = false;
            chk_sun.IsChecked = false;
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dataGrid = (DataGrid)sender;
            WorkEntity work = dataGrid.SelectedItem as WorkEntity;

            if (work != null)
            {
                workId_txt.Text = work.ID.ToString();
                batch_txt.Text = work.batchType.ToString();
                working_days_no_txt.Text = work.noOfWorkingDays.ToString();
                working_hours_no_txt.Text = work.noOfWorkingHours.ToString();
                startTime_txt.Text = work.timeSlotStartTime.ToString();
                endTime_txt.Text = work.timeSlotEndTime.ToString();


                String res = work.workingDays.ToString();

                Array workArray = res.Split(',');
                foreach (string value in workArray)
                {
                    String check = value.ToString();
                    if (check == "Monday")
                    {
                        chk_mon.IsChecked = true;
                    }
                    else if (check == "Tuesday")
                    {
                        chk_tue.IsChecked = true;
                    }
                    else if (check == "Wednesday")
                    {
                        chk_wed.IsChecked = true;
                    }
                    else if (check == "Thursday")
                    {
                        chk_thr.IsChecked = true;
                    }
                    else if (check == "Friday")
                    {
                        chk_fri.IsChecked = true;
                    }
                    else if (check == "Saturday")
                    {
                        chk_sat.IsChecked = true;
                    }
                    else if (check == "Sunday")
                    {
                        chk_sun.IsChecked = true;
                    }

                }
                //work.workingDays = String.Join(",", workArray);
            }
        }

        private void Chk_fri_Copy_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void edit_work_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int workId = int.Parse(workId_txt.Text);
                string batchType = batch_txt.Text;
                int noOfWorkingDays = int.Parse(working_days_no_txt.Text);
                int noOfWorkingHours = int.Parse(working_hours_no_txt.Text);
                String startTime = startTime_txt.Text;
                String endTime = endTime_txt.Text;

                String monday = "";
                String tuesday = "";
                String wednesday = "";
                String thursday = "";
                String friday = "";
                String saturday = "";
                String sunday = "";

                int count = 0;

                //String[] days = new String[7];
                ArrayList days = new ArrayList();

                if (chk_mon.IsChecked == true)
                {
                    monday = "Monday,";
                    days.Add(monday);
                    count++;

                }
                else
                {
                    monday = null;
                }
                if (chk_tue.IsChecked == true)
                {
                    tuesday = "Tuesday,";
                    days.Add(tuesday);
                    count++;

                }
                else
                {
                    tuesday = null;
                }
                if (chk_wed.IsChecked == true)
                {
                    wednesday = "Wednesday,";
                    days.Add(wednesday);
                    count++;

                }
                else
                {
                    wednesday = null;
                }
                if (chk_thr.IsChecked == true)
                {
                    thursday = "Thursday,";
                    days.Add(thursday);
                    count++;

                }
                else
                {
                    thursday = null;
                }
                if (chk_fri.IsChecked == true)
                {
                    friday = "Friday,";
                    days.Add(friday);
                    count++;

                }
                else
                {
                    friday = null;
                }
                if (chk_sat.IsChecked == true)
                {
                    saturday = "Saturday,";
                    days.Add(saturday);
                    count++;

                }
                else
                {
                    saturday = null;
                }
                if (chk_sun.IsChecked == true)
                {
                    sunday = "Sunday";
                    days.Add(sunday);
                    count++;

                }
                else
                {
                    sunday = null;
                }

                String workingDays = "";
                string[] array = days.ToArray(typeof(string)) as string[];

                if (count == int.Parse(working_days_no_txt.Text))
                {
                    foreach (string value in array)
                    {
                        edit_txt_hide.AppendText(value.ToString());
                        workingDays = edit_txt_hide.Text;
                    }
                    workEntity = new WorkEntity(workId, batchType, noOfWorkingDays, workingDays, noOfWorkingHours, startTime, endTime);

                    //workEntity = CreateWorkEntity();
                    _viewModel.UpdateWorkData(workEntity);
                    view_grid.ItemsSource = _viewModel.LoadData();
                    clear();
                }
                else
                {
                    MessageBox.Show("Count of Working days and No of working days are not matching");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void delete_work_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int workdID = int.Parse(workId_txt.Text);

                _viewModel.DeleteWorkData(workdID);
                view_grid.ItemsSource = _viewModel.LoadData();
                clear();

            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddWorkView addWorkView = new AddWorkView();
            this.NavigationService.Navigate(addWorkView);
        }

        /*private WorkEntity CreateWorkEntity()
        {
            /*int workId = int.Parse(workId_txt.Text);
            string batchType = batch_txt.Text;
            int noOfWorkingDays = int.Parse(working_days_no_txt.Text);
            int noOfWorkingHours = int.Parse(working_hours_no_txt.Text);
            String startTime = startTime_txt.Text;
            String endTime = endTime_txt.Text;

            String monday = "";
            String tuesday = "";
            String wednesday = "";
            String thursday = "";
            String friday = "";
            String saturday = "";
            String sunday = "";

            int count = 0;

            //String[] days = new String[7];
            ArrayList days = new ArrayList();

            if (chk_mon.IsChecked == true)
            {
                monday = "Monday,";
                days.Add(monday);
                count++;

            }
            else
            {
                monday = null;
            }
            if (chk_tue.IsChecked == true)
            {
                tuesday = "Tuesday,";
                days.Add(tuesday);
                count++;

            }
            else
            {
                tuesday = null;
            }
            if (chk_wed.IsChecked == true)
            {
                wednesday = "Wednesday,";
                days.Add(wednesday);
                count++;

            }
            else
            {
                wednesday = null;
            }
            if (chk_thr.IsChecked == true)
            {
                thursday = "Thursday,";
                days.Add(thursday);
                count++;

            }
            else
            {
                thursday = null;
            }
            if (chk_fri.IsChecked == true)
            {
                friday = "Friday,";
                days.Add(friday);
                count++;

            }
            else
            {
                friday = null;
            }
            if (chk_sat.IsChecked == true)
            {
                saturday = "Saturday,";
                days.Add(saturday);
                count++;

            }
            else
            {
                saturday = null;
            }
            if (chk_sun.IsChecked == true)
            {
                sunday = "Sunday";
                days.Add(sunday);
                count++;

            }
            else
            {
                sunday = null;
            }

            String workingDays = "";
            string[] array = days.ToArray(typeof(string)) as string[];

            if (count == int.Parse(working_days_no_txt.Text))
            {
                foreach (string value in array)
                {
                    edit_txt_hide.AppendText(value.ToString());
                    workingDays = edit_txt_hide.Text;
                }
                workEntity = new WorkEntity(workId, batchType, noOfWorkingDays, workingDays, noOfWorkingHours, startTime, endTime);
                return workEntity;
            }
            else
            {
                MessageBox.Show("Count of Working days and No of working days are not matching");
            }*/


        //}
    }
}
