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
        private static readonly object _lock = new object();


        public TrainModelAI()
        {
            _mlContext = new MLContext();
        }
        public void TrainModel(List<(string UserId, string ProductId, int? ViewCount, int? AddToCartCount, int? PurchaseCount)> rawData)
        {
            lock (_lock)
            {
                // Điểm tương tác
                const int viewScore = 1;
                const int addToCartScore = 3;
                const int purchaseScore = 5;

                var userMapping = rawData.Select(x => x.UserId).Distinct()
                                         .Select((user, index) => new { user, index })
                                         .ToDictionary(x => x.user, x => x.index);

                var productMapping = rawData.Select(x => x.ProductId).Distinct()
                                            .Select((prod, index) => new { prod, index })
                                            .ToDictionary(x => x.prod, x => x.index);

                // Chuyển đổi dữ liệu
                var trainingData = rawData.Select(x => new PurchaseData
                {
                    UserId = (uint)userMapping[x.UserId],
                    ProductId = (uint)productMapping[x.ProductId],
                    Label = (float)(x.ViewCount * viewScore + x.AddToCartCount * addToCartScore + x.PurchaseCount * purchaseScore)
                }).ToList();

                //var dataView = _mlContext.Data.LoadFromEnumerable(trainingData);

                // Huấn luyện mô hình
                var pipeline = _mlContext.Transforms.Conversion.MapValueToKey(
                        inputColumnName: "UserId", outputColumnName: "UserIdKey")
                    .Append(_mlContext.Transforms.Conversion.MapValueToKey(
                        inputColumnName: "ProductId", outputColumnName: "ProductIdKey"))
                    .Append(_mlContext.Recommendation().Trainers.MatrixFactorization(
                        labelColumnName: "Label",
                        matrixColumnIndexColumnName: "UserIdKey",
                        matrixRowIndexColumnName: "ProductIdKey"));
                var dataView = _mlContext.Data.LoadFromEnumerable(trainingData);

                _model = pipeline.Fit(dataView);

                // Lưu mô hình
                _mlContext.Model.Save(_model, dataView.Schema, "D:\\model.zip");
            }
        }
        public void TrainModelIfNotExists(List<(string UserId, string ProductId, int? ViewCount, int? AddToCartCount, int? PurchaseCount)> rawData)
        {
            var modelPath = "D:\\model.zip";

            // Nếu mô hình đã tồn tại, không cần huấn luyện lại
            if (System.IO.File.Exists(modelPath))
            {
                Console.WriteLine("Model already exists. Skipping training.");
                return;
            }

            TrainModel(rawData);
        }

        public void LoadModel()
        {
            // Tải mô hình đã huấn luyện
            _model = _mlContext.Model.Load("D:\\model.zip", out var _);
        }

        public PredictionEngine<PurchaseData, ProductPrediction> GetPredictionEngine()
        {
            return _mlContext.Model.CreatePredictionEngine<PurchaseData, ProductPrediction>(_model);
        }
    }

}