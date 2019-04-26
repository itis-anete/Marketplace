using System.Threading.Tasks;

namespace Marketplace.Sockets.Interfaces
{
    public interface ISocketServer
    {
        void Start(string ip, int port);
        
        
    }
}