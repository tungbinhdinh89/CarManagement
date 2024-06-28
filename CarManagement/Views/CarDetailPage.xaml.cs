using CarManagement.ViewModels;

namespace CarManagement.Views
{
    public partial class CarDetailPage : ContentPage
    {
        public CarDetailPage()
        {
            InitializeComponent();
            BindingContext = new CarDetailViewModel();
        }
    }
}
