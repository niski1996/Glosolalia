using System;
using System.IO;
using DocumentFormat.OpenXml.Drawing.Charts;
using Glosolalia.Common.Entities;
using Glosolalia.Data;

class Program
{
	static void Main()
	{
		try
		{
			Language l1 = new Language() { Name = "Spanish", TranslationSet = new(), WordSet = new() };
			Language l2 = new Language() { Name = "Polish", TranslationSet = new(), WordSet = new() };

			string sciezkaPliku = @"C:\Users\Mój komputer\Desktop\inputy hiszpańskie\input 2.txt";
		

			string[] linie = File.ReadAllLines(sciezkaPliku);
			linie = linie.Where(linia => !string.IsNullOrWhiteSpace(linia)).ToArray();
			foreach (string linia in linie)
			{
	
				string[] list = linia.Split('-');
				Word spwrd = new Word() { Value = list[0].Trim().ToLower(), LanguageId = 1 };
				Word plwrd = new Word() { Value = list[1].Trim().ToLower(), LanguageId = 2 };
				Translation translation = new Translation();
				translation.LanguageSet = new();
				translation.TranslatableSet= new();
				WordRepository wr = new();
				wr.Add(plwrd);
				
				//translation.LanguageSet.Add(l1);
				//translation.LanguageSet.Add(l2);
				//translation.TranslatableSet.Add(spwrd);
				//translation.TranslatableSet.Add(plwrd);
				//TranslationRepository tr = new();
				//tr.Add(translation);
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine("Wystąpił błąd: " + ex.Message);
		}

		Console.WriteLine("Naciśnij dowolny klawisz, aby zakończyć...");
		Console.ReadKey();
	}
}
