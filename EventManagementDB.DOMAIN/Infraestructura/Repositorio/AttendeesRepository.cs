using EventManagementDB.DOMAIN.Core.Entidades;
using EventManagementDB.DOMAIN.Core.Interfaces;
using EventManagementDB.DOMAIN.Infraestructura.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementDB.DOMAIN.Infraestructura.Repositorio
{
    public class AttendeesRepository : IAttendeesRepository
    {
        private readonly EventManagementDbContext _dbContext;

        public AttendeesRepository(EventManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Attendees>> GetAttendees()
        {
            var attendees = await _dbContext.Attendees.ToListAsync();
            return attendees;
        }


        //Create attendees
        public async Task<int> Insert(Attendees attendees)
        {
            await _dbContext.Attendees.AddAsync(attendees);
            int rows = await _dbContext.SaveChangesAsync();

            return rows > 0 ? attendees.Id : -1;
        }

        //Delete attendees
        public async Task<bool> Delete(int id)
        {
            var attendees = await _dbContext
                            .Attendees
                            .FirstOrDefaultAsync(c => c.Id == id);

            if (attendees == null) return false;

            int rows = await _dbContext.SaveChangesAsync();
            return (rows > 0);

            //_dbContext.Attendees.Remove(attendees);

        }




    }
}
