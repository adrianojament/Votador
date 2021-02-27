using Blazored.Modal;
using Blazored.Modal.Services;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using votador.Shared.Display;
using votador.Shared.Votacao;

namespace votador.Helpers
{
    public static class Helppers
    {
        static async Task<Settings> getSetttings(HttpClient http)
        {
            string json = await http.GetStringAsync(http.BaseAddress.AbsolutePath + "appsettings.json");            
            return await http.GetFromJsonAsync<Settings>(http.BaseAddress.AbsolutePath + "appsettings.json");
        }

        public static async Task<string> getUrlAPI(HttpClient http)
        {
            var settings = await getSetttings(http);
            return settings.ApiUrl;
        }

        public static async Task<string> getUrlAPI_Recursos(HttpClient http)
        {
            var settings = await getSetttings(http);            
            return $"{settings.ApiUrl}{settings.ApiUrlRecursos}";
        }

        public static async Task<string> getUrlAPI_Usuarios(HttpClient http)
        {
            var settings = await getSetttings(http);            
            return $"{settings.ApiUrl}{settings.ApiUrlUsuarios}";
        }

        public static async Task<string> getUrlAPI_Votacao(HttpClient http)
        {
            var settings = await getSetttings(http);
            return $"{settings.ApiUrl}{settings.ApiUrlVotacao}";
        }

        public static async Task<SimNao> ExibirMensagemSimNao(IModalService Modal, string mensagem)
        {
            var options = new ModalOptions()
            {
                DisableBackgroundCancel = true,
                HideHeader = true,
                HideCloseButton = true,
            };

            var parameters = new ModalParameters();
            parameters.Add(nameof(DisplayMessageYesNo.Message), mensagem);

            var messageForm = Modal.Show<DisplayMessageYesNo>("Atenção", parameters, options);
            var result = await messageForm.Result;

            return result.Cancelled ? SimNao.Nao : SimNao.Sim;
        }

        public static async Task ExibirMensagem(IModalService Modal, string mensagem)
        {
            var options = new ModalOptions()
            {
                DisableBackgroundCancel = true,
                HideHeader = true,
                HideCloseButton = true,
            };

            var parameters = new ModalParameters();
            parameters.Add(nameof(DisplayAlert.Message), mensagem);

            var messageForm = Modal.Show<DisplayAlert>("Atenção", parameters, options);
            await messageForm.Result;
        }

        public static async Task<SimNao> ExibirVotacao(IModalService Modal, HttpClient http, Guid idRecurso)
        {
            var options = new ModalOptions()
            {
                DisableBackgroundCancel = true,                
                HideCloseButton = true,
                HideHeader=true,                
            };

            var parameters = new ModalParameters();
            parameters.Add(nameof(http), http);
            parameters.Add(nameof(idRecurso), idRecurso);

            var messageForm = Modal.Show<VotingBallot>("Atenção", parameters, options);
            var result = await messageForm.Result;

            return result.Cancelled ? SimNao.Nao : SimNao.Sim;
        }
    }

    public enum SimNao
    {
        Sim=1,
        Nao=0
    }
}
