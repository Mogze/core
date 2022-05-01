using System.Threading.Tasks;

namespace Mogze.Core.Services
{
    public interface IService
    {
        Task Initialize();
        void Pause(bool isPaused);
        void Close();
    }
}