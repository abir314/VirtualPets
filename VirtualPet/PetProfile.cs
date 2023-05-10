namespace VirtualPet;

public class PetProfile
{
    public static string[] foods = new[] { "Banan", "Blåbær", "Kjøtt", "Melk" };
    public string Name { get; private set; }
    public int Age { get; private set; }
    public string Color { get; private set; }
    public string Type { get; private set; }
    public string FavoriteFood = favoriteFood();
    public List<PetProfile> listOfPets = new List<PetProfile>();

    public PetProfile(string name, int age, string color, string type)
    {
        Name = name;
        Age = age;
        Color = color;
        Type = type;
    }

    public PetProfile(string name, string color, string type)
    {
        Name = name;
        Color = color;
        Type = type;
    }


    static string favoriteFood()
    {
        //var random = new Random();
        var index = new Random().Next(0, foods.Length);
        return foods[index];
    }
}
