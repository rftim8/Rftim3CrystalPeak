using Rftim3Convoy.Data.Services.Algorithms.Searching.Binary;

namespace Rftim3Convoy.Data.Services.Algorithms
{
    public sealed class ServiceAlgorithms(IBinarySearch binarySearch)
    {
        private readonly IBinarySearch binarySearch = binarySearch;

        public async void ServiceAlgorithmsExecute()
        {
            await binarySearch.BinarySearchTask0();
        }
    }
}
