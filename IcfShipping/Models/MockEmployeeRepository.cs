namespace IcfShipping.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employeeList;

        public MockEmployeeRepository()
        {
            _employeeList = new List<Employee>()
            {
                new Employee() { Id = 1, Name = "Rehan", Department = "HR", Email = "rehanshaikh001@gmail.com" },
                new Employee() { Id = 2, Name = "Umar", Department = "IT", Email = "umarkhan001@gmail.com" },
                new Employee() { Id = 3, Name = "Manoj", Department = "IT", Email = "manojyadav@gmail.com" }
            };

        }

        public Employee GetEmployee(int id)
        {
            return _employeeList.FirstOrDefault(e => e.Id == id);
        }
    }
}
