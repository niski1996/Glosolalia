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
			Language l1 = new Language() { Name = "Spanish" };
			Language l2 = new Language() { Name = "Polish" };
			Language l3 = new Language() { Name = "English" };
			LanguageRepository lr = new();
			lr.Add(l1);
			lr.Add(l2);
			lr.Add(l3);

		}
		catch (Exception)
		{
		}
		try
		{
			LanguageRepository lr = new();
			var tmp = lr.GetAll();
			Language? pl = tmp.FirstOrDefault(a => a.Name == "Polish");
			Language? sp = tmp.FirstOrDefault(a => a.Name == "Spanish");
			if (pl is null || sp is null)
			{
				throw new NullReferenceException("nie mam takich języków w bazie");
			}
			


			string sciezkaPliku = @"C:\Users\Mój komputer\Desktop\inputy hiszpańskie\latinoamerica.txt";


			string[] linie = File.ReadAllLines(sciezkaPliku);
			linie = linie.Where(linia => !string.IsNullOrWhiteSpace(linia)).ToArray();
			List<Translation> trli = new();
            List<Tag> tags = new() { new Tag { Value="Calle13"},
            new Tag { Value="music"},
            new Tag { Value="lyrucs"},
            new Tag { Value="argentina"},
            new Tag { Value="private"}
            };
            foreach (string linia in linie)
			{
				string[] list = linia.Split('-');
				List<Word> words = new() {
				new Word() { Value = list[0].Trim().ToLower(), LanguageId = sp.Id },
				new Word() { Value = list[1].Trim().ToLower(), LanguageId = pl.Id }
				};
				Translation translation = new Translation
				{
					WordSet = words,
					Tags = tags
				};
				trli.Add(translation);
			}

			Sheet sh = new Sheet() { 
				Name = "Latinoamerica",
			TranslationSet = trli,
			};
			new SheetRepository().Add(sh);


			

	
		}
		catch (Exception ex)
		{
			Console.WriteLine("Wystąpił błąd: " + ex.Message);
		}

		Console.WriteLine("Naciśnij dowolny klawisz, aby zakończyć...");
		Console.ReadKey();
	}
}
