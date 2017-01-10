using Core.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Core.DB.Configurations
{
    public class PostRatingConfiguration : EntityTypeConfiguration<PostRating>
    {
        public PostRatingConfiguration()
        {
            ToTable("PostRatings");

            HasKey(p => p.ID);

            Property(p => p.Rating)
                .IsRequired();

            HasRequired(p => p.User)
                .WithMany(u => u.PostRatings)
                .HasForeignKey(p => p.UserID)
                .WillCascadeOnDelete(false);

            HasRequired(p => p.Post)
                .WithMany(p => p.Ratings)
                .HasForeignKey(p => p.PostID)
                .WillCascadeOnDelete(true);
        }
    }
}
