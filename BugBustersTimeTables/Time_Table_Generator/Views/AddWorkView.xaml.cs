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
    /// Interaction logic for AddWorkView.xaml
    /// </summary>
    public partial class AddWorkView : Page
    {
        WorkViewModel _viewModel;
        WorkEntity workEntity;
        TimeSlotEntity timeSlotEntity;
        TimeSlotViewModel _timeSlotViewModel;
        WorkViewModel _workViewModel;

        ArrayList getstartTimes = new ArrayList();
        ArrayList getendTimes = new ArrayList();
        ArrayList getfullTimes = new ArrayList();

        String startTimes = "";
        String endTimes = "";
        String fullTimes = "";
        public List<TimeSlotEntity> _timeSlotEntities;

        public AddWorkView()
        {
            InitializeComponent();
            _viewModel = new WorkViewModel();
            _timeSlotViewModel = new TimeSlotViewModel();
            var x =_viewModel.LoadData();
            /*string[] days = new string[] { "Mon", "Tue", "Wed", "Thu", "Fri" };
            //for (int i = 0; i < days.Length; i++)
            //{
            //    days[i] = 
            //}


            //For day : - 9 ? 
            // # of days : - 5 ? 
            // TOT = 9*5 = 45
            _timeSlotEntities = new List<TimeSlotEntity>();
            int startTime = 8;
            int currentDate = 0;
            int endTime = 17;
            for (int i = 1; i < 46; i++)
            {
                if (startTime == endTime)
                {
                    startTime = 8;
                    currentDate++;
                }

                _timeSlotEntities.Add(
                    new TimeSlotEntity { ID = i, TimeSlot = $"{startTime}-{++startTime}", Day = days[currentDate] }
                    );
            }

            //timeSlotEntity = new TimeSlotEntity(2, "8-9", "tue");
            //_timeSlotViewModel.SaveTimeSlotsData(timeSlotEntity);

            /*foreach (TimeSlotEntity t in _timeSlotEntities)
            {
                _timeSlotViewModel.SaveTimeSlotsData(t);
            }*/

            

        }

        public class TimeSlots
        {
            public String starting { get; set; }
            public String ending { get; set; }
        }

        public void clear()
        {
            workId_txt.Clear();
            batch_txtbx.Clear();
            workdays_no_txtbx.Clear();
            workinghr_no_txtbx.Clear();
            chk_mon.IsChecked = false;
            chk_tues.IsChecked = false;
            chk_wed.IsChecked = false;
            chk_thurs.IsChecked = false;
            chk_fri.IsChecked = false;
            chk_sat.IsChecked = false;
            chk_sun.IsChecked = false;
            timeSlots_grid.Items.Clear();

        }

        private void add_work_btn_Click(object sender, RoutedEventArgs e)
        {
            /*try
            {
                

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }*/

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
            if (chk_tues.IsChecked == true)
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
            if (chk_thurs.IsChecked == true)
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


            foreach (String obj in days)
            {

            }

            String workingDays = "";

            //workId = Convert.ToInt16(workId_txt.Text);
            String batch = batch_txtbx.Text;
            //int wdNo = int.Parse(workdays_no_txtbx.Text);
            string[] array = days.ToArray(typeof(string)) as string[];
            //int whNo = int.Parse(workinghr_no_txtbx.Text);
            // String time = timeslots_txtbx.Text;



            if (workdays_no_txtbx.Text == "" || batch_txtbx.Text == "" || workId_txt.Text == "" || workinghr_no_txtbx.Text == "")
            {
                MessageBox.Show("Please fill the fields");

            }
            else
            {
                if (count == int.Parse(workdays_no_txtbx.Text))
                {
                    foreach (string value in array)
                    {
                        txtbxcp.AppendText(value.ToString());
                        workingDays = txtbxcp.Text;
                    }

                    string[] array1 = getstartTimes.ToArray(typeof(string)) as string[];
                    foreach (string value1 in array1)
                    {
                        time1.AppendText(value1.ToString());
                        startTimes = time1.Text;
                    }

                    string[] array2 = getendTimes.ToArray(typeof(string)) as string[];
                    foreach (string value2 in array2)
                    {
                        time2.AppendText(value2.ToString());
                        endTimes = time2.Text;
                    }

                    string[] array3 = getfullTimes.ToArray(typeof(string)) as string[];
                    foreach (string value3 in array3)
                    {
                        time3.AppendText(value3.ToString());
                        fullTimes = time3.Text;
                    }

                    workEntity = new WorkEntity(int.Parse(workId_txt.Text), batch, int.Parse(workdays_no_txtbx.Text), workingDays, int.Parse(workinghr_no_txtbx.Text), startTimes, endTimes);
                    _viewModel.SaveData(workEntity);

                    

                    clear();

                }
                else
                {
                    MessageBox.Show("Count of Working days and No of working days are not matching");
                }

            }






        }

        private void add_timeslot_btn_Click(object sender, RoutedEventArgs e)
        {
            TimeSlots ts = new TimeSlots();
            ts.starting = timeslots_txtbx1.Text;
            ts.ending = timeslots_txtbx2.Text;

            String startTime = timeslots_txtbx1.Text;
            String endTime = timeslots_txtbx2.Text;
            String fullTime = startTime +" - "+ endTime;

            timeSlots_grid.Items.Add(ts);

            getstartTimes.Add(startTime+",");
            getendTimes.Add(endTime+",");
            getfullTimes.Add(fullTime);

            timeslots_txtbx1.Clear();
            timeslots_txtbx2.Clear();
        }

        private void TimeSlots_grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }



        private void manage_work_click(object sender, RoutedEventArgs e)
        {

            ManageWorkView manageWorkView = new ManageWorkView();
            this.NavigationService.Navigate(manageWorkView);

        }

        private void timetable_view_click(object sender, RoutedEventArgs e)
        {

            TimetablesCategories timetablesCategories = new TimetablesCategories();
            this.NavigationService.Navigate(timetablesCategories);

        }

        private void Chk_sat_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
