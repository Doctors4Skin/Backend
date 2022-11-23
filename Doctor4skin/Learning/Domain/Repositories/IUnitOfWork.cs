namespace Doctor4skin.Learning.Domain.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
}