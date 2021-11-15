using domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace data.Mapping
{
  public class UserMap : IEntityTypeConfiguration<UserEntity>
  {
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
      builder.ToTable("User");
      builder.HasKey(user => user.Id);
      builder.HasIndex(user => user.Email).IsUnique();
      builder.Property(user => user.Name).HasMaxLength(200).IsRequired();
      builder.Property(user => user.Email).HasMaxLength(200).IsRequired();
    }
  }
}