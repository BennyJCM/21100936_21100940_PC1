using EventManagementDB.DOMAIN.Core.Entidades;

namespace EventManagementDB.DOMAIN.Core.Interfaces
{
    public interface IAttendeesRepository
    {
        Task<IEnumerable<Attendees>> GetAttendees();
        Task<int> Insert(Attendees attendees);
        Task<bool> Delete(int id);
    }
}