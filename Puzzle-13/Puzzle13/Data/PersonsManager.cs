namespace Puzzle13.Data;

public static class PersonsManager
{
    private static List<Person> people = new();
    
    public static List<Person> GetAllPeople()
    {
        if (people.Count == 0)
        {
            var peopleFile = $"{Environment.CurrentDirectory}\\Data\\people.json";
            if (!File.Exists(peopleFile)) 
                return people;
            var json = File.ReadAllText(peopleFile);
            var allPeople = JsonSerializer.Deserialize<List<Person>>(json);
            people.AddRange(allPeople);
        }
        return people;
    }
}
