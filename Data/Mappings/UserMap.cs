using IbgeAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IbgeAPI.Data.Mappings;

public class UserMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.FirstName)
            .HasColumnType("nvachar")
            .HasMaxLength(15);

        builder.Property(x => x.LastName)
            .HasColumnType("nvachar")
            .HasMaxLength(20);

        builder.OwnsOne(x => x.Email, email =>
        {
            email.Property(x => x.Address)
                .IsRequired()
                .HasColumnType("nvarchar");
        });

        builder.OwnsOne(x => x.Password, password =>
        { 
            password.Property(x => x.Keyword)
                .IsRequired()
                .HasColumnType("nvarchar");
        });
    }
}
