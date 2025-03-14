using EF_Core_Project.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF_Core_Project.Data.FluentConfig;

public class OrderConfig : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(o => o.Id);
        
        builder.Property(o => o.Date)
            .IsRequired();
        
        builder.Property(o => o.totalAmount)
            .HasColumnType("decimal(18,2)");
        
        builder.HasMany(o => o.OrderСomposition)
            .WithOne(o => o.Order)
            .HasForeignKey(o => o.OrderId);
    }
}