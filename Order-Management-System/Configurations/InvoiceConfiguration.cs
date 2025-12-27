namespace Order_Management_System.Configurations
{
    public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.HasKey(i => i.InvoiceId);

            builder.Property(i => i.InvoiceDate)
                   .IsRequired()
                   .HasColumnType("datetime2");

            builder.Property(i => i.TotalAmount)
                   .IsRequired()
                   .HasColumnType("decimal(18,2)");

            builder.HasOne(i => i.Order)
                     .WithOne()
                     .HasForeignKey<Invoice>(i => i.OrderId)
                     .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
