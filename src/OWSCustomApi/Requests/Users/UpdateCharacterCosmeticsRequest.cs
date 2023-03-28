using OWSData.Models.Composites;
using OWSData.Models.StoredProcs;
using OWSData.Repositories.Interfaces;
using OWSShared.Interfaces;

namespace OWSCustomApi.Requests.Users
{

    public class UpdateCharacterCosmeticsRequest
    {
        public AddOrUpdateCustomCharacterData addOrUpdateCustomCharacterData { get; set; }

        private Guid customerGUID;
        private ICharactersRepository charactersRepository;

        public void SetData(IHeaderCustomerGUID customerGuid, ICharactersRepository charactersRepository)
        {
            customerGUID = customerGuid.CustomerGUID;
            this.charactersRepository = charactersRepository;
        }

        public async Task Handle()
        {
            await charactersRepository.AddOrUpdateCustomCharacterData(customerGUID, addOrUpdateCustomCharacterData);
        }
    }
}

