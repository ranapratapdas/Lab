using LabApi.Model;
using System.Threading.Tasks;

namespace LabAPI.Services
{
    public interface IPaymentService
    {
        Task<bool> Charge(UserPayment userpayment);
    }
}