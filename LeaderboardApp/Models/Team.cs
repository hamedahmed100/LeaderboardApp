namespace LeaderboardApp.Models
{

    public class CreateTeam
    {
        public int TeamId { get; set; }
        public string Name { get; set; } = string.Empty;

    }
    public class Team : CreateTeam
    {

        public int TotalSteps { get; set; }
    }
    public class TeamCounters 
    {
        public Team? Team { get; set; }
        public List<Counter>? Counters { get; set; }

    }
}
