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


        public void AddNewProduct(ProductModel product, List<string> specificationList)
        {
            var addedProductId = _db.SaveDataGetId("dbo.sp_ProductAdd", product, connectionStringName);

            List<SpecificationModel> specs = new List<SpecificationModel>();

            foreach (string item in specificationList)
            {
                SpecificationModel spec = new SpecificationModel();
                spec.ProductId = addedProductId;
                spec.Specification = item;
                specs.Add(spec);
            }

            foreach (var specification in specs)
            {
                _db.SaveData("dbo.sp_InsertSpecifications", specification, connectionStringName);
            }
        }

        public void DeleteProduct(int productId)
        {
            _db.SaveData("sp_DeleteProduct", new { @ProductId = productId }, connectionStringName);
        }
    }
}
