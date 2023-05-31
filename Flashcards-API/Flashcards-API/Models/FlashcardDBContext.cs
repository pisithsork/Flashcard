using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Flashcards_API.Models
{
    public partial class FlashcardDBContext : DbContext
    {
        public FlashcardDBContext()
        {
        }

        public FlashcardDBContext(DbContextOptions<FlashcardDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Flashcard> Flashcards { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=tcp:pisithserver.database.windows.net,1433;Initial Catalog=FlashcardDB;Persist Security Info=False;User ID=pisiths;Password=BlueBird12;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;Integrated Security=False;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Flashcard>(entity =>
            {
                entity.ToTable("Flashcard");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Answer)
                    .HasMaxLength(255)
                    .HasColumnName("answer");

                entity.Property(e => e.Question)
                    .HasMaxLength(255)
                    .HasColumnName("question");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
