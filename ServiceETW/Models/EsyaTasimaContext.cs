using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ServiceETW.Models;

public partial class EsyaTasimaContext : DbContext
{
    public EsyaTasimaContext()
    {
    }

    public EsyaTasimaContext(DbContextOptions<EsyaTasimaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Ilan> Ilans { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ilan>(entity =>
        {
            entity.ToTable("Ilan");

            entity.Property(e => e.Aciklama).HasMaxLength(300);
            entity.Property(e => e.Baslik).HasMaxLength(50);
            entity.Property(e => e.Ilantipi).HasMaxLength(50);
            entity.Property(e => e.Ilce).HasMaxLength(50);
            entity.Property(e => e.Sehir).HasMaxLength(50);
            entity.Property(e => e.Tarih).HasColumnType("datetime");
            entity.Property(e => e.UserId)
                .HasDefaultValueSql("((1))")
                .HasColumnName("User_Id");

            entity.HasOne(d => d.User).WithMany(p => p.Ilans)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Ilan_Users");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_User");

            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.FullName).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(15);
            entity.Property(e => e.PhoneNumber).HasMaxLength(11);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
