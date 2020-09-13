using BBTG.Entities.Data;
using System;
using System.Collections.Generic;
using System.Data;
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
using Time_Table_Generator.View;
using Time_Table_Generator.ViewModel;

namespace Time_Table_Generator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //this.WindowState = WindowState.Maximized;
        }

        private void lecturer_btn_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new LecturerView();
        }

        private void subject_btn_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new SubjectView();
        }

        private void student_btn_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new StudentView();
        }

        private void tag_btn_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new TagView();
        }

        private void location_btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void working_btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void stats_btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void session_btn_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new SessionView();
        }
    }
}
