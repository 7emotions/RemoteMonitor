namespace PCoder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.rtx_input = new System.Windows.Forms.RichTextBox();
            this.rtx_output = new System.Windows.Forms.RichTextBox();
            this.btn_encode = new System.Windows.Forms.Button();
            this.btn_decode = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rtx_input
            // 
            this.rtx_input.Location = new System.Drawing.Point(12, 24);
            this.rtx_input.Name = "rtx_input";
            this.rtx_input.Size = new System.Drawing.Size(571, 158);
            this.rtx_input.TabIndex = 0;
            this.rtx_input.Text = "";
            this.rtx_input.TabIndex = 0;
            // 
            // rtx_output
            // 
            this.rtx_output.Location = new System.Drawing.Point(12, 229);
            this.rtx_output.Name = "rtx_output";
            this.rtx_output.Size = new System.Drawing.Size(571, 158);
            this.rtx_output.TabIndex = 0;
            this.rtx_output.Text = "";
            this.rtx_output.TabIndex = 3;
            // 
            // btn_encode
            // 
            this.btn_encode.Location = new System.Drawing.Point(12, 188);
            this.btn_encode.Name = "btn_encode";
            this.btn_encode.Size = new System.Drawing.Size(75, 23);
            this.btn_encode.TabIndex = 1;
            this.btn_encode.Text = "Encode";
            this.btn_encode.UseVisualStyleBackColor = true;
            this.btn_encode.Click += new System.EventHandler(this.btn_encode_Click);
            this.btn_encode.TabIndex = 1;
            // 
            // btn_decode
            // 
            this.btn_decode.Location = new System.Drawing.Point(508, 188);
            this.btn_decode.Name = "btn_decode";
            this.btn_decode.Size = new System.Drawing.Size(75, 23);
            this.btn_decode.TabIndex = 1;
            this.btn_decode.Text = "Decode";
            this.btn_decode.UseVisualStyleBackColor = true;
            this.btn_decode.Click += new System.EventHandler(this.btn_decode_Click);
            this.btn_decode.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "Input:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 214);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Output:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 390);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "Author:Paradise_c@qq.com";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 411);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_decode);
            this.Controls.Add(this.btn_encode);
            this.Controls.Add(this.rtx_output);
            this.Controls.Add(this.rtx_input);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "PCoder";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtx_input;
        private System.Windows.Forms.RichTextBox rtx_output;
        private System.Windows.Forms.Button btn_encode;
        private System.Windows.Forms.Button btn_decode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

