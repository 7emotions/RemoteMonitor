namespace GodEyeServer
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.edt_ipadress = new System.Windows.Forms.TextBox();
            this.btn_listen = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nud_max_number = new System.Windows.Forms.NumericUpDown();
            this.nud_port = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nud_max_number)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_port)).BeginInit();
            this.SuspendLayout();
            // 
            // edt_ipadress
            // 
            this.edt_ipadress.Location = new System.Drawing.Point(143, 6);
            this.edt_ipadress.Name = "edt_ipadress";
            this.edt_ipadress.Size = new System.Drawing.Size(102, 21);
            this.edt_ipadress.TabIndex = 0;
            // 
            // btn_listen
            // 
            this.btn_listen.Location = new System.Drawing.Point(143, 91);
            this.btn_listen.Name = "btn_listen";
            this.btn_listen.Size = new System.Drawing.Size(102, 23);
            this.btn_listen.TabIndex = 1;
            this.btn_listen.Text = "Listen";
            this.btn_listen.UseVisualStyleBackColor = true;
            this.btn_listen.Click += new System.EventHandler(this.btn_listen_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "Local IP Address";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Port";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "Max Number of Client";
            // 
            // nud_max_number
            // 
            this.nud_max_number.Location = new System.Drawing.Point(193, 64);
            this.nud_max_number.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nud_max_number.Name = "nud_max_number";
            this.nud_max_number.Size = new System.Drawing.Size(52, 21);
            this.nud_max_number.TabIndex = 3;
            this.nud_max_number.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nud_port
            // 
            this.nud_port.Location = new System.Drawing.Point(193, 37);
            this.nud_port.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nud_port.Name = "nud_port";
            this.nud_port.Size = new System.Drawing.Size(52, 21);
            this.nud_port.TabIndex = 3;
            this.nud_port.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(260, 123);
            this.Controls.Add(this.nud_port);
            this.Controls.Add(this.nud_max_number);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_listen);
            this.Controls.Add(this.edt_ipadress);
            this.Name = "Form1";
            this.Text = "GodEye";
            ((System.ComponentModel.ISupportInitialize)(this.nud_max_number)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_port)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox edt_ipadress;
        private System.Windows.Forms.Button btn_listen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nud_max_number;
        private System.Windows.Forms.NumericUpDown nud_port;
    }
}

