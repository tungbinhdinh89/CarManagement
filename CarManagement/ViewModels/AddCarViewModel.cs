using CarManagement.Model;
using System.Windows.Input;

namespace CarManagement.ViewModels
{
    public class AddCarViewModel : BaseViewModel
    {
        private string name;
        private string model;
        private string make;
        private int year;
        private string createdAt;

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        public string Model
        {
            get => model;
            set => SetProperty(ref model, value);
        }

        public string Make
        {
            get => make;
            set => SetProperty(ref make, value);
        }

        public int Year
        {
            get => year;
            set => SetProperty(ref year, value);
        }

        public string CreatedAt
        {
            get => createdAt;
            set => SetProperty(ref createdAt, value);
        }

        public ICommand AddCarCommand { get; }
        public ICommand CancelCommand { get; }

        public AddCarViewModel()
        {
            AddCarCommand = new Command(async () => await AddCar());
            CancelCommand = new Command(async () => await Cancel());
        }

        private async Task AddCar()
        {
            // Thêm logic để lưu car mới
            var newCar = new CarModel();
            {
                Name = Name;
                Model = Model;
                Make = Make;
                Year = Year;
                CreatedAt = CreatedAt;
            };

            // Add logic to save the new car
            // For example, call an API to save the car

            // Navigate back to the main page
            await Shell.Current.GoToAsync("//MainPage");
        }

        private async Task Cancel()
        {
            await Shell.Current.GoToAsync("//MainPage");
        }
    }
}




