namespace StudentDetailsManagementAndRegistrationSystem_sn
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPassword.Text;

            if(email == "abc@institute.lk" && password == "ABC77")
            {
                MessageBox.Show("Login Success !");
                this.Hide();
                MainMenu obj = new MainMenu();
                obj.Show();
            }
            else
            {
                MessageBox.Show("Login not Success !");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}