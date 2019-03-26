namespace MyCustomers.Application.Dto.Models
{
    public class DisplayCustomer
    {
        public DisplayCustomer(int id, string fullName)
        {
            Id = id;
            FullName = fullName;
        }

        public int Id { get; }
        public string FullName { get; }
    }
}