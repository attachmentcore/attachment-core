using Microsoft.EntityFrameworkCore;

namespace AttachmentCore.Store.SqlServer.Context
{

    public partial class AttachmentDbContext : DbContext
    {
        public AttachmentDbContext(DbContextOptions<AttachmentDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        public virtual DbSet<Attachment> Attachments { get; set; }
        public virtual DbSet<AttachmentItem> AttachmentItems { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AttachmentItem>(entity =>
            {
                entity.HasOne(d => d.Attachment)
                    .WithMany(p => p.AttachmentItems)
                    .HasForeignKey(d => d.AttachmentId)
                    .HasConstraintName("FK_AttachmentItem_Attachment");
            });

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
