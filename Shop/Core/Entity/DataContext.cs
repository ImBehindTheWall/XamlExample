namespace Shop.Core.Entity
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DataContext : DbContext
    {
        public DataContext()
            : base("name=DataContext2")
        {
        }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Item> Item { get; set; }
        public virtual DbSet<Sale> Sale { get; set; }
        public virtual DbSet<Sale_history> Sale_history { get; set; }
        public virtual DbSet<SaleHasItem> SaleHasItem { get; set; }
        public virtual DbSet<Source> Source { get; set; }
        public virtual DbSet<Status> Status { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(e => e.Item)
                .WithMany(e => e.Category)
                .Map(m => m.ToTable("CategoryHasItem").MapLeftKey("CategoryID").MapRightKey("ItemID"));

            modelBuilder.Entity<Client>()
                .HasMany(e => e.Sale)
                .WithRequired(e => e.Client)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Item>()
                .HasMany(e => e.SaleHasItem)
                .WithRequired(e => e.Item)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Source>()
                .HasMany(e => e.Client)
                .WithRequired(e => e.Source)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Status>()
                .HasMany(e => e.Sale)
                .WithRequired(e => e.Status)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Status>()
                .HasMany(e => e.Sale_history)
                .WithRequired(e => e.Status)
                .WillCascadeOnDelete(false);
        }
    }
}
