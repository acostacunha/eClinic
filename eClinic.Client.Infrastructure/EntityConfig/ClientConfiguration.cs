using eClinic.Client.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Xml;
using ClientEntity = eClinic.Client.Domain.Entities.Client;

namespace eClinic.Client.Infrastructure.EntityConfig
{
    public class ClientConfiguration : IEntityTypeConfiguration<ClientEntity>
    {
        public const string NameTable = "Clients";
        public void Configure(EntityTypeBuilder<ClientEntity> builder)
        {
            _ = builder.ToTable(NameTable);
            _ = builder.HasKey(p => p.Id).HasName($"{NameTable}_P01");
            _ = builder.Property(p => p.Id).HasColumnName("ClienteId").IsRequired(true);
            _ = builder.Property(p => p.PublicId).HasColumnName("PublicId").IsRequired(true);
            _ = builder.Property(p => p.Name).HasColumnName("Name").HasColumnType("nvarchar(200)").IsRequired(true);
            _ = builder.Property(p => p.Phone).HasColumnName("Phone").HasColumnType("nvarchar(15)").IsRequired(true);
            _ = builder.Property(p => p.Birtdate).HasColumnName("Birtdate").HasColumnType("datetime2").IsRequired(true);
            _ = builder.Property(p => p.Gender).HasColumnName("Gender").HasConversion<string>().IsRequired(true);
            _ = builder.Property(p => p.Birtdate).HasColumnName("Birtdate").HasColumnType("datetime2").IsRequired(true);
            _ = builder.OwnsOne(p => p.Cpf, cpf =>
            {
                cpf.Property(p => p.CpfNumber).HasColumnName("Cpf").HasColumnType("nvarchar(11)").IsRequired(true);

                cpf.HasIndex(p => p.CpfNumber).IsUnique();
            });
            _ = builder.OwnsOne(p => p.Adress, address =>
            {
                address.Property(a => a.Street).HasColumnName("Street").HasMaxLength(200);
                address.Property(a => a.Number).HasColumnName("Number").HasMaxLength(20);
                address.Property(a => a.Complement).HasColumnName("Complement").HasMaxLength(200);
                address.Property(a => a.City).HasColumnName("City").HasMaxLength(100);
                address.Property(a => a.State).HasColumnName("State").HasMaxLength(2);
                address.Property(a => a.ZipCode).HasColumnName("ZipCode").HasMaxLength(9);
            });
            _ = builder.OwnsOne(p => p.Email, email =>
            {
                email.Property(a => a.Address).HasColumnName("Email").HasColumnType("nvarchar(200)").IsRequired(true);
            });
            _ = builder.Property(p => p.CreateAt).HasColumnName("CreateAt").IsRequired(true).ValueGeneratedOnAdd();
            _ = builder.Property(p => p.UpdateAt).HasColumnName("UpdateAt").IsRequired(false);

            _ = builder.HasIndex( x => x.Id ).IsUnique();
            _ = builder.HasIndex(x => x.PublicId).IsUnique();


        }
    }
}
