namespace prog35142.week12.deployment.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class OlympicsContext : DbContext
    {
        public OlympicsContext()
            : base("name=OlympicsContext")
        {
         }
        public virtual DbSet<Countries> Countries { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
