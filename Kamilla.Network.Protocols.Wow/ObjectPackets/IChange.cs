
namespace Kamilla.Network.Protocols.Wow.ObjectPackets
{
    public interface IChange : IObjectPacket
    {
        uint ChangeCounter { get; set; }
    }
}
