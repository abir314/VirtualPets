using System.Runtime.InteropServices.JavaScript;

namespace VirtualPet
{
    class Program
    {
       //static List<PetProfile> listOfPets = new List<PetProfile>();
        static void Main(string[] args)
        {
            List<PetProfile> listOfPets = new List<PetProfile>();
            var dog = new PetProfile("Barky", 5, "Black", "Dog");
            var cat = new PetProfile("Meow", 2, "White", "Cat");
            listOfPets.Add(dog);
            listOfPets.Add(cat);
            while (true)
            {
                Console.WriteLine("1- Choose between pets already in the system ");
                Console.WriteLine("2- Create your own pet.");
                var usersChoice = Convert.ToInt32(Console.ReadLine());
                if (usersChoice == 1)
                {
                    foreach (var pet in listOfPets)
                    {
                        System.Console.WriteLine($"Name: {pet.Name} the {pet.Type}");
                    }

                    Console.WriteLine("Choose a pet by typing the name to see the detail.");
                    var usersInput = Console.ReadLine();
                    PetProfile? selectedPet = NewMethod(listOfPets, usersInput);
                    if(selectedPet == null) continue;
                    Console.WriteLine(
                        $"Name: {selectedPet.Name}, Age: {selectedPet.Age}, Color: {selectedPet.Color}, Type: {selectedPet.Type}");
                    bool isNotFavoriteFood = true;
                    while (isNotFavoriteFood)
                    {   
                        bool isWrongFood = true;
                        int foodChoice = 0;
                        while (isWrongFood)
                        {
                            Console.WriteLine("Feed the pet. Food options are-");
                            for (var index = 0; index < PetProfile.foods.Length; index++)
                            {
                                var food = PetProfile.foods[index];
                                Console.WriteLine($"{index + 1} - {food}");
                            }

                            foodChoice = Convert.ToInt32(Console.ReadLine());
                            if (foodChoice <= PetProfile.foods.Length) isWrongFood = false;
                            else
                            {
                                Console.WriteLine("Wrong input.");
                                isWrongFood = true;
                            }
                        }

                        isNotFavoriteFood = FoodReaction(foodChoice - 1, selectedPet);
                    }

                }
                else if (usersChoice == 2)
                {
                    bool isNotCorrect = false;
                    string petInput;
                    string[] petArray;
                    do
                    {
                        Console.WriteLine("Type in the name, color and type of the pet and separate them with space.");
                        petInput = Console.ReadLine();
                        petArray = petInput.Split(' ');
                        if (petArray.Length != 3)
                        {
                            Console.WriteLine("Wrong input");
                            isNotCorrect = true;
                        }
                        else
                        {
                            isNotCorrect = false;
                        }
                    } while (isNotCorrect);
                    
                    listOfPets.Add(new(petArray[0], petArray[1], petArray[2]));
       
                }
                else continue;
                
            }


        }

        private static bool FoodReaction(int foodIndex, PetProfile pet)
        {
            var food = PetProfile.foods[foodIndex];
            Console.WriteLine(pet.FavoriteFood == food ? "Yum yum, my favorite food!!" : "Thank you for the food, but not my favorite.");
            return food != pet.FavoriteFood;
        }

        private static PetProfile NewMethod(List<PetProfile> listOfPets, string? usersInput)
        {
            PetProfile y = null;
            listOfPets.ForEach(x =>
            {
                if (x.Name == usersInput)  y=x;
            });
            return y;
        }
    }
}