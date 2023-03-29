using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp1.Models;

namespace WinFormsApp1
{
    public partial class fManaTable : Form
    {
        public fManaTable()
        {
            InitializeComponent();
        }

        private void fManaTable_Load(object sender, EventArgs e)
        {

            LoadData();
        }
        private void LoadData()
        {
            dataGridView1.Rows.Clear();
            panel1.Controls.Clear();
            using (var context = new QuanLiQuanAnContext())
            {
                List<TableFood> list = context.TableFoods.ToList();
                int y = 2;
                int x = 3;
                int j = 0;
                for (int i = 0; i < list.Count; i++)
                {

                    Button button = new Button()
                    {
                        Text = list[i].Name + "-" + list[i].Status,
                        Location = new Point(x * 43 * j, y),
                        Size = new Size(94, 72),
                        Name = "" + (i + 1)
                    };
                    if (list[i].Status.Equals("Có người"))
                    {
                        button.BackColor = Color.Blue;
                    }
                    else if (list[i].Status.Equals("Đã đặt"))
                    {
                        button.BackColor = Color.Green;
                    }
                    j++;
                    button.Click += btn_Click;
                    panel1.Controls.Add(button);
                    if ((i + 1) % 4 == 0)
                    {
                        j = 0;
                        x = 3;
                        y = y + 90;
                    }



                }
                List<Category> categories = context.Categories.ToList();
                comboBox1.DisplayMember = "Category1";
                comboBox1.ValueMember = "Id";
                comboBox1.DataSource = categories;
                List<Food> food = context.Foods.ToList();
                comboBox2.DisplayMember = "Name";
                comboBox2.ValueMember = "Id";
                comboBox2.DataSource = food;
                dataGridView2.Rows.Clear();
                List<Bill> bills = context.Bills.Where(x => x.Status == 3).ToList();
                foreach (Bill bi in bills)
                {
                    Account a = context.Accounts.FirstOrDefault(x => x.Phone.Equals(bi.Phone));
                    TableFood tb = context.TableFoods.FirstOrDefault(x => x.Id == bi.IdTable);
                    if (a == null)
                    {
                        dataGridView2.Rows.Add(bi.Id, "Chưa có tài khoản", tb.Name, bi.DateCheckIn, bi.Phone);
                    }
                    else
                    {

                        dataGridView2.Rows.Add(bi.Id, a.Name, tb.Name, bi.DateCheckIn, bi.Phone);
                    }

                }
                List<TableFood> ltb = context.TableFoods.ToList();
                comboBox3.DisplayMember = "Name";
                comboBox3.ValueMember = "Id";
                comboBox3.DataSource = ltb;

                textBox3.Text = "Tổng tiền: 0";
                Bill bill = context.Bills.FirstOrDefault(x => x.IdTable == int.Parse(textBox2.Text) && x.Status == 2);
                if (bill == null)
                {

                }
                else
                {
                    List<BillInfo> l = context.BillInfos.Where(x => x.IdBill == bill.Id).ToList();
                    int? total = 0;
                    foreach (BillInfo info in l)
                    {
                        Food f = context.Foods.First(x => x.Id == info.IdFood);
                        dataGridView1.Rows.Add(f.Name, info.Quantity, f.Price * info.Quantity);
                        //var result = (from b in BillInfo
                        //              join f in Food on b.IdFood equals f.Id
                        //              where b.IdBill == bill.Id
                        //              select b.Quantity * f.Price)
                        //                .Sum();


                        total += f.Price * info.Quantity;
                        textBox3.Text = "Tổng tiền: " + total;


                    }
                }
            }
        }

