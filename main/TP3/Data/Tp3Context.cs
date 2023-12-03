using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TP3.Models;

public partial class Tp3Context : DbContext
{
    public Tp3Context()
    {
    }

    public Tp3Context(DbContextOptions<Tp3Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<MembershipType> MembershipTypes { get; set; }

    public virtual DbSet<Movie> Movies { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=DESKTOP-L3IM02E;Database=TP3;Integrated Security=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Customer__3214EC273BF1F3D1");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Membershiptype).HasColumnName("membershiptype");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.MembershiptypeNavigation).WithMany(p => p.Customers)
                .HasForeignKey(d => d.Membershiptype)
                .HasConstraintName("FK__Customers__membe__2E1BDC42");
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Genres__3214EC276607FD67");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.GenreName)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<MembershipType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Membersh__3214EC27A0C96EC1");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.DiscountRate).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.SignUpFee).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<Movie>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Movie__3214EC27516FDD57");

            entity.ToTable("Movie");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.GenreId).HasColumnName("Genre_id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Genre).WithMany(p => p.Movies)
                .HasForeignKey(d => d.GenreId)
                .HasConstraintName("FK__Movie__Genre_id__2B3F6F97");
        });
    // Lire les données à partir du fichier JSON
    string genreJson = System.IO.File.ReadAllText("Genres.json");
    List<Genre> genres = System.Text.Json.JsonSerializer.Deserialize<List<Genre>>(genreJson);

    // Configuration de la relation entre Movie et Genre
    modelBuilder.Entity<Movie>()
        .HasOne(m => m.Genre)
        .WithMany(g => g.Movies)
        .HasForeignKey(m => m.GenreId);

    // Seed des données pour la table Genre
    modelBuilder.Entity<Genre>().HasData(genres.ToArray());
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
