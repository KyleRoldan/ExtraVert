using System.Numerics;
using System.Xml.Serialization;

List<Plant> plants = new List<Plant>()
{

new Plant()
{
Species= "Hidranga",
LightNeeds = 1.5,
AskingPrice = 25.00M,
City = "Boston",
Zip = 02118,
Sold = false,
AvailableUntil = new DateTime(2022, 10, 20),
},

new Plant()
{
Species= "Palm",
LightNeeds = 5.8,
AskingPrice = 75.00M,
City = "South Boston",
Zip = 02222,
Sold = false,
AvailableUntil = new DateTime(2022, 10, 20),
},

new Plant()
{
Species= "Spider",
LightNeeds = 4.8,
AskingPrice = 15.00M,
City = "Charlestown",
Zip = 02111,
Sold = true,
AvailableUntil = new DateTime(2023, 07, 13),
},
new Plant()
{
Species= "Pothos",
LightNeeds = 0.8,
AskingPrice = 10.00M,
City = "Brookline",
Zip = 02446,
Sold = true,
AvailableUntil = new DateTime(2021, 09, 21),
},
new Plant()
{
Species= "Nasturtium",
LightNeeds = 6.3,
AskingPrice = 34.00M,
City = "Fenway",
Zip = 02112,
Sold = false,
AvailableUntil = new DateTime(2022, 11, 22),
},


};

Random random = new Random();


/////////////Greeting////////////////
string greeting = @"Welcome to the ExtraVert Plant APP!";
/////////////////////////////////////

Console.WriteLine (greeting);
//////////////////////////////////////


