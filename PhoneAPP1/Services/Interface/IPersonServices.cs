using System;
using System.Collections.Generic;
using System.Linq;

public class PersonServices
{
    private DataDbContext dbContext;

    public PersonServices(DataDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public void AddPerson(Person person)
    {
        dbContext.Persons.Add(person);
    }

    public void RemovePerson(int personId)
    {
        var person = dbContext.Persons.FirstOrDefault(p => p.Id == personId);
        if (person != null)
        {
            dbContext.Persons.Remove(person);
        }
    }

    public void UpdatePerson(int personId, Person updatedPerson)
    {
        var person = dbContext.Persons.FirstOrDefault(p => p.Id == personId);
        if (person != null)
        {
            person.FirstName = updatedPerson.FirstName;
            person.LastName = updatedPerson.LastName;
            person.PhoneNumber = updatedPerson.PhoneNumber;
        }
    }

    public IEnumerable<Person> GetAllPersons()
    {
        return dbContext.Persons;
    }

    public IEnumerable<Person> SearchPersons(string keyword)
    {
        return dbContext.Persons
            .Where(p => p.FirstName.Contains(keyword, StringComparison.OrdinalIgnoreCase) || p.LastName.Contains(keyword, StringComparison.OrdinalIgnoreCase));
    }
}
