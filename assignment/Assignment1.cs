namespace NashTechAssignment
{
    class App
    {
        CarManagement carManager = new CarManagement();

        public void Run()
        {
            while (true)
            {
                DisplayMenu();
                Console.Write("> ");
                int choice;
                while (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid choice !! Please enter a valid choice");
                    Console.Write("> ");
                }

                switch (choice)
                {
                    case 1:
                        AddACar();
                        break;
                    case 2:
                        ViewAllCar();
                        break;
                    case 3:
                        SearchCarByMake();
                        break;
                    case 4:
                        FilterCarsByType();
                        break;
                    case 5:
                        RemoveCarByModel();
                        break;
                    case 6:
                        Console.Clear();
                        break;
                    case 7:
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.Write("> ");
                        Console.WriteLine("Invalid choice !! Please enter a valid choice");
                        break;
                }

            }
        }

        private void RemoveCarByModel()
        {
            string model = GetUserModel();
            string response = carManager.RemoveCarByModel(model);
            Console.WriteLine(response);
        }

        public void DisplayMenu()
        {

            Console.WriteLine("Menu: ");
            Console.WriteLine("1. Add a Car");
            Console.WriteLine("2. View All Cars");
            Console.WriteLine("3. Search Car by Make");
            Console.WriteLine("4. Filter Car by Type");
            Console.WriteLine("5. Remove a Car by Model");
            Console.WriteLine("6. Clear monitor.");
            Console.WriteLine("7. Exit");
            Console.WriteLine("Enter your choice:");
        }

        public void AddACar()
        {
            string make;
            string model;
            int year;
            CarType carType;

            make = GetUserMake();

            model = GetUserModel();

            carType = GetUserType();

            year = GetUserYear();

            Car newCar = new Car(make, model, year, carType);

            carManager.AddCar(newCar);

            Console.WriteLine("Press Enter to Continue.");
            Console.ReadLine();
        }

        public void ViewAllCar()
        {
            carManager.DisplayAllCars();
            Console.WriteLine("Press Enter to Continue.");
            Console.ReadLine();
        }

        public void SearchCarByMake()
        {
            string make = GetUserMake();
            Car makedCar = carManager.FindCarByMake(make);
            if (makedCar == null)
            {
                Console.WriteLine("Sorry, your operation cannot be process due to lack of information");
                Console.WriteLine("Press Enter to Continue.");
                Console.ReadLine();
                return;
            }
            Console.WriteLine($"Here is the car from {make}");
            Console.WriteLine(makedCar);
            Console.WriteLine("Press Enter to Continue.");
            Console.ReadLine();
        }

        public void FilterCarsByType()
        {
            CarType type = GetUserType();
            List<Car> filterCarList = carManager.FilterCarsByType(type);

            carManager.DisplayCarList(filterCarList);
            Console.WriteLine("Press Enter to Continue.");
            Console.ReadLine();
        }



        // Supportive function for handle user input 
        public string GetUserMake()
        {
            string make;
            Console.WriteLine("Enter car make:");
            Console.Write("> ");
            make = Console.ReadLine();
            while (make.Length == 0)
            {
                Console.WriteLine("Car make cannot be null!!! Please try again.");
                Console.Write("> ");
                make = Console.ReadLine();
            }
            return make;
        }

        public string GetUserModel()
        {
            string model;
            Console.WriteLine("Enter car model:");
            Console.Write("> ");
            model = Console.ReadLine();

            while (model.Length == 0)
            {
                Console.WriteLine("Car model cannot be null!!! Please try again.");
                Console.Write("> ");
                model = Console.ReadLine();
            }

            return model;
        }

        public CarType GetUserType()
        {

            string carTypeInput;
            Console.WriteLine("Enter car type (Fuel/Electric)");
            Console.Write("> ");
            carTypeInput = Console.ReadLine();
            CarType carType;
            while (!Enum.TryParse(carTypeInput, out carType))
            {
                Console.WriteLine("Invalid car type. Please enter 'Fuel' or 'Electric':");
                Console.Write("> ");
                carTypeInput = Console.ReadLine();
            }

            return carType;
        }

        public int GetUserYear()
        {
            int year;

            Console.WriteLine("Enter car year:");
            Console.Write("> ");
            int currentYear = DateTime.Now.Year;
            while (!int.TryParse(Console.ReadLine(), out year) || year < 1900 || year > currentYear)
            {
                Console.WriteLine("Invalid year. Please enter a valid year:");
                Console.Write("> ");
            }

            return year;
        }

    }
}