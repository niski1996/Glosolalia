using Glosolalia.Business;
using Glosolalia.Business.Entities;

var tmp = new TranslationEngine();
EnWord slaveWord;
List<PlWord> translations;
string slaveValue = "dick";
List<string> translationSet = new List<string>{"kutas","penis"};
tmp.WordsAlone(out slaveWord, out translations, slaveValue, translationSet);