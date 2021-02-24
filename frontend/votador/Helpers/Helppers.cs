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
        public static async Task<string> getUrlAPI(HttpClient http)
        {   
            var response = await http.GetFromJsonAsync<Settings>(http.BaseAddress.AbsolutePath + "settings.json");
            return response.ApiUrl;
        }
    }
}
