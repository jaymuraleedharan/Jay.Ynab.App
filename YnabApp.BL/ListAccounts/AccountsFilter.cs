using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YnabApp.BL.ListAccounts
{
    public class AccountsFilter
    {
        private string[] _jayAccountIds = new string[] 
        {
            "3cfcdb24-37e5-4738-acf9-5adc567614d8", //J_CHS_CHK (9895)
            "0bdada36-9db3-46a2-921f-42d19ce106e9", //J_CHS_CHK2 (2278)
            "4c9d6116-3abb-4c7a-8ab7-9bd82d0fe423", //J_CHS_SAV (2414)
            "68c525f3-ae0b-4c39-9aef-34bb574f27e3", //J_CHS_CRD (5601)
            "77233f3c-7258-40e5-b5b9-b247f87f98a5", //J_LGX_CHK (5700)
            "c2f7e164-97f8-4ecb-97d5-46a65c749205", //J_LGX_SAV (5700)
            "5911e065-21ba-4275-9634-240f07a4ac17", //J_LGX_CRD (5700)
            "78cb347d-14e5-4a50-ba4e-fa4ca91a2461", //J_LGX_CD
            "f6f763c1-9a1f-42a7-a4ab-182927880ab1", //J_BAC_HSA (0361)
            "f3f36e34-053a-4aab-a532-2aab0f2deab7", //J_CSB_NRO
            "9a514d8b-2565-4435-a4af-6124b32a36c1", //J_FTD_STK
            "f0b7eaa8-7bf0-434f-8653-e211d93786f5", //J_BAC_INV
            "4480b204-ce5c-47bd-ba78-27df76446e6e", //HRA
            //"128cc0ab-3cfb-49ec-a067-4d529907a9ef", //Mortgage
            "7020baec-4691-42cf-b855-8b29f6808c54" //Lending
        };

        public AccountData[] Filter(AccountData[] allAccountData, string accountOwner)
        {
            if (accountOwner == "JAY")
                return allAccountData.Where(a => _jayAccountIds.Contains(a.Id)).ToArray();
            else if (accountOwner == "SHAR")
                return allAccountData.Where(a => (_jayAccountIds.Contains(a.Id) == false) && a.Id != "128cc0ab-3cfb-49ec-a067-4d529907a9ef").ToArray();
            else
                return allAccountData;
        }
    }
}
