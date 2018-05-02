using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFWorkSample.Infrastructure;
using WPFWorkSample.Models;

namespace WPFWorkSample.ViewModels
{
    public class CarViewModel : ViewModelBase
    {
        public RelayCommand DeleteCarCommand { get; set; }
        public RelayCommand AddCarCommand { get; set; }
        public ObservableCollection<Car> Cars
        {
            get;
            set;
        }

        public CarViewModel()
        {
            LoadCars();
            DeleteCarCommand = new RelayCommand(OnDelete);
            AddCarCommand = new RelayCommand(AddCar);
        }

        public void LoadCars()
        {
            ObservableCollection<Car> cars = new ObservableCollection<Car>();

            cars.Add(new Car { Id = 1, Manufacture = "Honda", Model = "Honda Civic", Weight = 10 });
            cars.Add(new Car { Id = 2, Manufacture = "Toyota", Model = "Toyota Innova", Weight = 20 });
            cars.Add(new Car { Id = 3, Manufacture = "BMW", Model = "BMW F45", Weight = 5 });

            Cars = cars;
        }

        private void AddCar(object parameter)
        {
            if (parameter == null) return;
            Cars.Add(new Car { Id = Cars==null?1:Cars.Count+1, Manufacture = "Toyota", Model = "Car Model", Weight = 0 });
        }

        private Car _selectedCar;

        public Car SelectedCar
        {
            get
            {
                return _selectedCar;
            }

            set
            {
                _selectedCar = value;
                //DeleteCommand.CanExecuteChanged + ;
            }
        }

        private void OnDelete(object obj)
        {
            Cars.Remove(SelectedCar);
        }

        private bool CanDelete()
        {
            return SelectedCar != null;
        }

    }
}
