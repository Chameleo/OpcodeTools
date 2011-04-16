using System;
using System.Collections.Generic;
using System.Text;

namespace OpcodeTools
{
    class Windows406 : FormulasBase
    {
        public override string ToString()
        {
            return "4.0.6 Windows";
        }

        protected override bool AuthCheck(uint opcode)
        {
            return (opcode & 0x3FFD) == 8217;
        }

        protected override bool SpecialCheck(uint opcode)
        {
            return (opcode & 0xB2AD) == 12;
        }

        protected override bool NormalCheck(uint opcode)
        {
            return (opcode & 0x2093) == 8320 && opcode != 60096 && opcode != 44964;
        }

        public override uint CalcCryptedFromOpcode(uint opcode)
        {
            uint a1 = opcode;
            return (a1 & 0xC | ((a1 & 0x60 | ((a1 & 0x1F00 | (a1 >> 1) & 0x6000) >> 1)) >> 1)) >> 2;
        }

        public override uint CalcSpecialFromOpcode(uint opcode)
        {
            uint a4 = opcode;
            return (a4 & 2 | ((a4 & 0x10 | ((a4 & 0x40 | ((a4 & 0x100 | ((a4 & 0xC00 | (a4 >> 2) & 0x1000) >> 1)) >> 1)) >> 1)) >> 2)) >> 1;
        }

        public override uint CalcAuthFromOpcode(uint opcode)
        {
            uint a1 = opcode;
            return (a1 & 2 | (a1 >> 12) & 0xC) >> 1;
        }
    }
}