while (true)
{
    Console.WriteLine(@"Choose an option:
                        0. Exit
                        1. Display All Plants
                        2. Post a Plant for adoption
                        3. Adopt a Plant
                        4. De-List a Plant
                        5. Random Plant of the Day!
                        6. Search for a Plant
                        7. Display APP Statistics
                        ");

    string choice = Console.ReadLine()?.Trim();

    Console.Clear();

    if (string.IsNullOrEmpty(choice))
    {
        Console.WriteLine("You didn't choose anything!");
    }
    else
    {
        try
        {
            switch (choice)
            {
                case "0":
                    GoodByeGreeting();
                    break;
                case "1":
                    DisplayAllPlants();
                    break;
                case "2":
                    PostPlantForAdoption();
                    break;
                case "3":
                    AdoptPlant();
                    break;
                case "4":
                    DeListPlant();
                    break;
                case "5":
                    DisplayRandomPlantDetails();
                    break;
                case "6":
                    SearchForPlant();
                    break;
                case "7":
                    DisplayAppStatistics();
                    break;


                default:
                Console.WriteLine("Invalid choice. Please choose a valid option.");
                    break;
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Please type only integers!");
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Please choose an existing item only!");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            Console.WriteLine("Do Better!");
        }
    }
}


/////////////////////////////////////////////////////////////////////////////////

 void GoodByeGreeting()
{
    Console.WriteLine(@"Are you sure you want to exit?
                    0. Yes
                    1. No");

    string goodByeChoice = Console.ReadLine();

 Console.Clear();
 
    if (goodByeChoice == "0")
    {
        Console.WriteLine("Goodbye!");
        Environment.Exit(0);
    }
    else if (goodByeChoice == "1")
    {
       
        Console.WriteLine(greeting);
       goodByeChoice=null;
    }
}

///////////////////////////////////////////////////////////////////////////////////////////////////////

void DisplayAllPlants()
{
    
for (int i = 0; i < plants.Count; i++)
{
    
    Console.WriteLine($"{i + 1}. {PlantDetails(plants[i])}");
}

}

//////////////////////////////////////////////////////////////////////////////////////////////////////

void PostPlantForAdoption()
{
    Console.WriteLine("Enter plant details:");

    Console.Write("Species: ");
    string species = Console.ReadLine();

    Console.Write("Light Needs (on a scale of 1-5): ");
    double lightNeeds;
    while (!double.TryParse(Console.ReadLine(), out lightNeeds) || lightNeeds < 1.0 || lightNeeds > 5.0)
    {
        Console.WriteLine("Invalid input. Please enter a valid number for Light Needs.");
        Console.Write("Light Needs: ");
    }

    Console.Write("Asking Price: ");
    decimal askingPrice;
    while (!decimal.TryParse(Console.ReadLine(), out askingPrice))
    {
        Console.WriteLine("Invalid input. Please enter a valid number for Asking Price.");
        Console.Write("Asking Price: ");
    }

    Console.Write("City: ");
    string city = Console.ReadLine();

    Console.Write("Zip: ");
    int zip;
    while (!int.TryParse(Console.ReadLine(), out zip)|| zip.ToString().Length != 5)
    {
        Console.WriteLine("Invalid input. Please enter a valid number for Zip.");
        Console.Write("Zip: ");
    }

    Console.Write("Year of Expiration: ");
    int year;
    while (!int.TryParse(Console.ReadLine(), out year) || year <2022 || year > (DateTime.Now.Year + 5))
    {
        Console.WriteLine("Invalid input. Please enter a valid number for the Year.");
        Console.Write("Year: ");
    }

    Console.Write("Month Of Expiration:");
    int month;
    while (!int.TryParse(Console.ReadLine(), out month)|| month <1 || month > 12)
    {
        Console.WriteLine("Invalid input. Please enter a valid number for the Year.");
        Console.Write("Month: ");

    }

    Console.Write("Day of Expiration:");
    int day;
    while(!int.TryParse(Console.ReadLine(), out day)|| day < 1 || day > 31)
    {
        Console.WriteLine("Invalid input. Please enter a valid number between 1 and 31 for the Day.");
        Console.Write("Day:");
    }


    DateTime availableUntil = new DateTime(year, month, day);

    // Create a new Plant object 
    Plant newPlant = new Plant()
    {
        Species = species,
        LightNeeds = lightNeeds,
        AskingPrice = askingPrice,
        City = city,
        Zip = zip,
        Sold = false,
        AvailableUntil = availableUntil,
    };

    // Add the newPlant object to the plants List
    plants.Add(newPlant);

    Console.WriteLine("Plant posted for adoption. Press enter to continue.");
    Console.ReadLine();
}
/////////////////////////////////////////////////////////////////////////////////////
void AdoptPlant()
{
    Console.WriteLine("Available Plants for Adoption:");

     // create a new empty List to store the latest products
    List<Plant> availablePlants = new List<Plant>();
   
    //loop through the products
    foreach (Plant plant in plants)
    {
        //Add a product to latestProducts if it fits the criteria
        if (!plant.Sold && plant.AvailableUntil > DateTime.Now)
        {
            availablePlants.Add(plant);
            Console.WriteLine($"{availablePlants.Count}. {plant.Species}");
        }
    }
    // print out the latest products to the console 
    for (int i = 0; i < availablePlants.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {availablePlants[i].Species}");
    }
    // Ask the user to choose a plant
    Console.Write("Enter the number of the plant you want to adopt (0 to cancel): ");
    if (int.TryParse(Console.ReadLine(), out int adoptionChoice))
    {
        if (adoptionChoice >= 1 && adoptionChoice <= availablePlants.Count)
        {
            // Update the Sold property of the chosen plant
            Plant chosenPlant = availablePlants[adoptionChoice - 1];
            chosenPlant.Sold = true;

            Console.WriteLine($"You have adopted {chosenPlant.Species}. Press enter to continue.");
            Console.ReadLine();
        }
        else if (adoptionChoice == 0)
        {
            Console.WriteLine("Adoption canceled. Press enter to continue.");
            Console.ReadLine();
        }
        else
        {
            Console.WriteLine("Invalid choice. Press enter to continue.");
            Console.ReadLine();
        }
    }
    
}

////////////////////////////////////////////////////////////////////////////////////////

void DeListPlant()
{
   
    Console.WriteLine("Choose a plant to de-list:");

    for (int i = 0; i < plants.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {plants[i].Species}");
    }

    // Ask the user to choose a plant
    Console.Write("Enter the number of the plant you want to de-list (0 to cancel): ");
    if (int.TryParse(Console.ReadLine(), out int deListChoice))
    {
        if (deListChoice >= 1 && deListChoice <= plants.Count)
        {
            // Remove the chosen plant from the list
            plants.RemoveAt(deListChoice - 1);

            Console.WriteLine("Plant de-listed. Press enter to continue.");
            Console.ReadLine();
        }
        else if (deListChoice == 0)
        {
            Console.WriteLine("De-listing canceled. Press enter to continue.");
            Console.ReadLine();
        }
        else
        {
            Console.WriteLine("Invalid choice. Press enter to continue.");
            Console.ReadLine();
        }
    }
    else
    {
        Console.WriteLine("Invalid input. Press enter to continue.");
        Console.ReadLine();
    }
}
/////////////////////////////////////////////////////////////////////////////////////////

void DisplayRandomPlantDetails()
{
    
    Plant selectedPlant;
    
    do
    {
        int randomIndex = random.Next(0, plants.Count);
        selectedPlant = plants[randomIndex];
    } while (!selectedPlant.Sold);

    Console.WriteLine($"Randomly Selected Plant Details:");
    Console.WriteLine($"Species: {selectedPlant.Species}");
    Console.WriteLine($"Location: {selectedPlant.City}, Zip: {selectedPlant.Zip}");
    Console.WriteLine($"Light Needs: {selectedPlant.LightNeeds}");
    Console.WriteLine($"Asking Price: {selectedPlant.AskingPrice:C}");
}

void SearchForPlant()
{
    Console.WriteLine("Plant Search");

    Console.Write("Please Enter a Maximum Light Needs (between 1 and 5): ");
    if (double.TryParse(Console.ReadLine(), out double maxLightNeeds))
    {
        if (maxLightNeeds < 1 || maxLightNeeds > 5)
        {
            Console.WriteLine("Invalid input. Light Needs should be between 1 and 5.");
            Console.ReadLine();
            return;
        }

        List<Plant> searchResults = new List<Plant>();

        // Loop through the plants and add those that meet the light needs criteria to the searchResults list
        foreach (Plant plant in plants)
        {
            if (!plant.Sold && plant.LightNeeds <= maxLightNeeds)
            {
                searchResults.Add(plant);
            }
        }

        // Display search results
        Console.WriteLine($"Plants with Light Needs <= {maxLightNeeds}:");
        for (int i = 0; i < searchResults.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {searchResults[i].Species} in {searchResults[i].City} for {searchResults[i].AskingPrice:C}");
        }

        Console.WriteLine("Press enter to continue.");
        Console.ReadLine();
    }
    else
    {
        Console.WriteLine("Invalid input. Please enter a valid number for Light Needs.");
        Console.ReadLine();
    }
}
/////////////////////////////////////////////////////////////////////////////////////////

void DisplayAppStatistics()
{
Console.WriteLine("App Statistics");
    Console.WriteLine("---------------");

    DisplayLowestPricePlant();
    DisplayNumberOfPlantsAvailable();
    DisplayPlantWithHighestLightNeeds();
    DisplayAverageLightNeeds();
    DisplayPercentageOfPlantsAdopted();

    Console.WriteLine("Press enter to continue.");
    Console.ReadLine();
}

void DisplayLowestPricePlant()
{
    decimal lowestPrice = decimal.MaxValue;
    string lowestPricePlantName = null;

    foreach (var plant in plants)
    {
        if (plant.AskingPrice < lowestPrice)
        {
            lowestPrice = plant.AskingPrice;
            lowestPricePlantName = plant.Species;
        }
    }

    Console.WriteLine($"Lowest Price Plant: {lowestPricePlantName} - {lowestPrice:C}");
}

void DisplayNumberOfPlantsAvailable()
{
    int numberOfPlantsAvailable = 0;

    foreach (var plant in plants)
    {
        if (!plant.Sold && plant.AvailableUntil > DateTime.Now)
        {
            numberOfPlantsAvailable++;
        }
    }

    Console.WriteLine($"Number of Plants Available: {numberOfPlantsAvailable}");
}

void DisplayPlantWithHighestLightNeeds()
{
    double highestLightNeeds = double.MinValue;
    string plantWithHighestLightNeedsName = null;

    foreach (var plant in plants)
    {
        if (plant.LightNeeds > highestLightNeeds)
        {
            highestLightNeeds = plant.LightNeeds;
            plantWithHighestLightNeedsName = plant.Species;
        }
    }

    Console.WriteLine($"Plant with Highest Light Needs: {plantWithHighestLightNeedsName} - {highestLightNeeds}");
}

void DisplayAverageLightNeeds()
{
    double totalLightNeeds = 0;

    foreach (var plant in plants)
    {
        totalLightNeeds += plant.LightNeeds;
    }

    double averageLightNeeds = totalLightNeeds / plants.Count;

    Console.WriteLine($"Average Light Needs: {averageLightNeeds}");
}

void DisplayPercentageOfPlantsAdopted()
{
    int adoptedCount = 0;

    foreach (var plant in plants)
    {
        if (plant.Sold)
        {
            adoptedCount++;
        }
    }

    double percentageOfPlantsAdopted = (double)adoptedCount / plants.Count * 100;

    Console.WriteLine($"Percentage of Plants Adopted: {percentageOfPlantsAdopted:F2}%");
}


string PlantDetails(Plant plant)
{
    string availabilityStatus = plant.Sold ? "was sold" : "is available";
    string formattedPrice = $"{plant.AskingPrice:C}";
    string plantCity = $"{plant.City}";
    string plantSpecies = $"{plant.Species}";

    string plantString = $"{plantSpecies} in {plantCity} {availabilityStatus} for {formattedPrice}. It expires {plant.AvailableUntil}";

    return plantString;
}









