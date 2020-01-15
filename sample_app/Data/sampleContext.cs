using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sample_app.Models;
using Microsoft.EntityFrameworkCore;


namespace sample_app.Data
{
    public class sampleContext: DbContext
    {
        public sampleContext(DbContextOptions<sampleContext> options) :base(options)
        {


        }
        public DbSet<demo_app> Movie { get; set;}
    }
}
