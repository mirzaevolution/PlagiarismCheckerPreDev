namespace StringReverseService
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class StringReverseModel : DbContext
    {
        public StringReverseModel()
            : base("name=StringReverseModel")
        {
        }

        public virtual DbSet<StringReverse> StringReverses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StringReverse>()
                .Property(e => e.TextValue)
                .IsUnicode(false);
        }
    }
}
