﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CrazyBasketball.Models;

namespace CrazyBasketball.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        DbSet<Team> Teams { get; set; }

        public DbSet<CrazyBasketball.Models.Team> Team { get; set; }
    }
}
