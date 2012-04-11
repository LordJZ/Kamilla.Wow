using System;
using System.Linq;
using System.Net;
using System.Numerics;
using Kamilla.IO;
using Kamilla.Network.Protocols.Wow.Game;

namespace Kamilla.Network.Protocols.Wow.ObjectPackets
{
    public sealed class ConnectToPacket : ObjectPacket
    {
        public uint Token { get; private set; }
        public ulong UnknownULong { get; private set; }
        public byte ConnectionIndex { get; private set; }
        public ushort Port { get; private set; }
        public IPAddress IP { get; private set; }
        public byte[] ServerHash { get; private set; }
        public byte[] ComputedHash { get; private set; }
        public byte[] FixedBlob { get; private set; }

        public ConnectToPacket(StreamHandler reader)
        {
            this.Read(reader);
        }

        public override void Read(StreamHandler Reader)
        {
            ConnectionIndex = Reader.ReadByte();
            Token = Reader.ReadUInt32();
            byte[] blob = Reader.ReadBytes(256);
            UnknownULong = Reader.ReadUInt64();

            // hardcoded in client
            byte[] modulus1 = {
                    0x91, 0xD5, 0x9B, 0xB7, 0xD4, 0xE1, 0x83, 0xA5, 0x22, 0x2B, 0x5F, 0x38, 0xF4, 0xB8, 0x86, 0xFF, 
                    0x32, 0x84, 0x38, 0x2D, 0x99, 0x38, 0x8F, 0xBA, 0xF3, 0xC9, 0x22, 0x5D, 0x51, 0x73, 0x1E, 0x28, 
                    0x87, 0x24, 0x8F, 0xB5, 0xC9, 0xB0, 0x7C, 0x95, 0xD0, 0x6B, 0x5B, 0xF4, 0x94, 0xC5, 0x94, 0x9D, 
                    0xFA, 0x6F, 0x47, 0x3A, 0xA3, 0x86, 0xC0, 0xA8, 0x37, 0xF3, 0x9B, 0xEF, 0x2F, 0xC1, 0xFB, 0xB3, 
                    0xF4, 0x1C, 0x2B, 0x0E, 0xD3, 0x6D, 0x88, 0xBB, 0x02, 0xE0, 0x4E, 0x63, 0xFA, 0x76, 0xE3, 0x43, 
                    0xF9, 0x01, 0xFD, 0x23, 0x5E, 0x6A, 0x0B, 0x14, 0xEC, 0x5E, 0x91, 0x34, 0x0D, 0x0B, 0x4F, 0xA3, 
                    0x5A, 0x46, 0xC5, 0x5E, 0xDC, 0xB5, 0xCD, 0xC1, 0x47, 0x6B, 0x59, 0xCA, 0xFA, 0xA9, 0xBE, 0x24, 
                    0x9F, 0xF5, 0x05, 0x6B, 0xBB, 0x67, 0x8B, 0xB7, 0xE4, 0x3A, 0x43, 0x00, 0x5C, 0x1C, 0xB7, 0xCA, 
                    0x98, 0x90, 0x79, 0x77, 0x6D, 0x05, 0x4F, 0x83, 0xCC, 0xAC, 0x06, 0x2E, 0x50, 0x11, 0x87, 0x23, 
                    0xD8, 0xA6, 0xF7, 0x6F, 0x7A, 0x59, 0x87, 0xA6, 0xDE, 0x5D, 0xD8, 0xEC, 0x44, 0xBE, 0x45, 0x31, 
                    0x7F, 0x8A, 0xF0, 0x58, 0x89, 0x53, 0x74, 0xDF, 0xCC, 0xAD, 0x01, 0x24, 0xD8, 0x19, 0x65, 0x1C, 
                    0x25, 0xD3, 0xE1, 0x6B, 0x8B, 0xDA, 0xFE, 0x1D, 0xA4, 0x2C, 0x8B, 0x25, 0xED, 0x7C, 0xFF, 0x6A, 
                    0xE0, 0x63, 0xD0, 0x52, 0x20, 0x7E, 0x62, 0x49, 0xD2, 0xB3, 0x6B, 0xCC, 0x91, 0x69, 0xA5, 0x08, 
                    0x8B, 0x69, 0x65, 0xFF, 0xB9, 0xC9, 0x17, 0x02, 0x5D, 0xD8, 0x8E, 0x1A, 0x63, 0xD9, 0x2A, 0x7F, 
                    0xDB, 0xE3, 0xF8, 0x76, 0x6D, 0xEA, 0x0E, 0x36, 0x98, 0x78, 0x19, 0xC5, 0x87, 0xBA, 0x6C, 0x20, 
                    0xB6, 0x08, 0x44, 0x04, 0x4C, 0xA8, 0xD5, 0xB6, 0x9D, 0x4D, 0x00, 0x20, 0x40, 0x00, 0x90, 0x04
                };

            // hardcoded in client
            byte[] exp = { 0x01, 0x00, 0x01, 0x00 };

            BigInteger res_bn = BigInteger.ModPow(new BigInteger(blob), new BigInteger(exp), new BigInteger(modulus1));

            FixedBlob = FixBlob(res_bn.ToByteArray());

            ServerHash = new byte[0];
            Port = BitConverter.ToUInt16(FixedBlob, 21);
            IP = new IPAddress(FixedBlob.Take(4).ToArray());

            //byte[] bytes = new byte[0]
            //    .Concat(BitConverter.GetBytes(Port))
            //    .Concat(BitConverter.GetBytes(ip))
            //    .ToArray();

            //SHA1Managed sha1 = new SHA1Managed();
            ComputedHash = new byte[0]; //sha1.ComputeHash(bytes);
        }

