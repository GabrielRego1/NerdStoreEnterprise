using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NSE.Pedidos.WebAPI.Application.DTO;
using NSE.Pedidos.WebAPI.Application.Queries;
using NSE.WebApi.Core.Controllers;
using System.Net;
using System.Threading.Tasks;

namespace NSE.Pedidos.WebAPI.Controllers
{
    [Authorize]
    public class VoucherController : MainController
    {
        private readonly IVoucherQuerie _voucherQuerie;
        public VoucherController(IVoucherQuerie voucherQuerie)
        {
            _voucherQuerie = voucherQuerie;
        }


        [HttpGet("voucher/{codigo}")]
        [ProducesResponseType(typeof(VoucherDTO), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> ObterPorCodigo(string codigo)
        {
            if (string.IsNullOrEmpty(codigo))
                return NotFound();

            var voucher = await _voucherQuerie.ObterVoucherPorCodigo(codigo);

            return voucher == null ? NotFound() : CustomResponse(voucher);
        }


    }
}
