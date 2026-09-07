using System;

namespace QuanLySachCoBan
{
    public class Sach
    {
        private string _maSach;
        private string _tenSach;
        private string _tacGia;
        private int _namXuatBan;
        private double _giaBan;

        public Sach()
        {
            _maSach = "";
            _tenSach = "";
            _tacGia = "";
            _namXuatBan = 0;
            _giaBan = 0.0;
        }

        public Sach(string maSach, string tenSach, string tacGia, int namXuatBan, double giaBan)
        {
            _maSach = maSach;
            _tenSach = tenSach;
            _tacGia = tacGia;
            _namXuatBan = namXuatBan;
            _giaBan = giaBan;
        }

        public string MaSach
        {
            get { return _maSach; }
        }

        public string TenSach
        {
            get { return _tenSach; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _tenSach = value;
                }
                else
                {
                    throw new Exception("Tên sách không được để trống!");
                }
            }
        }

        public string TacGia
        {
            get { return _tacGia; }
            set { _tacGia = value; }
        }

        public int NamXuatBan
        {
            get { return _namXuatBan; }
            set
            {
                int namHienTai = DateTime.Now.Year;

                if (value >= 1900 && value <= namHienTai)
                {
                    _namXuatBan = value;
                }
                else
                {
                    throw new Exception("Năm xuất bản phải từ 1900 đến năm hiện tại!");
                }
            }
        }

        public double GiaBan
        {
            get { return _giaBan; }
        }

        public void HienThiThongTin()
        {
            Console.WriteLine("Mã sách: " + MaSach);
            Console.WriteLine("Tên sách: " + TenSach);
            Console.WriteLine("Tác giả: " + TacGia);
            Console.WriteLine("Năm xuất bản: " + NamXuatBan);
            Console.WriteLine("Giá bán: " + GiaBan);
            Console.WriteLine();
        }

        public override string ToString()
        {
            return "Mã sách: " + MaSach +
                   ", Tên sách: " + TenSach +
                   ", Tác giả: " + TacGia +
                   ", Năm xuất bản: " + NamXuatBan +
                   ", Giá bán: " + GiaBan;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Sach sach1 = new Sach(
                "S001",
                "Lập trình C#",
                "Nguyễn Văn A",
                2023,
                85000
            );

            Sach sach2 = new Sach();

            sach2.TenSach = "Lập trình hướng đối tượng";
            sach2.TacGia = "Trần Văn B";
            sach2.NamXuatBan = 2024;

            Sach sach3 = new Sach("S003", "", "", 2025, 120000)
            {
                TenSach = "Cơ sở dữ liệu",
                TacGia = "Lê Văn C"
            };

            Console.WriteLine("===== THÔNG TIN SÁCH 1 =====");
            sach1.HienThiThongTin();

            Console.WriteLine("===== THÔNG TIN SÁCH 2 =====");
            sach2.HienThiThongTin();

            Console.WriteLine("===== THÔNG TIN SÁCH 3 =====");
            sach3.HienThiThongTin();

            Console.WriteLine("===== SỬ DỤNG TOSTRING() =====");
            Console.WriteLine(sach1.ToString());
            Console.WriteLine();

            Console.WriteLine("===== KIỂM TRA NĂM XUẤT BẢN =====");

            try
            {
                sach1.NamXuatBan = 1800;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
            }

            Console.ReadKey();
        }
    }
}