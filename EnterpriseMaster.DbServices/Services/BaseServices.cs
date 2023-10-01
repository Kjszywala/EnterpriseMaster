using EnterpriseMaster.DbServices.Interfaces;
using System;
using System.Net.Http.Json;

namespace EnterpriseMaster.DbServices.Services
{
    public class BaseServices<T> 
        : IBaseServices<T> 
        where T : class
    {
        #region Variables

        /// <summary>
        /// Http client to send post requests.
        /// </summary>
        public readonly HttpClient _httpClient;

        /// <summary>
        /// Url to API calls.
        /// </summary>
        public readonly string URL;

        /// <summary>
        /// Uri of the API endpoint.
        /// </summary>
        public readonly string URI;

        #endregion

        #region Constructor

        public BaseServices(string _URI)
        {
            URL = "https://localhost:7249/swagger/v1/swagger.json";
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(URL);
            URI = _URI;
        }

        #endregion

        #region Methods

        public async Task<bool> AddAsync(T Item)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync(URI, Item);
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Endpoint: {URI}\nFailed to retrieve data from API. Task<bool> AddAsync(T Item)", ex);
            }
        }

        public async Task<bool> EditAsync(int Id, T Item)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync(URI + Id, Item);
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Endpoint: {URI}\nFailed to retrieve data from API. Task<bool> EditAsync(int Id, T Item)", ex);
            }
        }

        public async Task<List<T>> GetAllAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync(URI);
                response.EnsureSuccessStatusCode();
                var data = await response.Content.ReadFromJsonAsync<List<T>>();
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception($"Endpoint: {URI}\nFailed to retrieve data from API. Task<List<T>> GetAllAsync()", ex);
            }
        }

        public async Task<T> GetAsync(int Id)
        {
            try
            {
                var response = await _httpClient.GetAsync(URI + Id);
                response.EnsureSuccessStatusCode();
                var data = await response.Content.ReadFromJsonAsync<T>();
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception($"Endpoint: {URI}\nFailed to retrieve data from API. Task<T> GetAsync(int Id)", ex);
            }
        }

        public async Task<bool> RemoveAsync(int Id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync(URI + Id);
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Endpoint: {URI}\nFailed to retrieve data from API. Task<bool> RemoveAsync(int Id)", ex);
            }
        }

        #endregion
    }
}
