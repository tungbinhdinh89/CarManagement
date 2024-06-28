using CarManagement.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace CarManagement.ViewModels
{
    public class CarViewModel : BindableObject
    {
        public ObservableCollection<CarModel> Cars { get; set; }
        public ICommand EditCarCommand { get; }
        public ICommand DeleteCarCommand { get; }

        public CarViewModel()
        {
            Cars = new ObservableCollection<CarModel>();



            // Sample data (for testing purposes)
            Cars.Add(new CarModel { Id = 1, Name = "Car 1", Model = "Model 1", Make = "Make 1", Year = 2020, CreatedAt = DateTime.Now });
            Cars.Add(new CarModel { Id = 2, Name = "Car 2", Model = "Model 2", Make = "Make 2", Year = 2021, CreatedAt = DateTime.Now });

            EditCarCommand = new Command<CarModel>(EditCar);
            DeleteCarCommand = new Command<CarModel>(DeleteCar);
        }

        private void EditCar(CarModel car)
        {
            // Implement edit logic here
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