        private void btn_Click(object? sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            string index = ((Button)sender).Name;
            textBox2.Text = index;
            LoadData();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (var context = new QuanLiQuanAnContext())
            {
                int id = comboBox1.SelectedIndex + 1;
                List<Food> foods = context.Foods.Where(x => x.IdCate == id).ToList();
                comboBox2.DisplayMember = "Name";
                comboBox2.ValueMember = "Id";
                comboBox2.DataSource = foods;

            }
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            string phone = textBox1.Text;
            if (textBox2.Text == null || textBox2.Text == "")
            {
                MessageBox.Show("Hãy chọn bàn muốn đặt");


            }
            else if (phone.Length == 10 || Regex.IsMatch(phone, @"^0\d{9}$"))
            {
                using (var context = new QuanLiQuanAnContext())
                {
                    TableFood tb = context.TableFoods.FirstOrDefault(x => x.Id == int.Parse(textBox2.Text));
                    if (tb.Status.Equals("Đã đặt"))
                    {
                        MessageBox.Show(tb.Name + " đã có người đặt rồi");
                    }
                    else if (tb.Status.Equals("Đã đặt"))
                    {
                        MessageBox.Show(tb.Name + " hiện không trống");
                    }
                    else
                    {
                        Bill bill = new Bill();
                        bill.DateCheckIn = dateTimePicker1.Value;
                        bill.IdTable = int.Parse(textBox2.Text);
                        bill.Phone = textBox1.Text;
                        bill.Status = 3;

                        tb.Status = "Đã đặt";
                        context.Bills.Add(bill);
                        context.SaveChanges();

                        MessageBox.Show(bill.Phone + " đã đặt " + tb.Name + " vào lúc " + bill.DateCheckIn + " thành công");
                        LoadData();
                    }

                }
            }
            else
            {
                MessageBox.Show("Số điện thoại không hợp lệ");

            }

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string idt = textBox2.Text;
            try
            {
                int idtb = int.Parse(idt);
                decimal num = numericUpDown1.Value;
                int number = decimal.ToInt32(num);
                if (number == 0)
                {
                    MessageBox.Show("Chọn số lượng món ăn");
                }
                else
                {
                    using (var context = new QuanLiQuanAnContext())
                    {
                        TableFood tb = context.TableFoods.FirstOrDefault(x => x.Id == idtb);
                        Bill bill = context.Bills.FirstOrDefault(x => x.IdTable == idtb && x.DateCheckOut == null);
                        if (bill == null)
                        {
                            Bill bill1 = new Bill();
                            bill1.DateCheckIn = DateTime.Now;
                            bill1.IdTable = idtb;
                            bill1.Status = 2;
                            context.Bills.Add(bill1);
                            context.SaveChanges();
                            tb.Status = "Có người";
                            BillInfo billInfo = new BillInfo();
                            billInfo.IdBill = bill1.Id;
                            billInfo.IdFood = int.Parse(comboBox2.SelectedValue.ToString());
                            billInfo.Quantity = number;
                            context.BillInfos.Add(billInfo);
                            context.SaveChanges();
                            LoadData();
                        }
                        else
                        {
                            tb.Status = "Có người";

                            int idfood = int.Parse(comboBox2.SelectedValue.ToString());
                            bill.Status = 2;
                            BillInfo bf = context.BillInfos.FirstOrDefault(x => x.IdBill == bill.Id && x.IdFood == idfood);
                            if (bf == null)
                            {
                                BillInfo bf2 = new BillInfo();
                                bf2.IdBill = bill.Id;
                                bf2.IdFood = int.Parse(comboBox2.SelectedValue.ToString());
                                bf2.Quantity = number;
                                context.BillInfos.Add(bf2);
                            }
                            else
                            {
                                bf.Quantity += number;
                            }

                            context.SaveChanges();
                            LoadData();
                        }
                        LoadData();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hãy chọn bàn!!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string idtb = textBox2.Text;
            if (idtb == null)
            {
                MessageBox.Show("Bạn muốn thanh toán bàn nào");
            }
            else
            {
                int id = int.Parse(idtb);
                using (var context = new QuanLiQuanAnContext())
                {
                    Bill bill = context.Bills.FirstOrDefault(x => x.IdTable == id && x.DateCheckOut == null);
                    if (bill == null)
                    {
                        MessageBox.Show("Không thế thanh toán bàn này");
                    }
                    else
                    {
                        bill.DateCheckOut = DateTime.Now;
                        List<BillInfo> Bis = context.BillInfos.Where(x => x.IdBill == bill.Id).ToList();
                        int? total = 0;
                        foreach (var bi in Bis)
                        {
                            Food food = context.Foods.FirstOrDefault(x => x.Id == bi.IdFood);
                            total += food.Price * bi.Quantity;
                        }
                        bill.TotalPrice = total;
                        bill.Status = 1;

                        TableFood tb = context.TableFoods.FirstOrDefault(x => x.Id == bill.IdTable);
                        tb.Status = "Bàn trống";
                        context.SaveChanges();

                    }
                    LoadData();
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            comboBox3.Text = dataGridView2.Rows[e.RowIndex].Cells["Column6"].Value.ToString();
            using (var context = new QuanLiQuanAnContext())
            {
                List<TableFood> ltb = context.TableFoods.Where(x => x.Status.Equals("Bàn trống")).ToList();
                TableFood tb = context.TableFoods.FirstOrDefault(x => x.Name.Equals(comboBox3.Text));
                tb.Name = tb.Name + "(Đã chọn)";
                ltb.Add(tb);
                comboBox3.DisplayMember = "Name";
                comboBox3.ValueMember = "Id";
                comboBox3.DataSource = ltb;
            }
            textBox9.Text = dataGridView2.Rows[e.RowIndex].Cells["Column4"].Value.ToString();
            textBox4.Text = dataGridView2.Rows[e.RowIndex].Cells["Column5"].Value.ToString();
            comboBox3.Text = dataGridView2.Rows[e.RowIndex].Cells["Column6"].Value.ToString();
            dateTimePicker2.Text = dataGridView2.Rows[e.RowIndex].Cells["Column7"].Value.ToString();
            textBox7.Text = dataGridView2.Rows[e.RowIndex].Cells["Column8"].Value.ToString();


        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
            string s = textBox8.Text;
            using (var context = new QuanLiQuanAnContext())
            {
                List<Bill> bills = context.Bills.Where(x => x.Status == 3 && x.Phone.Contains(s)).ToList();

                foreach (Bill bi in bills)
                {
                    Account a = context.Accounts.FirstOrDefault(x => x.Phone.Equals(bi.Phone));
                    TableFood tb = context.TableFoods.FirstOrDefault(x => x.Id == bi.IdTable);
                    if (a == null)
                    {
                        dataGridView2.Rows.Add(bi.Id, "Chưa có tài khoản", tb.Name, bi.DateCheckIn, bi.Phone);
                    }
                    else
                    {

                        dataGridView2.Rows.Add(bi.Id, a.Name, tb.Name, bi.DateCheckIn, bi.Phone);
                    }

                }
            }

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string id = textBox9.Text;
            try
            {
                int idb = Convert.ToInt32(id);
                using (var context = new QuanLiQuanAnContext())
                {
                    Bill bill = context.Bills.FirstOrDefault(x => x.Id == idb);
                    bill.Status = 0;
                    TableFood tb = context.TableFoods.FirstOrDefault(x => x.Id == bill.IdTable);
                    tb.Status = "Bàn trống";
                    context.SaveChanges();
                    LoadData();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Bạn muốn hủy đặt bàn nào");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string id = textBox9.Text;
            try
            {
                int idb = Convert.ToInt32(id);
                using (var context = new QuanLiQuanAnContext())
                {
                    Bill bill = context.Bills.FirstOrDefault(x => x.Id == idb);
                    TableFood tbf1 = context.TableFoods.FirstOrDefault(x => x.Id == bill.IdTable);
                    tbf1.Status = "Bàn trống";
                    bill.Phone = textBox7.Text;
                    int s = int.Parse(comboBox3.SelectedValue.ToString());

                    bill.IdTable = s;
                    TableFood tbf2 = context.TableFoods.FirstOrDefault(x => x.Id == s);
                    tbf2.Status = "Đã đặt";
                    bill.DateCheckIn = dateTimePicker2.Value;
                    context.SaveChanges();
                    LoadData();

                }

            }
            catch (Exception ex)
            {


            }
        }
    }
}
