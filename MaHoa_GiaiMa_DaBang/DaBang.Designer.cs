
namespace MaHoa_GiaiMa_DaBang
{
    partial class DaBang
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_perform = new System.Windows.Forms.Button();
            this.btn_select = new System.Windows.Forms.Button();
            this.tbx_Path = new System.Windows.Forms.TextBox();
            this.rdbtn_GiaiMa = new System.Windows.Forms.RadioButton();
            this.rdbtn_MaHoa = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_perform
            // 
            this.btn_perform.Location = new System.Drawing.Point(234, 125);
            this.btn_perform.Name = "btn_perform";
            this.btn_perform.Size = new System.Drawing.Size(125, 36);
            this.btn_perform.TabIndex = 11;
            this.btn_perform.Text = "&Thực hiện";
            this.btn_perform.UseVisualStyleBackColor = true;
            this.btn_perform.Click += new System.EventHandler(this.btn_perform_Click);
            // 
            // btn_select
            // 
            this.btn_select.Location = new System.Drawing.Point(501, 60);
            this.btn_select.Name = "btn_select";
            this.btn_select.Size = new System.Drawing.Size(87, 39);
            this.btn_select.TabIndex = 10;
            this.btn_select.Text = "&Chọn";
            this.btn_select.UseVisualStyleBackColor = true;
            this.btn_select.Click += new System.EventHandler(this.btn_select_Click);
            // 
            // tbx_Path
            // 
            this.tbx_Path.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_Path.Location = new System.Drawing.Point(21, 60);
            this.tbx_Path.Multiline = true;
            this.tbx_Path.Name = "tbx_Path";
            this.tbx_Path.Size = new System.Drawing.Size(462, 40);
            this.tbx_Path.TabIndex = 9;
            // 
            // rdbtn_GiaiMa
            // 
            this.rdbtn_GiaiMa.AutoSize = true;
            this.rdbtn_GiaiMa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbtn_GiaiMa.Location = new System.Drawing.Point(367, 10);
            this.rdbtn_GiaiMa.Name = "rdbtn_GiaiMa";
            this.rdbtn_GiaiMa.Size = new System.Drawing.Size(80, 22);
            this.rdbtn_GiaiMa.TabIndex = 8;
            this.rdbtn_GiaiMa.TabStop = true;
            this.rdbtn_GiaiMa.Text = "Giải mã";
            this.rdbtn_GiaiMa.UseVisualStyleBackColor = true;
            // 
            // rdbtn_MaHoa
            // 
            this.rdbtn_MaHoa.AutoSize = true;
            this.rdbtn_MaHoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbtn_MaHoa.Location = new System.Drawing.Point(161, 10);
            this.rdbtn_MaHoa.Name = "rdbtn_MaHoa";
            this.rdbtn_MaHoa.Size = new System.Drawing.Size(79, 22);
            this.rdbtn_MaHoa.TabIndex = 7;
            this.rdbtn_MaHoa.TabStop = true;
            this.rdbtn_MaHoa.Text = "Mã hóa";
            this.rdbtn_MaHoa.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "Đường dẫn";
            // 
            // DaBang
            // 
            this.AcceptButton = this.btn_perform;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 173);
            this.Controls.Add(this.btn_perform);
            this.Controls.Add(this.btn_select);
            this.Controls.Add(this.tbx_Path);
            this.Controls.Add(this.rdbtn_GiaiMa);
            this.Controls.Add(this.rdbtn_MaHoa);
            this.Controls.Add(this.label1);
            this.Location = new System.Drawing.Point(625, 220);
            this.MaximumSize = new System.Drawing.Size(625, 220);
            this.Name = "DaBang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mã hóa || Giải mã || Đa bảng";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_perform;
        private System.Windows.Forms.Button btn_select;
        private System.Windows.Forms.TextBox tbx_Path;
        private System.Windows.Forms.RadioButton rdbtn_GiaiMa;
        private System.Windows.Forms.RadioButton rdbtn_MaHoa;
        private System.Windows.Forms.Label label1;
    }
}

