using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Entity_Framework_6_Database_first.Models
{
    public partial class copenhagen_airportContext : DbContext
    {
        public copenhagen_airportContext()
        {
        }

        public copenhagen_airportContext(DbContextOptions<copenhagen_airportContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AirlineCompany> AirlineCompany { get; set; }
        public virtual DbSet<Airport> Airport { get; set; }
        public virtual DbSet<Departure> Departure { get; set; }
        public virtual DbSet<ExtraPermittedRouteOperators> ExtraPermittedRouteOperators { get; set; }
        public virtual DbSet<Route> Route { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost,1433;Initial Catalog=copenhagen_airport;User ID=sa;Password=!supercomplex12345;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AirlineCompany>(entity =>
            {
                entity.ToTable("airline_company");

                entity.HasIndex(e => e.Name)
                    .HasName("UQ__airline___72E12F1BECA48CA6")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(240)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Airport>(entity =>
            {
                entity.ToTable("airport");

                entity.HasIndex(e => e.Iata)
                    .HasName("UQ__airport__9874D234F66F7ADE")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Iata)
                    .HasColumnName("iata")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(240)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Departure>(entity =>
            {
                entity.ToTable("departure");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.OperatorId).HasColumnName("operator_id");

                entity.Property(e => e.RouteId).HasColumnName("route_id");

                entity.Property(e => e.TimeOfDeparture)
                    .HasColumnName("time_of_departure")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Operator)
                    .WithMany(p => p.Departure)
                    .HasForeignKey(d => d.OperatorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__departure__opera__571DF1D5");

                entity.HasOne(d => d.Route)
                    .WithMany(p => p.Departure)
                    .HasForeignKey(d => d.RouteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__departure__route__5629CD9C");
            });

            modelBuilder.Entity<ExtraPermittedRouteOperators>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("extra_permitted_route_operators");

                entity.Property(e => e.AirlineCompanyId).HasColumnName("airline_company_id");

                entity.Property(e => e.RouteId).HasColumnName("route_id");

                entity.HasOne(d => d.AirlineCompany)
                    .WithMany(p => p.ExtraPermittedRouteOperators)
                    .HasForeignKey(d => d.AirlineCompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__extra_per__airli__52593CB8");

                entity.HasOne(d => d.Route)
                    .WithMany(p => p.ExtraPermittedRouteOperators)
                    .HasForeignKey(d => d.RouteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__extra_per__route__534D60F1");
            });

            modelBuilder.Entity<Route>(entity =>
            {
                entity.ToTable("route");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DestinationId).HasColumnName("destination_id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(240)
                    .IsUnicode(false);

                entity.Property(e => e.OriginId).HasColumnName("origin_id");

                entity.Property(e => e.OwnerOperatesThisRoute)
                    .IsRequired()
                    .HasColumnName("owner_operates_this_route")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.OwningCompanyId).HasColumnName("owning_company_id");

                entity.HasOne(d => d.Destination)
                    .WithMany(p => p.RouteDestination)
                    .HasForeignKey(d => d.DestinationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__route__destinati__4D94879B");

                entity.HasOne(d => d.Origin)
                    .WithMany(p => p.RouteOrigin)
                    .HasForeignKey(d => d.OriginId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__route__owner_ope__4CA06362");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
