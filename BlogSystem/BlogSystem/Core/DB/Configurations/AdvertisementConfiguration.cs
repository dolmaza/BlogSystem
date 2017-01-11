using Core.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Core.DB.Configurations
{
    public class AdvertisementConfiguration : EntityTypeConfiguration<Advertisement>
    {
        public AdvertisementConfiguration()
        {
            ToTable("Advertisements");

            HasKey(a => a.ID);

            Property(a => a.Title)
                .IsRequired()
                .HasMaxLength(200)
                .HasColumnType("nvarchar");

            Property(a => a.Description)
                .IsRequired()
                .HasColumnType("nvarchar");

            Property(a => a.CoverPhoto)
                .IsRequired()
                .HasMaxLength(250)
                .HasColumnType("nvarchar");

            Property(a => a.Url)
                .IsRequired()
                .HasMaxLength(200)
                .HasColumnType("nvarchar");

            Property(a => a.DaysCount)
                .IsRequired();

            Property(a => a.PostsCount)
                .IsRequired();

            Property(a => a.Price)
                .IsRequired()
                .HasColumnType("money");

            HasRequired(a => a.User)
                .WithMany(u => u.Advertisements)
                .HasForeignKey(a => a.UserID)
                .WillCascadeOnDelete(false);

            HasRequired(a => a.Status)
                .WithMany(s => s.AdvertisementStatuses)
                .HasForeignKey(a => a.StatusID)
                .WillCascadeOnDelete(false);

            HasMany(a => a.Categories)
                .WithMany(c => c.Advertisements)
                .Map(m =>
                {
                    m.ToTable("AdvertisementCategories");
                    m.MapLeftKey("AdvertisementID");
                    m.MapRightKey("CategoryID");
                });

        }
    }
}
