using System;
using System.Collections.Generic;
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

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public List<Product> GetProducts(int userId)
        {
            return _productRepository.GetProducts(userId);
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
                EndDate = model.StartDate.ToDateTime(model.EndTime),
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
            product.EndDate = model.StartDate.ToDateTime(model.EndTime);

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
            var imageName=_productRepository.DeleteImage(imageId);
            FileUploader.DeleteFile(imageName);
        }
    }
}