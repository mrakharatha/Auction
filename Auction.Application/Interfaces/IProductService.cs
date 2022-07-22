using System;
using System.Collections.Generic;
using Auction.Application.Utilities;
using Auction.Domain.Models;
using Auction.Domain.ViewModels;

namespace Auction.Application.Interfaces
{
    public interface IProductService
    {
        ActivityViewModel GetActivity(int userId);
        List<Product> GetProducts(int userId);
        List<Product> GetProducts(int? categoryId,string filter,DateTime dateTime);
        void AddProduct(ProductViewModel model);
        void AddProduct(Product product);

        Product GetProduct(int productId);
        ProductDetailViewModel GetProductDetail(int productId);
        ProductEditViewModel GetProductViewModel(int productId);
        void UpdateProduct(ProductEditViewModel model);
        void UpdateProduct(Product product);
        void DeleteProduct(int id, int userId);

        List<AuctionViewModel> GetAuction(DateTime dateTime);

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


        int GetLastOfferHistory(int productId);
        OperationResult CheckPrice(int productId,int userId,int offeredPrice);
        void AddOfferHistory(OfferHistory offerHistory);
        void CalculateAuction(int userId);

        List<ProductsExpireAuctionViewModel> GetProductsExpireAuction(int userId,DateTime dateTime);
        void UpdateProductsRange(List<Product> products);
        void AddAuctionsRange(List<Domain.Models.Auction> auctions);
        List<Domain.Models.Auction> GetAuctionExpire(int userId);
        void UpdateShipping(int auctionId);
        Domain.Models.Auction GetAuction(int auctionId);
        void UpdateAuction(Domain.Models.Auction auction);
        List<Domain.Models.Auction> GetWinner(int userId);
        void UpdateReceive(int auctionId);
    }
}