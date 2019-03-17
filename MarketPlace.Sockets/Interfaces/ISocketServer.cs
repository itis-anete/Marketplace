using System.Threading.Tasks;

namespace MarketPlace.Sockets.Interfaces
{
    public interface ISocketServer
    {
        void Start(string ip, int port);
        
        
    }
}