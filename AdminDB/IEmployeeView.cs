using System.Collections.Generic;

public interface IEmployeeView
{
    void UpdateEmployeeTable(IEnumerable<Employee> employees);
}