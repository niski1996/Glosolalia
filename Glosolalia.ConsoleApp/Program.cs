// See https://aka.ms/new-console-template for more information
using Glosolalia.Buisness.Entities;
using Glosolalia.Data;

Console.WriteLine("Hello, World!");
var wrd = new EnWord();
wrd.Value = "ddddd";
var tmp = new EnWordRepository();
tmp.Add(wrd);
Console.WriteLine("Hello, World!");

