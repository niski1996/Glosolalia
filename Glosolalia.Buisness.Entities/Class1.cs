namespace Glosolalia.Buisness.Entities
{
    public class EnWord : Word
    {

        public List<EnWordPlWord> PlTranslation { get; set; }
    }
    public class EnWordPlWord
    {
        public int IdPlWord { get; set; }
        public int IdEnWord { get; set; }
    }
    public class Language
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
    public class PlWord : Word
    {

        public List<EnWordPlWord> EnTranslation { get; set; }
    }
    public class PartOfSpeech
    {
        public int Id { get; set; }
        public string Value { get; set; }
    }
    public class Tag
    {
        public int Id { get; set; }
        public string Value { get; set; }
    }
    abstract public class Word
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public Language Language { get; set; }
        public PartOfSpeech PartOfSpeech { get; set; }
        public DateTime LastInput { get; set; }
        public int Progress { get; set; }


    }


}