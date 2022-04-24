#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SDS.Models;

    public class SDSContext : DbContext
    {
        public SDSContext (DbContextOptions<SDSContext> options)
            : base(options)
        {
        }

        public DbSet<SDS.Models.Course> Course { get; set; }
    }
