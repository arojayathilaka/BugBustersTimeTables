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
    /// Interaction logic for LecturerTimetable.xaml
    /// </summary>
    public partial class LecturerTimetable : Page
    {
        WorkViewModel _viewModel;
        WorkEntity workEntity;

        public LecturerTimetable()
        {
            InitializeComponent();
            
        }

        public class Data
        {

            public String[] Items
            {
                get;
                set;
            }
        }

        private void GenerateLecturerTable_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int workdID = int.Parse(timeTable_Id_txt.Text);
                List<WorkEntity> list = new List<WorkEntity>();

                
                _viewModel = new WorkViewModel();
                
                list = _viewModel.LoadWorkingDaysData(workdID);
                lecturerTable_grid.ItemsSource = list;

                WorkEntity work = lecturerTable_grid.Items[0] as WorkEntity;
                

                

                Data data = new Data();
                if (batchType_txt.Text == "Weekend" || batchType_txt.Text == "weekend")
                {
                    String works = "Monday,Tuesday,Wednesday, Thursday,Friday,Saturday, Sunday";
                    data.Items = works.Split(',');
                
                }
                
                if(batchType_txt.Text == "Weekday" || batchType_txt.Text == "weekday")
                {
                    String works = "Monday,Tuesday,Wednesday, Thursday,Friday,x,x";
                    data.Items = works.Split(',');
                }



                    DataContext = data;


                    

            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
