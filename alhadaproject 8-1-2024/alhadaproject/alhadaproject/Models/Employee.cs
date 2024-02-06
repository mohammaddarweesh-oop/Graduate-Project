namespace alhadaProject.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string? EmpName { get; set; }
        public int? Phone  { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? UserType { get; set; }

        public string? Notes { get; set; }
        //Relationship

    }
}
