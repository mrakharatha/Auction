using System;
using System.Collections.Generic;
using System.Linq;
using Auction.Application.Interfaces;
using Auction.Application.Utilities;
using Auction.Domain.Convertors;
using Auction.Domain.Interfaces;
using Auction.Domain.Models;
using Auction.Domain.ViewModels;

namespace Auction.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ISettingService _settingService;
        private readonly IWalletService _walletService;
        public ProductService(IProductRepository productRepository, ISettingService settingService, IWalletService walletService)
        {
            _productRepository = productRepository;
            _settingService = settingService;
            _walletService = walletService;
        }

        public ActivityViewModel GetActivity(int userId)
        {
            return _productRepository.GetActivity(userId);
        }

        public List<Product> GetProducts(int userId)
        {
            return _productRepository.GetProducts(userId);
        }

        public List<Product> GetProducts(int? categoryId, string filter, DateTime dateTime)
        {
            return _productRepository.GetProducts(categoryId, filter, dateTime);
        }

        public void AddProduct(ProductViewModel model)
        {
            var image = model.File.Upload(nameof(Product));

            var product = new Product()
            {
                CategoryId = model.CategoryId,
                UserId = model.UserId,
                ProductName = model.ProductName,
                Price = model.Price,
                Description = model.Description,
                Image = image,
                StartDate = model.StartDate.ToDateTime(model.StartTime),
                EndDate = model.EndDate.ToDateTime(model.EndTime),
            };

            AddProduct(product);
        }

        public void AddProduct(Product product)
        {
            _productRepository.AddProduct(product);
        }

        public Product GetProduct(int productId)
        {
            return _productRepository.GetProduct(productId);
        }

        public ProductDetailViewModel GetProductDetail(int productId)
        {
            return _productRepository.GetProductDetail(productId);
        }

        public ProductEditViewModel GetProductViewModel(int productId)
        {
            return _productRepository.GetProductViewModel(productId);
        }

        public void UpdateProduct(ProductEditViewModel model)
        {
            var product = GetProduct(model.ProductId);
            var image = model.File.Upload(nameof(Product), product.Image);

            product.CategoryId = model.CategoryId;
            product.UserId = model.UserId;
            product.ProductName = model.ProductName;
            product.Price = model.Price;
            product.Description = model.Description;
            product.Image = image;
            product.StartDate = model.StartDate.ToDateTime(model.StartTime);
            product.EndDate = model.EndDate.ToDateTime(model.EndTime);

            UpdateProduct(product);
        }

        public void UpdateProduct(Product product)
        {
            _productRepository.UpdateProduct(product);
        }

        public void DeleteProduct(int id, int userId)
        {
            var product = GetProduct(id);
            product.UserId = userId;
            product.DeleteDate = DateTime.Now;
            UpdateProduct(product);
        }

        public List<AuctionViewModel> GetAuction(DateTime dateTime)
        {
            return _productRepository.GetAuction(dateTime);
        }

        public List<ProductFeature> GetFeatures(int productId)
        {
            return _productRepository.GetFeatures(productId);
        }

        public void AddFeature(ProductFeature feature)
        {
            _productRepository.AddFeature(feature);
        }

        public void DeleteFeature(int featureId)
        {
            _productRepository.DeleteFeature(featureId);
        }

        public List<ProductTag> GetTags(int productId)
        {
            return _productRepository.GetTags(productId);
        }

        public void AddTag(ProductTag tag)
        {
            _productRepository.AddTag(tag);
        }

        public void DeleteTag(int tagId)
        {
            _productRepository.DeleteTag(tagId);
        }

        public List<ProductImage> GetImages(int productId)
        {
            return _productRepository.GetImages(productId);
        }

        public void AddImage(ProductImage image)
        {
            _productRepository.AddImage(image);
        }

        public void AddImage(ProductImageViewModel model)
        {
            var image = model.File.Upload(nameof(ProductImage));

            var productImage = new ProductImage()
            {
                ProductId = model.ProductId,
                ProductImageName = image
            };
            AddImage(productImage);
        }

        public void DeleteImage(int imageId)
        {
            var imageName = _productRepository.DeleteImage(imageId);
            FileUploader.DeleteFile(imageName);
        }

        public int GetLastOfferHistory(int productId)
        {
            return _productRepository.GetLastOfferHistory(productId);
        }

        public OperationResult CheckPrice(int productId, int userId, int offeredPrice)
        {
            var balanceUserWallet = _walletService.BalanceUserWallet(userId);

            if (offeredPrice > balanceUserWallet)
                return new OperationResult() { IsSucceed = false, Message = "موجودی کیف پول شما کافی نمی باشد" };


            var price = GetLastOfferHistory(productId);

            if (price == 0)
                price = GetProduct(productId).Price;


            var growthLadder = _settingService.GetSetting().GrowthLadder;

            var minimumMoney = (price * growthLadder / 100) + price;


            if (offeredPrice < minimumMoney)
                return new OperationResult() { IsSucceed = false, Message = $"حداقل مبلغ پیشنهادی {minimumMoney:#,0} تومان می باشد" };

            return new OperationResult() { IsSucceed = true };
        }

        public void AddOfferHistory(OfferHistory offerHistory)
        {
            _productRepository.AddOfferHistory(offerHistory);
        }

        public void CalculateAuction(int userId)
        {
            var productsExpireAuctions = GetProductsExpireAuction(userId, DateTime.Now);
            var auctions = new List<Domain.Models.Auction>();

            foreach (var item in productsExpireAuctions)
            {
                if (item.OfferHistory == null)
                    break;

                var product = item.Product;
                var offerHistory = item.OfferHistory;

                _walletService.UpdateWallet(WalletType.Block,WalletType.Decrease, offerHistory.UserId, offerHistory.Price, $"برنده  مزایده محصول : {product.ProductName}");

                Domain.Models.Auction auction = new Domain.Models.Auction()
                {
                    ProductId = product.ProductId,
                    Price = offerHistory.Price,
                    ReceiveStatus = false,
                    ShippingStatus = false,
                    BuyerId = offerHistory.UserId,
                    SellerId = product.ProductId,
                };

                auctions.Add(auction);

            }

            var products = productsExpireAuctions.Select(x => x.Product).ToList();
            products.ForEach(x => x.IsFinish = true);
            UpdateProductsRange(products);
            AddAuctionsRange(auctions);
        }

        public List<ProductsExpireAuctionViewModel> GetProductsExpireAuction(int userId, DateTime dateTime)
        {
            return _productRepository.GetProductsExpireAuction(userId, dateTime);
        }

        public void UpdateProductsRange(List<Product> products)
        {
            _productRepository.UpdateProductsRange(products);
        }

        public void AddAuctionsRange(List<Domain.Models.Auction> auctions)
        {
            _productRepository.AddAuctionsRange(auctions);
        }

        public List<Domain.Models.Auction> GetAuctionExpire(int userId)
        {
            return _productRepository.GetAuctionExpire(userId);
        }

        public void UpdateShipping(int auctionId)
        {
            var auction = GetAuction(auctionId);

            auction.ShippingStatus = true;

            UpdateAuction(auction);
        }

        public Domain.Models.Auction GetAuction(int auctionId)
        {
            return _productRepository.GetAuction(auctionId);
        }

        public void UpdateAuction(Domain.Models.Auction auction)
        {
            _productRepository.UpdateAuction(auction);
        }

        public List<Domain.Models.Auction> GetWinner(int userId)
        {
            return _productRepository.GetWinner(userId);
        }

        public void UpdateReceive(int auctionId)
        {
            var auction = GetAuction(auctionId);

            auction.ReceiveStatus = true;

            var commissionPercentage = _settingService.GetSetting().CommissionPercentage;

            var commission = auction.Price * commissionPercentage / 100;

            _walletService.UpdateWallet(WalletType.Commission,WalletType.Increase, 1, commission, "کمیسیون  مزایده");

            var leftOver = auction.Price - commission;

            _walletService.UpdateWallet(WalletType.Sale,WalletType.Increase, auction.SellerId, leftOver, "فروش محصول");

            UpdateAuction(auction);
        }
    }
}