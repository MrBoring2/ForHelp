using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication10
{
    public partial class HealphyTeethContext : DbContext
    {
        public HealphyTeethContext()
        {
        }

        public HealphyTeethContext(DbContextOptions<HealphyTeethContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Administrator> Administrators { get; set; } = null!;
        public virtual DbSet<Cabinet> Cabinets { get; set; } = null!;
        public virtual DbSet<Client> Clients { get; set; } = null!;
        public virtual DbSet<ClientsVisit> ClientsVisits { get; set; } = null!;
        public virtual DbSet<Consumable> Consumables { get; set; } = null!;
        public virtual DbSet<ConsumableType> ConsumableTypes { get; set; } = null!;
        public virtual DbSet<ConsumablesInDelivery> ConsumablesInDeliveries { get; set; } = null!;
        public virtual DbSet<ConsumablesInStorage> ConsumablesInStorages { get; set; } = null!;
        public virtual DbSet<Delivery> Deliveries { get; set; } = null!;
        public virtual DbSet<Doctor> Doctors { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Record> Records { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<SpentConsumablesForVisit> SpentConsumablesForVisits { get; set; } = null!;
        public virtual DbSet<Storage> Storages { get; set; } = null!;
        public virtual DbSet<Supplier> Suppliers { get; set; } = null!;
        public virtual DbSet<VisitType> VisitTypes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=MrBoring\\MSSQLSERVER01;database=HealphyTeeth;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrator>(entity =>
            {
                entity.HasKey(e => e.EmployeeId);

                entity.ToTable("Administrator");

                entity.Property(e => e.EmployeeId).ValueGeneratedNever();

                entity.HasOne(d => d.Employee)
                    .WithOne(p => p.Administrator)
                    .HasForeignKey<Administrator>(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Cabinet>(entity =>
            {
                entity.ToTable("Cabinet");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("Client");

                entity.Property(e => e.ClientDateOfBirth).HasColumnType("date");

                entity.Property(e => e.ClientFullName)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.ClientGender)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PassportNumber)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.PassportSeries)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ClientsVisit>(entity =>
            {
                entity.HasKey(e => e.ClientVisitId);

                entity.ToTable("ClientsVisit");

                entity.HasIndex(e => e.ClientId, "IX_ClientsVisit_ClientId");

                entity.HasIndex(e => e.DoctorId, "IX_ClientsVisit_DoctorId");

                entity.HasIndex(e => e.VisitTypeId, "IX_ClientsVisit_VisitTypeId");

                entity.Property(e => e.DoctorId).HasDefaultValueSql("((0))");

                entity.Property(e => e.VisitDate).HasColumnType("datetime");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientsVisits)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.ClientsVisits)
                    .HasForeignKey(d => d.DoctorId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(d => d.VisitType)
                    .WithMany(p => p.ClientsVisits)
                    .HasForeignKey(d => d.VisitTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClientsVisit_VisitType");
            });

            modelBuilder.Entity<Consumable>(entity =>
            {
                entity.ToTable("Consumable");

                entity.HasIndex(e => e.ConsumableTypeId, "IX_Consumable_ConsumableTypeId");

                entity.Property(e => e.ConsumableName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.ConsumableType)
                    .WithMany(p => p.Consumables)
                    .HasForeignKey(d => d.ConsumableTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Consumable_ConsumableType");
            });

            modelBuilder.Entity<ConsumableType>(entity =>
            {
                entity.ToTable("ConsumableType");

                entity.Property(e => e.ConsumableTypeName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ConsumablesInDelivery>(entity =>
            {
                entity.HasKey(e => new { e.DeliveryId, e.ConsumableId });

                entity.ToTable("ConsumablesInDelivery");

                entity.HasIndex(e => e.ConsumableId, "IX_ConsumablesInDelivery_ConsumableId");

                entity.HasOne(d => d.Consumable)
                    .WithMany(p => p.ConsumablesInDeliveries)
                    .HasForeignKey(d => d.ConsumableId)
                    .HasConstraintName("FK_ConsumablesInDelivery_Consumable");

                entity.HasOne(d => d.Delivery)
                    .WithMany(p => p.ConsumablesInDeliveries)
                    .HasForeignKey(d => d.DeliveryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ConsumablesInDelivery_Delivery");
            });

            modelBuilder.Entity<ConsumablesInStorage>(entity =>
            {
                entity.HasKey(e => new { e.StorageId, e.ConsumableId });

                entity.HasIndex(e => e.ConsumableId, "IX_ConsumablesInStorages_ConsumableId");

                entity.HasOne(d => d.Consumable)
                    .WithMany(p => p.ConsumablesInStorages)
                    .HasForeignKey(d => d.ConsumableId);

                entity.HasOne(d => d.Storage)
                    .WithMany(p => p.ConsumablesInStorages)
                    .HasForeignKey(d => d.StorageId);
            });

            modelBuilder.Entity<Delivery>(entity =>
            {
                entity.ToTable("Delivery");

                entity.HasIndex(e => e.StorageId, "IX_Delivery_StorageId");

                entity.HasIndex(e => e.SupplierId, "IX_Delivery_SupplierId");

                entity.Property(e => e.DeliveryDate).HasColumnType("datetime");

                entity.HasOne(d => d.Storage)
                    .WithMany(p => p.Deliveries)
                    .HasForeignKey(d => d.StorageId);

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.Deliveries)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Delivery_Supplier");
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.HasKey(e => e.EmployeeId);

                entity.ToTable("Doctor");

                entity.HasIndex(e => e.CabinetId, "IX_Doctor_CabinetId");

                entity.Property(e => e.EmployeeId).ValueGeneratedNever();

                entity.HasOne(d => d.Cabinet)
                    .WithMany(p => p.Doctors)
                    .HasForeignKey(d => d.CabinetId);

                entity.HasOne(d => d.Employee)
                    .WithOne(p => p.Doctor)
                    .HasForeignKey<Doctor>(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasIndex(e => e.RoleId, "IX_Employees_RoleId");

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.FullName)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Login)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PassportNumber)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.PassportSeries)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<Record>(entity =>
            {
                entity.ToTable("Record");

                entity.HasIndex(e => e.ClientId, "IX_Record_ClientId");

                entity.HasIndex(e => e.DoctorId, "IX_Record_DoctorId");

                entity.Property(e => e.RecordDate).HasColumnType("datetime");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Records)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK_Record_Client");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Records)
                    .HasForeignKey(d => d.DoctorId);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SpentConsumablesForVisit>(entity =>
            {
                entity.HasKey(e => new { e.СonsumableId, e.VisitId });

                entity.ToTable("SpentConsumablesForVisit");

                entity.HasIndex(e => e.VisitId, "IX_SpentConsumablesForVisit_VisitId");

                entity.HasOne(d => d.Visit)
                    .WithMany(p => p.SpentConsumablesForVisits)
                    .HasForeignKey(d => d.VisitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SpentConsumablesForVisit_ClientsVisit");

                entity.HasOne(d => d.Сonsumable)
                    .WithMany(p => p.SpentConsumablesForVisits)
                    .HasForeignKey(d => d.СonsumableId)
                    .HasConstraintName("FK_SpentConsumablesForVisit_Consumable");
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.ToTable("Supplier");

                entity.Property(e => e.SupplierAddress)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SupplierName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VisitType>(entity =>
            {
                entity.ToTable("VisitType");

                entity.Property(e => e.VisitTypeName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
