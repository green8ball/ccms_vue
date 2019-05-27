namespace server.Models.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string IdentityId { get; set; }
        public AppUser Identity { get; set; }
    }
}