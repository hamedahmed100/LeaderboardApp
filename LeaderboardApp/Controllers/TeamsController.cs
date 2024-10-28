using LeaderboardApp.Models;
using LeaderboardApp.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LeaderboardApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly ITeamRepository _repository;

        public TeamsController(ITeamRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Team>>> GetAllTeams()
        {
            var teams = await _repository.GetAllTeamsAsync();
           
            return Ok(teams);
        }

        [HttpGet("{teamId}")]
        public async Task<ActionResult<TeamCounters>> GetTeam(int teamId)
        {
            var teamCounters = new TeamCounters();
            teamCounters.Team = await _repository.GetTeamByIdAsync(teamId);
            teamCounters.Counters = await _repository.GetTeamCountersAsync(teamId);
            
            if (teamCounters == null) return NotFound();
            return Ok(teamCounters);
        }

        [HttpPost]
        public async Task<ActionResult<CreateTeam>> CreateTeam([FromBody] CreateTeam team)
        {
            var newTeam = await _repository.AddTeamAsync(team);
            return CreatedAtAction(nameof(GetTeam), new { teamId = newTeam.TeamId }, newTeam);
        }

        [HttpDelete("{teamId}")]
        public async Task<IActionResult> DeleteTeam(int teamId)
        {
            await _repository.DeleteTeamAsync(teamId);
            return NoContent();
        }

        [HttpPost("{teamId}/counters")]
        public async Task<ActionResult<Counter>> AddCounter(int teamId, [FromBody] Counter counter)
        {
            counter.TeamId = teamId;
            var newCounter = await _repository.AddCounterAsync(counter);
            return CreatedAtAction(nameof(GetTeam), new { teamId = newCounter.TeamId }, newCounter);
        }

        [HttpDelete("counters/{counterId}")]
        public async Task<IActionResult> DeleteCounter(int counterId)
        {
            await _repository.DeleteCounterAsync(counterId);
            return NoContent();
        }

        [HttpPost("counters/{counterId}/increment")]
        public async Task<IActionResult> IncrementCounter(int counterId, [FromQuery] int steps)
        {
            await _repository.IncrementCounterAsync(counterId, steps);
            return NoContent();
        }
    }
}