        private static byte[] FixBlob(byte[] blob)
        {
            var fixedBlob = new byte[260];

            using (var reader = new StreamHandler(blob))
            {
                fixedBlob[53] = reader.ReadByte();


                fixedBlob[84] = reader.ReadByte();


                fixedBlob[23] = reader.ReadByte();


                fixedBlob[205] = reader.ReadByte();


                fixedBlob[70] = reader.ReadByte();


                fixedBlob[112] = reader.ReadByte();


                fixedBlob[209] = reader.ReadByte();


                fixedBlob[50] = reader.ReadByte();


                fixedBlob[98] = reader.ReadByte();


                fixedBlob[131] = reader.ReadByte();


                fixedBlob[146] = reader.ReadByte();


                fixedBlob[57] = reader.ReadByte();


                fixedBlob[15] = reader.ReadByte();


                fixedBlob[82] = reader.ReadByte();


                fixedBlob[199] = reader.ReadByte();


                fixedBlob[14] = reader.ReadByte();


                fixedBlob[178] = reader.ReadByte();


                fixedBlob[64] = reader.ReadByte();


                fixedBlob[246] = reader.ReadByte();


                fixedBlob[144] = reader.ReadByte();


                fixedBlob[218] = reader.ReadByte();


                fixedBlob[125] = reader.ReadByte();


                fixedBlob[97] = reader.ReadByte();


                fixedBlob[52] = reader.ReadByte();


                fixedBlob[33] = reader.ReadByte();


                fixedBlob[1] = reader.ReadByte();


                fixedBlob[150] = reader.ReadByte();


                fixedBlob[48] = reader.ReadByte();


                fixedBlob[63] = reader.ReadByte();


                fixedBlob[74] = reader.ReadByte();


                fixedBlob[31] = reader.ReadByte();


                fixedBlob[69] = reader.ReadByte();


                fixedBlob[249] = reader.ReadByte();


                fixedBlob[85] = reader.ReadByte();


                fixedBlob[173] = reader.ReadByte();


                fixedBlob[35] = reader.ReadByte();


                fixedBlob[156] = reader.ReadByte();


                fixedBlob[239] = reader.ReadByte();


                fixedBlob[242] = reader.ReadByte();


                fixedBlob[220] = reader.ReadByte();


                fixedBlob[62] = reader.ReadByte();


                fixedBlob[179] = reader.ReadByte();


                fixedBlob[208] = reader.ReadByte();


                fixedBlob[137] = reader.ReadByte();


                fixedBlob[94] = reader.ReadByte();


                fixedBlob[254] = reader.ReadByte();


                fixedBlob[43] = reader.ReadByte();


                fixedBlob[36] = reader.ReadByte();


                fixedBlob[54] = reader.ReadByte();


                fixedBlob[103] = reader.ReadByte();


                fixedBlob[13] = reader.ReadByte();


                fixedBlob[172] = reader.ReadByte();


                fixedBlob[55] = reader.ReadByte();


                fixedBlob[195] = reader.ReadByte();


                fixedBlob[241] = reader.ReadByte();


                fixedBlob[87] = reader.ReadByte();


                fixedBlob[181] = reader.ReadByte();


                fixedBlob[44] = reader.ReadByte();


                fixedBlob[143] = reader.ReadByte();


                fixedBlob[196] = reader.ReadByte();


                fixedBlob[185] = reader.ReadByte();


                fixedBlob[243] = reader.ReadByte();


                fixedBlob[86] = reader.ReadByte();


                fixedBlob[227] = reader.ReadByte();


                fixedBlob[214] = reader.ReadByte();


                fixedBlob[12] = reader.ReadByte();


                fixedBlob[180] = reader.ReadByte();


                fixedBlob[67] = reader.ReadByte();


                fixedBlob[251] = reader.ReadByte();


                fixedBlob[108] = reader.ReadByte();


                fixedBlob[76] = reader.ReadByte();


                fixedBlob[56] = reader.ReadByte();


                fixedBlob[222] = reader.ReadByte();


                fixedBlob[174] = reader.ReadByte();


                fixedBlob[3] = reader.ReadByte();


                fixedBlob[9] = reader.ReadByte();


                fixedBlob[51] = reader.ReadByte();


                fixedBlob[257] = reader.ReadByte();


                fixedBlob[233] = reader.ReadByte();


                fixedBlob[187] = reader.ReadByte();


                fixedBlob[170] = reader.ReadByte();


                fixedBlob[130] = reader.ReadByte();


                fixedBlob[186] = reader.ReadByte();


                fixedBlob[27] = reader.ReadByte();


                fixedBlob[92] = reader.ReadByte();


                fixedBlob[4] = reader.ReadByte();


                fixedBlob[166] = reader.ReadByte();


                fixedBlob[120] = reader.ReadByte();


                fixedBlob[253] = reader.ReadByte();


                fixedBlob[114] = reader.ReadByte();


                fixedBlob[39] = reader.ReadByte();


                fixedBlob[164] = reader.ReadByte();


                fixedBlob[65] = reader.ReadByte();


                fixedBlob[206] = reader.ReadByte();


                fixedBlob[250] = reader.ReadByte();


                fixedBlob[175] = reader.ReadByte();


                fixedBlob[207] = reader.ReadByte();


                fixedBlob[255] = reader.ReadByte();


                fixedBlob[104] = reader.ReadByte();


                fixedBlob[40] = reader.ReadByte();


                fixedBlob[188] = reader.ReadByte();


                fixedBlob[129] = reader.ReadByte();


                fixedBlob[6] = reader.ReadByte();


                fixedBlob[216] = reader.ReadByte();


                fixedBlob[75] = reader.ReadByte();


                fixedBlob[215] = reader.ReadByte();


                fixedBlob[244] = reader.ReadByte();


                fixedBlob[113] = reader.ReadByte();


                fixedBlob[213] = reader.ReadByte();


                fixedBlob[153] = reader.ReadByte();


                fixedBlob[237] = reader.ReadByte();


                fixedBlob[77] = reader.ReadByte();


                fixedBlob[204] = reader.ReadByte();


                fixedBlob[58] = reader.ReadByte();


                fixedBlob[228] = reader.ReadByte();


                fixedBlob[119] = reader.ReadByte();


                fixedBlob[193] = reader.ReadByte();


                fixedBlob[105] = reader.ReadByte();


                fixedBlob[225] = reader.ReadByte();


                fixedBlob[90] = reader.ReadByte();


                fixedBlob[158] = reader.ReadByte();


                fixedBlob[157] = reader.ReadByte();


                fixedBlob[47] = reader.ReadByte();


                fixedBlob[115] = reader.ReadByte();


                fixedBlob[68] = reader.ReadByte();


                fixedBlob[140] = reader.ReadByte();


                fixedBlob[224] = reader.ReadByte();


                fixedBlob[226] = reader.ReadByte();


                fixedBlob[71] = reader.ReadByte();


                fixedBlob[198] = reader.ReadByte();


                fixedBlob[155] = reader.ReadByte();


                fixedBlob[235] = reader.ReadByte();


                fixedBlob[167] = reader.ReadByte();


                fixedBlob[190] = reader.ReadByte();


                fixedBlob[141] = reader.ReadByte();


                fixedBlob[20] = reader.ReadByte();


                fixedBlob[42] = reader.ReadByte();


                fixedBlob[95] = reader.ReadByte();


                fixedBlob[88] = reader.ReadByte();


                fixedBlob[162] = reader.ReadByte();


                fixedBlob[49] = reader.ReadByte();


                fixedBlob[121] = reader.ReadByte();


                fixedBlob[163] = reader.ReadByte();


                fixedBlob[99] = reader.ReadByte();


                fixedBlob[80] = reader.ReadByte();


                fixedBlob[147] = reader.ReadByte();


                fixedBlob[91] = reader.ReadByte();


                fixedBlob[236] = reader.ReadByte();


                fixedBlob[177] = reader.ReadByte();


                fixedBlob[168] = reader.ReadByte();


                fixedBlob[234] = reader.ReadByte();


                fixedBlob[2] = reader.ReadByte();


                fixedBlob[93] = reader.ReadByte();


                fixedBlob[182] = reader.ReadByte();


                fixedBlob[219] = reader.ReadByte();


                fixedBlob[148] = reader.ReadByte();


                fixedBlob[38] = reader.ReadByte();


                fixedBlob[229] = reader.ReadByte();


                fixedBlob[184] = reader.ReadByte();


                fixedBlob[116] = reader.ReadByte();


                fixedBlob[110] = reader.ReadByte();


                fixedBlob[122] = reader.ReadByte();


                fixedBlob[11] = reader.ReadByte();


                fixedBlob[183] = reader.ReadByte();


                fixedBlob[24] = reader.ReadByte();


                fixedBlob[26] = reader.ReadByte();


                fixedBlob[46] = reader.ReadByte();


                fixedBlob[138] = reader.ReadByte();


                fixedBlob[142] = reader.ReadByte();


                fixedBlob[165] = reader.ReadByte();


                fixedBlob[139] = reader.ReadByte();


                fixedBlob[28] = reader.ReadByte();


                fixedBlob[25] = reader.ReadByte();


                fixedBlob[231] = reader.ReadByte();


                fixedBlob[197] = reader.ReadByte();


                fixedBlob[5] = reader.ReadByte();


                fixedBlob[73] = reader.ReadByte();


                fixedBlob[171] = reader.ReadByte();


                fixedBlob[133] = reader.ReadByte();


                fixedBlob[16] = reader.ReadByte();


                fixedBlob[202] = reader.ReadByte();


                fixedBlob[106] = reader.ReadByte();


                fixedBlob[102] = reader.ReadByte();


                fixedBlob[247] = reader.ReadByte();


                fixedBlob[238] = reader.ReadByte();


                fixedBlob[8] = reader.ReadByte();


                fixedBlob[126] = reader.ReadByte();


                fixedBlob[194] = reader.ReadByte();


                fixedBlob[176] = reader.ReadByte();


                fixedBlob[159] = reader.ReadByte();


                fixedBlob[200] = reader.ReadByte();


                fixedBlob[252] = reader.ReadByte();


                fixedBlob[100] = reader.ReadByte();


                fixedBlob[45] = reader.ReadByte();


                fixedBlob[78] = reader.ReadByte();


                fixedBlob[201] = reader.ReadByte();


                fixedBlob[132] = reader.ReadByte();


                fixedBlob[29] = reader.ReadByte();


                fixedBlob[212] = reader.ReadByte();


                fixedBlob[152] = reader.ReadByte();


                fixedBlob[7] = reader.ReadByte();


                fixedBlob[248] = reader.ReadByte();


                fixedBlob[217] = reader.ReadByte();


                fixedBlob[223] = reader.ReadByte();


                fixedBlob[240] = reader.ReadByte();


                fixedBlob[245] = reader.ReadByte();


                fixedBlob[210] = reader.ReadByte();


                fixedBlob[79] = reader.ReadByte();


                fixedBlob[134] = reader.ReadByte();


                fixedBlob[211] = reader.ReadByte();


                fixedBlob[66] = reader.ReadByte();


                fixedBlob[149] = reader.ReadByte();


                fixedBlob[72] = reader.ReadByte();


                fixedBlob[32] = reader.ReadByte();


                fixedBlob[61] = reader.ReadByte();


                fixedBlob[89] = reader.ReadByte();


                fixedBlob[189] = reader.ReadByte();


                fixedBlob[124] = reader.ReadByte();


                fixedBlob[10] = reader.ReadByte();


                fixedBlob[37] = reader.ReadByte();


                fixedBlob[230] = reader.ReadByte();


                fixedBlob[21] = reader.ReadByte();


                fixedBlob[41] = reader.ReadByte();


                fixedBlob[81] = reader.ReadByte();


                fixedBlob[0] = reader.ReadByte();


                fixedBlob[123] = reader.ReadByte();


                fixedBlob[128] = reader.ReadByte();


                fixedBlob[22] = reader.ReadByte();


                fixedBlob[221] = reader.ReadByte();


                fixedBlob[203] = reader.ReadByte();


                fixedBlob[135] = reader.ReadByte();


                fixedBlob[30] = reader.ReadByte();


                fixedBlob[109] = reader.ReadByte();


                fixedBlob[232] = reader.ReadByte();


                fixedBlob[136] = reader.ReadByte();


                fixedBlob[256] = reader.ReadByte();


                fixedBlob[34] = reader.ReadByte();


                fixedBlob[145] = reader.ReadByte();


                fixedBlob[111] = reader.ReadByte();


                fixedBlob[117] = reader.ReadByte();


                fixedBlob[127] = reader.ReadByte();


                fixedBlob[83] = reader.ReadByte();


                fixedBlob[160] = reader.ReadByte();


                fixedBlob[96] = reader.ReadByte();


                fixedBlob[161] = reader.ReadByte();


                fixedBlob[169] = reader.ReadByte();


                fixedBlob[59] = reader.ReadByte();


                fixedBlob[118] = reader.ReadByte();


                fixedBlob[192] = reader.ReadByte();


                fixedBlob[191] = reader.ReadByte();


                fixedBlob[151] = reader.ReadByte();


                fixedBlob[107] = reader.ReadByte();


                fixedBlob[101] = reader.ReadByte();


                fixedBlob[154] = reader.ReadByte();

                fixedBlob[60] = reader.ReadByte();
            }

            return fixedBlob;
        }

        public override void ToString(System.Text.StringBuilder builder)
        {
            builder.AppendLine("Connection token: " + this.Token);
            builder.AppendFormatLine("Unknown uint64: {0} 0x{0:X16}", this.UnknownULong);
            builder.AppendLine("Connection index: " + this.ConnectionIndex);
            builder.AppendFormatLine("Connection server: {0}:{1}", this.IP, this.Port);
            builder.AppendLine("Computed Hash: " + this.ComputedHash.ToHexString());
            builder.AppendLine("Server's Hash: " + this.ServerHash.ToHexString());
        }

        public override void Save(StreamHandler writer)
        {
            throw new NotImplementedException("Saving redirect data to a packet is not implemented.");
        }

        public override CustomPacket CreatePacket()
        {
            throw new NotImplementedException("Saving redirect data to a packet is not implemented.");
        }
    }
}
