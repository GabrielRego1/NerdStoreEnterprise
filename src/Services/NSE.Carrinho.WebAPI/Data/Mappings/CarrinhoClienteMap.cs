using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSE.Carrinho.WebAPI.Model;

namespace NSE.Carrinho.WebAPI.Data.Mappings
{
    public class CarrinhoClienteMap : IEntityTypeConfiguration<CarrinhoCliente>
    {
        public void Configure(EntityTypeBuilder<CarrinhoCliente> builder)
        {
            builder.HasKey(c => c.Id);

            builder.HasIndex(c => c.ClienteId)
                .HasName("IDX_Cliente");

            builder.Ignore(c => c.Voucher)
                   .OwnsOne(c => c.Voucher, v =>
                   {
                       v.Property(vc => vc.Codigo)
                           .HasColumnName("VoucherCodigo")
                           .HasColumnType("varchar(50)");

                       v.Property(vc => vc.TipoDesconto)
                           .HasColumnName("TipoDesconto");

                       v.Property(vc => vc.Percentual)
                           .HasColumnName("Percentual");

                       v.Property(vc => vc.ValorDesconto)
                           .HasColumnName("ValorDesconto");
                   });

            builder
                .HasMany(c => c.Itens)
                .WithOne(i => i.CarrinhoCliente)
                .HasForeignKey(c => c.CarrinhoId);
        }

    }
}
