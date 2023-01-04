using Album.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using Album.Service.Model;

namespace Album.Service.Service
{
    public class AlbumService : IAlbumService
    {
        private readonly HttpClient httpClient;
        public AlbumService(IHttpClientFactory httpClientFactory)
        {
            httpClient = httpClientFactory.CreateClient(EndpointNames.Album);
        }

        public async Task<List<AlbumModel>> GetAlbums(CancellationToken cancellationToken)
        {
            JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };            
            var result = await httpClient.GetFromJsonAsync<List<AlbumModel>>("Album", jsonSerializerOptions, cancellationToken);
            return result ?? new List<AlbumModel>();
        }

        public async Task<bool> UpdateAlbum(AlbumModel album, CancellationToken cancellationToken)
        {
            bool result = false;
            var response = await httpClient.PostAsJsonAsync<AlbumModel>("Album", album);
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadFromJsonAsync<bool>();
            }
            return result;
        }

        public async Task<List<AlbumModel>> GetAlbumTrack(List<AlbumModel> albumIds, CancellationToken cancellationToken)
        {
            var response = await httpClient.PostAsJsonAsync<List<AlbumModel>>("Tracks", albumIds);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<List<AlbumModel>>();
                return result ?? new List<AlbumModel>();
            }
            return new List<AlbumModel>();
        }
    }
}
