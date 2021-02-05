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
            List<string> specificationList = ProductSpecificationsList.Items.Cast<object>().Select(o => o.ToString()).ToList();
            _db.AddNewProduct(product, specificationList);
        }

        private void ClearForm()
        {
            ProductNameText.Clear();
            ProductDescriptionText.Clear();
            ProductSpecificationsList.Items.Clear();
        }

        private void AddSpecButton_Click(object sender, RoutedEventArgs e)
        {
            ProductSpecificationsList.Items.Add(SpecificationText.Text);
            SpecificationText.Clear();
        }

        private void RemoveSpecButton_Click(object sender, RoutedEventArgs e)
        {
            ProductSpecificationsList.Items.RemoveAt(ProductSpecificationsList.Items.IndexOf(ProductSpecificationsList.SelectedItem));
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            ClearForm();
        }

        
    }
}
