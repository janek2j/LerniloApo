namespace LerniloApo
{
    public sealed class Card
    {
        public int Id { get; set; }
        public int DeckId { get; set; }
        public string Front { get; set; }
        public string Back { get; set; }
        public string Extra { get; set; } = "";
        public string? Image { get; set; } = null;
        public List<string> Tags { get; set; } = new List<string>();
        public DateTime CreatedOn { get; set; }
        public int EaseFactor { get; set; } = 250;
        public int? IntervalModifier { get; set; } = null;
    }
}
