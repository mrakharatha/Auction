﻿using System;
using System.Collections.Generic;
using Auction.Domain.Models;
using Auction.Domain.ViewModels;

namespace Auction.Domain.Interfaces
{
    public interface IProductRepository
    {
        List<Domain.Models.Auction> GetWinner(int userId);
        ActivityViewModel GetActivity(int userId);
        Domain.Models.Auction GetAuction(int auctionId);
        void UpdateAuction(Domain.Models.Auction auction);
        void AddOfferHistory(OfferHistory offerHistory);
        int GetLastOfferHistory(int productId);
        List<Product> GetProducts(int userId);
        List<Product> GetProducts(int? categoryId, string filter,DateTime dateTime);
        ProductDetailViewModel GetProductDetail(int productId);
        void AddProduct(Product product);
        Product GetProduct(int productId);
        ProductEditViewModel GetProductViewModel(int productId);
        void UpdateProduct(Product product);
        List<AuctionViewModel> GetAuction(DateTime dateTime);
        List<ProductFeature> GetFeatures(int productId);
        void AddFeature(ProductFeature feature);
        void DeleteFeature(int featureId);
        List<ProductTag> GetTags(int productId);
        void AddTag(ProductTag tag);
        void DeleteTag(int tagId);
        List<ProductImage> GetImages(int productId);
        void AddImage(ProductImage image);
        string DeleteImage(int imageId);
        List<ProductsExpireAuctionViewModel> GetProductsExpireAuction(int userId, DateTime dateTime);
        void UpdateProductsRange(List<Product> products);
        void AddAuctionsRange(List<Domain.Models.Auction> auctions);
        List<Domain.Models.Auction> GetAuctionExpire(int userId);

    }
}