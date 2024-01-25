using NetCongratulator.Models;
using NetCongratulator.Data;
using Microsoft.EntityFrameworkCore;

namespace NetCongratulator.Services;

public class UserCardService(UserCardContext context)
{
    private readonly UserCardContext _context = context;

    public IEnumerable<UserCard> GetAll()
    {
        return _context.UserCards
            .AsNoTracking()
            .ToList();
    }

    public UserCard? GetById(int id)
    {
        return _context.UserCards
            .AsNoTracking()
            .SingleOrDefault(u => u.Id == id);
    }

    public async Task<UserCard?> Create(UserCard newUserCard)
    {
        newUserCard.CreatedAt = DateTime.Now;
        _context.UserCards.Add(newUserCard);
        await _context.SaveChangesAsync();

        return newUserCard;
    }

    public async Task<UserCard?> UpdateDataByCard(UserCard editUserCard)
    {
        var userCardToUpdate = _context.UserCards.Find(editUserCard.Id) ?? throw new InvalidOperationException("User Card with given ID does not exist");

        userCardToUpdate.ImageName = editUserCard.ImageName;
        userCardToUpdate.FirstName = editUserCard.FirstName;
        userCardToUpdate.LastName = editUserCard.LastName;
        userCardToUpdate.BirthdayDate = editUserCard.BirthdayDate;

        userCardToUpdate.UpdatedAt = DateTime.Now;

        await _context.SaveChangesAsync();

        return userCardToUpdate;
    }

    public async Task DeleteById(int id)
    {
        var userCardToDelete = _context.UserCards.Find(id);
        if (userCardToDelete is not null)
        {
            _context.UserCards.Remove(userCardToDelete);
            await _context.SaveChangesAsync();
        } else {
            throw new InvalidOperationException("User Card to delete does not exist");
        }
    }
}