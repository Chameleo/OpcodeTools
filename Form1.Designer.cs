namespace OpcodeTools
{
	partial class Form1
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
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.offsetBox = new System.Windows.Forms.TextBox();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.crypted = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.special = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.specialInput = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.OpcodeForSpecial = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(22, 76);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(51, 20);
			this.textBox1.TabIndex = 0;
			this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
			// 
			// offsetBox
			// 
			this.offsetBox.Location = new System.Drawing.Point(134, 61);
			this.offsetBox.Name = "offsetBox";
			this.offsetBox.Size = new System.Drawing.Size(46, 20);
			this.offsetBox.TabIndex = 1;
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(23, 40);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(41, 20);
			this.textBox3.TabIndex = 2;
			this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
			// 
			// crypted
			// 
			this.crypted.Location = new System.Drawing.Point(134, 25);
			this.crypted.Name = "crypted";
			this.crypted.Size = new System.Drawing.Size(46, 20);
			this.crypted.TabIndex = 3;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(131, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "Converted";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(131, 45);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(35, 13);
			this.label2.TabIndex = 5;
			this.label2.Text = "Offset";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(19, 60);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(66, 13);
			this.label3.TabIndex = 6;
			this.label3.Text = "Opcode dec";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(20, 24);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(65, 13);
			this.label4.TabIndex = 7;
			this.label4.Text = "Opcode hex";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(131, 82);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(42, 13);
			this.label5.TabIndex = 9;
			this.label5.Text = "Special";
			// 
			// special
			// 
			this.special.Location = new System.Drawing.Point(134, 98);
			this.special.Name = "special";
			this.special.Size = new System.Drawing.Size(46, 20);
			this.special.TabIndex = 8;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(31, 181);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(42, 13);
			this.label6.TabIndex = 11;
			this.label6.Text = "Special";
			// 
			// specialInput
			// 
			this.specialInput.Location = new System.Drawing.Point(26, 210);
			this.specialInput.Name = "specialInput";
			this.specialInput.Size = new System.Drawing.Size(47, 20);
			this.specialInput.TabIndex = 10;
			this.specialInput.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(131, 181);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(45, 13);
			this.label7.TabIndex = 13;
			this.label7.Text = "Opcode";
			// 
			// OpcodeForSpecial
			// 
			this.OpcodeForSpecial.Location = new System.Drawing.Point(126, 210);
			this.OpcodeForSpecial.Name = "OpcodeForSpecial";
			this.OpcodeForSpecial.Size = new System.Drawing.Size(47, 20);
			this.OpcodeForSpecial.TabIndex = 12;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(86, 196);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(19, 13);
			this.label8.TabIndex = 14;
			this.label8.Text = "=>";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(91, 47);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(19, 13);
			this.label9.TabIndex = 15;
			this.label9.Text = "=>";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(213, 258);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.OpcodeForSpecial);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.specialInput);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.special);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.crypted);
			this.Controls.Add(this.textBox3);
			this.Controls.Add(this.offsetBox);
			this.Controls.Add(this.textBox1);
			this.Name = "Form1";
			this.Text = "Opcode tools";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox offsetBox;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.TextBox crypted;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox special;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox specialInput;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox OpcodeForSpecial;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
	}
}

