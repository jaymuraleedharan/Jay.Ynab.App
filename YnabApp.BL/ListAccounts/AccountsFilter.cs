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
            "3cfcdb24-37e5-4738-acf9-5adc567614d8", //Chase Checking
            "4c9d6116-3abb-4c7a-8ab7-9bd82d0fe423", //Chase Savings
            "68c525f3-ae0b-4c39-9aef-34bb574f27e3", //Chase Credit
            "77233f3c-7258-40e5-b5b9-b247f87f98a5", //Logix Checking
            "c2f7e164-97f8-4ecb-97d5-46a65c749205", //Logix Savings
            "5911e065-21ba-4275-9634-240f07a4ac17", //Logix Credit
            "f6f763c1-9a1f-42a7-a4ab-182927880ab1", //HSA
            "9a514d8b-2565-4435-a4af-6124b32a36c1", //Firstrade
            "4480b204-ce5c-47bd-ba78-27df76446e6e", //HRA
            "128cc0ab-3cfb-49ec-a067-4d529907a9ef", //Mortgage
            "7020baec-4691-42cf-b855-8b29f6808c54" //Lending
        };

        public AccountData[] Filter(AccountData[] allAccountData, string accountOwner)
        {
            if (accountOwner == "JAY")
                return allAccountData.Where(a => _jayAccountIds.Contains(a.Id)).ToArray();
            else if (accountOwner == "SHAR")
                return allAccountData.Where(a => _jayAccountIds.Contains(a.Id) == false).ToArray();
            else
                return allAccountData;
        }
    }
}
