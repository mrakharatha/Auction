﻿using System;
using System.Collections.Generic;
using System.Linq;
using Auction.Domain.Convertors;
using Auction.Domain.Interfaces;
using Auction.Domain.Models;
using Auction.Domain.ViewModels;
using Auction.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Auction.Infra.Data.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationContext _context;

        public ProductRepository(ApplicationContext context)
        {
            _context = context;
        }

        public List<Product> GetProducts(int userId)
        {
            return _context.Products
                .Where(x =>
                    x.UserId == userId&&
                    !x.IsFinish)
                .Include(x=> x.Category)
                .OrderBy(x => x.ProductId)
                .ToList();
        }

        public List<Product> GetProducts(int? categoryId, string filter,DateTime dateTime)
        {
            IQueryable<Product> query = _context.Products.Where(x => !x.IsFinish && x.StartDate <= dateTime && x.EndDate >= dateTime);

            if (categoryId != null)
                query = query.Where(x => x.CategoryId.Equals(categoryId));

            if (!string.IsNullOrWhiteSpace(filter))
                query = query.Where(x => x.ProductName.Contains(filter) || x.Category.CategoryName.Contains(filter));


            return query.ToList();
        }

        public ProductDetailViewModel GetProductDetail(int productId)
        {
            return _context.Products
                .Where(x => x.ProductId == productId)
                .Include(x=> x.User)
                .Include(x=> x.ProductFeatures)
                .Include(x=> x.ProductImages)
                .Select(x=> new ProductDetailViewModel()
                {
                    ProductId = x.ProductId,
                    ProductName = x.ProductName,
                    Price = x.Price,
                    FullName = x.User.FullName,
                    Description = x.Description,
                    ProductFeatures = x.ProductFeatures,
                    ProductImages = x.ProductImages,
                    ProductImage = x.Image
                })
                .SingleOrDefault();
        }

        public void AddProduct(Product product)
        {
            _context.Add(product);
            _context.SaveChanges();
        }

        public Product GetProduct(int productId)
        {
            return _context.Products.Find(productId);
        }

        public ProductEditViewModel GetProductViewModel(int productId)
        {
           return _context.Products
                .Where(x => x.ProductId == productId)
                .Select(x => new ProductEditViewModel()
                {
                    EndDate = x.EndDate.ToShamsi(),
                    StartDate = x.StartDate.ToShamsi(),
                    CategoryId = x.CategoryId,
                    Description = x.Description,
                    EndTime = x.EndDate.ToString("HH:mm"),
                    StartTime = x.StartDate.ToString("HH:mm"),
                    Price = x.Price,
                    ProductId = x.ProductId,
                    ProductName = x.ProductName,
                    UserId = x.UserId
                })
                .SingleOrDefault();
        }

        public void UpdateProduct(Product product)
        {
            _context.Update(product);
            _context.SaveChanges();
        }

        public List<AuctionViewModel> GetAuction(DateTime dateTime)
        {
          return  _context.Products
                .Include(x => x.Category)
                .Where(x => !x.IsFinish && x.StartDate <= dateTime && x.EndDate >= dateTime)
                .ToList()
                .GroupBy(
                    p => p.CategoryId,
                    (key, g) => new AuctionViewModel
                    {
                        Products = g.OrderByDescending(x => x.StartDate).Take(3).ToList(),
                        Category = g.FirstOrDefault().Category
                    }).ToList();
        }

        public List<ProductFeature> GetFeatures(int productId)
        {
            return _context.ProductFeatures.Where(x => x.ProductId == productId).ToList();
        }

        public void AddFeature(ProductFeature feature)
        {
            _context.Add(feature);
            _context.SaveChanges();
        }

        public void DeleteFeature(int featureId)
        {
            var productFeature = _context.ProductFeatures.Find(featureId);
            _context.Remove(productFeature);
            _context.SaveChanges();
        }

        public List<ProductTag> GetTags(int productId)
        {
            return _context.ProductTags.Where(x => x.ProductId == productId).ToList();
        }

        public void AddTag(ProductTag tag)
        {
            _context.Add(tag);
            _context.SaveChanges();
        }

        public void DeleteTag(int tagId)
        {
            var productTag = _context.ProductTags.Find(tagId);
            _context.Remove(productTag);
            _context.SaveChanges();
        }

        public List<ProductImage> GetImages(int productId)
        {
            return _context.ProductImages.Where(x => x.ProductId == productId).ToList();
        }

        public void AddImage(ProductImage image)
        {
            _context.Add(image);
            _context.SaveChanges();
        }

        public string DeleteImage(int imageId)
        {
            var productImage = _context.ProductImages.Find(imageId);
            _context.Remove(productImage);
            _context.SaveChanges();
            return productImage.ProductImageName;
        }
    }
}