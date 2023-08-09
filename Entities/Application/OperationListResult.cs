namespace EXOPEK_Backend.Entities.Application;

public class OperationListResult<T> : OperationResult
{
    public IEnumerable<T> Items { get; set; }
}
