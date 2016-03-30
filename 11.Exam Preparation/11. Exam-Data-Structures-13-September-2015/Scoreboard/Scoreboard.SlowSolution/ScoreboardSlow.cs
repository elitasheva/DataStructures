using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class ScoreboardSlowMain
{
    static void Main()
    {
        var commandExecutor = new ScoreboardCommandSlowExecutor();
        while (true)
        {
            string command = Console.ReadLine();
            if (command == "End")
            {
                break;
            }
            if (command != "")
            {
                string commandResult = commandExecutor.ProcessCommand(command);
                Console.WriteLine(commandResult);
            }
        }
    }
}

public class ScoreboardCommandSlowExecutor
{
    private ScoreboardSlow scoreboard = new ScoreboardSlow();

    public string ProcessCommand(string commandLine)
    {
        var tokens = commandLine.Split(new char[] { ' ' },
            StringSplitOptions.RemoveEmptyEntries);
        var command = tokens[0];
        switch (command)
        {
            case "RegisterUser":
                return RegisterUser(tokens[1], tokens[2]);
            case "RegisterGame":
                return RegisterGame(tokens[1], tokens[2]);
            case "AddScore":
                return AddScore(tokens[1], tokens[2], tokens[3], tokens[4],
                    int.Parse(tokens[5]));
            case "ShowScoreboard":
                return ShowScoreboard(tokens[1]);
            case "DeleteGame":
                return DeleteGame(tokens[1], tokens[2]);
            case "ListGamesByPrefix":
                return ListGamesByPrefix(tokens[1]);
            default:
                return "Incorrect command";
        }
    }

    private string RegisterUser(string username, string userPassword)
    {
        if (this.scoreboard.RegisterUser(username, userPassword))
        {
            return "User registered";
        }

        return "Duplicated user";
    }

    private string RegisterGame(string gameName, string gamePassword)
    {
        if (this.scoreboard.RegisterGame(gameName, gamePassword))
        {
            return "Game registered";
        }

        return "Duplicated game";
    }

    private string AddScore(string username, string userPassword,
        string gameName, string gamePassword, int score)
    {
        if (this.scoreboard.AddScore(username, userPassword,
            gameName, gamePassword, score))
        {
            return "Score added";
        }

        return "Cannot add score";
    }

    private string ShowScoreboard(string gameName)
    {
        var scoreboardEntries = this.scoreboard.ShowScoreboard(gameName);
        if (scoreboardEntries == null)
        {
            return "Game not found";
        }

        if (scoreboardEntries.Any())
        {
            var result = new StringBuilder();
            int counter = 0;
            foreach (var entry in scoreboardEntries)
            {
                counter++;
                result.AppendFormat("#{0} {1} {2}",
                    counter, entry.Username, entry.Score);
                result.AppendLine();
            }
            result.Length -= Environment.NewLine.Length;
            return result.ToString();
        }

        return "No score";
    }

    private string DeleteGame(string gameName, string gamePassword)
    {
        if (this.scoreboard.DeleteGame(gameName, gamePassword))
        {
            return "Game deleted";
        }

        return "Cannot delete game";
    }

    private string ListGamesByPrefix(string namePrefix)
    {
        var matchedGames = this.scoreboard.ListGamesByPrefix(namePrefix);
        if (matchedGames.Any())
        {
            return string.Join(", ", matchedGames);
        }

        return "No matches";
    }
}

public class ScoreboardSlow
{
    private List<Tuple<string, string>> usersPasswords =
        new List<Tuple<string, string>>();
    private List<Tuple<string, string>> gamesPasswords =
        new List<Tuple<string, string>>();
    private List<ScoreboardEntry> scoreboardEntries =
        new List<ScoreboardEntry>();

    public bool RegisterUser(string username, string password)
    {
        if (this.usersPasswords.Select(e => e.Item1).Contains(username))
        {
            return false;
        }

        var userAndPass = new Tuple<string, string>(username, password);
        this.usersPasswords.Add(userAndPass);
        return true;
    }

    public bool RegisterGame(string game, string password)
    {
        if (this.gamesPasswords.Select(e => e.Item1).Contains(game))
        {
            return false;
        }

        var gameAndPass = new Tuple<string, string>(game, password);
        this.gamesPasswords.Add(gameAndPass);
        return true;
    }

    public bool AddScore(string username, string userPassword, 
        string game, string gamePassword, int score)
    {
        var userAndPass = new Tuple<string, string>(username, userPassword);
        if (! this.usersPasswords.Contains(userAndPass))
        {
            return false;
        }

        var gameAndPass = new Tuple<string, string>(game, gamePassword);
        if (!this.gamesPasswords.Contains(gameAndPass))
        {
            return false;
        }

        var scoreboardEntry = new ScoreboardEntry()
        {
            Score = score,
            Username = username,
            Game = game
        };
        this.scoreboardEntries.Add(scoreboardEntry);

        return true;
    }

    public IEnumerable<ScoreboardEntry> ShowScoreboard(string game)
    {
        if (!this.gamesPasswords.Select(e => e.Item1).Contains(game))
        {
            // Game does not exist
            return null;
        }

        var scoreboard = this.scoreboardEntries
            .Where(e => e.Game == game)
            .OrderByDescending(e => e.Score)
            .ThenBy(e => e.Username)
            .Take(10);
        return scoreboard;
    }

    public bool DeleteGame(string game, string gamePassword)
    {
        var gameAndPass = new Tuple<string, string>(game, gamePassword);
        this.scoreboardEntries.RemoveAll(e => e.Game == game);
        return this.gamesPasswords.Remove(gameAndPass);
    }

    public IEnumerable<string> ListGamesByPrefix(string gameNamePrefix)
    {
        return this.gamesPasswords
            .Select(g => g.Item1)
            .OrderBy(g => g)
            .Where(g => g.StartsWith(gameNamePrefix))
            .Take(10);
    }
}

public class ScoreboardEntry : IComparable<ScoreboardEntry>
{
    public int Score { get; set; }
    public string Username { get; set; }
    public string Game { get; set; }

    public int CompareTo(ScoreboardEntry other)
    {
        var result = -this.Score.CompareTo(other.Score);
        if (result == 0)
        {
            result = this.Username.CompareTo(other.Username);
        }
        return result;
    }
}
