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

    class Mac13860 : FormulasBase
    {
        public override string ToString()
        {
            return "0.4.1.0.13860 Mac";
        }

        protected override uint BaseOffset { get { return 1380; } }

        protected override bool AuthCheck(uint opcode)
        {
            return (opcode & 0xFCFB) == 1216;
        }

        protected override bool SpecialCheck(uint opcode)
        {
            return (opcode & 0x467C) == 1544;
        }

        protected override bool NormalCheck(uint opcode)
        {
            return (opcode & 0x4C9) == 1088 && opcode != 24176 && opcode != 23636;
        }

        public override uint CalcCryptedFromOpcode(uint opcode)
        {
            uint v3 = opcode;
            return (((v3 & 0xF800u) >> 5) | ((v3 & 0x300u) >> 4) | ((v3 & 6u) >> 1) | ((v3 & 0x30u) >> 2));
        }

        public override uint CalcSpecialFromOpcode(uint opcode)
        {
            uint a4 = opcode;
            return ((a4 & 0x8000) >> 8) | a4 & 3 | ((a4 & 0x3800) >> 7) | ((a4 & 0x180) >> 5);
        }

        public override uint CalcAuthFromOpcode(uint opcode)
        {
            uint a4 = opcode;
            return ((a4 & 4) >> 2) | ((a4 & 0x300) >> 7);
        }
    }

    class Mac13875 : FormulasBase
    {
        public override string ToString()
        {
            return "0.4.1.0.13875 Mac";
        }

        protected override uint BaseOffset { get { return 1380; } }

        protected override bool AuthCheck(uint opcode)
        {
            return (opcode & 0xDFF6) == 546;
        }

        protected override bool SpecialCheck(uint opcode)
        {
            return (opcode & 0xD57) == 1346;
        }

        protected override bool NormalCheck(uint opcode)
        {
            return (opcode & 0x8AA) == 2088 && opcode != 52776 && opcode != 7784;
        }

        public override uint CalcCryptedFromOpcode(uint opcode)
        {
            uint v3 = opcode;
            return ((v3 & 0xF000u) >> 5) | ((v3 & 0x700u) >> 4) | ((v3 & 0x40u) >> 3) | v3 & 1 | ((v3 & 0x10u) >> 2) | ((v3 & 4u) >> 1);
        }

        public override uint CalcSpecialFromOpcode(uint opcode)
        {
            uint a4 = opcode;
            return ((a4 & 0xF000) >> 8) | ((a4 & 0x200) >> 6) | ((a4 & 0x80) >> 5) | ((a4 & 8) >> 3) | ((a4 & 0x20) >> 4);
        }

        public override uint CalcAuthFromOpcode(uint opcode)
        {
            uint a4 = opcode;
            return (a4 & 1 | ((a4 & 0x2000) >> 11) | ((a4 & 8) >> 2));
        }
    }
}
