using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace api.Models
{
    public partial class DocDBContext : DbContext
    {
        public DocDBContext()
        {
        }

        public DocDBContext(DbContextOptions<DocDBContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          using (var hmac = new System.Security.Cryptography.HMACSHA512())
          {
        modelBuilder.Entity<Admin>().HasData(
          new Admin
          {
            Id= "ee32b23f-bf74-46c3-b995-499e46d3dfec",
            Username = "admin",
            PasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes("admin123")),
            PasswordSalt = hmac.Key

          }
         ) ;
          }
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Appoinment> Appoinments { get; set; }

        public virtual DbSet<Doctor> Doctors { get; set; }

        public virtual DbSet<Schedule> Schedules { get; set; }


  }
}
