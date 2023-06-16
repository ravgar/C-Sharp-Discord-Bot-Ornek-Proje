using System;
using System.Collections.Generic;
using System.Threading;

class Program
{
    static List<Bot> botList = new List<Bot>();
    static bool isRunning = true;

    static void Main(string[] args)
    {
        string[] botTokens = { "TOKEN1", "TOKEN2", "TOKEN3" };

        foreach (string token in botTokens)
        {
            Bot bot = new Bot(token);
            botList.Add(bot);
            bot.Start();
        }

        while (isRunning)
        {
            string command = Console.ReadLine();
            if (command == "stop")
            {
                isRunning = false;
                StopAllBots();
            }
        }

        Console.WriteLine("Program Terminali");
    }

    static void StopAllBots()
    {
        foreach (Bot bot in botList)
        {
            bot.Stop();
        }
    }
}

class Bot
{
    private string token;
    private Thread botThread;

    public Bot(string token)
    {
        this.token = token;
    }

    public void Start()
    {
        botThread = new Thread(Run);
        botThread.Start();
    }

    public void Stop()
    {

        botThread.Join();
    }

    private void Run()
    {
    
    }
}
