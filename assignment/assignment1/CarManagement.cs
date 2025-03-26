using System.Runtime.InteropServices;

namespace NashTechAssignment
{
    public class CarManagement
    {
        private List<Car> cars = new List<Car>();

        public void AddCar(Car car)
        {
            cars.Add(car);
        }

        public string RemoveCarByModel(string model)
        {
            var carToRemove = cars.Find(car => car.model.Equals(model, StringComparison.OrdinalIgnoreCase));
            if (carToRemove != null)
            {
                cars.Remove(carToRemove);
                return "Removed car successully";
            }
            return "There is no existing model";
        }
        public Car FindCarByMake(string make)
        {
            return cars.Find(car => car.make.Equals(make, StringComparison.OrdinalIgnoreCase));
        }

        public List<Car> FilterCarsByType(CarType type)
        {
            return cars.Where(car => car.type == type).ToList();
        }

        public void DisplayAllCars()
        {
            DisplayCarList(cars);
        }

        public void DisplayCarList(List<Car> carsList)
        {
            Console.WriteLine("Car list:");
            for (int i = 0; i < carsList.Count(); i++)
            {
                Console.WriteLine($"Car number {i + 1}");
                Console.WriteLine(carsList[i]);
            }
        }
    }

}