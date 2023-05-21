namespace csharp_app
{
    internal class Car
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public override string ToString()
        {
            return "Car: " + Name + " Price:" + Price;
        }
    }
}
