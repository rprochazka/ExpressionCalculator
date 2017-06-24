using System.Collections.Generic;

namespace ExpressionCalculator.Api.DataLayer
{
    public interface IDataProvider<T>
    {
        void Save(T item);

        IEnumerable<T> GetAll();
    }    
}
