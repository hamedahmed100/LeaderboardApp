using LeaderboardApp.Data;
using LeaderboardApp.Models;
using Microsoft.EntityFrameworkCore;

namespace LeaderboardApp.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private readonly LeaderboardContext _context;

        public TeamRepository(LeaderboardContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Team>> GetAllTeamsAsync()
        {
            var teams = await _context.Teams.ToListAsync();
            foreach (var team in teams)
            {
                team.TotalSteps = await CalculateTotalStepsAsync(team.TeamId);
            }
            return teams;
        }

        public async Task<Team?> GetTeamByIdAsync(int teamId)
        {
            var team = await _context.Teams.FindAsync(teamId);
            if (team != null)
            {
                team.TotalSteps = await CalculateTotalStepsAsync(teamId);
            }
            return team;
        }

        public async Task<Team> AddTeamAsync(CreateTeam createTeam)
        {
            var team = new Team { TeamId = createTeam.TeamId, Name = createTeam.Name, TotalSteps = 0 };
            _context.Teams.Add(team);
            await _context.SaveChangesAsync();
            return team;
        }

        public async Task DeleteTeamAsync(int teamId)
        {
            var team = await _context.Teams.FindAsync(teamId);
            if (team != null)
            {
                _context.Teams.Remove(team);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Counter>> GetTeamCountersAsync(int teamId) =>
            await _context.Counters.Where(c => c.TeamId == teamId).ToListAsync();

        public async Task<Counter?> GetCounterByIdAsync(int counterId) =>
            await _context.Counters.FindAsync(counterId);

        public async Task<Counter> AddCounterAsync(Counter counter)
        {
            _context.Counters.Add(counter);
            await _context.SaveChangesAsync();
            return counter;
        }

        public async Task DeleteCounterAsync(int counterId)
        {
            var counter = await _context.Counters.FindAsync(counterId);
            if (counter != null)
            {
                _context.Counters.Remove(counter);
                await _context.SaveChangesAsync();
            }
        }

        public async Task IncrementCounterAsync(int counterId, int steps)
        {
            var counter = await _context.Counters.FindAsync(counterId);
            if (counter != null)
            {
                counter.Steps += steps;
                await _context.SaveChangesAsync();
            }
        }
        // Method to calculate total steps for a specific team
        private async Task<int> CalculateTotalStepsAsync(int teamId)
        {
            return await _context.Counters
                .Where(c => c.TeamId == teamId)
                .SumAsync(c => c.Steps);
        }
    }
}
