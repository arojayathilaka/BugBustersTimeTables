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
using BBTG.Entities;
using BBTG.Entities.Data;
using System.Collections;
using System.Data;

namespace Time_Table_Generator.Views
{
    /// <summary>
    /// Interaction logic for StudentTimetable.xaml
    /// </summary>
    public partial class StudentTimetable : Page
    {

        WorkViewModel _viewModel;
        TimeSlotViewModel _timeSlotViewModel;
        WorkEntity workEntity;
        SessionViewModel _sessionViewModel;
        LecturerViewModel _lecturerViewModel;
        SessionEntity session;

        public static List<TimeSlotEntity> _timeSlotEntities { get; private set; }
        List<SessionEntity> sessions;
        List<LecturerEntity> lecturers;


        public StudentTimetable()
        {
            InitializeComponent();
            _lecturerViewModel = new LecturerViewModel();
            _sessionViewModel = new SessionViewModel();
            lecturers = _lecturerViewModel.LoadLecturerData();
        }

        public class Data
        {
            public String start
            {
                get;
                set;
            }
            public String[] items
            {
                get;
                set;
            }
            public String fullTime
            {
                get;
                set;
            }
        }


        private void GenerateStudent_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //string lecturername = lec_name_txt.Text;
                //var s = _sessionViewModel.LoadSessionData();

                int workdID = int.Parse(timeTable_Id_txt.Text);
                List<WorkEntity> list = new List<WorkEntity>();


                _viewModel = new WorkViewModel();

                list = _viewModel.LoadWorkingDaysData(workdID);
                studentTable_grid.ItemsSource = list;

                WorkEntity work = studentTable_grid.Items[0] as WorkEntity;

                String res = work.workingDays.ToString();
                int num = work.noOfWorkingHours;
                String res1 = work.timeSlotStartTime.ToString();
                String res2 = work.timeSlotEndTime.ToString();


                //data.items = works.Split(',');

                //List<string> list1 = new List<string>();
                //Data data = new Data();

                string[] days;
                string[] start;
                string[] end;

                start = res1.Split(',');
                end = res2.Split(',');

                _timeSlotViewModel = new TimeSlotViewModel();
                string batch = batchType_txt.Text;

                if (batch == "Main Group")
                {
                    days = res.Split(',');


                    int len = (end.Length) - 2;

                    string x = end[len];

                    string batchId = batchId_txt.Text;

                    List<int> sessionIdsMainGrp = new List<int>();
                    _sessionViewModel.LoadSessionDataByGroup(batchId).Select(ee => { sessionIdsMainGrp.Add(ee.SessionId); return ee; }).ToList();
                    var c = sessionIdsMainGrp;

                    // _sessionViewModel.LoadSessionDataByLecturer(lecId).Select(e => { sessionIds.Add(e.SessionId); return e; }).ToList();
                    //var c = sessionIds;


                    _timeSlotEntities = new List<TimeSlotEntity>();
                    double startTime = double.Parse(start[0]);
                    int currentDate = 0;
                    double endTime = double.Parse(end[len]);
                    int num1 = num * days.Length;
                    for (int i = 0; i < num1; i++)
                    {
                        if (startTime == endTime)
                        {
                            startTime = double.Parse(start[0]);
                            currentDate++;
                        }

                        if (i >= c.Count)
                        {
                            _timeSlotEntities.Add(
                            new TimeSlotEntity { ID = i, TimeSlots = $"{startTime}-{++startTime}", Days = days[currentDate], SessionId = 0 }
                            );
                        }
                        else
                        {
                            _timeSlotEntities.Add(
                            new TimeSlotEntity { ID = i, TimeSlots = $"{startTime}-{++startTime}", Days = days[currentDate], SessionId = c[i] }
                            );
                        }



                    }

                    foreach (TimeSlotEntity t in _timeSlotEntities)
                    {
                        _timeSlotViewModel.SaveTimeSlotsData(t);
                    }

                    var y = _timeSlotViewModel.LoadTimeSlotData();
                    student_timetable.ItemsSource = y;

                    _timeSlotViewModel.DeleteTimeData();

                }

                if (batch == "Sub Group")
                {
                    days = res.Split(',');


                    int len = (end.Length) - 2;

                    string x = end[len];

                    string batchId = batchId_txt.Text;

                    List<int> sessionIdsSubGrp = new List<int>();
                    _sessionViewModel.LoadSessionDataBySubGroup(batchId).Select(ee => { sessionIdsSubGrp.Add(ee.SessionId); return ee; }).ToList();
                    var c = sessionIdsSubGrp;

                    _timeSlotEntities = new List<TimeSlotEntity>();
                    double startTime = double.Parse(start[0]);
                    int currentDate = 0;
                    double endTime = double.Parse(end[len]);
                    int num1 = num * days.Length;
                    for (int i = 0; i < num1; i++)
                    {
                        if (startTime == endTime)
                        {
                            startTime = double.Parse(start[0]);
                            currentDate++;
                        }

                        if (i >= c.Count)
                        {
                            _timeSlotEntities.Add(
                            new TimeSlotEntity { ID = i, TimeSlots = $"{startTime}-{++startTime}", Days = days[currentDate], SessionId = 0 }
                            );
                        }
                        else
                        {
                            _timeSlotEntities.Add(
                            new TimeSlotEntity { ID = i, TimeSlots = $"{startTime}-{++startTime}", Days = days[currentDate], SessionId = c[i] }
                            );
                        }



                    }

                    foreach (TimeSlotEntity t in _timeSlotEntities)
                    {
                        _timeSlotViewModel.SaveTimeSlotsData(t);
                    }

                    var y = _timeSlotViewModel.LoadTimeSlotData();
                    student_timetable.ItemsSource = y;

                    _timeSlotViewModel.DeleteTimeData();

                }
            }

            catch (NullReferenceException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
