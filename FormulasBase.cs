using System;
namespace OpcodeTools
{
    abstract class FormulasBase
    {
        public abstract uint CalcCryptedFromOpcode(uint opcode);
        public abstract uint CalcSpecialFromOpcode(uint opcode);
        public abstract uint CalcAuthFromOpcode(uint opcode);
        protected abstract bool NormalCheck(uint opcode);
        protected abstract bool SpecialCheck(uint opcode);
        protected abstract bool AuthCheck(uint opcode);
        protected uint BaseOffset { get { return 1376; } }

        public bool IsAuthOpcode(uint opcode)
        {
            return AuthCheck(opcode);
        }

        public bool IsNormalOpcode(uint opcode)
        {
            return !IsSpecialOpcode(opcode) && !IsAuthOpcode(opcode) && NormalCheck(opcode);
        }
        
        public bool IsSpecialOpcode(uint opcode)
        {
            return !IsAuthOpcode(opcode) && SpecialCheck(opcode);
        }

        public uint CalcOffsetFromOpcode(uint opcode)
        {
            uint crypted = CalcCryptedFromOpcode(opcode);
            return (crypted * 4) + BaseOffset;
        }
    }
}
