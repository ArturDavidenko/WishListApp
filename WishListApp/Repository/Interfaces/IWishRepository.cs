using WishListApp.Models;

namespace WishListApp.Repository.Interfaces
{
    public interface IWishRepository
    {
        public Task<List<WishItem>> GetWishItems();
        
        public Task<WishItem> GetWishItem(int id);

        public Task DeleteWishItem(int id);
    }
}
