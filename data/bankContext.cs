using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankApi.models;
using Microsoft.EntityFrameworkCore;


namespace BankApi.data
{
    public class bankContext:DbContext
    {
         public bankContext(DbContextOptions<bankContext> options) : base(options) { }

    public DbSet<Person> People { get; set; }
    public DbSet<Transaction> Transactions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Transaction>()
            .HasOne(t => t.Sender)
            .WithMany()
            .HasForeignKey(t => t.SenderId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Transaction>()
            .HasOne(t => t.Receiver)
            .WithMany()
            .HasForeignKey(t => t.ReceiverId)
            .OnDelete(DeleteBehavior.Restrict);
    }
    }
}