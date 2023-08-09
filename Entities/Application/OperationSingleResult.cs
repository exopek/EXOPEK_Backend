namespace EXOPEK_Backend.Entities.Application;

public class OperationSingleResult<T> : OperationResult
{
    public T Item { get; set; }
}