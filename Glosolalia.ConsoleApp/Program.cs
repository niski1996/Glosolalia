// See https://aka.ms/new-console-template for more information
using System.Collections.Generic;
using Glosolalia.Buisness.Entities;
using Glosolalia.Data;

internal class Program
{
    private static void Main(string[] args)
    {
        loadNecesseryDB();
    }

    static void Start()
    {
        string intro = @"Jeżeli chcesz się:
            Uczyć : Wrpowadź U              Dodawać : Wprowadź D
            a następnie zatwierdź klawiszem Enter";
        Console.WriteLine(intro);
        var input = Console.ReadLine().ToLower().Trim();
        if (input=="u")
        {

        }
        else if (input=="d") 
        {
            loadNecesseryDB();
        }
        else
        {
            Console.WriteLine("zły input");
        }
        
    }

    private static void loadNecesseryDB()
    {
        addLang();
        Console.WriteLine("Dostepne jezyki, wybierz numer");
        int iter = 1;
        var langList = loadLanguages();
        foreach (var lan in langList)
        {
            Console.WriteLine($@"{iter}. {lan.Name}");
        }
       
    }

    private static void addLang()
    {
        new LanguageRepository().Add(new Language("turecki"));
    }

    private static List<Language> loadLanguages()
    {
        return  new LanguageRepository().GetAll().ToList();
    }
}

    


