using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace votador.Helpers
{
    public static class Helppers
    {
        static async Task<Settings> getSetttings(HttpClient http)
        {
            string json = await http.GetStringAsync(http.BaseAddress.AbsolutePath + "appsettings.json");
            Console.WriteLine(json);
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
            Console.WriteLine($"{settings.ApiUrl}{settings.ApiUrlRecursos}");
            return $"{settings.ApiUrl}{settings.ApiUrlRecursos}";
        }

        public static async Task<string> getUrlAPI_Usuarios(HttpClient http)
        {
            var settings = await getSetttings(http);
            Console.WriteLine($"{settings.ApiUrl}{settings.ApiUrlUsuarios}");
            return $"{settings.ApiUrl}{settings.ApiUrlUsuarios}";
        }
    }
}
