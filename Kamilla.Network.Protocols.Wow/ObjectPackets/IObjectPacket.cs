using System.Text;
using Kamilla.IO;
using Kamilla.Network.Protocols.Wow.Game;

namespace Kamilla.Network.Protocols.Wow.ObjectPackets
{
    /// <summary>
    /// Defines means to manipulate data of a <see cref="Kamilla.WorldOfWarcraft.WowPacket"/>.
    /// </summary>
    public interface IObjectPacket
    {
        /// <summary>
        /// When overriden in a derived class, reads the packet data from a <see cref="StreamHandler"/>.
        /// </summary>
        /// <param name="reader">The StreamHandler to read data from.</param>
        void Read(StreamHandler reader);

        /// <summary>
        /// When overriden in a derived class, reads the packet data from a byte array.
        /// </summary>
        /// <param name="data">The byte array to read data from.</param>
        void Read(byte[] data);

        /// <summary>
        /// When overriden in a derived class, writes the packet data to a <see cref="StreamHandler"/>.
        /// </summary>
        /// <param name="writer">The StreamHandler to write data to.</param>
        void Save(StreamHandler writer);

        /// <summary>
        /// When overriden in a derived class, writes the packet data to a byte array.
        /// </summary>
        /// <returns>The byte array that contains the packet structure.</returns>
        byte[] Save();

        /// <summary>
        /// When overriden in a derived class, returns a <see cref="System.String"/> that represents the current packet data.
        /// </summary>
        /// <returns>A <see cref="System.String"/> that represents the current packet.</returns>
        string ToString();

        /// <summary>
        /// When overriden in a derived class, writes a string representation of the current packet data.
        /// </summary>
        /// <param name="builder">The StringBuilder to write a string representation of the current packet data to.</param>
        void ToString(StringBuilder builder);

        /// <summary>
        /// When overriden in a derived class, creates a new instance of <see cref="Kamilla.Network.Protocols.Wow.CustomPacket"/>
        /// that represents the current packet.
        /// </summary>
        /// <returns>
        /// A new instance of <see cref="Kamilla.Network.Protocols.Wow.CustomPacket"/>,
        /// that represents the current packet.
        /// </returns>
        CustomPacket CreatePacket();
    }

    /// <summary>
    /// Implements some basic methods to work with opcode data.
    /// </summary>
    public abstract class ObjectPacket : IObjectPacket
    {
        /// <summary>
        /// When overriden in a derived class, reads the packet data from a <see cref="StreamHandler"/>.
        /// </summary>
        /// <param name="reader">The StreamHandler to read data from.</param>
        public abstract void Read(StreamHandler reader);

        /// <summary>
        /// When overriden in a derived class, reads the packet data from a byte array.
        /// </summary>
        /// <param name="data">The byte array to read data from.</param>
        public virtual void Read(byte[] data)
        {
            using (var reader = new StreamHandler(data))
                Read(reader);
        }

        /// <summary>
        /// When overriden in a derived class, writes the packet data to a <see cref="StreamHandler"/>.
        /// </summary>
        /// <param name="writer">The StreamHandler to write data to.</param>
        public abstract void Save(StreamHandler writer);

        /// <summary>
        /// When overriden in a derived class, writes the packet data to a byte array.
        /// </summary>
        /// <returns>The byte array that contains the packet structure.</returns>
        public virtual byte[] Save()
        {
            byte[] result;

            using (var writer = new StreamHandler())
            {
                Save(writer);

                result = writer.ToByteArray();
            }

            return result;
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            this.ToString(builder);
            return builder.ToString();
        }

        /// <summary>
        /// When overriden in a derived class, writes a string representation of the current packet data.
        /// </summary>
        /// <param name="builder">The StringBuilder to write a string representation of the current packet data to.</param>
        public abstract void ToString(StringBuilder builder);

        /// <summary>
        /// When overriden in a derived class, creates a new instance of <see cref="Kamilla.Network.Protocols.Wow.CustomPacket"/>
        /// that represents the current packet.
        /// </summary>
        /// <returns>
        /// A new instance of <see cref="Kamilla.Network.Protocols.Wow.CustomPacket"/>,
        /// that represents the current packet.
        /// </returns>
        public abstract CustomPacket CreatePacket();

        /// <summary>
        /// Creates a new instance of <see cref="Kamilla.Network.Protocols.Wow.CustomPacket"/> using the specified opcode and direction,
        /// and saves the current packet data to it.
        /// </summary>
        /// <param name="opcode">The opcode to use to create a new instance of CustomPacket class.</param>
        /// <param name="direction">The packet direction to use to create a new instance of CustomPacket class.</param>
        /// <returns>A new instance of CustomPacket with the specified opcode, direction, and data saved to it.</returns>
        protected CustomPacket CreatePacket(WowOpcodes opcode, TransferDirection direction)
        {
            return new CustomPacket(opcode, direction).WriteBytes(Save());
        }
    }
}
