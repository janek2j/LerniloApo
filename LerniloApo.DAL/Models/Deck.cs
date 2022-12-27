namespace LerniloApo
{
    public sealed class Deck
    {
        public int Id { get; set; }
        public int AppUserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } = "";
        public List<Card> Cards { get; set; } = new List<Card>();

        public Deck(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
