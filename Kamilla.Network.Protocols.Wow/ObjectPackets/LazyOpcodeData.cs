using System;
using Kamilla.IO;
using Kamilla.Network.Protocols.Wow.Game;

namespace Kamilla.Network.Protocols.Wow.ObjectPackets
{
    public abstract class LazyObjectPacket : ObjectPacket
    {
        protected Action[] m_readers;
        protected StreamHandler Reader;
        private byte m_readLevel = 0;

        protected void EnsureRead(byte level)
        {
            while (m_readLevel < level && m_readers.Length > m_readLevel)
                m_readers[m_readLevel++]();
        }

        protected void EnsureRead()
        {
            EnsureRead(byte.MaxValue);
        }

        protected void SetRead()
        {
            m_readLevel = byte.MaxValue;
        }

        public override void Read(StreamHandler reader)
        {
            if (this.Reader != reader)
                throw new ArgumentException("The provided reader in argument must be the same "
                    + "instance of StreamHandler as the provided reader in the constructor.", "reader");

            EnsureRead();
        }
    }
}
