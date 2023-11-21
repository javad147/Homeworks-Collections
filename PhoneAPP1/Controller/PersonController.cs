using System;

public class PersonController
{
    private DataDbContext dbContext;
    private PersonServices personServices;

    public PersonController()
    {
        dbContext = new DataDbContext();
        personServices = new PersonServices(dbContext);
    }

    public void AddPerson(string firstName, string lastName, string phoneNumber)
    {
        var newPerson = new Person { FirstName = firstName, LastName = lastName, PhoneNumber = phoneNumber };
        personServices.AddPerson(newPerson);
        Console.WriteLine($"Person added. ID: {newPerson.Id}");
    }

    public void RemovePerson(int personId)
    {
        personServices.RemovePerson(personId);
        Console.WriteLine("Person removed.");
    }

    public void UpdatePerson(int personId, string firstName, string lastName, string phoneNumber)
    {
        var updatedPerson = new Person { FirstName = firstName, LastName = lastName, PhoneNumber = phoneNumber };
        personServices.UpdatePerson(personId, updatedPerson);
        Console.WriteLine("Person updated.");
    }

    public void ListPersons()
    {
        Console.WriteLine("Persons:");
        foreach (var person in personServices.GetAllPersons())
        {
            Console.WriteLine($"ID: {person.Id}, First Name: {person.FirstName}, Last Name: {person.LastName}, Phone Number: {person.PhoneNumber}");
        }
    }

    public void SearchPersons(string keyword)
    {
        Console.WriteLine("Search Results:");
        foreach (var person in personServices.SearchPersons(keyword))
        {
            Console.WriteLine($"ID: {person.Id}, First Name: {person.FirstName}, Last Name: {person.LastName}, Phone Number: {person.PhoneNumber}");
        }
    }
}
