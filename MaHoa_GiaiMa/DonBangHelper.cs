using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaHoa_GiaiMa
{
    class DonBangHelper
    {
        //Bang chu cai
        char[] BCC = new char[35]
        {
            'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm','n', 'o','p', 'q', 'r',
            's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '1', '2', '3', '4', '5', '6', '7', '8', '9'
        };

        /// <summary>
        /// Tạo khóa với những ký tự như trong bảng chữ cái nhưng thay đổi vị trí ngẫu nhiên
        /// </summary>
        /// <returns></returns>
        public string TaoKhoa()
        {
            string khoa = "";
            List<char> bCC1 = BCC.ToList();
            Random rand = new Random();
            int viTri;
            for (int i = 0; i < BCC.Length; ++i)
            {
                viTri = rand.Next(bCC1.Count - 1);
                khoa += bCC1[viTri].ToString();
                bCC1.RemoveAt(viTri);
            }
            return khoa;
        }


        public string MaHoa(string _duLieuCanMaHoa, string _khoa)
        {
            string chuoiDaMaHoa = "";
            int viTri = -1;
            for (int i = 0; i < _duLieuCanMaHoa.Length; ++i)
            {
                viTri = Array.IndexOf(BCC, _duLieuCanMaHoa[i]);
                if (viTri == -1)
                {
                    //Ký tự không có trong bảng chữ cái, bỏ qua ký tự này và không mã hóa
                    chuoiDaMaHoa += _duLieuCanMaHoa[i];
                }
                else
                {
                    chuoiDaMaHoa += _khoa[viTri];
                }
            }
            return chuoiDaMaHoa;
        }

        public string GiaiMa(string _duLieuCanGiaiMa, string _khoa)
        {
            string chuoiDaGiaiMa = "";
            int viTri = -1;
            for (int i = 0; i < _duLieuCanGiaiMa.Length; ++i)
            {
                viTri = _khoa.IndexOf(_duLieuCanGiaiMa[i]);
                if (viTri == -1)
                {
                    chuoiDaGiaiMa += _duLieuCanGiaiMa[i];
                }
                else
                {
                    chuoiDaGiaiMa += BCC[viTri];
                }
            }
            return chuoiDaGiaiMa;
        }
    }
}
