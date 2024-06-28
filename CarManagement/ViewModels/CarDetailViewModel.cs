using CarManagement.Model;
using System.Windows.Input;

namespace CarManagement.ViewModels
{
    public class CarDetailViewModel : BaseViewModel
    {
        private CarModel _car;
        private CarModel _tempCar;

        public CarModel Car
        {
            get => _car;
            set => SetProperty(ref _car, value);
        }

        public CarModel TempCar
        {
            get => _tempCar;
            set => SetProperty(ref _tempCar, value);
        }

        public ICommand EditCarCommand { get; }
        public ICommand SaveCarCommand { get; }

        public CarDetailViewModel()
        {
            EditCarCommand = new Command(EditCar);
            SaveCarCommand = new Command(SaveCar);


            Car = new CarModel();
            TempCar = new CarModel();
        }

        private void EditCar()
        {

            TempCar.Id = Car.Id;
            TempCar.Name = Car.Name;
            TempCar.Model = Car.Model;
            TempCar.Make = Car.Make;
            TempCar.Year = Car.Year;
            TempCar.CreatedAt = Car.CreatedAt;


            Car = TempCar;
        }

        private void SaveCar()
        {

            Car.Id = TempCar.Id;
            Car.Name = TempCar.Name;
            Car.Model = TempCar.Model;
            Car.Make = TempCar.Make;
            Car.Year = TempCar.Year;
            Car.CreatedAt = TempCar.CreatedAt;
            Car = Car;
        }
    }
}
