using IMS.CoreBusiness;
using IMS.UseCases.Activities.Interfaces;
using IMS.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UseCases.Activities
{
    public class SellProductUseCase : ISellProductUseCase
    {
        private readonly IProductTransactionRepository productTransactionRepository;
        private readonly IProductRepository productRepository;

        public SellProductUseCase(IProductTransactionRepository productTransactionRepository,
            IProductRepository productRepository)
        {
            this.productTransactionRepository = productTransactionRepository;
            this.productRepository = productRepository;
        }
        public async Task ExecuteAsync(string sales, Product product, int quantity,double unitPrice, string doneBy)
        {
            await this.productTransactionRepository.SellProductAsync(sales, product, quantity, unitPrice,doneBy);

            product.Quantity -= quantity;
            await this.productRepository.UpdateProductAsync(product);
        }
    }
}
