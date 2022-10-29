using _19T1021303.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _19T1021303
{
    public partial class Form1 : Form
    {
        int manhom = 0;
        int masinhvien = 0;

        public Form1()
        {
            InitializeComponent();
            NapDanhSachNhom();
        }
        void NapDanhSachNhom()
        {
            var list = NhomView.GetList();
            dataGridNhom.DataSource = list;
        }
        void NapDanhSachNguoi(int id)
        {

            var list = NguoiView.GetListByID(id);
            dataGridNguoi.DataSource = list;
        }
        private void ShowForm2()
        {
            Form2 f = new Form2();
            f.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'baiKiemTraDataSet1.Nguoi' table. You can move, or remove it, as needed.
            this.nguoiTableAdapter.Fill(this.baiKiemTraDataSet1.Nguoi);
            // TODO: This line of code loads data into the 'baiKiemTraDataSet.Nhom' table. You can move, or remove it, as needed.
            this.nhomTableAdapter.Fill(this.baiKiemTraDataSet.Nhom);

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = dataGridNhom.Rows[e.RowIndex];
            string tennhom = Convert.ToString(row.Cells["TenNhom"].Value);
            var list = NhomView.GetList();
            int id = 0;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].TenNhom.Equals(tennhom))
                {
                    id = list[i].ID;
                    manhom = id;
                }
            }
            NapDanhSachNguoi(manhom);
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = dataGridNguoi.Rows[e.RowIndex];
            txtTenGoi.Text = Convert.ToString(row.Cells["TenGoi"].Value);
            txtEmail.Text = Convert.ToString(row.Cells["Email"].Value);
            txtSDT.Text = Convert.ToString(row.Cells["SDT"].Value);
            string email = Convert.ToString(row.Cells["Email"].Value);

            var list = NguoiView.GetListAll();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Email.Equals(email))
                {
                    txtDiaChi.Text = list[i].DiaChi;
                    masinhvien = list[i].ID;
                }
            }
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(ShowForm2));
            thread.Start();
            this.Close();
        }

        private void clickXoaNhom_Click(object sender, EventArgs e)
        {
            if (manhom != 0)
            {
                var rs = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Chú ý", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (rs == DialogResult.OK)
                {
                    NhomView.XoaNhom(manhom);
                    NapDanhSachNhom();
                }
            }
        }
        private void ShowForm3()
        {
            Form3 f = new Form3();
            f.ShowDialog();
        }
        private void clickThemLienLac_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(ShowForm3));
            thread.Start();
            this.Close();
        }

        private void clickXoaLienLac_Click(object sender, EventArgs e)
        {
            if (masinhvien != 0)
            {
                var rs = MessageBox.Show("Bạn có chắc chắn muốn xóa không? ?", "Chú ", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (rs == DialogResult.OK)
                {
                    NguoiView.XoaNguoi(masinhvien);
                    NapDanhSachNhom();
                    NapDanhSachNguoi(manhom);
                }
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
