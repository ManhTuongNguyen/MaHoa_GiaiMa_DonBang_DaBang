using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaHoa_GiaiMa_DaBang
{
    class DaBangHelper
    {
        char[] BCC = new char[]
        {
            'f', 'g', 'h', 'x', '5', '6', 'o', 'p', 'k', '7', '8', 'y', 'z', ' ', '1', 'i', 'j', 's', 't',
            'n', 'c', 'd', 'e', 'r', 'b', 'u', 'l', 'm', 'v', '2', 'w', '3', 'q', 'a', '4', '9'
        };

        char[,] bangTra;

        /// <summary>
        /// Tạo bảng tra là mảng char 2 chiều, mỗi hàng chênh lệch nhau vị trí 1 ký tự
        /// </summary>
        public DaBangHelper()
        {
            int len = this.BCC.Length;
            bangTra = new char[len, len];
            for (int i = 0; i < len; ++i)
                for (int j = 0; j < len; ++j)
                    this.bangTra[i,j] = BCC[(i + j) % len];
        }

        /// <summary>
        /// Tạo khóa ngẫu nhiên có độ dài bằng với văn bản được mã hóa
        /// </summary>
        /// <param name="_doDaiKhoa"></param>
        /// <returns></returns>
        public string TaoKhoa(int _doDaiKhoa)
        {
            string khoa = "";
            Random rand = new Random();
            for (int i = 0; i <_doDaiKhoa; ++i)
            {
                khoa += BCC[rand.Next(this.BCC.Length - 1)].ToString();
            }

            return khoa;
        }

        /// <summary>
        /// Mã hóa dữ liệu với khóa có độ dài bằng với độ dài dữ liệu
        /// </summary>
        /// <param name="_chuoiCanMaHoa"></param>
        /// <param name="_khoa"></param>
        /// <returns></returns>
        public string MaHoa(string _chuoiCanMaHoa, string _khoa)
        {
            string chuoiDaMaHoa = "";
            for (int i = 0; i < _chuoiCanMaHoa.Length; ++i)
                chuoiDaMaHoa += Array.IndexOf(BCC, _chuoiCanMaHoa[i]) == -1 ? _chuoiCanMaHoa[i] :
                    this.bangTra[Array.IndexOf(BCC, _chuoiCanMaHoa[i]), Array.IndexOf(BCC, _khoa[i])];
            return chuoiDaMaHoa;
        }


        public string GiaiMa(string _chuoiCanGiaiMa, string _khoa)
        {
            string chuoiDaGiaiMa = "";
            for (int i = 0; i < _chuoiCanGiaiMa.Length; ++i)
            {
                int viTri = -1;
                if (Array.IndexOf(BCC, _chuoiCanGiaiMa[i]) == -1)
                {
                    //Ký tự cần giải mã không có trong bảng chữ cái
                    //Ta không mã hóa, giải mã ký tự này
                    chuoiDaGiaiMa += _chuoiCanGiaiMa[i];
                }
                else
                {
                    //Tìm vị trí của ký tự trước khi được mã hóa trong bảng tra
                    for (int j = 0; j < _chuoiCanGiaiMa.Length; ++j)
                        if (bangTra[j, Array.IndexOf(BCC, _khoa[i])] == _chuoiCanGiaiMa[i])
                        {
                            viTri = j;
                            break;
                        }
                    chuoiDaGiaiMa += BCC[viTri].ToString();
                }
            }
            return chuoiDaGiaiMa;
        }
    }
}
