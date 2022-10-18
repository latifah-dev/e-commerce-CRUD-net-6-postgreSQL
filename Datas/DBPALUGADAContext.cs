using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PALUGADA.Datas.Entities;

namespace PALUGADA.Datas
{
    public partial class DBPALUGADAContext : DbContext
    {
        public DBPALUGADAContext()
        {
        }

        public DBPALUGADAContext(DbContextOptions<DBPALUGADAContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Barang> Barangs { get; set; } = null!;
        public virtual DbSet<Pembeli> Pembelis { get; set; } = null!;
        public virtual DbSet<Penjual> Penjuals { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Server=localhost; Port=5432; Database=DBPALUGADA; User Id=postgres; Password=lupakatasandi;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Barang>(entity =>
            {
                entity.HasKey(e => e.IdBarang)
                    .HasName("barang_pk");

                entity.ToTable("Barang");

                entity.Property(e => e.IdBarang)
                    .HasColumnName("id_barang")
                    .HasDefaultValueSql("nextval('barang_id_barang_seq'::regclass)");

                entity.Property(e => e.DeskripsiBarang).HasColumnName("deskripsi_barang");

                entity.Property(e => e.GambarBarang)
                    .HasColumnType("oid")
                    .HasColumnName("gambar_barang");

                entity.Property(e => e.HargaBarang).HasColumnName("harga_barang");

                entity.Property(e => e.IdPenjual).HasColumnName("id_penjual");

                entity.Property(e => e.JenisBarang)
                    .HasColumnType("character varying")
                    .HasColumnName("jenis_barang");

                entity.Property(e => e.KodeBarang)
                    .HasColumnType("character varying")
                    .HasColumnName("kode_barang");

                entity.Property(e => e.NamaBarang)
                    .HasColumnType("character varying")
                    .HasColumnName("nama_barang");

                entity.Property(e => e.StokBarang).HasColumnName("stok_barang");

                entity.HasOne(d => d.IdPenjualNavigation)
                    .WithMany(p => p.Barangs)
                    .HasForeignKey(d => d.IdPenjual)
                    .HasConstraintName("barang_fk");
            });

            modelBuilder.Entity<Pembeli>(entity =>
            {
                entity.HasKey(e => e.IdPembeli)
                    .HasName("Pembeli_pkey");

                entity.ToTable("Pembeli");

                entity.Property(e => e.IdPembeli)
                    .ValueGeneratedNever()
                    .HasColumnName("id_pembeli");

                entity.Property(e => e.AlamatPembeli).HasColumnName("alamat_pembeli");

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.Property(e => e.NamaPembeli)
                    .HasMaxLength(30)
                    .HasColumnName("nama_pembeli");

                entity.Property(e => e.NegaraPembeli)
                    .HasColumnType("character varying")
                    .HasColumnName("negara_pembeli");

                entity.Property(e => e.NotelpPembeli)
                    .HasColumnType("character varying")
                    .HasColumnName("notelp_pembeli");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Pembelis)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("pembeli_fk");
            });

            modelBuilder.Entity<Penjual>(entity =>
            {
                entity.HasKey(e => e.IdPenjual)
                    .HasName("Penjual_pkey");

                entity.ToTable("Penjual");

                entity.Property(e => e.IdPenjual)
                    .ValueGeneratedNever()
                    .HasColumnName("id_penjual");

                entity.Property(e => e.AlamatToko).HasColumnName("alamat_toko");

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.Property(e => e.KodeToko)
                    .HasMaxLength(10)
                    .HasColumnName("kode_toko");

                entity.Property(e => e.NamaToko)
                    .HasMaxLength(30)
                    .HasColumnName("nama_toko");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Penjuals)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("penjual_fk");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("User_pkey");

                entity.ToTable("User");

                entity.Property(e => e.IdUser)
                    .ValueGeneratedNever()
                    .HasColumnName("id_user");

                entity.Property(e => e.EmailUser)
                    .HasColumnType("character varying")
                    .HasColumnName("email_user");

                entity.Property(e => e.NohpUser)
                    .HasColumnType("character varying")
                    .HasColumnName("nohp_user");

                entity.Property(e => e.Password)
                    .HasMaxLength(30)
                    .HasColumnName("password")
                    .IsFixedLength();

                entity.Property(e => e.TipeUser)
                    .HasMaxLength(30)
                    .HasColumnName("tipe_user")
                    .IsFixedLength();

                entity.Property(e => e.Username)
                    .HasMaxLength(30)
                    .HasColumnName("username")
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
