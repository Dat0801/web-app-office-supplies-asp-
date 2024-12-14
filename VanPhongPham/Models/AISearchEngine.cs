using FuzzySharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Services.Description;

namespace VanPhongPham.Models
{
    public class AISearchEngine
    {
        public List<ProductViewModel> FindRelevantProducts(string searchQuery, List<ProductViewModel> products)
        {
            //// Triển khai thuật toán AI hoặc kết nối đến API (ví dụ OpenAI hoặc ML.NET)
            //var lowerQuery = searchQuery.ToLower();

            //// Tìm kiếm tương đối dựa trên TF-IDF hoặc Cosine Similarity
            //var filteredProducts = products
            //    .Where(p => ComputeRelevanceScore(lowerQuery, p) > 0) // Chỉ giữ sản phẩm liên quan
            //    .OrderByDescending(p => ComputeRelevanceScore(lowerQuery, p))
            //    .ToList();


            //return filteredProducts;
            var filteredProducts = products
            .Where(p =>
                Fuzz.PartialRatio(searchQuery.ToLower(), p.ProductName.ToLower()) > 70 || // Tìm trong tên sản phẩm
                (!string.IsNullOrWhiteSpace(p.Description) && Fuzz.PartialRatio(searchQuery.ToLower(), p.Description.ToLower()) > 70) ||  // Tìm trong mô tả sản phẩm
                Fuzz.PartialRatio(searchQuery.ToLower(), p.Categories.category_name.ToLower()) > 70 || // Tìm trong tên danh mục
                p.Attributes.Any(a => Fuzz.PartialRatio(searchQuery.ToLower(), a.AttributeName.ToLower()) > 70) // Tìm trong thuộc tính
            )
            .OrderByDescending(p => Fuzz.PartialRatio(searchQuery.ToLower(), p.ProductName.ToLower())) // Sắp xếp theo điểm tương đồng
            .ToList();

            return filteredProducts;
        }
        public List<ProductViewModel> SuggestProducts(List<ProductViewModel> products, List<string> searchQueries)
        {
            var suggestedProducts = new List<ProductViewModel>();
            foreach (var query in searchQueries)
            {
                suggestedProducts.AddRange(FindRelevantProducts(query, products));
            }

            return suggestedProducts.Distinct().Take(5).ToList();
        }
        //private double ComputeRelevanceScore(string query, ProductViewModel product)
        //{
        //    var cleanDescription = Regex.Replace(product.Description ?? "", "<.•*?>", "").ToLower();
        //    //loại bỏ các ký tự đặc biệt
        //    cleanDescription = Regex.Replace(cleanDescription, @"[^\w\s]", "");

        //    var descriptionWords = cleanDescription.Split(new[] { ' ', '.', ',', ';', ':', '!', '•' }, StringSplitOptions.RemoveEmptyEntries);

        //    //var descriptionWords = product.Description?.ToLower().Split(' ') ?? Array.Empty<string>();
        //    var queryWords = query.ToLower().Split(' ');

        //    // Tạo vector từ
        //    var allWords = descriptionWords.Union(queryWords).Distinct().ToList();
        //    var queryVector = allWords.Select(w => queryWords.Count(q => q == w)).ToArray();
        //    var descriptionVector = allWords.Select(w => descriptionWords.Count(d => d == w)).ToArray();

        //    // Tính Cosine Similarity
        //    var dotProduct = queryVector.Zip(descriptionVector, (q, d) => q * d).Sum();
        //    var queryMagnitude = Math.Sqrt(queryVector.Sum(q => q * q));
        //    var descriptionMagnitude = Math.Sqrt(descriptionVector.Sum(d => d * d));

        //    var rs = dotProduct / (queryMagnitude * descriptionMagnitude + 1e-10); // Thêm epsilon để tránh chia cho 0
        //    if(rs ==0)
        //        Console.WriteLine(" " + product);            
        //    return rs;
        //}

    }
}