namespace MarketPlace.Sockets.Interfaces
{
    public interface ISocketClient
    {
        void Start(string ip, int port);
    }
}