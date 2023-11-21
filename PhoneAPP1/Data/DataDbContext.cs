using System.Collections.Generic;

public class DataDbContext
{
    public List<Person> Persons { get; set; }

    public DataDbContext()
    {
        Persons = new List<Person>
        {
            new Person { FirstName = "Javad", LastName = "Bakirli", PhoneNumber = "0552221069" },
        };
    }
}
