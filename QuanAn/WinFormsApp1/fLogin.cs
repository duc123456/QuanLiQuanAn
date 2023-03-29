//using WinFormsApp1.Models;

using WinFormsApp1.Models;

namespace WinFormsApp1
{
    public partial class fLogin : Form
    {
        public fLogin()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label3.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void fLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thực sự muốn thoát chương trình?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var context = new QuanLiQuanAnContext())
            {
                string user = textBox1.Text;
                string password = textBox2.Text;
                Account account = context.Accounts.FirstOrDefault(x => x.Username.Equals(user) && x.Password.Equals(password));
                if (account != null && account.Role ==2)
                {
                    fManaTable f = new fManaTable();
                    this.Hide();
                    f.ShowDialog();
                    this.Show();
                }else if (account != null && account.Role == 1)
                {
                    fAdmin f = new fAdmin();
                    this.Hide();
                    f.ShowDialog();
                    this.Show();
                }
                else
                {
                    label3.Visible = true;
                    label3.Text = "Sai tài khoản hoặc mật khẩu";
                }
            }
        }

        private void fLogin_Load(object sender, EventArgs e)
        {

        }
    }
}