﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace NationalDrivingLicense.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<DriverLicence> DriverLicences { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<DriverLicence>().HasKey(m => m.Id);

            builder.Entity<DriverLicence>()
               .HasOne(p => p.ApplicationUser)
               .WithMany(b => b.DriverLicences);

            base.OnModelCreating(builder);
        }
    }
}
