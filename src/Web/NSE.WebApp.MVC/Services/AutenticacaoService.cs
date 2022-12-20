using NSE.WebApp.MVC.Models;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace NSE.WebApp.MVC.Services
{
    public class AutenticacaoService : Service, IAutenticacaoService
    {
        private readonly HttpClient _httpClient;
        public AutenticacaoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<UsuarioRespostaLogin> Login(UsuarioLogin usuarioLogin)
        {
            var loginContent = ObterConteudo(usuarioLogin);

            var response = await _httpClient.PostAsync("https://localhost:44323/api/identidade/autenticar", loginContent);


            if (!TratarErrosResponse(response))
            {
                return new UsuarioRespostaLogin
                {
                    ResponseResult = await DeserialiarObjetoResponse<ResponseResult>(response)
                };
            }

            return await DeserialiarObjetoResponse<UsuarioRespostaLogin>(response);
        }

        public async Task<UsuarioRespostaLogin> Registro(UsuarioRegistro usuarioRegistro)
        {
            var loginContent = ObterConteudo(usuarioRegistro);

            var response = await _httpClient.PostAsync("https://localhost:44323/api/identidade/nova-conta", loginContent);

            if (!TratarErrosResponse(response))
            {
                return new UsuarioRespostaLogin
                {
                    ResponseResult = await DeserialiarObjetoResponse<ResponseResult>(response)
                };
            }
            return await DeserialiarObjetoResponse<UsuarioRespostaLogin>(response);
        }
    }
}
