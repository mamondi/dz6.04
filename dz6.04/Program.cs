using System;
using System.Linq;

namespace CompanyQueries
{
    class Company
    {
        public string Name { get; set; }
        public DateTime FoundationDate { get; set; }
        public string BusinessProfile { get; set; }
        public string DirectorFullName { get; set; }
        public int NumberOfEmployees { get; set; }
        public string Address { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Company[] companies = {
                new Company { Name = "ABC Food Ltd.", FoundationDate = new DateTime(2010, 5, 15), BusinessProfile = "Food", DirectorFullName = "John White", NumberOfEmployees = 120, Address = "London" },
                new Company { Name = "XYZ Marketing Agency", FoundationDate = new DateTime(2015, 8, 20), BusinessProfile = "Marketing", DirectorFullName = "Emily Johnson", NumberOfEmployees = 80, Address = "New York" },
                new Company { Name = "Tech Innovations Inc.", FoundationDate = new DateTime(2008, 11, 10), BusinessProfile = "IT", DirectorFullName = "David Smith", NumberOfEmployees = 250, Address = "San Francisco" },
                new Company { Name = "Green Energy Solutions", FoundationDate = new DateTime(2012, 3, 25), BusinessProfile = "Energy", DirectorFullName = "Sarah Brown", NumberOfEmployees = 180, Address = "London" }
            };

            var allCompanies = companies.ToArray();

            var foodCompanies = companies.WhereContains("Food", company => company.Name);

            var marketingCompanies = companies.WhereEquals("Marketing", company => company.BusinessProfile);

            var marketingOrITCompanies = companies.WhereAny(new[] { "Marketing", "IT" }, company => company.BusinessProfile);

            var companiesWithMoreThan100Employees = companies.Where(company => company.NumberOfEmployees > 100);

            var companiesWith100To300Employees = companies.Where(company => company.NumberOfEmployees >= 100 && company.NumberOfEmployees <= 300);

            var londonCompanies = companies.WhereEquals("London", company => company.Address);

            var whiteDirectorCompanies = companies.WhereEndsWith("White", company => company.DirectorFullName.Split().Last());

            var foundedMoreThanTwoYearsAgo = companies.Where(company => (DateTime.Now - company.FoundationDate).TotalDays > 730);

            var founded123DaysAgo = companies.Where(company => (DateTime.Now - company.FoundationDate).TotalDays == 123);

            var directorSmithAndCompanyNameContainsWhite = companies.WhereAll(new[] { "Smith", "White" }, company => company.DirectorFullName.Split().Last(), company => company.Name);
        }
    }

    static class CompanyExtensions
    {
        public static IQueryable<Company> WhereContains(this IQueryable<Company> source, string value, Func<Company, string> selector)
        {
            return source.Where(company => selector(company).Contains(value));
        }

        public static IQueryable<Company> WhereEquals(this IQueryable<Company> source, string value, Func<Company, string> selector)
        {
            return source.Where(company => selector(company) == value);
        }

        public static IQueryable<Company> WhereAny(this IQueryable<Company> source, string[] values, Func<Company, string> selector)
        {
            return source.Where(company => values.Contains(selector(company)));
        }

        public static IQueryable<Company> WhereEndsWith(this IQueryable<Company> source, string value, Func<Company, string> selector)
        {
            return source.Where(company => selector(company).EndsWith(value));
        }

        public static IQueryable<Company> WhereAll(this IQueryable<Company> source, string[] values, Func<Company, string> selector1, Func<Company, string> selector2)
        {
            return source.Where(company => values.All(value => selector1(company) == value) && selector2(company).Contains(values.Last()));
        }
    }
}
