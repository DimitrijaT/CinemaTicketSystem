using CinemaTicketSystem.Domain.Identity;
using System.Collections.Generic;

namespace CinemaTicketSystem.Repository.Interface
{
    public interface IUserRepository
    {
        IEnumerable<CinemaTicketSystemUser> GetAll();

        CinemaTicketSystemUser Get(string id);

        void Insert(CinemaTicketSystemUser entity);

        void Update(CinemaTicketSystemUser entity);

        void Delete(CinemaTicketSystemUser entity);

        //void Remove(T entity);

        //void SaveChanges();
    }
}