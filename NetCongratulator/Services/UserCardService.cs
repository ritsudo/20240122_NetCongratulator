using NetCongratulator.Models;
using NetCongratulator.Data;
using Microsoft.EntityFrameworkCore;

namespace NetCongratulator.Services;

public class UserCardService
{
    private readonly UserCardContext _context;
    public UserCardService(UserCardContext context)
    {
        _context = context;
    }

    public IEnumerable<UserCard> GetAll()
    {
        return _context.UserCards
            .AsNoTracking()
            .ToList();
    }

    public UserCard? GetById(int id)
    {
        return _context.UserCards
            .Include(u => u.Avatar)
            .AsNoTracking()
            .SingleOrDefault(u => u.Id == id);
    }

    public UserCard? GetNearestByDate(DateTime dateTime)
    {
        throw new NotImplementedException();
    }

    public UserCard? Create(UserCard newUserCard)
    {
        newUserCard.CreatedAt = DateTime.Now;
        _context.UserCards.Add(newUserCard);
        _context.SaveChanges();

        return newUserCard;
    }

    public void UpdateData(int id, string UserCardName, string UserCardSurname, DateTime UserCardDateTime)
    {
        throw new NotImplementedException();
    }

    public void UpdateDataByCard(UserCard editUserCard)
    {
        var userCardToUpdate = _context.UserCards.Find(editUserCard.Id);

        if (userCardToUpdate is null) {
            throw new InvalidOperationException("User Card with given ID does not exist");
        }

        userCardToUpdate.Avatar = editUserCard.Avatar;
        userCardToUpdate.FirstName = editUserCard.FirstName;
        userCardToUpdate.LastName = editUserCard.LastName;
        userCardToUpdate.BirthdayDate = editUserCard.BirthdayDate;

        userCardToUpdate.UpdatedAt = DateTime.Now;

        _context.SaveChanges();
    }

    public void UpdateAvatar(int userCardId, int avatarId)
    {
        var userCardToUpdate = _context.UserCards.Find(userCardId);
        var avatarToAdd = _context.Avatars.Find(avatarId);

        if (userCardToUpdate is null) {
            throw new InvalidOperationException("User Card does not exist");
        }

        if (avatarToAdd is null) {
            throw new InvalidOperationException("Avatar ID incorrect or does not exist");
        }

        userCardToUpdate.Avatar = avatarToAdd;
        _context.SaveChanges();
    }

    public void DeleteById(int id)
    {
        var userCardToDelete = _context.UserCards.Find(id);
        if (userCardToDelete is not null)
        {
            _context.UserCards.Remove(userCardToDelete);
            _context.SaveChanges();
        } else {
            throw new InvalidOperationException("User Card to delete does not exist");
        }
    }
}