using IMS.WebApp.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace IMS.WebApp.ViewModelsValidations
{
    public class Produce_EnsureEnoughInventoryQuantity : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var produceViewModel = validationContext.ObjectInstance as ProduceViewModel;
            if (produceViewModel is not null)
            {
                if (produceViewModel.Product is not null && produceViewModel.Product.ProductInventories !=null)
                {
                    foreach (var pi in produceViewModel.Product.ProductInventories)
                    {
                        if(pi.Inventory !=null &&
                            pi.InventoryQuantity*produceViewModel.QuantityToProduce >pi.Inventory.Quantity)
                        {
                            return new ValidationResult($"Not enough inventory for {pi.Inventory.InventoryName} to produce {produceViewModel.QuantityToProduce}",
                                new [] { validationContext.MemberName } );
                        }
                    }

                }
            }

            return ValidationResult.Success;
        }
    }
}
