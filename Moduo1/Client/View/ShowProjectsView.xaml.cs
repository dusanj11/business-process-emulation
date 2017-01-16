using Client.ViewModel;
using HiringCompanyData;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public ShowProjectsView()
        {
            InitializeComponent();
            //this.DataContext = ClientDialogViewModel.Instance;
            this.DataContext = ViewProjectsViewModel.Instance;
            
        }

        private void ProjectsDataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {

        }

        private void projectsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Console.WriteLine(sender);
            DataGrid dg = sender as DataGrid;
            if (dg == null)
            {
                Log.Debug("DataGrid is null");
                return;
            }

            Project p = dg.SelectedItem as Project;

            
            
            if (p != null)
            {
                Log.Debug("Selection changed. (Project data)");
                Log.Debug("Get user story from OC");
                ClientProxy.Instance.GetUserStories(p.Name);

                Log.Debug("Get user story from OC DB");
                List<UserStory> list = ClientProxy.Instance.GetProjectUserStory(p.Name);

                if (list != null)
                {
                    Log.Info("Successfully returned user stories for selected project");
                    userStoriesProjectsDataGrid.ItemsSource = new ObservableCollection<UserStory>(list);
                }
                else
                {
                    Log.Warn("Project doesn't have assigned user stories.");
                }
            }
            else
            {
                Log.Debug("Selected project is null");
            }
            
        }
    }
}
