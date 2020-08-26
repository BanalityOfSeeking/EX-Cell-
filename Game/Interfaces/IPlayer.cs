namespace EXCell
{
    public interface IPlayer
    {
        string Name { get; }
        int Health { get; }
        Player SetPlayerName(string name);
    }
}