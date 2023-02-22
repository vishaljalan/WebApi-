using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebApplication1_feb16.Models;

namespace WebApplication1_feb16.DataAccess;

public partial class MoviedbContext : DbContext
{
    public MoviedbContext()
    {
    }

    public MoviedbContext(DbContextOptions<MoviedbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Tmovie> Tmovies { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
  //      => optionsBuilder.UseSqlServer("Data Source=IN3314428W1\\SQLEXPRESS;Initial Catalog=Moviedb;trusted_connection=TRUE;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tmovie>(entity =>
        {
            entity.HasKey(e => e.Movieid);

            entity.ToTable("Tmovie");

            entity.Property(e => e.Moviedir)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Moviename)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Movietype)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("user");

            entity.Property(e => e.UserId).HasColumnName("userId");
            entity.Property(e => e.Designation)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("designation");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("password");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
