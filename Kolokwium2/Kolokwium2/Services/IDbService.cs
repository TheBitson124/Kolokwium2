namespace Kolokwium2.Services;

public interface IDbService
{
    Task<bool> DoesCharacterExist(int characterId);
    Task<object> GetCharacter(int characterId);
    Task<bool> DoesItemExist(int itemId);
    Task<bool> DoesCharacterHasEnoughFreeWeight(int characterId, List<int> itemsId);
    Task AddItemsToBackpack(int characterId, List<int> itemsId);
    Task<List<object>> GetCharactersItems(int characterId);
}