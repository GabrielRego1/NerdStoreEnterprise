using Microsoft.EntityFrameworkCore;
using NSE.Core.Data;
using NSE.Pedidos.Domain.Vouchers;
using System.Threading.Tasks;

namespace NSE.Pedidos.Infra.Data.Repositories
{
    public class VoucherRepository : IVoucherRepository
    {
        private readonly PedidosContext _context;

        public VoucherRepository(PedidosContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;


        public async Task<Voucher> ObterVoucherPorCodigo(string codigo)
            => await _context.Vouchers.FirstOrDefaultAsync(p => p.Codigo == codigo);

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
