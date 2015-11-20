using System.Threading.Tasks;

namespace MediaPlayerFramework_LiveTree.Windows10.Model
{
    public interface IDataService
    {
        Task<DataItem> GetData();
    }
}