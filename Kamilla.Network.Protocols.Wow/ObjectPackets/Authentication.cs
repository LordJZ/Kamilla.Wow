using System;
using System.IO;
using System.Linq;
using System.Text;
using Kamilla.IO;
using Kamilla.Network.Protocols.Wow.Game;

namespace Kamilla.Network.Protocols.Wow.ObjectPackets
{
    /// <summary>
    /// 14545
    /// </summary>
    public sealed class AuthChallenge : ObjectPacket
    {
        public uint Seed { get; private set; }
        public byte Count { get; private set; }
        public byte[] ClientSeed { get; private set; }
        public byte[] ServerSeed { get; private set; }

        public AuthChallenge()
        {
        }

        public AuthChallenge(StreamHandler Reader)
        {
            this.Read(Reader);
        }

        public override void Read(StreamHandler Reader)
        {
            this.ClientSeed = Reader.ReadBytes(16);
            this.ServerSeed = Reader.ReadBytes(16);
            this.Seed = Reader.ReadUInt32();
            this.Count = Reader.ReadByte();
        }

        public override void ToString(StringBuilder builder)
        {
            builder.AppendFormatLine("Seed: 0x{0:X8}  Count: {1}", Seed, Count);
            builder.Append("Client Seed: ");
            ClientSeed.ToHexString(builder);
            builder.AppendLine();
            builder.Append("Server Seed: ");
            ServerSeed.ToHexString(builder);
            builder.AppendLine();
        }

        public override void Save(StreamHandler writer)
        {
            throw new NotImplementedException("Saving an auth challenge to a packet is not yet implemented.");
        }

        public override CustomPacket CreatePacket()
        {
            throw new NotImplementedException("Saving an auth challenge to a packet is not yet implemented.");
        }
    }
}
