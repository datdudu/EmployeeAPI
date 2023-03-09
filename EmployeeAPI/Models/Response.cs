namespace EmployeeAPI.Models
{
    public class Response
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public Employee Employee { get; set; }
        public List<Employee> ListEmployee { get; set; }
    }
}
