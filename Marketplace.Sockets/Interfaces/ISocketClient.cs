namespace Marketplace.Sockets.Interfaces
{
    public interface ISocketClient
    {
        void Start(string ip, int port);
    }
}