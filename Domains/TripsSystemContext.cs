using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Domains;

public partial class TripsSystemContext : DbContext
{
    public TripsSystemContext()
    {
    }

    public TripsSystemContext(DbContextOptions<TripsSystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbCategory> TbCategories { get; set; }

    public virtual DbSet<TbCity> TbCities { get; set; }

    public virtual DbSet<TbImg> TbImgs { get; set; }

    public virtual DbSet<TbTicket> TbTickets { get; set; }

    public virtual DbSet<TbTrip> TbTrips { get; set; }

    public virtual DbSet<VwTicket> VwTickets { get; set; }

    public virtual DbSet<VwTrip> VwTrips { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-IIL7N6G;Database=Trips System;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbCategory>(entity =>
        {
            entity.HasKey(e => e.Categoryid);

            entity.Property(e => e.Categoryid).HasColumnName("categoryid");
            entity.Property(e => e.Categoryname)
                .HasMaxLength(50)
                .HasColumnName("categoryname");
        });

        modelBuilder.Entity<TbCity>(entity =>
        {
            entity.HasKey(e => e.Cityid);

            entity.Property(e => e.Cityid).HasColumnName("cityid");
            entity.Property(e => e.Cityname)
                .HasMaxLength(50)
                .HasColumnName("cityname");
            entity.Property(e => e.Countryname)
                .HasMaxLength(50)
                .HasColumnName("countryname");
        });

        modelBuilder.Entity<TbImg>(entity =>
        {
            entity.HasKey(e => e.Imgid);

            entity.Property(e => e.Imgid).HasColumnName("imgid");
            entity.Property(e => e.Imgname)
                .HasMaxLength(50)
                .HasColumnName("imgname");
        });

        modelBuilder.Entity<TbTicket>(entity =>
        {
            entity.HasKey(e => e.Ticketid);

            entity.Property(e => e.Ticketid).HasColumnName("ticketid");
            entity.Property(e => e.Personemail)
                .HasMaxLength(50)
                .HasColumnName("personemail");
            entity.Property(e => e.Personname)
                .HasMaxLength(50)
                .HasColumnName("personname");
            entity.Property(e => e.Personphonenumber)
                .HasMaxLength(50)
                .HasColumnName("personphonenumber");
            entity.Property(e => e.Tripid).HasColumnName("tripid");

            entity.HasOne(d => d.Trip).WithMany(p => p.TbTickets)
                .HasForeignKey(d => d.Tripid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TbTickets_TbTrips");
        });

        modelBuilder.Entity<TbTrip>(entity =>
        {
            entity.HasKey(e => e.Tripid);

            entity.Property(e => e.Tripid).HasColumnName("tripid");
            entity.Property(e => e.Categoryid).HasColumnName("categoryid");
            entity.Property(e => e.Cityid).HasColumnName("cityid");
            entity.Property(e => e.Imgid).HasColumnName("imgid");
            entity.Property(e => e.Tripdescreption).HasColumnName("tripdescreption");
            entity.Property(e => e.Tripname)
                .HasMaxLength(50)
                .HasColumnName("tripname");
            entity.Property(e => e.Tripprice)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("tripprice");

            entity.HasOne(d => d.Category).WithMany(p => p.TbTrips)
                .HasForeignKey(d => d.Categoryid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TbTrips_TbCategories");

            entity.HasOne(d => d.City).WithMany(p => p.TbTrips)
                .HasForeignKey(d => d.Cityid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TbTrips_TbCities");

            entity.HasOne(d => d.Img).WithMany(p => p.TbTrips)
                .HasForeignKey(d => d.Imgid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TbTrips_TbImgs");
        });

        modelBuilder.Entity<VwTicket>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VwTickets");

            entity.Property(e => e.Categoryname)
                .HasMaxLength(50)
                .HasColumnName("categoryname");
            entity.Property(e => e.Cityname)
                .HasMaxLength(50)
                .HasColumnName("cityname");
            entity.Property(e => e.Countryname)
                .HasMaxLength(50)
                .HasColumnName("countryname");
            entity.Property(e => e.Imgname)
                .HasMaxLength(50)
                .HasColumnName("imgname");
            entity.Property(e => e.Personemail)
                .HasMaxLength(50)
                .HasColumnName("personemail");
            entity.Property(e => e.Personname)
                .HasMaxLength(50)
                .HasColumnName("personname");
            entity.Property(e => e.Personphonenumber)
                .HasMaxLength(50)
                .HasColumnName("personphonenumber");
            entity.Property(e => e.Tripdescreption).HasColumnName("tripdescreption");
            entity.Property(e => e.Tripname)
                .HasMaxLength(50)
                .HasColumnName("tripname");
            entity.Property(e => e.Tripprice)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("tripprice");
        });

        modelBuilder.Entity<VwTrip>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VwTrips");

            entity.Property(e => e.Categoryid).HasColumnName("categoryid");
            entity.Property(e => e.Categoryname)
                .HasMaxLength(50)
                .HasColumnName("categoryname");
            entity.Property(e => e.Cityid).HasColumnName("cityid");
            entity.Property(e => e.Cityname)
                .HasMaxLength(50)
                .HasColumnName("cityname");
            entity.Property(e => e.Countryname)
                .HasMaxLength(50)
                .HasColumnName("countryname");
            entity.Property(e => e.Imgid).HasColumnName("imgid");
            entity.Property(e => e.Imgname)
                .HasMaxLength(50)
                .HasColumnName("imgname");
            entity.Property(e => e.Tripdescreption).HasColumnName("tripdescreption");
            entity.Property(e => e.Tripid).HasColumnName("tripid");
            entity.Property(e => e.Tripname)
                .HasMaxLength(50)
                .HasColumnName("tripname");
            entity.Property(e => e.Tripprice)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("tripprice");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
