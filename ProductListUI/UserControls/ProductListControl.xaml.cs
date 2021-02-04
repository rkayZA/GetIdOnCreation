using ProductListLibrary.DataAccess;
using ProductListLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProductListUI.UserControls
{
    /// <summary>
    /// Interaction logic for ProductListControl.xaml
    /// </summary>
    public partial class ProductListControl : UserControl
    {
        private readonly ISqlData _db;

        public ProductListControl(ISqlData db)
        {
            _db = db;
            InitializeComponent();
            LoadProductList();
        }

        private void LoadProductList()
        {
            List<ProductModel> products = _db.GetAllProducts();
            ProductListGrid.ItemsSource = products;
            ProductListGrid.DisplayMemberPath = "ProductName";
            ProductListGrid.SelectedValuePath = "Id";
            ProductListGrid.ItemsSource = products;
        }

        private void DeleteProductButton_Click(object sender, RoutedEventArgs e)
        {
            DeleteSelectedProduct();
        }

        private void DeleteSelectedProduct()
        {
            int productId = (int)ProductListGrid.SelectedValue;
            _db.DeleteProduct(productId);
            LoadProductList();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            SaveProductToDatabase();
            ClearForm();
            LoadProductList();
        }

        private void SaveProductToDatabase()
        {
            // Only adds product name and description
            // TODO add functionality to get the newly added product Id and save the specification list
            ProductModel product = new ProductModel();
            product.ProductName = ProductNameText.Text;
            product.ProductDescription = ProductDescriptionText.Text;
            _db.AddNewProduct(product);
        }

        private void ClearForm()
        {
            ProductNameText.Clear();
            ProductDescriptionText.Clear();
        }
    }
}
