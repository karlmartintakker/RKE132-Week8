string folderPath = @"C:\Users\KM\Downloads\data\";
string heroFile = "Heroes.txt";
string villainFile = "Villains.txt";

string[] heroes = File.ReadAllLines(Path.Combine(folderPath, heroFile));
string[] villains = File.ReadAllLines(Path.Combine(folderPath, villainFile));
string[] weapon = { "a sword", "a polearm", "a catalyst", "a claymore", "a bow" };

string hero = GetRandomValueFromArray(heroes);
string heroWeapon = GetRandomValueFromArray(weapon);
int heroHP = GetCharacterHP(hero);
int HeroStrikeStrength = heroHP;
Console.WriteLine($"Today {hero} ({heroHP} HP) with {heroWeapon} saves the day!");


string villain = GetRandomValueFromArray(villains);
string villainWeapon = GetRandomValueFromArray(weapon);
int villainHP = GetCharacterHP(villain);
int VillainStrikeStrength = villainHP;
Console.WriteLine($"Today {villain} ({villainHP} HP) with {villainWeapon} tries to take over the world!");


while (heroHP > 0 && villainHP > 0)
{
    heroHP = heroHP - Hit(villain, VillainStrikeStrength);
    villainHP = villainHP - Hit(hero, HeroStrikeStrength);
}

Console.WriteLine($"{hero} HP:{heroHP}");
Console.WriteLine($"{villain} HP:{villainHP}");

if (heroHP > 0)
{
    Console.WriteLine($"{hero} has saved the day!");
}
else if (villainHP > 0)
{
    Console.WriteLine($"{villain} has won!");
}
else
{
    Console.WriteLine("Draw!");
}
static string GetRandomValueFromArray(string[] someArray)
{
    Random rnd = new Random();
    int randomIndex = rnd.Next(0, someArray.Length);
    string randomStringFromArray = someArray[randomIndex];
    return randomStringFromArray;
}

static int GetCharacterHP(string characterName)
{
    if (characterName.Length < 10)
    {
        return 10;
    }
    else
    {
        return characterName.Length;
    }
}

static int Hit(string characterName, int characterHP)
{
    Random rnd = new Random();
    int strike = rnd.Next(0, characterHP);

    if (strike == 0)
    {
        Console.WriteLine($"{characterName} missed the target!");
    }
    else if (strike == characterHP - 1)
    {
        Console.WriteLine($"{characterName} made a critical hit");
    }
    else
    {
        Console.WriteLine($"{characterName} hit {strike}");
    }
    return strike;

}