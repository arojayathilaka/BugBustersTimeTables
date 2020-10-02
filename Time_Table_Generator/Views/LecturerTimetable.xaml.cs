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
    /// Interaction logic for LecturerTimetable.xaml
    /// </summary>
    public partial class LecturerTimetable : Page
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


        public LecturerTimetable()
        {
            InitializeComponent();
            //_timeSlotViewModel.LoadTimeSlotData();
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

        
        private void GenerateLecturerTable_btn_Click(object sender, RoutedEventArgs ev)
        {
            try
            {
                //string lecturername = lec_name_txt.Text;
                //var s = _sessionViewModel.LoadSessionData();

                int workdID = int.Parse(timeTable_Id_txt.Text);
                List<WorkEntity> list = new List<WorkEntity>();

                
                _viewModel = new WorkViewModel();
                
                list = _viewModel.LoadWorkingDaysData(workdID);
                lecturerTable_grid.ItemsSource = list;

                WorkEntity work = lecturerTable_grid.Items[0] as WorkEntity;

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

                //string full;

                //List<Data> datalist = new List<Data>();


                /*for (int i=0; i<start.Length; i++)
                {
                    full = start[i] + end[i];
                    list1.Add(full);

                }

                for (int i = 0; i < list1.Count; i++)
                {
                    datalist.Add(new Data
                    {
                        fullTime = list1[i].ToString()
                    });
                }*/
                //lecturer_timetable.DataContext = datalist;


                //string[] test = list1.ToArray();
                 //data.fullTime = list1.ToArray();



                _timeSlotViewModel = new TimeSlotViewModel();

                

                

                days = res.Split(',');

                //data.items[0] = "";
                //data.items = res.Split(',');

                //DataContext = data;

                //lecturer_timetable.Items.Add(data);

                //lecturer_timetable.DataContext = data.fullTime;
                

                int len = (end.Length) - 2;

                string x = end[len];

                string name = lec_name_txt.Text;

                int lecId = lecturers.Find(e => e.Name == name).EmployeeId;
                List<int> sessionIds = new List<int>();
                _sessionViewModel.LoadSessionDataByLecturer(lecId).Select(e => { sessionIds.Add(e.SessionId); return e; }).ToList();
                var c = sessionIds;

                //var f = _sessionViewModel.LoadSessionDataByLecturer(lecId);


                // for(int i; i < )


                //for (int i = 0; i < days.Length; i++)
                //{
                //    days[i] = 
                //}


                //For day : - 9 ? 
                // # of days : - 5 ? 
                // TOT = 9*5 = 45
                _timeSlotEntities = new List<TimeSlotEntity>();
                double startTime = double.Parse(start[0]);
                //int sttime = 8;
                //float st = ++startTime;
                int currentDate = 0;
                //int edtime = 17;
                double endTime = double.Parse(end[len]); 
                int num1 = num * days.Length;
                for (int i = 0; i < num1; i++)
                {
                    if (startTime == endTime)
                    {
                        startTime = double.Parse(start[0]);
                        currentDate++;
                    }

                    if(i>=c.Count)
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

                //timeSlotEntity = new TimeSlotEntity(2, "8-9", "tue");
                //_timeSlotViewModel.SaveTimeSlotsData(timeSlotEntity);

                foreach (TimeSlotEntity t in _timeSlotEntities)
                {
                    _timeSlotViewModel.SaveTimeSlotsData(t);
                }

                var y = _timeSlotViewModel.LoadTimeSlotData();
                lecturer_timetable.ItemsSource = y;


                _timeSlotViewModel.DeleteTimeData();



                //string name = "Arosha";

                //int lecId = lecturers.Find(e => e.Name == name).EmployeeId;
                //List<int> sessionIds = new List<int>();
                //_sessionViewModel.LoadSessionDataByLecturer(lecId).Select(e => { sessionIds.Add(e.SessionId); return e; });
                //var c = sessionIds;


                /*string[,] daysAndSlots = {
                    { "Monday", "8.30-9.30" },
                    { "Tuesday", "9.30-10.30" },
                    { "Wednesday", "10.30-11.30" },
                    { "Thursday", "11.30-12.30" },
                    { "Friday", "12.30-13.30" },
                    { "Saturday", "13.30-14.30" }
                };*/





            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PrintLecturerTable_btn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
