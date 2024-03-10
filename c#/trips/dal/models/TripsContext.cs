using System;
using System.Collections.Generic;
using dal.models;
using Microsoft.EntityFrameworkCore;

namespace dal;

public partial class TripsContext : DbContext
{
    public TripsContext()
    {
    }

    public TripsContext(DbContextOptions<TripsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<Trip> Trips { get; set; }

    public virtual DbSet<TripsType> TripsTypes { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-L9S4R74;Initial Catalog=trips; Trusted_Connection=True;MultipleActiveResultSets=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.IdBooking).HasName("PK__booking__3A710F7FA461E3CC");

            entity.ToTable("booking");

            entity.Property(e => e.IdBooking).HasColumnName("idBooking");
            entity.Property(e => e.DateBookink)
                .HasColumnType("date")
                .HasColumnName("dateBookink");
            entity.Property(e => e.IdTrip).HasColumnName("idTrip");
            entity.Property(e => e.IdUser).HasColumnName("idUser");
            entity.Property(e => e.Places).HasColumnName("places");
            entity.Property(e => e.TimeBooking).HasColumnName("timeBooking");

            entity.HasOne(d => d.IdTripNavigation).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.IdTrip)
                .HasConstraintName("FK__booking__idTrip__4316F928");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("FK__booking__idUser__4222D4EF");
        });

        modelBuilder.Entity<Trip>(entity =>
        {
            entity.HasKey(e => e.IdTrips).HasName("PK__trips__04935DA600B4C382");

            entity.ToTable("trips");

            entity.Property(e => e.IdTrips).HasColumnName("idTrips");
            entity.Property(e => e.DateTrip).HasColumnType("date");
            entity.Property(e => e.DestinationTrip)
                .HasMaxLength(12)
                .IsUnicode(false);
            entity.Property(e => e.DurationTrip).HasColumnName("durationTrip");
            entity.Property(e => e.IdType).HasColumnName("idType");
            entity.Property(e => e.Image)
                .HasColumnType("text")
                .HasColumnName("image");
            entity.Property(e => e.LeavingTime).HasColumnName("leavingTime");
            entity.Property(e => e.PlacesAvailable).HasColumnName("placesAvailable");
            entity.Property(e => e.Price).HasColumnName("price");

            entity.HasOne(d => d.IdTypeNavigation).WithMany(p => p.Trips)
                .HasForeignKey(d => d.IdType)
                .HasConstraintName("FK__trips__idType__398D8EEE");
        });

        modelBuilder.Entity<TripsType>(entity =>
        {
            entity.HasKey(e => e.IdType).HasName("PK__tripsTyp__4BB98BC6F8C8539B");

            entity.ToTable("tripsTypes");

            entity.Property(e => e.IdType).HasColumnName("idType");
            entity.Property(e => e.NameType)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("nameType");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("PK__users__3717C982CD523742");

            entity.ToTable("users");

            entity.Property(e => e.IdUser).HasColumnName("idUser");
            entity.Property(e => e.UserFirstAid).HasColumnName("userFirstAid");
            entity.Property(e => e.UserFirstName)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("userFirstName");
            entity.Property(e => e.UserLastName)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("userLastName");
            entity.Property(e => e.UserMail)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("userMail");
            entity.Property(e => e.UserPassword)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("userPassword");
            entity.Property(e => e.UserPhone)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("userPhone");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
