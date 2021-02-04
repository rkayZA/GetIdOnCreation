using ProductListLibrary.Models;
using System.Collections.Generic;

namespace ProductListLibrary.DataAccess
{
    public interface ISqlData
    {
        void AddNewProduct(ProductModel product);
        void DeleteProduct(int productId);
        List<ProductModel> GetAllProducts();
    }
}