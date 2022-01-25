#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcProject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


public class MvcProjectContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
        public MvcProjectContext (DbContextOptions<MvcProjectContext> options)
            : base(options)
        {
        }
        
        public DbSet<MvcProject.Models.League> League { get; set; }

        public DbSet<MvcProject.Models.Player> Player { get; set; }
        
        public DbSet<MvcProject.Models.Seazon> Seazon { get; set; }

        public DbSet<MvcProject.Models.Team> Team { get; set; }
    }
