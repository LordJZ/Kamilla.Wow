
namespace Kamilla.Network.Protocols.Wow.ObjectPackets
{
    public interface IValueChange : IObjectPacket
    {
        float NewValue { get; set; }
    }
}
