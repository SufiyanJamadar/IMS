using IMS.WebApp.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace IMS.WebApp.ViewModelsValidations
{
    public class Sell_EnsureEnoughProductQuantity:ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var sellviewModel= validationContext.ObjectInstance as SellViewModel;
             if (sellviewModel is not null)
            {
                if(sellviewModel.Product is not null)
                {
                    if(sellviewModel.Product.Quantity<sellviewModel.QuantityToSell)
                    {
                        return new ValidationResult($"Not enough product {sellviewModel.Product.ProductName} to sell {sellviewModel.QuantityToSell}",
                            new[] { validationContext.MemberName });
                    }
                }
            }

            return ValidationResult.Success;
        }
    }
}
