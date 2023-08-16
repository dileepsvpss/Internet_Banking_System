using Microsoft.EntityFrameworkCore;

namespace online_internet_banking.Models
{
    public class ManagerContext:DbContext
    {
       
        
            public ManagerContext(DbContextOptions<ManagerContext> options) : base(options)
            { }
            public DbSet<Manager> Managers { get; set; }
        

    } 
}
