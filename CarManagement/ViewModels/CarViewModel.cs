using CarManagement.Model;
using CarManagement.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace CarManagement.ViewModels
{
    public class CarViewModel : BindableObject
    {
        public ObservableCollection<CarModel> Cars { get; set; }
        public ICommand EditCarCommand { get; }
        public ICommand DeleteCarCommand { get; }
        public ICommand OnAddCarCommand { get; }
        public ICommand OnCarTappedCommand { get; }



        public CarViewModel()
        {
            Cars = new ObservableCollection<CarModel>();

            // Sample data (for testing purposes)
            Cars.Add(new CarModel { Id = 1, Name = "Car 1", Model = "Model 1", Make = "Make 1", Year = 2020, CreatedAt = DateTime.Now });
            Cars.Add(new CarModel { Id = 2, Name = "Car 2", Model = "Model 2", Make = "Make 2", Year = 2021, CreatedAt = DateTime.Now });

            EditCarCommand = new Command<CarModel>(async (car) => await EditCar(car));
            DeleteCarCommand = new Command<CarModel>(DeleteCar);
            OnAddCarCommand = new Command(OnAddCar);
            OnCarTappedCommand = new Command<CarModel>(async (car) => await OnCarTapped(car));
        }

        private async void OnAddCar()
        {
            var addCarPage = new AddCarPage();
            var viewModel = (AddCarViewModel)addCarPage.BindingContext;
            viewModel.Initialize(new CarModel(), false);
            await Shell.Current.Navigation.PushAsync(addCarPage);
        }

        private async Task OnCarTapped(CarModel car)
        {
            if (car == null) return;

            var carDetailPage = new CarDetailPage { BindingContext = new CarDetailViewModel { Car = car } };
            await Shell.Current.Navigation.PushAsync(carDetailPage);
        }

        private async Task EditCar(CarModel car)
        {
            if (car != null)
            {
                var editCarPage = new AddCarPage();
                var viewModel = (AddCarViewModel)editCarPage.BindingContext;
                viewModel.Initialize(car, true);
                await Shell.Current.Navigation.PushAsync(editCarPage);
            }
        }

        private void DeleteCar(CarModel car)
        {
            if (car != null)
            {
                Cars.Remove(car);
            }
        }
    }
}
