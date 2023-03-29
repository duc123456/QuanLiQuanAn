using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp1.Models;

namespace WinFormsApp1
{
    public partial class fAdmin : Form
    {
        public fAdmin()
        {
            InitializeComponent();
        }

        private void fAdmin_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {

            DateTime from = DateTime.Parse(dateTimePicker1.Text);
            DateTime to = DateTime.Parse(dateTimePicker2.Text);

            dataGridView1.Rows.Clear();
            using (var context = new QuanLiQuanAnContext())
            {
                int? total = 0;
                if (from.Equals(to))
                {
                    List<Bill> bills = context.Bills.Where(x => x.Status == 1).ToList();

                    foreach (Bill bill in bills)
                    {
                        TableFood tb = context.TableFoods.FirstOrDefault(x => x.Id == bill.IdTable);
                        dataGridView1.Rows.Add(bill.Id, bill.DateCheckIn, bill.DateCheckOut, tb.Name, bill.TotalPrice);
                        total += bill.TotalPrice;
                    }
                }
                else
                {
                    List<Bill> bills = context.Bills.Where(b => b.Status == 1 && b.DateCheckOut >= from && b.DateCheckOut <= to).ToList();

                    foreach (Bill bill in bills)
                    {
                        TableFood tb = context.TableFoods.FirstOrDefault(x => x.Id == bill.IdTable);
                        dataGridView1.Rows.Add(bill.Id, bill.DateCheckIn, bill.DateCheckOut, tb.Name, bill.TotalPrice);
                        total += bill.TotalPrice;
                    }
                }
                label3.Text = "Tổng thu: " + total.ToString();
                List<Category> categories = context.Categories.ToList();
                comboBox2.DisplayMember = "Category1";
                comboBox2.ValueMember = "Id";
                comboBox2.DataSource = categories;
                List<Food> food = context.Foods.ToList();
                comboBox3.DisplayMember = "Name";
                comboBox3.ValueMember = "Id";
                comboBox3.DataSource = food;

                comboBox1.DisplayMember = "Category1";
                comboBox1.ValueMember = "Id";
                comboBox1.DataSource = categories;
            }
        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cate = comboBox2.SelectedValue.ToString();
            try
            {
                int cateid = int.Parse(cate);
                using (var context = new QuanLiQuanAnContext())
                {
                    List<Food> food = context.Foods.Where(x => x.IdCate == cateid).ToList();
                    comboBox3.DisplayMember = "Name";
                    comboBox3.ValueMember = "Id";
                    comboBox3.DataSource = food;
                }


            }
            catch (Exception ex)
            {


            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string cate = textBox1.Text;
            string food = textBox2.Text;

            using (var context = new QuanLiQuanAnContext())
            {
                if (cate != null && !cate.Equals(""))
                {
                    Category category = new Category();
                    category.Category1 = cate;
                    context.Categories.Add(category);
                    context.SaveChanges();
                    LoadData();
                }
                if (food != null && !food.Equals(""))
                {
                    Food food1 = context.Foods.FirstOrDefault(x=>x.Name.Equals(food));
                    if(food1 == null)
                    {

                        int price = Convert.ToInt32(numericUpDown1.Value);
                        if (price > 0)
                        {
                            Food food2 = new Food();
                            food2.Price = price;
                            food2.Name = food;
                            food2.IdCate = int.Parse(comboBox1.SelectedValue.ToString());
                            context.Foods.Add(food2);
                            context.SaveChanges();
                            LoadData();
                            MessageBox.Show("Đã thêm món thành công!");
                        }else
                        {
                            MessageBox.Show("Sai giá rồi!");
                        }
                    }else
                    {
                        MessageBox.Show("Đã có món này rồi");
                    }
                }

            }
        }
    }
}
