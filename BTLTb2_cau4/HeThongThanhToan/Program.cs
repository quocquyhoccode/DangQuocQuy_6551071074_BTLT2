using System;

namespace HeThongThanhToan
{
    public abstract class PhuongThucThanhToan
    {
        public string TenPhuongThuc { get; }

        public PhuongThucThanhToan(string tenPhuongThuc)
        {
            TenPhuongThuc = tenPhuongThuc;
        }

        public abstract decimal TinhPhiGiaoDich(decimal soTien);

        public abstract bool XacNhan();

        public void ThongTinGiaoDich(decimal soTien)
        {
            decimal phi = TinhPhiGiaoDich(soTien);
            bool xacNhan = XacNhan();

            Console.WriteLine("Phương thức: " + TenPhuongThuc);
            Console.WriteLine("Số tiền: " + soTien + " VNĐ");
            Console.WriteLine("Phí giao dịch: " + phi + " VNĐ");
            Console.WriteLine("Xác nhận: " + (xacNhan ? "Thành công" : "Thất bại"));
            Console.WriteLine();
        }
    }

    public class ThanhToanTienMat : PhuongThucThanhToan
    {
        private decimal _tienKhachDua;

        public ThanhToanTienMat(decimal tienKhachDua)
            : base("Tiền mặt")
        {
            _tienKhachDua = tienKhachDua;
        }

        public decimal TienKhachDua
        {
            get { return _tienKhachDua; }
            set { _tienKhachDua = value; }
        }

        public decimal TienThua
        {
            get { return _tienKhachDua - 500000; }
        }

        public override decimal TinhPhiGiaoDich(decimal soTien)
        {
            return 0;
        }

        public override bool XacNhan()
        {
            return true;
        }
    }

    public class ThanhToanTheNganHang : PhuongThucThanhToan
    {
        private string _soThe;

        public ThanhToanTheNganHang(string soThe)
            : base("Thẻ ngân hàng")
        {
            _soThe = soThe;
        }

        public string SoThe
        {
            get
            {
                if (_soThe.Length > 8)
                {
                    return "********" + _soThe.Substring(8);
                }

                return "********";
            }
            set { _soThe = value; }
        }

        public override decimal TinhPhiGiaoDich(decimal soTien)
        {
            return soTien * 0.015m;
        }

        public override bool XacNhan()
        {
            Random random = new Random();
            return random.Next(2) == 1;
        }
    }

    public class ThanhToanViDienTu : PhuongThucThanhToan
    {
        private string _tenVi;

        public ThanhToanViDienTu(string tenVi)
            : base("Ví điện tử")
        {
            _tenVi = tenVi;
        }

        public string TenVi
        {
            get { return _tenVi; }
            set { _tenVi = value; }
        }

        public override decimal TinhPhiGiaoDich(decimal soTien)
        {
            decimal phi = soTien * 0.005m;

            if (phi < 2000)
            {
                phi = 2000;
            }

            return phi;
        }

        public override bool XacNhan()
        {
            return true;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            decimal soTien = 500000;

            PhuongThucThanhToan[] danhSach =
            {
                new ThanhToanTienMat(500000),
                new ThanhToanTheNganHang("1234567812345678"),
                new ThanhToanViDienTu("MoMo")
            };

            Console.WriteLine("===== THÔNG TIN GIAO DỊCH =====");
            Console.WriteLine("Số tiền hóa đơn: " + soTien + " VNĐ");
            Console.WriteLine();

            foreach (PhuongThucThanhToan p in danhSach)
            {
                p.ThongTinGiaoDich(soTien);
            }

            decimal phiThapNhat = danhSach[0].TinhPhiGiaoDich(soTien);
            string phuongThucThapNhat = danhSach[0].TenPhuongThuc;

            foreach (PhuongThucThanhToan p in danhSach)
            {
                decimal phi = p.TinhPhiGiaoDich(soTien);

                if (phi < phiThapNhat)
                {
                    phiThapNhat = phi;
                    phuongThucThapNhat = p.TenPhuongThuc;
                }
            }

            Console.WriteLine("===== PHÍ THẤP NHẤT =====");
            Console.WriteLine("Phương thức: " + phuongThucThapNhat);
            Console.WriteLine("Phí giao dịch: " + phiThapNhat + " VNĐ");

            ThanhToanTienMat tienMat = (ThanhToanTienMat)danhSach[0];

            Console.WriteLine();
            Console.WriteLine("===== TIỀN MẶT =====");
            Console.WriteLine("Tiền khách đưa: " + tienMat.TienKhachDua + " VNĐ");
            Console.WriteLine("Tiền thừa: " + tienMat.TienThua + " VNĐ");

            Console.ReadKey();
        }
    }
}