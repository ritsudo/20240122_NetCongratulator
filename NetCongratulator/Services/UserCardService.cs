using NetCongratulator.Domain;
using NetCongratulator.Infrastructure;
using Microsoft.EntityFrameworkCore;
using NetCongratulator.Interfaces;

namespace NetCongratulator.Services;

public class UserCardService(NetCongratulatorDbContext context, ImageService imageService) : IUserCardService
{
    private readonly NetCongratulatorDbContext _context = context;
    private readonly ImageService _imageService = imageService;

    public IEnumerable<UserCard> GetAll()
    {
        return [.. _context.UserCards.AsNoTracking()];
    }

    public IEnumerable<UserCard> GetWithOffset(int offset, int limit)
    {
        return [.. _context.UserCards
            .Skip(offset)
            .Take(limit)
            .AsNoTracking()];
    }

    public IEnumerable<UserCard> GetWithOffsetAndSort(int offset, int limit, bool isAscending)
    {
        var query = _context.UserCards
            .Skip(offset)
            .Take(limit)
            .AsNoTracking();

        if (isAscending)
        {
            query = query.OrderBy(e => e.CreatedAt);
        }
        else
        {
            query = query.OrderByDescending(e => e.CreatedAt);
        }

        return [.. query];
    }

    public IEnumerable<UserCard> GetAllWithinMonth()
    {
        int currentDayOfMonth = DateTime.Now.Day;
        int currentMonth = DateTime.Now.Month;
        int nextMonth = DateTime.Now.Month+1;

        if (nextMonth > 12)
        {
            nextMonth = 1;
        }

        var query = _context.UserCards
            .Where(e => e.BirthdayDate.HasValue && 
            ((e.BirthdayDate.Value.Month == currentMonth && e.BirthdayDate.Value.Day >= currentDayOfMonth) || e.BirthdayDate.Value.Month == nextMonth))
            .OrderBy(e => e.BirthdayDate.Value.Month)
            .ThenBy(e => e.BirthdayDate.Value.Day);

        return [.. query];
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

        userCardToUpdate.FirstName = editUserCard.FirstName;
        userCardToUpdate.LastName = editUserCard.LastName;
        userCardToUpdate.BirthdayDate = editUserCard.BirthdayDate;

        userCardToUpdate.UpdatedAt = DateTime.Now;

        await _context.SaveChangesAsync();

        return userCardToUpdate;
    }

    public async Task<UserCard?> UpdateUserImage(int id, IFormFile file)
    {
        var userCardToUpdate = _context.UserCards.Find(id) ?? throw new InvalidOperationException("User Card with given ID does not exist");

        try
        {
            var image = await _imageService.UploadImage(file);
            if (image is not null)
            {
                if (image.FilePath is not null)
                {
                    userCardToUpdate.ImageName = image.FilePath;
                    await _context.SaveChangesAsync();
                    return userCardToUpdate;
                }
            }
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("Image error: " + ex.Message);
        }

        throw new InvalidOperationException("User not found");
    }

    public async Task DeleteById(int id)
    {
        var userCardToDelete = _context.UserCards.Find(id);
        if (userCardToDelete is not null)
        {
            _context.UserCards.Remove(userCardToDelete);
            await _context.SaveChangesAsync();
        }
        else
        {
            throw new InvalidOperationException("User Card to delete does not exist");
        }
    }
}