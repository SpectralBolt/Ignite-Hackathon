using ApiRest.Services;
using Common.Models;
using Microsoft.ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRest.ML.NET
{
    public class Model
    {
        private readonly IRepository repository;
        private MLContext mlContext;
        public Model(IRepository repository)
        {
            this.repository = repository;
            mlContext = new MLContext();
            LoadData();
        }

        private async void LoadData()
        {
            var inMemoryCollection = await repository.GetOfficesAsync();
            IDataView data = mlContext.Data.LoadFromEnumerable<Office>(inMemoryCollection);
        }
    }
}
