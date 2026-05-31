using System;
using System.Collections.Generic;
using System.Threading;
		
public class Car
{
	public string Nazwa{get; set;}
	public int Dystans{get; set;}
	
	public Car(string def_nazwa)
	{
		Nazwa = def_nazwa;
		Dystans = 0;
	}
}
public class Track
{
	public string Nazwa{get; set;}
	public int Dlugosc{get; set;}
	
	public Track(string def_nazwa, int def_dlugosc)
	{
		Nazwa = def_nazwa;
		Dlugosc = def_dlugosc;
	}
}
public class Race
{
	public Track Tor{get; set;}
	public Car Auto1{get; set;}
	public Car Auto2{get; set;}
	public LapTimer Stoper{get; set;}
		
	public Race(Track def_tor, Car def_auto1, Car def_auto2)
	{
		Tor = def_tor;
		Auto1 = def_auto1;
		Auto2 = def_auto2;
		Stoper = new LapTimer();
	}
}
public class LapTimer
{
	public int Czas{get; set;}
	
	public LapTimer()
	{
		Czas = 0;	
	}
}

public class Program
{
	public static void Main()
	{
		//START Sekcja wyboru 2 aut do wyścigu 
		Console.Clear();
		List<string> listaaut = new List<string> {"Ferrari F40", "Mclaren F1", "Mazda 787B", "Lamborghini Diablo SV", "Porsche 911"};
		Console.WriteLine("Dostepne auta:");
		for (int i = 0; i < listaaut.Count; i++)
			{
				Console.WriteLine((i + 1) + " - " + listaaut[i]);
			}
		Console.WriteLine();
		Console.Write("Wybierz pierwsze auto (1-5): ");
		int numer1 = Convert.ToInt32(Console.ReadLine());
		string nazwawybor1 = listaaut[numer1 - 1];
		Car auto1 = new Car(nazwawybor1);
		listaaut.RemoveAt(numer1 - 1);
		Console.Clear();
		
		Console.WriteLine("Wybrane auto nr1: " + auto1.Nazwa);
		Console.WriteLine();
		Console.WriteLine("Dostepne auta:");
		for (int i = 0; i < listaaut.Count; i++)
			{
				Console.WriteLine((i + 1) + " - " + listaaut[i]);
			}
		Console.WriteLine();
		Console.Write("Wybierz drugie auto (1-4): ");
		int numer2 = Convert.ToInt32(Console.ReadLine());
		string nazwawybor2 = listaaut[numer2 - 1];
		Car auto2 = new Car(nazwawybor2);
		listaaut.RemoveAt(numer2 - 1);
		Console.Clear();
		//END Sekcja wyboru 2 aut do wyścigu
		
		//START Sekcja wyboru toru
		Console.Clear();
		Console.WriteLine("Wybrane auta: " + auto1.Nazwa + " oraz " + auto2.Nazwa);
		Console.WriteLine();
		Console.WriteLine("Dostępne Tory");
		Console.WriteLine("1. Nordschleife (20832m)");
        Console.WriteLine("2. Spa-Francorchamps (7004m)");
        Console.WriteLine("3. Monza (5793m)");
        Console.WriteLine();
        Console.Write("Wybierz tor (1-3): ");
		
		int numertoru = Convert.ToInt32(Console.ReadLine());
		Track wybranytor = null;
		switch (numertoru)
		{
		    case 1:
		        wybranytor = new Track("Nordschleife", 20832);
		        break;
		    case 2:
		        wybranytor = new Track("Spa-Francorchamps", 7004);
		        break;
		    case 3:
		        wybranytor = new Track("Monza", 5793);
		        break;
		    default:
                wybranytor = new Track("Nordschleife", 20832);
                break;
		}
		//END Sekcja wyboru toru
		
		//START Sekcja wyboru liczby okrazen
		Console.Clear();
		Console.WriteLine();
		Console.Write("Podaj liczbe okrazen (1-...): ");
		int liczbaokrazen = Convert.ToInt32(Console.ReadLine());
		//END Sekcja wyboru liczby okrazen
		
		//START Sekcja podsumowanie przed wyscigiem   
		Race glownywyscig = new Race(wybranytor, auto1, auto2);
		Console.Clear();
		Console.WriteLine("Wybrany tor: " + wybranytor.Nazwa + " " + wybranytor.Dlugosc + "m");
		Console.WriteLine("Wybrane auta: " + auto1.Nazwa + " oraz " + auto2.Nazwa);
		
		int calkowitydystans = glownywyscig.Tor.Dlugosc * liczbaokrazen;
		Console.WriteLine("Ilosc okrazen: " + liczbaokrazen);
		Console.WriteLine("Całkowity dystans wyscigu: " + calkowitydystans + "m");
		//END Sekcja podsumowanie przed wyscigiem
		
		//START Sekcja wyscig
		Console.WriteLine("\nNaciśnij ENTER, aby rozpocząć wyścig!");
		Console.ReadLine();
		
		Random losowanie = new Random();
		
        while(glownywyscig.Auto1.Dystans < calkowitydystans && glownywyscig.Auto2.Dystans < calkowitydystans)
		{
			glownywyscig.Stoper.Czas++;
		
			int ruchauto1 = losowanie.Next(50, 550);
			int ruchauto2 = losowanie.Next(50, 550);
		
			glownywyscig.Auto1.Dystans += ruchauto1;
			glownywyscig.Auto2.Dystans += ruchauto2;
		
			Console.Clear();
			Console.WriteLine("=== WYŚCIG ===");
			Console.WriteLine("Czas wyścigu: " + glownywyscig.Stoper.Czas + "s\n");

			int okrazauto1 = (glownywyscig.Auto1.Dystans / wybranytor.Dlugosc) + 1;
			int okrazauto2 = (glownywyscig.Auto2.Dystans / wybranytor.Dlugosc) + 1;
			
			int dystansauto1 = glownywyscig.Auto1.Dystans % wybranytor.Dlugosc;
			int dystansauto2 = glownywyscig.Auto2.Dystans % wybranytor.Dlugosc;

			Console.WriteLine(glownywyscig.Auto1.Nazwa);
			Console.WriteLine("Okrążenie: " + okrazauto1 + "/" + liczbaokrazen + " | Dystans: " + dystansauto1 + "m / " + wybranytor.Dlugosc + "m\n");

			Console.WriteLine(glownywyscig.Auto2.Nazwa);
			Console.WriteLine("Okrążenie: " + okrazauto2 + "/" + liczbaokrazen + " | Dystans: " + dystansauto2 + "m / " + wybranytor.Dlugosc + "m");

			Thread.Sleep(1000);
		}
		//END Sekcja wyscig
		
		//START Sekcja wyniki
        Console.WriteLine("\n=== KONIEC WYŚCIGU ===");
		
		if (glownywyscig.Auto1.Dystans >= calkowitydystans)
		{
			Console.WriteLine("Zwycięzca: " + glownywyscig.Auto1.Nazwa);
		}
		else
		{
			Console.WriteLine("Zwycięzca: " + glownywyscig.Auto2.Nazwa);
		}
		
		Console.WriteLine("Czas całkowity: " + glownywyscig.Stoper.Czas + "s");
		//END Sekcja wyniki
		}
		
	}
