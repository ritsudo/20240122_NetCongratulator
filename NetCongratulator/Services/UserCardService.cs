using NetCongratulator.Models;

namespace NetCongratulator.Services;

public class UserCardService
{
    public UserCardService()
    {
        
    }

    public IEnumerable<UserCard> GetAll()
    {
        throw new NotImplementedException();
    }

    public UserCard? GetById(int id)
    {
        throw new NotImplementedException();
    }

    public UserCard? GetNearestByDate(DateTime dateTime)
    {
        throw new NotImplementedException();
    }

    public UserCard? Create(UserCard newUserCard)
    {
        throw new NotImplementedException();
    }

    public void UpdateData(int UserCardId, string UserCardName, string UserCardSurname, DateTime UserCardDateTime)
    {
        throw new NotImplementedException();
    }

    public void UpdateAvatar(int UserCardId, int AvatarId)
    {
        throw new NotImplementedException();
    }

    public void DeleteById(int id)
    {
        throw new NotImplementedException();
    }
}