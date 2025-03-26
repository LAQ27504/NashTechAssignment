public enum CarType
{
    Electric,
    Fuel
}

namespace NashTechAssignment
{
    public class Car
    {
        public string make { get; set; }
        public string model { get; set; }
        public int year { get; set; }

        public CarType type { get; set; }

        public Car(string make, string model, int year, CarType type)
        {
            this.make = make;
            this.model = model;
            this.year = year;
            this.type = type;
        }

        public override string ToString()
        {
            return $"Car model: {model} ({type})\n Car make: {make} \n Year: {year} ";
        }
    }
}