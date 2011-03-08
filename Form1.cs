using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OpcodeTools
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			uint opcode;
			if(!UInt32.TryParse(textBox1.Text, out opcode))
				return;

			update(opcode);
		}

		private void textBox3_TextChanged(object sender, EventArgs e)
		{
			try 
			{
				update(Convert.ToUInt32(textBox3.Text, 16));
			}
			catch (Exception)
			{
			}
			
		}
		void update(uint a1)
		{
			uint offset = (a1 & 0xC | ((a1 & 0x60 | ((a1 & 0x1F00 | (a1 >> 1) & 0x6000) >> 1)) >> 1)) >> 2;
			crypted.Text = offset.ToString();
			offset = offset * 4 + 1376;
			offsetBox.Text = offset.ToString();
			uint a4 = a1;
			uint specialHandlerNum = (a4 & 2 | ((a4 & 0x10 | ((a4 & 0x40 | ((a4 & 0x100 | ((a4 & 0xC00 | (a4 >> 2) & 0x1000) >> 1)) >> 1)) >> 1)) >> 2)) >> 1;
			special.Text = String.Format("{0:x}", specialHandlerNum);
		}

		private uint CalcOffsetFromOpcode(uint opcode)
		{
			uint a1 = opcode;
			uint offset = (a1 & 0xC | ((a1 & 0x60 | ((a1 & 0x1F00 | (a1 >> 1) & 0x6000) >> 1)) >> 1)) >> 2;
			return (offset * 4) + 1376;
		}

		public uint CalcSpecialFromOpcode(uint opcode)
		{
			uint a4 = opcode;
			return (a4 & 2 | ((a4 & 0x10 | ((a4 & 0x40 | ((a4 & 0x100 | ((a4 & 0xC00 | (a4 >> 2) & 0x1000) >> 1)) >> 1)) >> 1)) >> 2)) >> 1;
		}

		private int CalcOpcodeFromSpecial(uint offset)
		{
			for (uint i = 0; i < 0xFFFF; ++i)
			{
				if ((i & 0xB2AD) == 12 )
				{
					if (CalcSpecialFromOpcode(i) == offset)
						return (int)i;
				}
			}
			return -1;
		}

		private void textBox2_TextChanged(object sender, EventArgs e)
		{
			try
			{
				OpcodeForSpecial.Text = String.Format("{0:x}",
					CalcOpcodeFromSpecial(Convert.ToUInt32(specialInput.Text, 16)));
			}
			catch (Exception)
			{
			}
		}
	}
}
