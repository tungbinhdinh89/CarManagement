using CarManagement.Model;
using System.Windows.Input;

namespace CarManagement.ViewModels
{
    //public class AddCarViewModel : BaseViewModel
    //{
    //    private string _pageTitle;
    //    public string PageTitle
    //    {
    //        get => _pageTitle;
    //        set => SetProperty(ref _pageTitle, value);
    //    }

    //    private string _buttonText;
    //    public string ButtonText
    //    {
    //        get => _buttonText;
    //        set => SetProperty(ref _buttonText, value);
    //    }

    //    private CarModel _car;
    //    public CarModel Car
    //    {
    //        get => _car;
    //        set => SetProperty(ref _car, value);
    //    }

    //    public string Name
    //    {
    //        get => Car.Name;
    //        set
    //        {
    //            Car.Name = value;
    //            OnPropertyChanged();
    //        }
    //    }

    //    public string Model
    //    {
    //        get => Car.Model;
    //        set
    //        {
    //            Car.Model = value;
    //            OnPropertyChanged();
    //        }
    //    }

    //    public string Make
    //    {
    //        get => Car.Make;
    //        set
    //        {
    //            Car.Make = value;
    //            OnPropertyChanged();
    //        }
    //    }

    //    public int Year
    //    {
    //        get => Car.Year;
    //        set
    //        {
    //            Car.Year = value;
    //            OnPropertyChanged();
    //        }
    //    }

    //    public string CreatedAt
    //    {
    //        get => Car.CreatedAt;
    //        set
    //        {
    //            Car.CreatedAt = value;
    //            OnPropertyChanged();
    //        }
    //    }

    //    public ICommand SaveCommand { get; }
    //    public ICommand CancelCommand { get; }

    //    public AddCarViewModel()
    //    {
    //        Car = new CarModel();
    //        SaveCommand = new Command(async () => await SaveCar());
    //        CancelCommand = new Command(async () => await Cancel());
    //    }

    //    public AddCarViewModel(CarModel car)
    //    {
    //        Car = car;
    //        PageTitle = "Edit Car";
    //        ButtonText = "Save";
    //        SaveCommand = new Command(async () => await SaveCar());
    //        CancelCommand = new Command(async () => await Cancel());
    //    }

    //    private async Task SaveCar()
    //    {
    //        // Logic to save the car (either add new or update existing)
    //        // Example: await carService.SaveCarAsync(Car);
    //    }

    //    private async Task Cancel()
    //    {
    //        await Application.Current.MainPage.Navigation.PopAsync();
    //    }
    //}

    public class AddCarViewModel : BaseViewModel
    {
        private CarModel _car;
        public CarModel Car
        {
            get => _car;
            set => SetProperty(ref _car, value);
        }

        public string PageTitle { get; set; }
        public string ActionButtonText { get; set; }
        public ICommand SaveCarCommand { get; }
        public ICommand CancelCommand { get; }

        public AddCarViewModel()
        {
            SaveCarCommand = new Command(SaveCar);
            CancelCommand = new Command(Cancel);
        }

        private async void SaveCar()
        {
            // Logic to save or update the car
        }

        private async void Cancel()
        {
            await Shell.Current.Navigation.PopAsync();
        }

        public void Initialize(CarModel car, bool isEditMode)
        {
            Car = car;
            PageTitle = isEditMode ? "Edit Car" : "Add New Car";
            ActionButtonText = isEditMode ? "Save Changes" : "Add Car";
        }
    }
}




