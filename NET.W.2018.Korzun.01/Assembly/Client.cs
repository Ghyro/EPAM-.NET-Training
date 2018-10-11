using System;
using Animal;

class Program
{
    static void Main()
    {
	//pet.netmodule
        Pet obj2 = new Pet();
	obj2.PetInfo();
	
	Cat obj1 = new Cat();
	obj1.CatInfo();
	
	Console.ReadLine();
	
    }
}