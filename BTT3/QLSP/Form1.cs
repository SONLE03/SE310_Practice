using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSP
{
    public partial class Form1 : Form
    {
        private List<Product> danhSachSanPham = new List<Product>();

        public Form1()
        {
            InitializeComponent();
        }

        private void CapNhatDanhSachSanPham()
        {
            dataGridView1.DataSource = null; 
            dataGridView1.DataSource = danhSachSanPham;

            dataGridView2.DataSource = null;
            dataGridView2.DataSource = danhSachSanPham;
        }

        // Thêm sản phẩm
        private void btnLuu_Click(object sender, EventArgs e)
        {
            Product sp = new Product()
            {
                MaSP = txtMaSP.Text,
                TenSP = txtTenSP.Text,
                SoLuong = int.Parse(txtSoLuong.Text),
                DonGia = decimal.Parse(txtDonGia.Text),
                XuatXu = txtXuatXu.Text,
                NgayHetHan = dtpNgayHetHan.Value
            };

            danhSachSanPham.Add(sp);
            CapNhatDanhSachSanPham();
        }

        // Xóa sản phẩm
        private void btnXoa_Click(object sender, EventArgs e)
        {
            var spXoa = danhSachSanPham.FirstOrDefault(sp => sp.MaSP == txtMaSP.Text);
            if (spXoa != null)
            {
                danhSachSanPham.Remove(spXoa);
                CapNhatDanhSachSanPham();
            }
        }

        // Kiểm tra sản phẩm quá hạn
        private void btnKiemTraQuaHan_Click(object sender, EventArgs e)
        {
            var sanPhamQuaHan = danhSachSanPham.Where(sp => sp.NgayHetHan < DateTime.Now).ToList();
            if (sanPhamQuaHan.Any())
            {
                MessageBox.Show("Có sản phẩm đã quá hạn!");
            }
            else
            {
                MessageBox.Show("Không có sản phẩm nào quá hạn.");
            }
        }

        // Tìm sản phẩm có đơn giá cao nhất
        private void btnTimDGCaoNhat_Click(object sender, EventArgs e)
        {
            var sanPhamDGCaoNhat = danhSachSanPham.OrderByDescending(sp => sp.DonGia).FirstOrDefault();
            if (sanPhamDGCaoNhat != null)
            {
                MessageBox.Show($"Sản phẩm có đơn giá cao nhất: {sanPhamDGCaoNhat.TenSP}");
            }
        }

        // Tìm sản phẩm có xuất xứ từ Nhật Bản
        private void btnTimSPXuatXuNhatBan_Click(object sender, EventArgs e)
        {
            var spXuatXuNhat = danhSachSanPham.FirstOrDefault(sp => sp.XuatXu == "Nhật Bản");
            if (spXuatXuNhat != null)
            {
                MessageBox.Show($"Sản phẩm xuất xứ Nhật Bản: {spXuatXuNhat.TenSP}");
            }
            else
            {
                MessageBox.Show("Không tìm thấy sản phẩm nào từ Nhật Bản.");
            }
        }

        // Tìm sản phẩm có đơn giá trong khoảng [a...b]
        private void btnTimSPTheoDonGia_Click(object sender, EventArgs e)
        {
            decimal giaMin = decimal.Parse(txtGiaMin.Text);
            decimal giaMax = decimal.Parse(txtGiaMax.Text);

            var sanPhamTheoGia = danhSachSanPham.Where(sp => sp.DonGia >= giaMin && sp.DonGia <= giaMax).ToList();
            if (sanPhamTheoGia.Any())
            {
                dataGridView2.DataSource = sanPhamTheoGia;
            }
            else
            {
                MessageBox.Show("Không tìm thấy sản phẩm nào trong khoảng giá này.");
            }
        }

        // Xóa sản phẩm theo xuất xứ bất kỳ
        private void btnXoaSPTheoXuatXu_Click(object sender, EventArgs e)
        {
            string xuatXuCanXoa = txtXuatXuCanXoa.Text;
            danhSachSanPham.RemoveAll(sp => sp.XuatXu == xuatXuCanXoa);
            CapNhatDanhSachSanPham();
        }
    }

}

