using System;
namespace Visitor
{
    public interface IVisitor
    {
        void VisitPerson(Person person);
        void VisitCompany(Company company);
    }

    public class ToXml: IVisitor
    {
        public void VisitPerson(Person person)
        {
            string xml = "<article lang = \"\">\n";
            xml += $"<para>Person name: {person.Name}</para>\n";
            xml += $"<para>Account: {person.Account}</para>\n";
            xml += "</article>\n";

            Console.WriteLine(xml);
        }

        public void VisitCompany(Company company)
        {
            string xml = "<article lang = \"\">\n";
            xml += $"<para>Company name: {company.Name}</para>\n";
            xml += $"<para>Number of Employees: {company.NumberOfEmployees}</para>\n";
            xml += $"<para>Company statement: {company.Statement}</para>\n";
            xml += "</article>\n";

            Console.WriteLine(xml);
        }
    }

    public class ToJson : IVisitor
    {
        public void VisitPerson(Person person)
        {
            string json = "{\n";
            json += $"    \"name\": {person.Name},\n";
            json += $"    \"account\": {person.Account}\n";
            json += "}\n";

            Console.WriteLine(json);
        }

        public void VisitCompany(Company company)
        {
            string json = "{\n";
            json += $"    \"name\": {company.Name},\n";
            json += $"    \"number_of_employees\": {company.NumberOfEmployees},\n";
            json += $"    \"company_statement\": {company.Statement}\n";
            json += "}\n";

            Console.WriteLine(json);
        }
    }

    public interface IAccount
    {
        void Accept(IVisitor visitor);
    }

    public class Person: IAccount
    {
        public string Name { get; private set; }

        public double Account { get; private set; }

        public Person(string name, double account)
        {
            this.Name = name;
            this.Account = account;
        }

        public void Accept(IVisitor visitor)
        {
            visitor.VisitPerson(this);
        }
    }

    public class Company: IAccount
    {
        public string Name { get; private set; }

        public int NumberOfEmployees { get; private set; }

        public double Statement { get; private set; }

        public Company(string name, int count, double statement) 
        {
            this.Name = name;
            this.NumberOfEmployees = count;
            this.Statement = statement;
        }

        public void Accept(IVisitor visitor)
        {
            visitor.VisitCompany(this);
        }
    }
}
