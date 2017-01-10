using Core.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Core.DB.Configurations
{
    public class PostConfiguration : EntityTypeConfiguration<Post>
    {
        public PostConfiguration()
        {
            ToTable("Posts");

            HasKey(p => p.ID);

            Property(p => p.Title)
                .IsRequired()
                .HasMaxLength(200)
                .HasColumnType("nvarchar");

            Property(p => p.Slug)
                .IsRequired()
                .HasMaxLength(200)
                .HasColumnType("nvarchar");

            Property(p => p.Description)
                .IsRequired()
                .HasColumnType("nvarchar");

            Property(p => p.CoverPhoto)
                .IsRequired()
                .HasMaxLength(200)
                .HasColumnType("nvarchar");

            HasRequired(p => p.CreatorUser)
                .WithMany(u => u.Posts)
                .HasForeignKey(p => p.CreatorUserID)
                .WillCascadeOnDelete(false);

            HasRequired(p => p.Category)
                .WithMany(c => c.Posts)
                .HasForeignKey(p => p.CategoryID)
                .WillCascadeOnDelete(false);

            HasRequired(p => p.Type)
                .WithMany(t => t.PostTypes)
                .HasForeignKey(p => p.TypeID)
                .WillCascadeOnDelete(false);

            HasRequired(p => p.Language)
                .WithMany(t => t.PostLanguages)
                .HasForeignKey(p => p.LanguageID)
                .WillCascadeOnDelete(false);

            HasRequired(p => p.Status)
                .WithMany(t => t.PostStatuses)
                .HasForeignKey(p => p.StatusID)
                .WillCascadeOnDelete(false);

        }
    }
}
