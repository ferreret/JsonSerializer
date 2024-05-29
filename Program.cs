using System.Text.Json;
using Serializer.Helpers;
using Serializer.Models;

var person = new Person {
    Id = 1,
    FirstName = "John",
    LastName = "Doe",
    Age = 30,
    IsAlive = true,
    Address = new Address {
        Street = "123 Elm St",
        City = "Springfield",
        State = "IL",
        PostalCode = "62701"
    },
    PhoneNumbers = new List<Phone> {
        new Phone { Number = "217-555-1212", Type = "Home" },
        new Phone { Number = "217-555-3434", Type = "Work" }
    },
    EyeColor = "Blue"
};

var opt = new JsonSerializerOptions {
    WriteIndented = true,
    // PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
     PropertyNamingPolicy = new LowerCaseNamingPolicy(),
    // IncludeFields = true
};

string jsonString = JsonSerializer.Serialize<Person>(person, opt);
string fileName = "person.json";
await File.WriteAllTextAsync(fileName, jsonString);

Console.WriteLine(File.ReadAllText(fileName));

