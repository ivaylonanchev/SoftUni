namespace _05.TeamworkProjects
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string end = Console.ReadLine();
            List<Team> teams = new List<Team>();

            while (end != "end of assignment")
            {
                Team team = new Team();

                List<string> list = new List<string>(3);

                string name;
                string teamName;

                int num = 0;
                int num2 = 0;

                if (end.Contains("->"))//Join
                {
                    list = end.Split("->").ToList();
                    name = list[0];
                    teamName = list[1];

                    foreach (Team t in teams)
                    {
                        if (t.Creator == name)
                        {
                            num++;
                            break;
                        }
                        if (t.Member != null)
                        {
                            for (int i = 0; i < t.Member.Count; i++)
                            {
                                if (t.Member[i] == name)
                                {
                                    num++;
                                    break;
                                }
                            }
                        }
                    }

                    if (num > 0)
                    {
                        Console.WriteLine($"Member {name} cannot join team {teamName}!");
                    }
                    else
                    {
                        foreach (Team t in teams)
                        {
                            if (t.TeamName == teamName)
                            {
                                t.Member.Add(name);
                                num2++;
                                break;
                            }
                        }
                    }
                    if (num2 == 0 && num == 0)
                    {
                        Console.WriteLine($"Team {teamName} does not exist!");
                    }
                }
                else if (end.Contains("-"))//Create
                {
                    list = end.Split("-").ToList();
                    name = list[0];
                    teamName = list[1];

                    foreach (Team t in teams)
                    {
                        if (t.TeamName == teamName)
                        {
                            Console.WriteLine($"Team {teamName} was already created!");
                            num++;
                            break;
                        }
                        if (t.Creator == name)
                        {
                            Console.WriteLine($"{name} cannot create another team!");
                            num++;
                            break;
                        }

                    }
                    if (num == 0)
                    {
                        team.TeamName = teamName;
                        team.Creator = name;
                        teams.Add(team);
                        Console.WriteLine($"Team {teamName} has been created by {name}!");
                    }

                }
                num = 0;
                end = Console.ReadLine();
            }
            var regularTeams = teams
            .Where(x => x.Member.Count > 0)
            .OrderByDescending(x => x.Member.Count)
            .ThenBy(x => x.TeamName)
            .ToList();
            var disbandTeams = teams
                .Where(x => x.Member.Count == 0)
                .OrderByDescending(x => x.Member.Count)
                .ThenBy(x => x.TeamName)
                .ToList();
            foreach (Team t in regularTeams)
            {
                Console.WriteLine(t.TeamName);
                Console.WriteLine($"- {t.Creator}");
                foreach (string m in t.Member)
                {
                    Console.WriteLine($"-- {m}");
                }
            }
            Console.WriteLine("Teams to disband:");
            foreach (Team t in disbandTeams)
            {
                Console.WriteLine(t.TeamName);
            }
        }
    }
    class Team
    {
        public Team()
        {
            Member = new();
        }
        public string TeamName { get; set; }
        public string Creator { get; set; }
        public List<string> Member { get; set; }
    }
}