using System;
using System.IO;
using DocumentFormat.OpenXml.Drawing.Charts;
using Glosolalia.Common.Entities;
using Glosolalia.Data;

class Program
{
	static void Main()
	{
		//try
		//{
		//	Language l1 = new Language() { Name = "Spanish", WordSet = new() };
		//	Language l2 = new Language() { Name = "Polish", WordSet = new() };
		//	Language l3 = new Language() { Name = "English", WordSet = new() };
		//	LanguageRepository lr = new();
		//	lr.Add(l1);
		//	lr.Add(l2);
		//	lr.Add(l3);

		//}
		//catch (Exception)
		//{
		//}
		try
		{
			LanguageRepository lr = new();
			var tmp = lr.GetAll();
			Language pl = tmp.FirstOrDefault(a => a.Name == "Polish");
			Language sp = tmp.FirstOrDefault(a => a.Name == "Spanish");
			

			string sciezkaPliku = @"C:\Users\Mój komputer\Desktop\inputy hiszpańskie\input 2.txt";
		

			string[] linie = File.ReadAllLines(sciezkaPliku);
			linie = linie.Where(linia => !string.IsNullOrWhiteSpace(linia)).ToArray();
			foreach (string linia in linie)
			{

				string[] list = linia.Split('-');
				Word spwrd = new Word() { Value = list[0].Trim().ToLower(), LanguageId = sp.Id };
				Word plwrd = new Word() { Value = list[1].Trim().ToLower(), LanguageId = pl.Id };
				//Word spwrd = new Word() { Value = "gotować", LanguageId = sp.Id };
				//Word plwrd = new Word() { Value = "cocinar", LanguageId = pl.Id };
				Translation translation = new Translation();
				translation.TranslatableSet = new()
				{
					//WordRepository wr = new();
					//wr.Add(plwrd);
					//wr.Add(spwrd);


					//translation.LanguageSet.Add(l1);
					//translation.LanguageSet.Add(l2);
					spwrd,
					plwrd
				};
				TranslationRepository tr = new();
				tr.AddRelationalTranslation(translation);
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
