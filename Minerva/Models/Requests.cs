using System.Collections.Generic;
using System.Threading.Tasks;
using Fortnite_API.Objects;
using RestSharp;

namespace Minerva.Models
{
    public class Requests
    {
        public static RestClient Client = new ("https://fortnite-api.com/");

        public static async Task<ApiResponse<List<Cosmetics>>> Connect(string where)
        {
            var request = new RestRequest(where, Method.GET);
            var response = await Client.ExecuteAsync<ApiResponse<List<Cosmetics>>>(request).ConfigureAwait(false);
            return response.Data;
        }
    }
}