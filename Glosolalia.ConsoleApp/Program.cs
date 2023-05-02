// See https://aka.ms/new-console-template for more information
using System.Collections.Generic;
using Glosolalia.Business.Entities;
using Glosolalia.Data;

internal class Program
{
    private static void Main(string[] args)
    {;
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
        }
        else
        {
            Console.WriteLine("zły input");
        }
        
    }





}

    


