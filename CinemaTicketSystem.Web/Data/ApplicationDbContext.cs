using CinemaTicketSystem.Web.Models.Domain;
using CinemaTicketSystem.Web.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaTicketSystem.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<CinemaTicketSystemUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Adding Dbsets for the Entities

        public virtual DbSet<Ticket> Tickets { get; set; }

        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }

        public virtual DbSet<ShoppingCartTicket> ShoppingCartTickets { get; set; }

        public virtual DbSet<Order> Orders { get; set; }

        public virtual DbSet<TicketOrder> TicketOrders { get; set; }


        // Adding FluentApi Entity Constriants

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            // Config Incrementing Id

            builder.Entity<Ticket>()
                .Property(z => z.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<ShoppingCart>()
                .Property(z => z.Id)
                .ValueGeneratedOnAdd();


            // Config ManyToMany

            builder.Entity<ShoppingCartTicket>()
                .HasKey(z => new { z.TicketId, z.ShoppingCartId });


            builder.Entity<ShoppingCartTicket>()
                .HasOne(z => z.Ticket)
                .WithMany(z => z.ShoppingCartTickets)
                .HasForeignKey(z => z.TicketId);

            builder.Entity<ShoppingCartTicket>()
                .HasOne(z => z.ShoppingCart)
                .WithMany(z => z.ShoppingCartTickets)
                .HasForeignKey(z => z.ShoppingCartId);


            // Config ManyToMany

            builder.Entity<TicketOrder>()
                .HasKey(z => new { z.TicketId, z.OrderId });


            builder.Entity<TicketOrder>()
                .HasOne(z => z.OrderedTicket)
                .WithMany(z => z.TicketOrder)
                .HasForeignKey(z => z.TicketId);

            builder.Entity<TicketOrder>()
                .HasOne(z => z.UserOrder)
                .WithMany(z => z.TicketOrders)
                .HasForeignKey(z => z.OrderId);

            // Config OneToOne

            builder.Entity<ShoppingCart>()
                .HasOne<CinemaTicketSystemUser>(z => z.Owner)
                .WithOne(z => z.UserCart)
                .HasForeignKey<ShoppingCart>(z => z.OwnerId);
        }

    }



}
