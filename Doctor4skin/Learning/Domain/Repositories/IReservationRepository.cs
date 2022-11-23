using Doctor4skin.Learning.Domain.Models;

namespace Doctor4skin.Learning.Domain.Repositories;

public interface IReservationRepository
{
    Task<IEnumerable<Reservation>> ListAsync();

}
