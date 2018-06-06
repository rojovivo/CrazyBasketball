using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrazyBasketball.Data;
using CrazyBasketball.Models;
using Microsoft.EntityFrameworkCore;

namespace CrazyBasketball.Services
{
    public class TeamService : ITeamService
    {
        private readonly ApplicationDbContext _context;

        public TeamService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Team> GetOneAsync(Guid id)
        {
            return await _context.Teams
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<Team[]> GetAllAsync()
        {
            return await _context.Teams.ToArrayAsync();
        }

        public async Task AddAsync(Team team)
        {
            _context.Add(team);
            await _context.SaveChangesAsync();
        }

        public async Task<Team> FindAsync(Guid value)
        {
            return await _context.Teams.FindAsync(value);
        }

        public async Task UpdateAsync(Team team)
        {
            _context.Update(team);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveByIdAsync(Guid id)
        {
            var team = await _context.Teams.FindAsync(id);
            _context.Teams.Remove(team);
            await _context.SaveChangesAsync();
        }

        public bool ExistById(Guid id)
        {
            return _context.Teams.Any(e => e.Id == id);
        }
    }
}
