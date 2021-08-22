﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OWSData.Models.StoredProcs;
using OWSData.Models.Tables;

namespace OWSData.Repositories.Interfaces
{
    public interface ICharactersRepository
    {
        Task AddCharacterToMapInstanceByCharName(Guid customerGUID, string characterName, int mapInstanceID);
        Task AddOrUpdateCustomCharacterData(Guid customerGUID, AddOrUpdateCustomCharacterData addOrUpdateCustomCharacterData);
        Task<CheckMapInstanceStatus> CheckMapInstanceStatus(Guid customerGUID, int mapInstanceID);
        Task<GetCharByCharName> GetCharByCharName(Guid customerGUID, string characterName);
        Task<CustomCharacterData> GetCustomCharacterData(Guid customerGUID, string characterName);
        Task<JoinMapByCharName> JoinMapByCharName(Guid customerGUID, string characterName, string zoneName, int playerGroupType);        
        Task UpdateCharacterStats(UpdateCharacterStats updateCharacterStats);
        Task UpdatePosition(Guid customerGUID, string playerName, string mapName, float X, float Y, float Z, float RX, float RY, float RZ);
    }
}