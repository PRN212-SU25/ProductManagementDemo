using System.Windows;
using BusinessObjects;
using Services;

namespace WPFApp
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private readonly IAccountService iAccountService;

        public LoginWindow()
        {
            InitializeComponent();
            iAccountService = new AccountService();
        }
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string user = txtUser.Text.Trim();
            string pass = txtPass.Password;

            AccountMember account = iAccountService.Login(user, pass);

            if (account != null && account.MemberRole == 1)
            {
                this.Hide();
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
            }
            else
            {
                MessageBox.Show("Invalid credentials or no permission.");
            }
        }


        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {            
            this.Close();
        }

        private void txtUser_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }
    }
}
