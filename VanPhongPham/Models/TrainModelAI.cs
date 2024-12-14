using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.ML;
using Microsoft.ML.Data;

namespace VanPhongPham.Models
{
    public class TrainModelAI
    {
        private readonly MLContext _mlContext;
        private ITransformer _model;

        public TrainModelAI()
        {
            _mlContext = new MLContext();
        }

        //public void TrainModel(List<(string UserId, string ProductId, int? ViewCount, int? AddToCartCount, int? PurchaseCount)> rawData)
        //{
        //    // Điểm tương tác
        //    const int viewScore = 1;
        //    const int addToCartScore = 3;
        //    const int purchaseScore = 5;

        //    var userMapping = rawData.Select(x => x.UserId).Distinct()
        //                             .Select((user, index) => new { user, index })
        //                             .ToDictionary(x => x.user, x => x.index);

        //    var productMapping = rawData.Select(x => x.ProductId).Distinct()
        //                                .Select((prod, index) => new { prod, index })
        //                                .ToDictionary(x => x.prod, x => x.index);

        //    // Chuyển đổi dữ liệu
        //    var trainingData = rawData.Select(x => new PurchaseData
        //    {
        //        UserId = userMapping[x.UserId],
        //        ProductId = productMapping[x.ProductId],
        //        Label = (double)(x.ViewCount * viewScore + x.AddToCartCount * addToCartScore + x.PurchaseCount * purchaseScore)
        //    }).ToList();

        //    var dataView = _mlContext.Data.LoadFromEnumerable(trainingData);

        //    // Huấn luyện mô hình
        //    var pipeline = _mlContext.Recommendation().Trainers.MatrixFactorization(
        //        labelColumnName: "Label",
        //        matrixColumnIndexColumnName: "UserId",
        //        matrixRowIndexColumnName: "ProductId");

        //    _model = pipeline.Fit(dataView);

        //    // Lưu mô hình
        //    _mlContext.Model.Save(_model, dataView.Schema, "model.zip");
        //}

        //public void LoadModel()
        //{
        //    // Tải mô hình đã huấn luyện
        //    _model = _mlContext.Model.Load("model.zip", out var _);
        //}

        //public PredictionEngine<PurchaseData, ProductPrediction> GetPredictionEngine()
        //{
        //    return _mlContext.Model.CreatePredictionEngine<PurchaseData, ProductPrediction>(_model);
        //}
    }

}