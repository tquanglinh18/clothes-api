using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClothesAPI.Context;
using ClothesAPI.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClothesAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        private readonly AppDbContext _dbContext;
        public ProductsController(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        // GET: api/values
        [HttpGet]
        [Route("/Products/list-products")]
        public IActionResult GetList()
        {
            return Ok(_dbContext.Products.ToList());
        }

        [HttpPost]
        [Route("/Products/Insert")]
        public IActionResult AddProducts(string Name, string? Description, string? Brand, string? Category,
            string? Gender, decimal Price, int? Discount, string? Sizes, string? Colors, string? Material, int? StockQuantity,
            string? Images, bool? IsNew, bool IsFeatured, double? Rating, DateTime? CreatedAt, DateTime? UpdatedAt)
        {

            var product = new Products
            {
                Name = Name,
                Description = Description,
                Brand = Brand,
                Category = Category,
                Gender = Gender,
                Price = Price,
                Discount = Discount,
                Sizes = Sizes,
                Colors = Colors,
                Material = Material,
                StockQuantity = StockQuantity,
                Images = Images,
                IsNew = IsNew,
                IsFeatured = IsFeatured,
                Rating = Rating,
                CreatedAt = CreatedAt ?? DateTime.Now,
                UpdatedAt = UpdatedAt ?? DateTime.Now
            };

            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();

            return Ok(product);
        }

        [HttpPost]
        [Route("/Products/Detail/{id}")]
        public IActionResult GetDetail(int id)
        {
            //var product = _dbContext.Products.FindAsync(id).Result;
            var product = _dbContext.Products.FirstOrDefault(idItem => idItem.Id == id);
            return Ok(product);
        }

        // POST api/values
        [HttpPost]
        [Route("/Products/Update/{id}")]
        public IActionResult UpdateProduct(int id, string Name, string? Description, string? Brand, string? Category,
            string? Gender, decimal Price, int? Discount, string? Sizes, string? Colors, string? Material, int? StockQuantity,
            string? Images, bool? IsNew, bool IsFeatured, double? Rating, DateTime? CreatedAt, DateTime? UpdatedAt)
        {
            var product = new Products
            {
                Id = id,
                Name = Name,
                Description = Description,
                Brand = Brand,
                Category = Category,
                Gender = Gender,
                Price = Price,
                Discount = Discount,
                Sizes = Sizes,
                Colors = Colors,
                Material = Material,
                StockQuantity = StockQuantity,
                Images = Images,
                IsNew = IsNew,
                IsFeatured = IsFeatured,
                Rating = Rating,
                CreatedAt = CreatedAt ?? DateTime.Now,
                UpdatedAt = UpdatedAt ?? DateTime.Now
            };

            _dbContext.Products.Update(product);
            _dbContext.SaveChanges();
            return Ok(product);
        }

        [HttpPost]
        [Route("/Products/Delete/{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = _dbContext.Products.FirstOrDefault(idItem => idItem.Id == id);
            if (product != null)
            {
                _dbContext.Products.Remove(product);
            } else
            {
                return Ok("Không tìm thấy sản phẩm!");
            }
            _dbContext.SaveChanges();
            return Ok("Xoá thành công!");
        }
    }
}

