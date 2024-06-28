using CarManagement.Model;
using CarManagement.ViewModels;

namespace CarManagement.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

        }
        private void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null) return;

            var viewModel = BindingContext as MainViewModel;
            var car = e.Item as CarModel;
            if (viewModel?.CarViewModel?.OnCarTappedCommand?.CanExecute(car) == true)
            {
                viewModel.CarViewModel.OnCarTappedCommand.Execute(car);
            }

                   // Deselect item
                   ((ListView)sender).SelectedItem = null;
        }

    }

}
