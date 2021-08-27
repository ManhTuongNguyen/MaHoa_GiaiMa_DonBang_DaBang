using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaHoa_GiaiMa
{
    public partial class MaHoaGiaiMaDonBang : Form
    {
        public MaHoaGiaiMaDonBang()
        {
            InitializeComponent();
        }

        private void btn_select_Click(object sender, EventArgs e)
        {
            OpenFileDialog oFD = new OpenFileDialog();
            oFD.Multiselect = false;
            if (rdbtn_MaHoa.Checked)
            {
                oFD.Title = "Chọn file văn bản cần mã hóa";
                oFD.Filter = "(Text file) *.txt | *.txt";
            }
            else
            {
                oFD.Title = "Chọn file văn bản cần giải mã";
                oFD.Filter = "(Text file) *.donbang | *.donbang";
            }
            if (oFD.ShowDialog() == DialogResult.OK)
            {
                tbx_Path.Text = oFD.FileName;
            }
        }

        private void btn_perform_Click(object sender, EventArgs e)
        {
            if (!File.Exists(tbx_Path.Text))
            {
                MessageBox.Show("Bạn phải lựa chọn file trước!", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DonBangHelper donBangHP = new DonBangHelper();
            if (rdbtn_MaHoa.Checked)
            {
                //Encrypt

                //Kiểm tra file

                string str = Path.GetExtension(tbx_Path.Text);
                if (str != ".txt")
                {
                    var msg = MessageBox.Show("File mã hóa không có đuôi mở rộng *.txt\nBạn có muốn tiếp tục không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (msg == DialogResult.No)
                    {
                        return;
                    }
                }

                //Tạo khóa
                SaveFileDialog sFD = new SaveFileDialog();
                string khoa = donBangHP.TaoKhoa();
                MessageBox.Show("Chọn nơi lưu khóa để giải mã file này về sau!", "Lưu khóa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                sFD.Filter = "(Text file) *.txt | *.txt";
                sFD.Title = "Lưu khóa";
                if (sFD.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(sFD.FileName, khoa);
                    MessageBox.Show($"Đã lưu khóa thành công tại vị trí {sFD.FileName}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.None);
                }
                else
                {
                    return;
                }


                string chuoiCanMaHoa = "";
                try
                {
                    StreamReader sRD = new StreamReader(tbx_Path.Text);
                    chuoiCanMaHoa = sRD.ReadToEnd();
                    sRD.Close();
                    sRD.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR: " + ex.Message, "ERROR", MessageBoxButtons.OK);
                    return;
                }

                //Mã hóa văn bản

                string chuoiDaMaHoa = "";
                chuoiDaMaHoa = donBangHP.MaHoa(chuoiCanMaHoa, khoa);

                //Lưu văn bản sau khi mã hóa vào file
                MessageBox.Show("Chọn nơi lưu file văn bản đã mã hóa", "Lưu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SaveFileDialog sFD1 = new SaveFileDialog();
                sFD1.Title = "Lưu file đã mã hóa!";
                sFD1.Filter = "(Text file) *.donbang | *.donbang";
                if (sFD1.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(sFD1.FileName, chuoiDaMaHoa);
                    MessageBox.Show($"Đã lưu file thành công tại vị trí {sFD1.FileName}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.None);
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra!\nFile chưa được lưu", "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                //Decrypt

                //Kiểm tra file

                string str = Path.GetExtension(tbx_Path.Text);
                if (str != ".donbang")
                {
                    var msg = MessageBox.Show("File mã hóa không có đuôi mở rộng *.donbang\nBạn có muốn tiếp tục không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (msg == DialogResult.No)
                    {
                        return;
                    }
                }

                MessageBox.Show("Chọn nơi lưu file chứa khóa để giải mã file này!", "Tìm khóa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                string khoa = "";
                OpenFileDialog oFD = new OpenFileDialog();
                oFD.Title = "Chọn file văn bản chứa khóa";
                oFD.Filter = "(Text file) *.txt | *.txt";
                if (oFD.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        StreamReader sRD = new StreamReader(oFD.FileName);
                        khoa = sRD.ReadToEnd();
                        sRD.Close();
                        sRD.Dispose();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("ERROR: " + ex.Message, "ERROR", MessageBoxButtons.OK);
                        return;
                    }
                }
                else
                {
                    return;
                }


                string chuoiCanGiaiMa = "";
                try
                {
                    StreamReader sRD = new StreamReader(tbx_Path.Text);
                    chuoiCanGiaiMa = sRD.ReadToEnd();
                    sRD.Close();
                    sRD.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR: " + ex.Message, "ERROR", MessageBoxButtons.OK);
                    return;
                }

                string chuoiDaGiaiMa = "";
                chuoiDaGiaiMa = donBangHP.GiaiMa(chuoiCanGiaiMa, khoa);


                SaveFileDialog sFD = new SaveFileDialog();
                MessageBox.Show("Chọn nơi lưu file sau khi đã giải mã!", "Lưu file", MessageBoxButtons.OK, MessageBoxIcon.Information);
                sFD.Title = "Chọn nơi lưu văn bản đã giải mã";
                sFD.Filter = "(Text file) *.txt | *.txt";
                if (sFD.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(sFD.FileName, chuoiDaGiaiMa);
                    MessageBox.Show($"Đã lưu file thành công tại vị trí {sFD.FileName}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.None);
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra!\nFile chưa được lưu", "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }
    }
}
