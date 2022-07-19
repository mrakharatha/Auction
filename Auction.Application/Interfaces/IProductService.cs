using System.Collections.Generic;
using Auction.Domain.Models;
using Auction.Domain.ViewModels;

namespace Auction.Application.Interfaces
{
    public interface IProductService
    {
        List<Product> GetProducts(int userId);
        void AddProduct(ProductViewModel model);
        void AddProduct(Product product);

        Product GetProduct(int productId);
        ProductEditViewModel GetProductViewModel(int productId);
        void UpdateProduct(ProductEditViewModel model);
        void UpdateProduct(Product product);
        void DeleteProduct(int id, int userId);



        List<ProductFeature> GetFeatures(int productId);
        void AddFeature(ProductFeature feature);
        void DeleteFeature(int featureId);


        List<ProductTag> GetTags(int productId);
        void AddTag(ProductTag tag);
        void DeleteTag(int tagId);


        List<ProductImage> GetImages(int productId);
        void AddImage(ProductImage image);
        void AddImage(ProductImageViewModel model);
        void DeleteImage(int imageId);
    }
}