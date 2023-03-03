using NSE.Pedido.WebAPI.Application.DTO;
using NSE.Pedidos.Domain.Vouchers;
using System.Threading.Tasks;

namespace NSE.Pedido.WebAPI.Application.Queries
{
    public interface IVoucherQuerie
    {
        Task<VoucherDTO> ObterVoucherPorCodigo(string codigo);
    }
    public class VoucherQuerie : IVoucherQuerie
    {
        private readonly IVoucherRepository _voucherRepository;
        public VoucherQuerie(IVoucherRepository voucherRepository)
        {
            _voucherRepository = voucherRepository;
        }
        public async Task<VoucherDTO> ObterVoucherPorCodigo(string codigo)
        {
            var voucher = await _voucherRepository.ObterVoucherPorCodigo(codigo);

            if (voucher == null)
                return null;

            if (!voucher.EstaValidoParaUtilizacao())
                return null;

            return new VoucherDTO
            {
                Codigo = voucher.Codigo,
                TipoDesconto = (int)voucher.TipoDesconto,
                Percentual = voucher.Percentual,
                ValorDesconto = voucher.ValorDesconto
            };

        }
    }
}
