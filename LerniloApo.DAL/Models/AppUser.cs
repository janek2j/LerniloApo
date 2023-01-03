namespace LerniloApo;

public sealed class AppUser
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public DateTime CreatedDate { get; set; }
    public List<Deck> Decks { get; set; } = new();
}
