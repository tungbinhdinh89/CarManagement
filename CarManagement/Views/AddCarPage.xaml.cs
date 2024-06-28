using CarManagement.ViewModels;

namespace CarManagement.Views
{
    public partial class AddCarPage : ContentPage
    {
        public AddCarPage()
        {
            InitializeComponent();
            BindingContext = new AddCarViewModel();
        }
    }
}
