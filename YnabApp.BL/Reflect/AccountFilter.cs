using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YnabApp.BL.Reflect
{
    public static class AccountFilter
    {
        private static List<AcountDefinitionData> JayAccounts = new List<AcountDefinitionData>();
        private static List<AcountDefinitionData> SharAccounts = new List<AcountDefinitionData>();

        static AccountFilter()
        {
            JayAccounts.Add(new("0bdada36-9db3-46a2-921f-42d19ce106e9", "J_CHS_CHK2 (2278)", "checking"));
            JayAccounts.Add(new("4c9d6116-3abb-4c7a-8ab7-9bd82d0fe423", "J_CHS_SAV (2414)", "savings"));
            JayAccounts.Add(new("68c525f3-ae0b-4c39-9aef-34bb574f27e3", "J_CHS_CRD (5601)", "creditCard"));
            JayAccounts.Add(new("77233f3c-7258-40e5-b5b9-b247f87f98a5", "J_LGX_CHK (5700)", "checking"));
            JayAccounts.Add(new("c2f7e164-97f8-4ecb-97d5-46a65c749205", "J_LGX_SAV (5700)", "savings"));
            JayAccounts.Add(new("5911e065-21ba-4275-9634-240f07a4ac17", "J_LGX_CRD (5700)", "creditCard"));
            JayAccounts.Add(new("f6f763c1-9a1f-42a7-a4ab-182927880ab1", "J_BAC_HSA (0361)", "savings"));
            JayAccounts.Add(new("f3f36e34-053a-4aab-a532-2aab0f2deab7", "J_CSB_NRO", "savings"));


            SharAccounts.Add(new("cc2abf9d-2387-44b3-9311-18fb340d0937", "S_CHS_CHK (4737)", "checking"));
            SharAccounts.Add(new("c999b143-a106-4436-bcf7-42a19f57952f", "S_CHS_SAV (0727)", "savings"));
            SharAccounts.Add(new("f63ec995-95ac-4e21-864f-3012ad14e7d0", "S_CHS_CRD (9671)", "creditCard"));
            SharAccounts.Add(new("a4b2c93a-408b-47f8-a3fa-c4d1501eb1a6", "S_AMX_CHK (1796)", "checking"));
            SharAccounts.Add(new("610f43af-4513-4510-b607-37f36a46fee8", "S_AMX_SAV", "savings"));
            SharAccounts.Add(new("ffe6bffd-40e7-4c14-a41f-7c08368db020", "S_AMX_CRD ()", "creditCard"));
            SharAccounts.Add(new("b4f660fc-dfc8-483c-aa66-df75449dc606", "S_AMX_CD", "savings"));
            SharAccounts.Add(new("82b37913-ccc6-4e4d-a73e-0c96ac42e6a8", "S_HEQ_HSA (1993)", "savings"));
        }

        public static bool IsPersonAccount(string accountID, Person person)
        {
            switch (person)
            {
                case Person.Jay:
                    return JayAccounts.Exists(a => a.Id == accountID);
                case Person.Shar:
                    return SharAccounts.Exists(a => a.Id == accountID);
                default:
                    return true;
            }
        }
        /*
            {
                "id": "0bdada36-9db3-46a2-921f-42d19ce106e9",
                "name": "J_CHS_CHK2 (2278)",
                "type": "checking",
            },
            {
                "id": "4c9d6116-3abb-4c7a-8ab7-9bd82d0fe423",
                "name": "J_CHS_SAV (2414)",
                "type": "savings",
            },
            {
                "id": "68c525f3-ae0b-4c39-9aef-34bb574f27e3",
                "name": "J_CHS_CRD (5601)",
                "type": "creditCard",
            },
            {
                "id": "77233f3c-7258-40e5-b5b9-b247f87f98a5",
                "name": "J_LGX_CHK (5700)",
                "type": "checking",
            },
            {
                "id": "c2f7e164-97f8-4ecb-97d5-46a65c749205",
                "name": "J_LGX_SAV (5700)",
                "type": "savings",
            },
            {
                "id": "5911e065-21ba-4275-9634-240f07a4ac17",
                "name": "J_LGX_CRD (5700)",
                "type": "creditCard",
            },
            {
                "id": "78cb347d-14e5-4a50-ba4e-fa4ca91a2461",
                "name": "J_LGX_CD",
                "type": "savings",
            },
            {
                "id": "f6f763c1-9a1f-42a7-a4ab-182927880ab1",
                "name": "J_BAC_HSA (0361)",
                "type": "savings",
            },
            {
                "id": "f3f36e34-053a-4aab-a532-2aab0f2deab7",
                "name": "J_CSB_NRO",
                "type": "savings",
            },
            {
                "id": "cc2abf9d-2387-44b3-9311-18fb340d0937",
                "name": "S_CHS_CHK (4737)",
                "type": "checking",
            },
            {
                "id": "c999b143-a106-4436-bcf7-42a19f57952f",
                "name": "S_CHS_SAV (0727)",
                "type": "savings",
            },
            {
                "id": "f63ec995-95ac-4e21-864f-3012ad14e7d0",
                "name": "S_CHS_CRD (9671)",
                "type": "creditCard",
            },
            {
                "id": "a4b2c93a-408b-47f8-a3fa-c4d1501eb1a6",
                "name": "S_AMX_CHK (1796)",
                "type": "checking",
            },
            {
                "id": "610f43af-4513-4510-b607-37f36a46fee8",
                "name": "S_AMX_SAV",
                "type": "savings",
            },
            {
                "id": "ffe6bffd-40e7-4c14-a41f-7c08368db020",
                "name": "S_AMX_CRD ()",
                "type": "creditCard",
            },
            {
                "id": "f43e76b8-8704-4e4a-af14-e4bc7029f6ff",
                "name": "Cash",
                "type": "cash",
            },
            {
                "id": "9a514d8b-2565-4435-a4af-6124b32a36c1",
                "name": "J_FTD_STK",
                "type": "otherAsset",
            },
            {
                "id": "f0b7eaa8-7bf0-434f-8653-e211d93786f5",
                "name": "J_BAC_INV",
                "type": "otherAsset",
            },
            {
                "id": "927d915d-35fe-4eaf-b27d-3df5d8a3f387",
                "name": "Jay IRA",
                "type": "otherAsset",
            },
            {
                "id": "4a98b191-eeba-4870-b008-6c851cfbecd4",
                "name": "S_CHS_BRK (1727)",
                "type": "otherAsset",
                "on_budget": false,
            },
            {
                "id": "70f30c79-40be-44d3-bbac-b9889d2525bc",
                "name": "S_CHS_STK (6251)",
                "type": "otherAsset",
            },
            {
                "id": "128cc0ab-3cfb-49ec-a067-4d529907a9ef",
                "name": "Mortgage",
                "type": "otherLiability",
            },
            {
                "id": "7020baec-4691-42cf-b855-8b29f6808c54",
                "name": "Lending",
                "type": "otherAsset",
                "on_budget": false,
            },
            {
                "id": "b4f660fc-dfc8-483c-aa66-df75449dc606",
                "name": "S_AMX_CD",
                "type": "savings",
            },
            {
                "id": "82b37913-ccc6-4e4d-a73e-0c96ac42e6a8",
                "name": "S_HEQ_HSA (1993)",
                "type": "savings",
            },
            {
                "id": "9841acee-6917-4610-8208-bda6fddb213b",
                "name": "Shop\\Gift Cards",
                "type": "checking",
            }
         */


    }

    public record AcountDefinitionData(string Id, string Name, string Type);

    public enum Person
    {
        All = 0,
        Jay = 1,
        Shar = 2
    }
}
