using System;
using System.Collections.Generic;

namespace QuanLySanPhamCuaHang
{
    public class SanPham
    {
        private string _maSP;
        private string _tenSP;
        private decimal _gia;
        private int _soLuongTon;

        public SanPham()
        {
            _maSP = "";
            _tenSP = "";
            _gia = 0;
            _soLuongTon = 0;
        }

        public SanPham(string maSP, string tenSP, decimal gia, int soLuongTon)
        {
            _maSP = maSP;
            _tenSP = tenSP;
            _gia = gia;
            _soLuongTon = soLuongTon;
        }

        public string MaSP
        {
            get { return _maSP; }
            set { _maSP = value; }
        }

        public string TenSP
        {
            get { return _tenSP; }
            set { _tenSP = value; }
        }

        public decimal Gia
        {
            get { return _gia; }
            set { _gia = value; }
        }

        public int SoLuongTon
        {
            get { return _soLuongTon; }
            set { _soLuongTon = value; }
        }

        public virtual decimal TinhGiaBan()
        {
            return _gia;
        }

        public virtual string MoTa()
        {
            return "Mã SP: " + MaSP +
                   ", Tên SP: " + TenSP +
                   ", Giá: " + Gia +
                   ", Số lượng tồn: " + SoLuongTon;
        }
    }

    public class SanPhamThucPham : SanPham
    {
        private DateTime _ngayHetHan;
        private int _nhietDoBaoQuan;

        public SanPhamThucPham()
        {
            _ngayHetHan = DateTime.Now;
            _nhietDoBaoQuan = 0;
        }

        public SanPhamThucPham(
            string maSP,
            string tenSP,
            decimal gia,
            int soLuongTon,
            DateTime ngayHetHan,
            int nhietDoBaoQuan)
            : base(maSP, tenSP, gia, soLuongTon)
        {
            _ngayHetHan = ngayHetHan;
            _nhietDoBaoQuan = nhietDoBaoQuan;
        }

        public DateTime NgayHetHan
        {
            get { return _ngayHetHan; }
            set { _ngayHetHan = value; }
        }

        public int NhietDoBaoQuan
        {
            get { return _nhietDoBaoQuan; }
            set { _nhietDoBaoQuan = value; }
        }

        public override decimal TinhGiaBan()
        {
            TimeSpan thoiGianConLai = NgayHetHan - DateTime.Now;

            if (thoiGianConLai.TotalDays >= 0 &&
                thoiGianConLai.TotalDays <= 3)
            {
                return Gia * 0.7m;
            }

            return Gia;
        }

        public override string MoTa()
        {
            return "Thực phẩm - Mã SP: " + MaSP +
                   ", Tên SP: " + TenSP +
                   ", Giá gốc: " + Gia +
                   ", Giá bán: " + TinhGiaBan() +
                   ", Số lượng tồn: " + SoLuongTon +
                   ", Ngày hết hạn: " + NgayHetHan.ToString("dd/MM/yyyy") +
                   ", Nhiệt độ bảo quản: " + NhietDoBaoQuan + "°C";
        }
    }

    public class SanPhamDienTu : SanPham
    {
        private int _baoHanhThang;
        private string _hangSanXuat;

        public SanPhamDienTu()
        {
            _baoHanhThang = 0;
            _hangSanXuat = "";
        }

        public SanPhamDienTu(
            string maSP,
            string tenSP,
            decimal gia,
            int soLuongTon,
            int baoHanhThang,
            string hangSanXuat)
            : base(maSP, tenSP, gia, soLuongTon)
        {
            _baoHanhThang = baoHanhThang;
            _hangSanXuat = hangSanXuat;
        }

        public int BaoHanhThang
        {
            get { return _baoHanhThang; }
            set { _baoHanhThang = value; }
        }

        public string HangSanXuat
        {
            get { return _hangSanXuat; }
            set { _hangSanXuat = value; }
        }

        public override decimal TinhGiaBan()
        {
            if (BaoHanhThang > 12)
            {
                return Gia * 1.1m;
            }

            return Gia;
        }

        public override string MoTa()
        {
            return "Điện tử - Mã SP: " + MaSP +
                   ", Tên SP: " + TenSP +
                   ", Giá gốc: " + Gia +
                   ", Giá bán: " + TinhGiaBan() +
                   ", Số lượng tồn: " + SoLuongTon +
                   ", Bảo hành: " + BaoHanhThang + " tháng" +
                   ", Hãng sản xuất: " + HangSanXuat;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<SanPham> danhSach = new List<SanPham>
            {
                new SanPham
                {
                    MaSP = "SP01",
                    TenSP = "Bánh mì",
                    Gia = 15000,
                    SoLuongTon = 20
                },

                new SanPhamThucPham
                {
                    MaSP = "TP01",
                    TenSP = "Sữa tươi",
                    Gia = 30000,
                    SoLuongTon = 15,
                    NgayHetHan = DateTime.Now.AddDays(2),
                    NhietDoBaoQuan = 4
                },

                new SanPhamDienTu
                {
                    MaSP = "DT01",
                    TenSP = "Điện thoại",
                    Gia = 8000000,
                    SoLuongTon = 5,
                    BaoHanhThang = 24,
                    HangSanXuat = "Samsung"
                },

                new SanPhamThucPham
                {
                    MaSP = "TP02",
                    TenSP = "Nước ngọt",
                    Gia = 12000,
                    SoLuongTon = 30,
                    NgayHetHan = DateTime.Now.AddDays(10),
                    NhietDoBaoQuan = 25
                },

                new SanPhamDienTu
                {
                    MaSP = "DT02",
                    TenSP = "Laptop",
                    Gia = 15000000,
                    SoLuongTon = 3,
                    BaoHanhThang = 12,
                    HangSanXuat = "Dell"
                }
            };

            Console.WriteLine("===== DANH SÁCH SẢN PHẨM =====");

            foreach (SanPham sp in danhSach)
            {
                Console.WriteLine(sp.MoTa());
                Console.WriteLine();
            }

            decimal tongGiaTriKho = 0;

            foreach (SanPham sp in danhSach)
            {
                tongGiaTriKho += sp.TinhGiaBan() * sp.SoLuongTon;
            }

            Console.WriteLine("===== TỔNG GIÁ TRỊ KHO HÀNG =====");
            Console.WriteLine("Tổng giá trị kho: " + tongGiaTriKho + " VNĐ");

            Console.ReadKey();
        }
    }
}
