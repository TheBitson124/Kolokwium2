using Kolokwium2.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium2.Controllers;
[ApiController]
public class CharactersController :ControllerBase
{
    public IDbService _Service;

    public CharactersController(IDbService service)
    {
        _Service = service;
    }

    [HttpGet]
    [Route("api/characters/{characterId:int}")]
    public async Task<IActionResult> GetCharacters(int characterId)
    {
        if (!await _Service.DoesCharacterExist(characterId))
        {
            return NotFound($"Character with id: {characterId} not found");
        }

        var result = await _Service.GetCharacter(characterId);
        return Ok(result);

    }

    [HttpPost]
    [Route("api/characters/{characterId:int}/backpacks")]
    public async Task<IActionResult> AddItems(int characterId, List<int> itemsId)
    {
        foreach (var itemId in itemsId)
        {
            if (!await _Service.DoesItemExist(itemId))
            {
                return NotFound($"Item with id : {itemId} not found");
            }
        }
        if (!await _Service.DoesCharacterExist(characterId))
        {
            return NotFound($"Character with id: {characterId} not found");
        }
        if (!await _Service.DoesCharacterHasEnoughFreeWeight(characterId, itemsId))
        {
            return NotFound($"Character with id: {characterId} doesnt have enough free room");
        }
        
        await _Service.AddItemsToBackpack(characterId, itemsId);
        
        var result = await _Service.GetCharactersItems(characterId);
        
        return Ok(result);
    }
    
}