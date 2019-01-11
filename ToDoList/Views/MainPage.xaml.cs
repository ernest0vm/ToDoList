using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace ToDoList.Views
{
    public sealed partial class MainPage : Page
    {
        
        public MainPage()
        {
            InitializeComponent();
            this.NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
            NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
            UpdateList();
        }

        public void Delete_Item(object sender, RoutedEventArgs e)
        {
            ViewModel.Delete_Items(Output.SelectedIndex);
            UpdateList();
        }
        
        public void UpdateList()
        {
            Output.ItemsSource = ViewModel.Get_Items();
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            editbtn.Visibility = Visibility.Visible;
            deletebtn.Visibility = Visibility.Visible;
        }
    }

        
    
}