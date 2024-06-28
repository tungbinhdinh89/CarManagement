using System.Windows.Input;

namespace CarManagement.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public CarViewModel CarViewModel { get; }
        public ICommand NavigateToAddCarCommand { get; }

        public MainViewModel()
        {
            CarViewModel = new CarViewModel();
            NavigateToAddCarCommand = new Command(async () => await NavigateToAddCarPage());
        }

        private async Task NavigateToAddCarPage()
        {
            await Shell.Current.GoToAsync("///AddCarPage");
        }
    }
}
