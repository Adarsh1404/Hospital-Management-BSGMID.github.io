namespace HospitalManagement
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            String username = txtUserName.Text;
            String pass = txtPassword.Text;

            if(username == "has" && pass == "pass")
            {
               this.Hide();
               Dashboard ds = new Dashboard();
               ds.Show();
            }
            else
            {
                MessageBox.Show("wrong user id and password");
            }
        }
    }
}