using DataModels.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataModels
{
    public class BkdnContext: DbContext
    {
        public BkdnContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Research> Researches { get; set; }

        public DbSet<Catalog> Catalogs { get; set; }

        public DbSet<Faculty> Faculties { get; set; }

        public DbSet<ResearchMember> ResearchMembers { get; set; }
        
        public DbSet<User> Users { get; set; }
    }
}