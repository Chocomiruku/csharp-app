using csharp_app;
using Newtonsoft.Json;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Car car1 = new Car
            {
                Id = 1,
                Name = "Foo",
                Price = 20.8
            };
            Car car2 = new Car
            {
                Id = 2,
                Name = "Bar",
                Price = 15.4
            };
            List<Car> cars = new List<Car> { car1, car2 };

            string json = JsonConvert.SerializeObject(cars);
            File.WriteAllText("text.json", json);

            string readedJson = File.ReadAllText("text.json");
            List<Car> readedCars = JsonConvert.DeserializeObject<List<Car>>(readedJson);
            foreach (Car car in readedCars)
            {
                Console.WriteLine(car.ToString());
            }

            double maxPrice = cars.Select(c => c.Price).Max();
            double minPrice = cars.Select(c => c.Price).Min();

            List<Car> filteredCars = cars.Where(c => c.Price > 20).ToList();

            Dictionary<string, Car> test = cars.GroupBy(c => c.Name).ToDictionary(c => c.Key, c => c.First());
            Dictionary<string, Car> test2 = cars.GroupBy(c => c.Name).ToDictionary(c => c.Key, c => c.FirstOrDefault() ?? new Car());

            Console.WriteLine(minPrice + " " + maxPrice);
            Console.ReadLine();
        }
    }
}