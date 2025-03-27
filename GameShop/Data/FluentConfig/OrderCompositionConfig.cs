using EF_Core_Project.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF_Core_Project.Data.FluentConfig;

public class OrderCompositionConfig : IEntityTypeConfiguration<OrderСomposition>
{
    public void Configure(EntityTypeBuilder<OrderСomposition> builder)
    {
        builder.HasKey(oc => oc.Id);
        
        builder.Property(oc => oc.Count)
            .IsRequired();
        
        builder.Property(oc => oc.TotalAmount)
            .HasColumnType("decimal(18,2)");
        
        builder.HasOne(oc => oc.Order)
            .WithMany(o => o.OrderСompositions)
            .HasForeignKey(oc => oc.OrderId);
        
        builder.HasOne(oc => oc.Game)
            .WithMany()
            .HasForeignKey(oc => oc.GameId);
    }
}