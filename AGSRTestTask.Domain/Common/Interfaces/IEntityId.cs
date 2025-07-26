namespace AGSRTestTask.Domain.Common.Interfaces;

public interface IEntityId<T>
{
   public T Id { get; set; }
}