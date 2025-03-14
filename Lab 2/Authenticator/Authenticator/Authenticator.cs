using System;

public class Authenticator
{
    private static Authenticator instance = null;

    private static readonly object lockObj = new object();

    private Authenticator()
    {
        Console.WriteLine("Authenticator created.");
    }

    public static Authenticator GetInstance()
    {
        if (instance == null)
        {
            lock (lockObj)
            {
                if (instance == null)
                {
                    instance = new Authenticator();
                }
            }
        }
        return instance;
    }

    public void Authenticate(string username, string password)
    {
        Console.WriteLine($"Authenticating user: {username}");
    }
}
