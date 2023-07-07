using CinemaTicketSystem.Domain.Identity;
using CinemaTicketSystem.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CinemaTicketSystem.Repository.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<CinemaTicketSystemUser> entities;
        private string errorMessage = string.Empty;

        public UserRepository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<CinemaTicketSystemUser>();
        }

        public IEnumerable<CinemaTicketSystemUser> GetAll()
        {
            return entities.AsEnumerable();
        }

        // Major difference between repository and userrepository is that we have a string for id
        public CinemaTicketSystemUser Get(string id)
        {
            return entities
                .Include(z => z.UserCart)
                .Include("UserCart.ShoppingCartTickets")
                .Include("UserCart.ShoppingCartTickets.Ticket")
                .SingleOrDefault(s => s.Id == id);
        }

        public void Insert(CinemaTicketSystemUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            context.SaveChanges();
        }

        public void Update(CinemaTicketSystemUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Update(entity);
            context.SaveChanges();
        }

        public void Delete(CinemaTicketSystemUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            context.SaveChanges();
        }
    }
}