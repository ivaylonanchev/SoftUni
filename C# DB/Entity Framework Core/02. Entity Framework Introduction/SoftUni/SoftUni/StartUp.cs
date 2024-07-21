using SoftUni.Data;
using SoftUni.Models;
using System.Text;
using System.Text.RegularExpressions;

namespace SoftUni
{
    public class StartUp
    {
        public static void Main()
        {
            var context = new SoftUniContext();
            Console.WriteLine(IncreaseSalaries(context));
        }


        //03
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            return string.Join(Environment.NewLine, context.Employees
                .Select(e => $"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary:f2}")
                .ToList());
        }
        //04
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(e => e.Salary > 50000)
                .Select(e => new
                {
                    e.FirstName,
                    e.Salary
                })
                .OrderBy(e => e.FirstName)
                .ToList();

            var sb = new StringBuilder();
            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} - {e.Salary:f2}");
            }
            return sb.ToString().Trim();
        }
        //05
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var employee = context.Employees
                .Where(e => e.Department.Name == "Research and Development")
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.Department.Name,
                    e.Salary
                })
                .OrderBy(e => e.Salary).ThenByDescending(e => e.FirstName)
                .ToList();

            var sb = new StringBuilder();
            foreach (var e in employee)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} from {e.Name} - ${e.Salary:f2}");
            }

            return sb.ToString().Trim();
        }
        //06
        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            Address address = new Address()
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            var nakov = context.Employees.FirstOrDefault(e => e.LastName == "Nakov");

            if (nakov != null)
            {
                nakov.Address = address;
                context.SaveChanges();
            }

            var employeeAddresses = context.Addresses
                .OrderByDescending(x => x.AddressId)
                .Take(10)
                .ToList();
            var sb = new StringBuilder();
            foreach (var e in employeeAddresses)
            {
                sb.AppendLine(e.AddressText);
            }
            return sb.ToString().Trim();
        }
        //07
        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var employees = context.Employees
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.Manager,
                    e.EmployeesProjects,
                    Projects = e.EmployeesProjects
                    .Where(e => e.Project.StartDate.Year >= 2001 &&
                                e.Project.StartDate.Year <= 2003)
                    .Select(e => new
                    {
                        ProjectName = e.Project.Name,
                        e.Project.StartDate,
                        e.Project.EndDate
                    })
                })
                .Take(10)
                .ToList();

            var sb = new StringBuilder();
            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - Manager: {e.Manager.FirstName} {e.Manager.LastName}");
                if (e.Projects.Any())
                {
                    foreach (var p in e.Projects)
                    {
                        if (p.EndDate is null)
                        {
                            sb.AppendLine($"--{p.ProjectName} - {p.StartDate:M/d/yyyy h:mm:ss tt} - not finished");
                        }
                        else sb.AppendLine($"--{p.ProjectName} - {p.StartDate:M/d/yyyy h:mm:ss tt} - {p.EndDate:M/d/yyyy h:mm:ss tt}");
                    }
                }
            }

            return sb.ToString().Trim();
        }
        //08
        public static string GetAddressesByTown(SoftUniContext context)
        {
            var addresses = context.Addresses
                .Select(e => new
                {
                    e.AddressText,
                    e.Town,
                    EmployeeCount = e.Employees.Count()
                })
                .OrderByDescending(e => e.EmployeeCount)
                .ThenBy(e => e.Town.Name)
                .ThenBy(e => e.AddressText)
                .Take(10)
                .ToList();

            var sb = new StringBuilder();

            foreach (var a in addresses)
            {
                sb.AppendLine($"{a.AddressText}, {a.Town.Name} - {a.EmployeeCount} employees");
            }
            return sb.ToString().Trim();
        }
        //09
        public static string GetEmployee147(SoftUniContext context)
        {
            var emplyees = context.Employees
                .Where(e => e.EmployeeId == 147)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    Projects = e.EmployeesProjects
                    .Select(x => new
                    {
                        x.Project
                    })
                    .OrderBy(x => x.Project.Name)
                    .ToList()
                })
                .ToList();


            var sb = new StringBuilder();
            foreach (var e in emplyees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle}");
                foreach (var p in e.Projects)
                {
                    sb.AppendLine(p.Project.Name);
                }
            }
            return sb.ToString().Trim();
        }
        //10
        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var departments = context.Departments
                .Where(d => d.Employees.Count() > 5)
                .Select(d => new
                {
                    d.Name,
                    ManagerName = $"{d.Manager.FirstName} {d.Manager.LastName}",
                    Count = d.Employees.Count(),
                    DepEmployees = d.Employees
                    .OrderBy(x => x.FirstName)
                    .ThenBy(x => x.LastName)
                    .ToList()
                })
                .OrderBy(x => x.Count)
                .ThenByDescending(x => x.Name)
                .ToList();

            var sb = new StringBuilder();
            foreach (var d in departments)
            {
                sb.AppendLine($"{d.Name} - {d.ManagerName}");
                foreach (var e in d.DepEmployees)
                {
                    sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle}");
                }
            }
            return sb.ToString().Trim();
        }
        //11
        public static string GetLatestProjects(SoftUniContext context)
        {
            var lastProjects = context.Projects
                .OrderByDescending(x => x.StartDate)
                .Take(10)
                .ToList();

            var projects = lastProjects
                .Select(p => new
                {
                    p.Name,
                    p.Description,
                    p.StartDate
                })
                .OrderBy(p => p.Name)
                .ToList();

            var sb = new StringBuilder();

            foreach (var p in projects)
            {
                sb.AppendLine(p.Name);
                sb.AppendLine(p.Description);
                sb.AppendLine($"{p.StartDate:M/d/yyyy h:mm:ss tt}");
            }
            return sb.ToString().Trim();
        }
        //12
        public static string IncreaseSalaries(SoftUniContext context)
        {
            var employee = context.Employees
                .Where(e => e.Department.Name == "Engineering"
                || e.Department.Name == "Tool Desig"
                || e.Department.Name == "Marketing"
                || e.Department.Name == "Information Services")
                .ToList();

            foreach (var e in employee)
            {
                e.Salary += e.Salary * 0.12m;
            }

            context.SaveChanges();

            var updatedEmployees = context.Employees
                .Where(e => e.Department.Name == "Engineering" || e.Department.Name == "Tool Desig"
                || e.Department.Name == "Marketing" || e.Department.Name == "Information Services")
                 .Select(e => new
                 {
                     e.FirstName,
                     e.LastName,
                     e.Salary
                 })
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToList();

            var result = new StringBuilder();

            foreach (var emp in updatedEmployees)
            {
                result.AppendLine($"{emp.FirstName} {emp.LastName} (${emp.Salary:f2})");
            }

            return result.ToString().Trim();
        }
    }
}

