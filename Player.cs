using System;

[Serializable]
public class Player
{
    public int Id;
    public string Name;
    public string Email;
    public string Username;
    public string Password;

    public Player()
    {

    }

    public Player(int id, string name, string email, string username, string password)
    {
        Id = id;
        Name = name;
        Email = email;
        Username = username;
        Password = password;
    }
}
