using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TunBasedBattler.Models
{
    public partial class tunbasedbattlerContext : DbContext
    {
        private const string ConnectionString = "server=localhost;user=root;password=NeshtoNovo0026;database=tunbasedbattler";

        public tunbasedbattlerContext()
        {
        }

        public tunbasedbattlerContext(DbContextOptions<tunbasedbattlerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Hero> Heroes { get; set; }
        public virtual DbSet<Player> Players { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL(ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hero>(entity =>
            {
                entity.ToTable("heroes");

                entity.HasIndex(e => e.Name)
                    .HasName("name")
                    .IsUnique();

                entity.HasIndex(e => e.PlayerId)
                    .HasName("fk_heroes_players");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Attack)
                    .HasColumnName("attack")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Defence)
                    .HasColumnName("defence")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Dodge)
                    .HasColumnName("dodge")
                    .HasColumnType("decimal(3,2)");

                entity.Property(e => e.Hp)
                    .HasColumnName("hp")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Magic)
                    .HasColumnName("magic")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PlayerId)
                    .HasColumnName("player_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.Heroes)
                    .HasForeignKey(d => d.PlayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_heroes_players");
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.ToTable("players");

                entity.HasIndex(e => e.Username)
                    .HasName("username")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
