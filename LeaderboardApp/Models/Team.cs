namespace LeaderboardApp.Models
{
    public class Team
    {
        public int TeamId { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<Counter> Counters { get; set; } = new List<Counter>();
        public int TotalSteps => Counters.Sum(c => c.Steps);
    }
}
