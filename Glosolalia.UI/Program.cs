using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Glosolalia.UI
{
    public class Program
    {
        static void Main(string[] args)
        {
            StartConsoleProgram();

        }

        private static void StartConsoleProgram()
        {
            ManualyUpdateDB();
        }

        private static void ManualyUpdateDB()
        {
            Console.WriteLine(@"you are in console to manually operate datbase.
Insert l to operate on Languages: ");
            var userInput = Console.ReadLine();
            if (userInput=="l")
            {
                
            }
        }

        private static void InsertLanguage()
        {
            //using (var context = new GlosolaliaContext())
            //{
            //    var ang = new Language();
            //    ang.Name = "English";
            //    var pl = new Language();
            //    pl.Name = "Polish";
            //    context.Languages.Add(pl);
            //    context.Languages.Add(ang);
            //    context.SaveChanges();

            //}
        }
    }
}
