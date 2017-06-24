using System.Collections.Generic;

namespace ExpressionCalculator.Api.DataLayer
{
    internal class MemoryStoreDataProvider<T> : IDataProvider<T>
    {
        private readonly IList<T> dataStore;
        public MemoryStoreDataProvider()
        {
            dataStore = new List<T>();
        }

        public void Save(T item)
        {
            dataStore.Add(item);
        }

        public IEnumerable<T> GetAll()
        {
            return dataStore;
        }
    }
}