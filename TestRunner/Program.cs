// See https://aka.ms/new-console-template for more information
using LocationMap.GameManagement;
using LocationMap.PhysicalEntities.Animals;

Console.WriteLine("Hello, World!");


GameManager.Init();



GameManager gameManager = GameManager.Instance;

gameManager.RunNavigationTest();

//gameManager.LoadDefinitions();

Console.WriteLine("");
Console.WriteLine("#############################################");
Console.WriteLine("Generate animals");
Console.WriteLine("----------------");
Console.WriteLine("");

for(int i =0; i < 10; i++)
{
    Animal_Attributes aa = new();
    aa.GenerateHumanPotential();


    Console.WriteLine("");
    Console.WriteLine($"Sex: \t{aa.Sex}");
    Console.WriteLine($"Height: \t{aa.Height}");
    Console.WriteLine($"Weight: \t{aa.Weight}");
    Console.WriteLine("");
    Console.WriteLine("----------------");

}


Console.WriteLine("");
Console.WriteLine("#############################################");
Console.WriteLine("");
Console.ReadLine();