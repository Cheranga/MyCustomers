using System.Threading.Tasks;

namespace MyCustomers.Infrastructure.Abstractions.Application
{
    public interface IHandler<in TIn, TOut> where TIn : class where TOut : class
    {
        Task<TOut> HandleAsync(TIn input);
    }
}