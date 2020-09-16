using System;
using System.Collections.Generic;
using System.Text;

namespace IS.Database.Enums
{
    public enum EnumUserType
    {
        //Store Manager - Super Admin (should be able to perform all of the above)
        SuperAdministrator = 0,

        //IT personnel - Account Maintenance, Add and delete user
        Administrator = 1,

        //Inventory Clerk - Upload of Stocks
        InventoryClerk = 2,

        //Finance Manager - Run reports and extract data in Daily Sales and Stocks database
        FinanceManager = 3,

        //Pharmacy Assistant - Enter Daily Sales"
        PharmacyAssistant =4 ,

        //Enter ongoing stocks
        Member = 5
    }
}
