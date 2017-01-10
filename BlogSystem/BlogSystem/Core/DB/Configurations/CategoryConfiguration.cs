using Core.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Core.DB.Configurations
{
    public class CategoryConfiguration : EntityTypeConfiguration<Category>
    {
        public CategoryConfiguration()
        {
            ToTable("Categories");

            HasKey(c => c.ID);

            Property(c => c.Caption)
                .IsRequired()
                .HasMaxLength(200);

            HasOptional(c => c.Parent)
                .WithMany(c => c.Childrens)
                .HasForeignKey(c => c.ParentID)
                .WillCascadeOnDelete(false);
        }
    }
}
