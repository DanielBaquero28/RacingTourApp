using System;

// Serializable allows the serialization and deserialization of the variables
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
	// Having an empty constructor ensures that an instance is created no matter what (User didn't fill it's information)
    }

    // Player Constructor
    public Player(Guid id, string name, string email, string username, float bestTime)
    {
        Id = id;
        Name = name;
        Email = email;
        Username = username;
        BestTime = bestTime;
    }
}
