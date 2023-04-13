using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace дэнахууй.Classes
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model13")
        {
        }

        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<test1> test1 { get; set; }
        public virtual DbSet<texst2> texst2 { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<test1>()
                .HasOptional(e => e.texst2)
                .WithRequired(e => e.test1);
        }
    }
}
