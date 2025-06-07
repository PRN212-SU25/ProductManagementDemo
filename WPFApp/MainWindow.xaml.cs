using System;
using System.Windows;
using System.Windows.Controls;
using BusinessObjects;
using Services;

namespace WPFApp
{
    public partial class MainWindow : Window
    {
        private readonly IProductService iProductService;
        private readonly ICategoryService iCategoryService;

        public MainWindow()
        {
            InitializeComponent();
            iProductService = new ProductService();
            iCategoryService = new CategoryService();
        }

        public void LoadCategoryList()
        {
            try
            {
                var catList = iCategoryService.GetCategories();
                cboCategory.ItemsSource = catList;
                cboCategory.DisplayMemberPath = "CategoryName";
                cboCategory.SelectedValuePath = "CategoryId";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on load list of categories");
            }
        }

        public void LoadProductList()
        {
            try
            {
                var productList = iProductService.GetProducts();
                dgData.ItemsSource = productList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on load of products");
            }
            finally
            {
                resetInput();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadCategoryList();
            LoadProductList();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtProductName.Text) ||
                    string.IsNullOrWhiteSpace(txtPrice.Text) ||
                    string.IsNullOrWhiteSpace(txtUnitsInStock.Text) ||
                    cboCategory.SelectedValue == null)
                {
                    MessageBox.Show("All fields are required.");
                    return;
                }

                Product product = new Product
                {
                    ProductName = txtProductName.Text,
                    UnitPrice = decimal.Parse(txtPrice.Text),
                    UnitInStock = short.Parse(txtUnitsInStock.Text),
                    CategoryId = (int)cboCategory.SelectedValue
                };

                iProductService.SaveProduct(product);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creating product: " + ex.Message);
            }
            finally
            {
                LoadProductList();
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (int.TryParse(txtProductID.Text, out int productId))
                {
                    Product product = new Product
                    {
                        ProductId = productId,
                        ProductName = txtProductName.Text,
                        UnitPrice = decimal.Parse(txtPrice.Text),
                        UnitInStock = short.Parse(txtUnitsInStock.Text),
                        CategoryId = (int)cboCategory.SelectedValue
                    };
                    iProductService.UpdateProduct(product);
                }
                else
                {
                    MessageBox.Show("You must select a product to update.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating product: " + ex.Message);
            }
            finally
            {
                LoadProductList();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (int.TryParse(txtProductID.Text, out int productId))
                {
                    iProductService.DeleteProduct(productId);
                }
                else
                {
                    MessageBox.Show("You must select a product to delete.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting product: " + ex.Message);
            }
            finally
            {
                LoadProductList();
            }
        }

        private void dgData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgData.SelectedItem is Product product)
            {
                txtProductID.Text = product.ProductId.ToString();
                txtProductName.Text = product.ProductName;
                txtPrice.Text = product.UnitPrice.ToString();
                txtUnitsInStock.Text = product.UnitInStock.ToString();
                cboCategory.SelectedValue = product.CategoryId;
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void resetInput()
        {
            txtProductID.Clear();
            txtProductName.Clear();
            txtPrice.Clear();
            txtUnitsInStock.Clear();
            cboCategory.SelectedIndex = -1;
        }

        private void txtProductID_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(txtProductID.Text, out int productId))
            {
                try
                {
                    Product product = iProductService.GetProductById(productId);
                    if (product != null)
                    {
                        txtProductName.Text = product.ProductName;
                        txtPrice.Text = product.UnitPrice.ToString();
                        txtUnitsInStock.Text = product.UnitInStock.ToString();
                        cboCategory.SelectedValue = product.CategoryId;
                    }
                    else
                    {
                        // If no product found, clear input fields except ID
                        txtProductName.Clear();
                        txtPrice.Clear();
                        txtUnitsInStock.Clear();
                        cboCategory.SelectedIndex = -1;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading product: " + ex.Message);
                }
            }
            else
            {
                // If not a valid number, clear other fields
                txtProductName.Clear();
                txtPrice.Clear();
                txtUnitsInStock.Clear();
                cboCategory.SelectedIndex = -1;
            }
        }

        private void txtProductName_TextChanged(object sender, TextChangedEventArgs e)
        {
            string name = txtProductName.Text.Trim();
            if (!string.IsNullOrEmpty(name))
            {
                try
                {
                    // Assuming product names are unique
                    var matchedProduct = iProductService.GetProducts()
                                            .FirstOrDefault(p => p.ProductName.Equals(name, StringComparison.OrdinalIgnoreCase));

                    if (matchedProduct != null)
                    {
                        txtProductID.Text = matchedProduct.ProductId.ToString();
                        txtPrice.Text = matchedProduct.UnitPrice.ToString();
                        txtUnitsInStock.Text = matchedProduct.UnitInStock.ToString();
                        cboCategory.SelectedValue = matchedProduct.CategoryId;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading product: " + ex.Message);
                }
            }
        }
    }
}
