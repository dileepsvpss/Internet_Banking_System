using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using online_internet_banking.Models;

namespace online_internet_banking.Data
{
    public class online_internet_bankingContext : DbContext
    {
        public online_internet_bankingContext (DbContextOptions<online_internet_bankingContext> options)
            : base(options)
        {
        }

        public DbSet<online_internet_banking.Models.Manager>? Manager { get; set; }
    }
}
