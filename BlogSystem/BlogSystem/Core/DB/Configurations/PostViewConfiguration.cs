using Core.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Core.DB.Configurations
{
    public class PostViewConfiguration : EntityTypeConfiguration<PostView>
    {
        public PostViewConfiguration()
        {
            ToTable("PostViews");

            HasKey(p => p.ID);

            Property(p => p.IpAddress)
                .IsRequired()
                .HasMaxLength(50);

            Property(p => p.Count)
                .IsRequired();

            HasRequired(p => p.User)
                .WithMany(u => u.PostViews)
                .HasForeignKey(p => p.UserID)
                .WillCascadeOnDelete(false);

            HasRequired(p => p.Post)
                .WithMany(p => p.Views)
                .HasForeignKey(p => p.PostID)
                .WillCascadeOnDelete(true);
        }
    }
}
