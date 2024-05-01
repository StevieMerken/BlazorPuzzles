namespace Puzzle13.Data;

public static class PersonManager
{
    private static List<dtoPerson> people = new();
    
    public static List<dtoPerson> GetAllPeople()
    {
        if (people.Count == 0)
        {
            var peopleFile = $"{Environment.CurrentDirectory}\\Data\\people.json";
            if (!File.Exists(peopleFile)) 
                return people;
            var json = File.ReadAllText(peopleFile);
            var allPeople = JsonSerializer.Deserialize<List<dtoPerson>>(json);
            people.AddRange(allPeople);
        }
        return people;
    }
}
