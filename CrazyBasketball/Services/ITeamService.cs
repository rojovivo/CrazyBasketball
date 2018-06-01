using CrazyBasketball.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrazyBasketball.Services
{
    public interface ITeamService
    {
        Task<Team[]> GetAllAsync();
        Task<Team> GetOneAsync(Guid id);
        Task AddAsync(Team team);
        Task<Team> FindAsync(Guid value);
        Task UpdateAsync(Team team);
        Task RemoveByIdAsync(Guid id);
        bool ExistById(Guid id);
    }
}
