using System;
using System.Collections.Generic;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataAccesLayer.Concrete
{
    public partial class libraryDBContext : DbContext
    {
        public libraryDBContext()
        {
        }

        public libraryDBContext(DbContextOptions<libraryDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; } = null!;
        public virtual DbSet<Book> Books { get; set; } = null!;
        public virtual DbSet<BookAvailability> BookAvailabilities { get; set; } = null!;
        public virtual DbSet<BorrowingHistory> BorrowingHistories { get; set; } = null!;
        public virtual DbSet<Member> Members { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=libraryDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>(entity =>
            {
                entity.ToTable("Author");

                entity.Property(e => e.AuthorId)
                    .ValueGeneratedNever()
                    .HasColumnName("AuthorID");

                entity.Property(e => e.AuthorFullName).HasMaxLength(30);
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.Property(e => e.BookId)
                    .ValueGeneratedNever()
                    .HasColumnName("BookID");

                entity.Property(e => e.AuthorId).HasColumnName("AuthorID");

                entity.Property(e => e.BookAvailabilityId).HasColumnName("BookAvailabilityID");

                entity.Property(e => e.BookImgUrl).HasMaxLength(100);

                entity.Property(e => e.BookName).HasMaxLength(50);

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Kitaplar_YazarID");

                entity.HasOne(d => d.BookAvailability)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.BookAvailabilityId)
                    .HasConstraintName("FK_Kitap_KitapDurumu");
            });

            modelBuilder.Entity<BookAvailability>(entity =>
            {
                entity.ToTable("BookAvailability");

                entity.Property(e => e.BookAvailabilityId)
                    .ValueGeneratedNever()
                    .HasColumnName("BookAvailabilityID");

                entity.Property(e => e.BookAvailabilityDescription).HasMaxLength(30);
            });

            modelBuilder.Entity<BorrowingHistory>(entity =>
            {
                entity.HasKey(e => e.BorrowingId)
                    .HasName("PK_Ödünç");

                entity.ToTable("BorrowingHistory");

                entity.Property(e => e.BorrowingId)
                    .ValueGeneratedNever()
                    .HasColumnName("BorrowingID");

                entity.Property(e => e.BookId).HasColumnName("BookID");

             

                entity.Property(e => e.DueDate).HasColumnType("date");

                entity.Property(e => e.MemberId).HasColumnName("MemberID");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.BorrowingHistories)
                    .HasForeignKey(d => d.BookId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Odunc_KitapId");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.BorrowingHistories)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Odunc_UyeId");
            });

            modelBuilder.Entity<Member>(entity =>
            {
                entity.Property(e => e.MemberId)
                    .ValueGeneratedNever()
                    .HasColumnName("MemberID");

                entity.Property(e => e.MemberEmailAddress).HasMaxLength(320);

                entity.Property(e => e.MemberFullName).HasMaxLength(50);

                entity.Property(e => e.MemberPhone).HasMaxLength(15);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
