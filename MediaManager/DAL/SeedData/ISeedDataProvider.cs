using System.Collections.Generic;

namespace MediaManager.DAL
{
    public interface ISeedDataProvider
    {
        IEnumerable<seedDataModel> GetData();
    }
}