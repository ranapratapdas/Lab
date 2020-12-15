using System.Collections.Generic;
using System.Threading.Tasks;
using LabApi.Model;

namespace LabAPI.Services
{
    public interface IInvenotySerivce
    {
        Task<IEnumerable<Product>> GetAllProducts();
        Task<bool> CheckInvenotry(string porductid, int qty);
    }
}