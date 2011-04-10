using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OpcodeTools
{
	public partial class Form1 : Form
	{
        bool IgnoreTextChanged = false;

		public Form1()
		{
			InitializeComponent();
		}

		private void OpcodeDecBox_TextChanged(object sender, EventArgs e)
		{
            if (IgnoreTextChanged)
                return;

			uint opcode;
			if(!UInt32.TryParse(opcodeDecBox.Text, out opcode))
				return;

            opcodeHexBox.Text = String.Format("{0:x}", opcode);
			updateValuesForOpcode(opcode);
		}

        private void OpcodeHex_TextChanged(object sender, EventArgs e)
        {
            try 
	        {
                opcodeDecBox.Text = Convert.ToUInt32(opcodeHexBox.Text, 16).ToString();
	        }
	        catch (Exception)
	        {
	        }
        }
        private void CleanValues()
        {
            IgnoreTextChanged = true;
            cryptedBox.Text = specialBox.Text = offsetBox.Text = authBox.Text = "";
            IgnoreTextChanged = false;
        }

		void updateValuesForOpcode(uint opcode)
		{
            // start clean
            CleanValues();

            IgnoreTextChanged = true;
            if (IsAuthOpcode(opcode))
            {
                uint auth = CalcAuthFromOpcode(opcode);
                authBox.Text = auth.ToString();
            }
            else if (IsSpecialOpcode(opcode))
            {
                uint specialHandlerNum = CalcSpecialFromOpcode(opcode);
                specialBox.Text = String.Format("{0:x}", specialHandlerNum);
            }
            else if (IsNormalOpcode(opcode))
            {
                uint crypt = CalcCryptedFromOpcode(opcode);
                uint offset = CalcOffsetFromOpcode(opcode);
			    cryptedBox.Text = crypt.ToString();
			    offsetBox.Text = offset.ToString();
            }
            IgnoreTextChanged = false;
		}

        private void specialBox_TextChanged(object sender, EventArgs e)
        {
            if (IgnoreTextChanged)
                return;
            try
            {
                SetOpcode(CalcOpcodeFromSpecial(Convert.ToUInt32(specialBox.Text, 16)));
            }
            catch (Exception)
            {
            }
        }

        private void offsetBox_TextChanged(object sender, EventArgs e)
        {
            if (IgnoreTextChanged)
                return;
            try
            {
                SetOpcode(CalcOpcodeFromOffset(Convert.ToUInt32(offsetBox.Text)));

            }
            catch (Exception)
            {
            }
        }

        private void authBox_TextChanged(object sender, EventArgs e)
        {
            if (IgnoreTextChanged)
                return;
            try
            {
                SetOpcode(CalcOpcodeFromAuth(Convert.ToUInt32(authBox.Text)));
            }
            catch (Exception)
            {
            }
        }

        private void SetOpcode(uint opcode)
        {
            IgnoreTextChanged = true;
            opcodeHexBox.Text = String.Format("{0:X}", opcode);
            opcodeDecBox.Text = opcode.ToString();
            IgnoreTextChanged = false;
        }

        #region Verison specific functions. Currently 4.0.6

        private static bool IsAuthOpcode(uint opcode)
        {
            return (opcode & 0x3FFD) == 8217;
        }
        private static bool IsSpecialOpcode(uint opcode)
        {
            return !IsAuthOpcode(opcode) && (opcode & 0xB2AD) == 12;
        }
        private static bool IsNormalOpcode(uint opcode)
        {
            return !IsSpecialOpcode(opcode) && !IsAuthOpcode(opcode) &&
                    (opcode & 0x2093) == 8320 && opcode != 60096 && opcode != 44964;
        }

        private uint CalcCryptedFromOpcode(uint opcode)
        {
            uint a1 = opcode;
            return (a1 & 0xC | ((a1 & 0x60 | ((a1 & 0x1F00 | (a1 >> 1) & 0x6000) >> 1)) >> 1)) >> 2;
        }

		private uint CalcOffsetFromOpcode(uint opcode)
		{
            uint crypted = CalcCryptedFromOpcode(opcode);
			return (crypted * 4) + 1376;
		}

		public uint CalcSpecialFromOpcode(uint opcode)
		{
			uint a4 = opcode;
			return (a4 & 2 | ((a4 & 0x10 | ((a4 & 0x40 | ((a4 & 0x100 | ((a4 & 0xC00 | (a4 >> 2) & 0x1000) >> 1)) >> 1)) >> 1)) >> 2)) >> 1;
		}

        public uint CalcAuthFromOpcode(uint opcode)
        {
            uint a1 = opcode;
            return (a1 & 2 | (a1 >> 12) & 0xC) >> 1;
        }

        #endregion

        private uint CalcOpcodeFromSpecial(uint offset)
		{
			for (uint i = 1; i < 0xFFFF; ++i)
			{
				if (IsSpecialOpcode(i))
				{
					if (CalcSpecialFromOpcode(i) == offset)
						return i;
				}
			}
			return 0;
		}

		private uint CalcOpcodeFromOffset(uint offset)
		{
			for (uint i = 1; i < 0xFFFF; ++i)
			{
				if (IsNormalOpcode(i))
				{
					if (CalcOffsetFromOpcode(i) == offset)
						return i;
				}
			}
			return 0;
		}

		private uint CalcOpcodeFromAuth(uint auth)
		{
			for (uint i = 1; i < 0xFFFF; ++i)
			{
                if (IsAuthOpcode(i) && 
					CalcAuthFromOpcode(i) == auth)
				{
						return i;
				}
			}
			return 0;
		}
	}
}
