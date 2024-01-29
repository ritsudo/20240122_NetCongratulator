using NetCongratulator.Domain;

namespace NetCongratulator.Interfaces;

public interface IUserCardService
{
    IEnumerable<UserCard> GetAll();
    IEnumerable<UserCard> GetWithOffset(int offset, int limit);
    IEnumerable<UserCard> GetWithOffsetAndSort(int offset, int limit, bool isAscending);
    IEnumerable<UserCard> GetAllWithinMonth();
    UserCard? GetById(int id);
    Task<UserCard?> Create(UserCard newUserCard);
    Task<UserCard?> UpdateDataByCard(UserCard editUserCard);
    Task<UserCard?> UpdateUserImage(int id, IFormFile file);
    Task DeleteById(int id);

}