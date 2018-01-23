using System.Collections.Generic;

namespace Employee.Business.Mappers
{
    public interface IMapper<in TInput, out TOutput>
    {
        TOutput Map(TInput input);
        IEnumerable<TOutput> Map(IEnumerable<TInput> inputs);
    }
}
