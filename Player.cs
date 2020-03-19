using System;

[Serializable]
public class Player
{
    public Guid Id;
    public string Name;
    public string Email;
    public string Username;

    public float BestTime;

    public Player()
    {

    }

    public Player(Guid id, string name, string email, string username, float bestTime)
    {
        Id = id;
        Name = name;
        Email = email;
        Username = username;
        BestTime = bestTime;
    }
}
