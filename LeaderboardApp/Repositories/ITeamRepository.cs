using LeaderboardApp.Models;

namespace LeaderboardApp.Repositories
{
    public interface ITeamRepository
    {
        Task<IEnumerable<Team>> GetAllTeamsAsync();
        Task<Team?> GetTeamByIdAsync(int teamId);
        Task<Team> AddTeamAsync(CreateTeam team);

        Task DeleteTeamAsync(int teamId);

        Task<List<Counter>> GetTeamCountersAsync(int teamId);
        Task<Counter?> GetCounterByIdAsync(int counterId);
        Task<Counter> AddCounterAsync(Counter counter);
        Task DeleteCounterAsync(int counterId);
        Task IncrementCounterAsync(int counterId, int steps);
    }
}
