using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;
using WishListApp.Models;
using WishListApp.Repository.Interfaces;

namespace WishListApp.Repository
{
    public class WishRepository : IWishRepository
    {
        public async Task CreateWishItem(WishItem wishItem)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var jsonContent = new StringContent(JsonSerializer.Serialize(wishItem), Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync("https://localhost:7043/api/WishItem", jsonContent);
            }
        }

        public async Task DeleteWishItem(int id)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.DeleteAsync($"https://localhost:7043/api/WishItem/{id}");
            }
        }

        public async Task<WishItem> GetWishItem(int id)
        {
            WishItem wishItem = null;

            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.GetAsync($"https://localhost:7043/api/WishItem/{id}");

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    wishItem = JsonSerializer.Deserialize<WishItem>(jsonResponse);
                }

            }
            return wishItem;
        }

        public async Task<List<WishItem>> GetWishItems()
        {
            List<WishItem> wishItems = new List<WishItem>();

            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.GetAsync("https://localhost:7043/api/WishItem");

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    wishItems = JsonSerializer.Deserialize<List<WishItem>>(jsonResponse);

                }
            }
            return wishItems;
        }

        public async Task UpdateWishItem(WishItem item)
        {
            WishItem itemToSave = new WishItem
            {
                Id = item.Id,
                Title = item.Title,
                Description = item.Description
            };

            using (HttpClient httpClient = new HttpClient())
            {
                var json = JsonSerializer.Serialize(itemToSave);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await httpClient.PutAsync($"https://localhost:7043/api/WishItem/{itemToSave.Id}", content);
            }
        }
    }
}
