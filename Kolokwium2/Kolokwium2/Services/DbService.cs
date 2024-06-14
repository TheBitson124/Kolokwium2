using System.Transactions;
using Kolokwium2.Data;
using Kolokwium2.Models_DTOs;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium2.Services;

public class DbService : IDbService
{
    public CharacterContext _Context;

    public DbService(CharacterContext context)
    {
        _Context = context;
    }

    public async Task<bool> DoesCharacterExist(int characterId)
    {
        return (await _Context.Characters.FindAsync(characterId)) != null;
    }

    public async Task<object> GetCharacter(int characterId)
    {
        var character = await _Context.Characters.Include(c => c.Backpacks).ThenInclude(b => b.ItemNavigation)
            .Include(c => c.CharacterTitles).ThenInclude(t => t.TitleNavigation)
            .FirstOrDefaultAsync(c => c.id == characterId);
        if (character == null)
        {
            throw new Exception();
        }
        var result = new
        {
            character.FirstName,
            character.LastName,
            character.CurrentWeight,
            character.MaxWeight,
            backpackItems = character.Backpacks.Select(b => new
            {
                b.ItemNavigation.Name,
                ItemWeight =  b.ItemNavigation.Weight,
                b.Amount
            }),
            titles = character.CharacterTitles.Select(ct => new
            {
                ct.TitleNavigation.Name,
                ct.AcquiredAt
            })
        };
        return result;
    }

    public async Task<bool> DoesItemExist(int itemId)
    {
        return (await _Context.Items.FindAsync(itemId)) != null;
    }

    public async Task<bool> DoesCharacterHasEnoughFreeWeight(int characterId, List<int> itemsId)
    {
        int item_weight = 0;
        foreach (var itemId in itemsId)
        {
            var item = await _Context.Items.FirstOrDefaultAsync(i => i.id == itemId);
            item_weight += item.Weight;
        }
        var character = _Context.Characters.FindAsync(characterId).Result;
        return (character.MaxWeight > character.CurrentWeight + item_weight);
    }
    public async Task AddItemsToBackpack(int characterId, List<int> itemsId)
    {
        using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
        {
            foreach (var itemId in itemsId)
            {
                var backpack = await _Context.Backpacks.FirstOrDefaultAsync(b=> b.CharacterId == characterId && b.ItemId==itemId);
                if (backpack == null)
                {
                    _Context.Backpacks.Add(new Backpack() { CharacterId = characterId, ItemId = itemId, Amount = 1 });
                }
                else
                {
                    backpack.Amount++;
                    var character = await _Context.Characters.FindAsync(characterId);
                    character.CurrentWeight += backpack.ItemNavigation.Weight;
                }
                await _Context.SaveChangesAsync();
            }
            scope.Complete();
        }
    }

    public async Task<List<object>> GetCharactersItems(int characterId)
    {
        var res = _Context.Backpacks.Where(b => b.CharacterId == characterId).Select(b => new
        {
            b.Amount,
            b.ItemId,
            b.CharacterId
        });
        return res.Cast<object>().ToList();
    }
}