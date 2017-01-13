using Client.ViewModel;
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

namespace Client.View
{
    /// <summary>
    /// Interaction logic for ShowProjectsView.xaml
    /// </summary>
    public partial class ShowProjectsView : UserControl
    {
        public ShowProjectsView()
        {
            InitializeComponent();
            this.DataContext = ClientDialogViewModel.Instance;
        }

        private void ProjectsDataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {

        }

    }
}
