using CollageInfo.Entities;
using Microsoft.EntityFrameworkCore;

namespace Learner_API.Data
{
    public class CollageInfoDBContext : DbContext
    {
        public CollageInfoDBContext(DbContextOptions<CollageInfoDBContext> options) : base(options)
        {
        }

        public DbSet<Learner> Learners { get; set; }
        public DbSet<CourseSubscription> CourseSubscriptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CourseSubscription>(entity =>
            {
                entity.HasKey(e => e.SubscriberId).HasName("PK__CourseSu__7DFEB634445F815C");

                entity.ToTable("CourseSubscription");

                entity.Property(e => e.SubscriberId).HasColumnName("SubscriberID");
                entity.Property(e => e.ContentLevel).HasMaxLength(255);
                entity.Property(e => e.CourseHours).HasColumnType("decimal(10, 2)");
                entity.Property(e => e.CourseId)
                    .HasMaxLength(255)
                    .HasColumnName("CourseID");
                entity.Property(e => e.CourseName).HasMaxLength(255);
                entity.Property(e => e.CourseType).HasMaxLength(255);
                entity.Property(e => e.CurriculumDispCat).HasMaxLength(255);
                entity.Property(e => e.SessionId)
                    .HasMaxLength(255)
                    .HasColumnName("SessionID");
                entity.Property(e => e.SubscribedDateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<CourseSubscription>(entity =>
            {
                entity.HasKey(e => e.SubscriberId).HasName("PK__CourseSu__7DFEB634445F815C");

                entity.ToTable("CourseSubscription");

                entity.Property(e => e.SubscriberId).HasColumnName("SubscriberID");
                entity.Property(e => e.ContentLevel).HasMaxLength(255);
                entity.Property(e => e.CourseHours).HasColumnType("decimal(10, 2)");
                entity.Property(e => e.CourseId)
                    .HasMaxLength(255)
                    .HasColumnName("CourseID");
                entity.Property(e => e.CourseName).HasMaxLength(255);
                entity.Property(e => e.CourseType).HasMaxLength(255);
                entity.Property(e => e.CurriculumDispCat).HasMaxLength(255);
                entity.Property(e => e.SessionId)
                    .HasMaxLength(255)
                    .HasColumnName("SessionID");
                entity.Property(e => e.SubscribedDateTime).HasColumnType("datetime");
            });
        }
    }
}
