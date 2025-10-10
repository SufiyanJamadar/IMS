using IMS.CoreBusiness;

namespace IMS.UseCases.Activities.Interfaces
{
    public interface ISellProductUseCase
    {
        Task ExecuteAsync(string sales, Product product, int quantity, double unitPrice, string doneBy);
    }
}