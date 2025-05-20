using IMS.CoreBusiness;

namespace IMS.UseCases.Inventories
{
    public interface IViewInventoriesByNameUseCase
    {
        Task<IEnumerable<Inventory>> ExceuteAsync(string name = " ");
    }
}