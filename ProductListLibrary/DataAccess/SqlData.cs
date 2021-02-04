using ProductListLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductListLibrary.DataAccess
{
    public class SqlData : ISqlData
    {
        private readonly ISqlDataAccess _db;
        private const string connectionStringName = "DefaultConnection";

        public SqlData(ISqlDataAccess db)
        {
            _db = db;
        }

        public List<ProductModel> GetAllProducts()
        {
            var output = _db.LoadData<ProductModel, dynamic>("dbo.sp_GetAllProducts", new { }, connectionStringName);
            return output;
        }


        public void AddNewProduct(ProductModel product)
        {
            _db.SaveData("sp_ProductAdd", new { product.ProductName, product.ProductDescription }, connectionStringName);
        }

        public void DeleteProduct(int productId)
        {
            _db.SaveData("sp_DeleteProduct", new { @ProductId = productId }, connectionStringName);
        }
    }
}
