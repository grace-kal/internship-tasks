
namespace TestsWin
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_normal = new System.Windows.Forms.Button();
            this.btn_normal_parallel = new System.Windows.Forms.Button();
            this.btn_async = new System.Windows.Forms.Button();
            this.btn_parallel_async = new System.Windows.Forms.Button();
            this.textBox = new System.Windows.Forms.TextBox();
            this.labelMethod = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_normal
            // 
            this.btn_normal.Location = new System.Drawing.Point(183, 29);
            this.btn_normal.Name = "btn_normal";
            this.btn_normal.Size = new System.Drawing.Size(403, 31);
            this.btn_normal.TabIndex = 0;
            this.btn_normal.Text = "Normal Execute";
            this.btn_normal.UseVisualStyleBackColor = true;
            this.btn_normal.Click += new System.EventHandler(this.btn_normal_Click);
            // 
            // btn_normal_parallel
            // 
            this.btn_normal_parallel.Location = new System.Drawing.Point(183, 78);
            this.btn_normal_parallel.Name = "btn_normal_parallel";
            this.btn_normal_parallel.Size = new System.Drawing.Size(403, 33);
            this.btn_normal_parallel.TabIndex = 1;
            this.btn_normal_parallel.Text = "Normal Parallel Execute";
            this.btn_normal_parallel.UseVisualStyleBackColor = true;
            this.btn_normal_parallel.Click += new System.EventHandler(this.btn_normal_parallel_Click);
            // 
            // btn_async
            // 
            this.btn_async.Location = new System.Drawing.Point(183, 129);
            this.btn_async.Name = "btn_async";
            this.btn_async.Size = new System.Drawing.Size(402, 33);
            this.btn_async.TabIndex = 4;
            this.btn_async.Text = "Async Execute";
            this.btn_async.UseVisualStyleBackColor = true;
            this.btn_async.Click += new System.EventHandler(this.btn_async_Click);
            // 
            // btn_parallel_async
            // 
            this.btn_parallel_async.Location = new System.Drawing.Point(183, 181);
            this.btn_parallel_async.Name = "btn_parallel_async";
            this.btn_parallel_async.Size = new System.Drawing.Size(402, 32);
            this.btn_parallel_async.TabIndex = 6;
            this.btn_parallel_async.Text = "Parallel Async Execute";
            this.btn_parallel_async.UseVisualStyleBackColor = true;
            this.btn_parallel_async.Click += new System.EventHandler(this.btn_parallel_async_Click);
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(38, 294);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(744, 401);
            this.textBox.TabIndex = 8;
            // 
            // labelMethod
            // 
            this.labelMethod.AutoSize = true;
            this.labelMethod.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.labelMethod.Location = new System.Drawing.Point(38, 225);
            this.labelMethod.Name = "labelMethod";
            this.labelMethod.Size = new System.Drawing.Size(61, 20);
            this.labelMethod.TabIndex = 9;
            this.labelMethod.Text = "Method";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 740);
            this.Controls.Add(this.labelMethod);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.btn_parallel_async);
            this.Controls.Add(this.btn_async);
            this.Controls.Add(this.btn_normal_parallel);
            this.Controls.Add(this.btn_normal);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_normal;
        private System.Windows.Forms.Button btn_normal_parallel;
        private System.Windows.Forms.Button btn_async;
        private System.Windows.Forms.Button btn_parallel_async;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Label labelMethod;
    }
}

