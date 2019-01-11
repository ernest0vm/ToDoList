using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using ToDoList.Views;
using Template10.Services.NavigationService;

namespace ToDoList.Views
{
    public sealed partial class EditPage : Page
    {
        
        public EditPage()
        {
            InitializeComponent();

        }

        private void Add_Item(object sender, RoutedEventArgs e)
        {
            Input_Box.Document.GetText(Windows.UI.Text.TextGetOptions.AdjustCrlf, out string _getText);
            ViewModel.AddtoDataBase( _getText);
        }
    }
}
