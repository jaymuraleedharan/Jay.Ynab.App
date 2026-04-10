using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YnabApp.BL.BudgetSettings;

namespace YnabApp.BL.ListAccounts
{
    public static class PersonAccount
    {
        public static AccountData[] GetPersonAccounts(AccountData[] allAccounts, PersonSetting person)
        {
            if (person == null)
                return allAccounts;
            else
                return allAccounts.ToList().Where(a => person.Accounts.Any(aset => aset.Id == a.Id)).ToArray();
        }
    }
}
