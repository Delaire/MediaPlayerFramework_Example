using System;

namespace MediaPlayerFramework_LiveTree.Model
{
    public interface IDataService
    {
        void GetData(Action<DataItem, Exception> callback);
    }
}