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

namespace MaHoa_GiaiMa_DaBang
{
    public partial class DaBang : Form
    {
        public DaBang()
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
                oFD.Filter = "(Text file) *.dabang | *.dabang";
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
            //Đọc dữ liệu từ file vào string rawText
            string rawText = "";
            try
            {
                StreamReader sRD = new StreamReader(tbx_Path.Text);
                rawText = sRD.ReadToEnd();
                sRD.Close();
                sRD.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DaBangHelper daBangHP = new DaBangHelper();
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
                string khoa = "";
                khoa = daBangHP.TaoKhoa(rawText.Length);

                //Lưu khóa vào 1 file, dùng để giải mã về sau

                MessageBox.Show("Chọn nơi lưu khóa", "Lưu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SaveFileDialog sFD = new SaveFileDialog();
                sFD.Title = "Lưu khóa";
                sFD.Filter = "(Text file) *.txt | *.txt";
                if (sFD.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(sFD.FileName, khoa);
                    MessageBox.Show($"Đã lưu khóa thành công!\nKhóa được lưu tại {sFD.FileName}", "Thành công!", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra!\nFile chưa được lưu", "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //Mã hóa

                string chuoiDaMaHoa = "";
                chuoiDaMaHoa = daBangHP.MaHoa(rawText, khoa);

                //Lưu văn bản đã mã hóa

                MessageBox.Show("Chọn nơi file văn bản đã mã hóa", "Lưu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SaveFileDialog sFD1 = new SaveFileDialog();
                sFD1.Title = "Lưu văn bản đã mã hóa";
                sFD1.Filter = "(Text file) *.dabang | *.dabang";
                if (sFD1.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(sFD1.FileName, chuoiDaMaHoa);
                    MessageBox.Show($"Đã lưu văn bản mã hóa thành công!\nFile được lưu tại {sFD1.FileName}", "Thành công!", MessageBoxButtons.OK);
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
                if (str != ".dabang")
                {
                    var msg = MessageBox.Show("File mã hóa không có đuôi mở rộng *.dabang\nBạn có muốn tiếp tục không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (msg == DialogResult.No)
                    {
                        return;
                    }
                }

                //Yêu cầu tìm khóa để giải mã

                string khoa = "";
                MessageBox.Show("Chọn file chứa khóa của file này để giải mã", "Tìm khóa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                OpenFileDialog oFD = new OpenFileDialog();
                oFD.Title = "Tìm khóa";
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
                        MessageBox.Show("ERROR: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    return;
                }

                //Giải mã

                string chuoiDaGiaiMa = "";
                chuoiDaGiaiMa = daBangHP.GiaiMa(rawText, khoa);

                //Lưu file đã giải mã

                MessageBox.Show("Chọn nơi lưu văn bản đã giải mã", "Lưu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SaveFileDialog sFD = new SaveFileDialog();
                sFD.Title = "Lưu file sau khi giải mã";
                sFD.Filter = "(Text file) *.txt | *.txt";
                if (sFD.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(sFD.FileName, chuoiDaGiaiMa);
                    MessageBox.Show($"Đã lưu văn bản giải mã thành công!\nFile được lưu tại {sFD.FileName}", "Thành công!", MessageBoxButtons.OK);
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
