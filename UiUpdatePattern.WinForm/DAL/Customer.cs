namespace UiUpdatePattern.WinForm.DAL
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; } = "unnamed";

        public Customer(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public override string ToString()
        {
            return $"Customer: Id={Id}, Name={Name}";
        }
    }
}