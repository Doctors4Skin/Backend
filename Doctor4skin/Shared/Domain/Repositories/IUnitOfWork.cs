namespace Doctor4skin.Shared.Domain.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
}