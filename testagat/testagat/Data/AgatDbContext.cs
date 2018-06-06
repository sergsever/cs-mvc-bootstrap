namespace testagat
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using testagat.Data;

    public partial class AgatDbContext : DbContext
    {
        public AgatDbContext()
            : base("name=AgatDbContext")
        {
        }

        public virtual DbSet<TaskComments> TaskComments { get; set; }
        public virtual DbSet<Tasks> Tasks { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tasks>().HasOptional(e => e.Creator);
            modelBuilder.Entity<Tasks>().HasOptional(e => e.Executor);


            modelBuilder.Entity<Tasks>();

            modelBuilder.Entity<Users>();

        }
    }
}
