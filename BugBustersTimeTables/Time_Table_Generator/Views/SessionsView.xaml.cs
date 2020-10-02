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
using Time_Table_Generator.View;

namespace Time_Table_Generator.Views
{
    /// <summary>
    /// Interaction logic for SessionsView.xaml
    /// </summary>
    public partial class SessionsView : Page
    {
        public SessionsView()
        {
            InitializeComponent();
        }

        private void add_session_btn_Click(object sender, RoutedEventArgs e)
        {
            SessionAddView sessionAddView = new SessionAddView();
            this.NavigationService.Navigate(sessionAddView);
        }
    }
}
