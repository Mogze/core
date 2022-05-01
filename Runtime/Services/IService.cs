using System.Threading.Tasks;

namespace Mogze.Core.Services
{
    public interface IService
    {
        Task Initialize();
        /// <summary>
        /// To be paired with OnApplicationPause event in Unity.
        /// </summary>
        void Pause(bool isPaused);
        void Close();
    }
}