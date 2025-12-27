namespace Order_Management_System.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.OrderId);

            builder.Property(o => o.OrderDate)
                .IsRequired();

            builder.Property(o => o.TotalAmount)
                .HasColumnType("decimal(18,2)");

            builder.Property(o => o.PaymentMethod)
                .IsRequired();

            builder.Property(o => o.Status)
                .IsRequired();

            builder.HasMany(o => o.OrderItems)
                .WithOne(oi => oi.Order)
                .HasForeignKey(oi => oi.OrderId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
