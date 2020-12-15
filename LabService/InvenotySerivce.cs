using LabApi.Model;
using LabAPI.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LabAPI.Services
{
    public class InvenotySerivce : IInvenotySerivce
    {
        private readonly ILogger<InvenotySerivce> _logger;
        private readonly IInventoryRepository _repository;
        public InvenotySerivce(ILogger<InvenotySerivce> logger, IInventoryRepository repository)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        public async Task<bool> CheckInvenotry(string porductid, int qty)
        {
            //check repository class and return
            //_repository.CheckInvenotory
            return true;
        }

        public Task<IEnumerable<Product>> GetAllProducts()
        {
            throw new NotImplementedException();
        }
    }
}
