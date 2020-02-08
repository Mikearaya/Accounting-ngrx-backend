/*
 * @CreateTime: May 1, 2019 3:07 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 14, 2019 1:18 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using Accounting.Domain;

namespace Accounting.Persistance {
    public class AccountingDatabaseInitializer {

        private readonly Dictionary<int, AccountCatagory> AccountCatagorys = new Dictionary<int, AccountCatagory> ();
        private readonly Dictionary<int, AccountType> AccountType = new Dictionary<int, AccountType> ();

        public static void Initialize (AccountingDatabaseService context) {
            var initializer = new AccountingDatabaseInitializer ();
            initializer.SeedEverything (context);
        }

        public void SeedEverything (AccountingDatabaseService context) {

            context.Database.EnsureDeleted ();
            context.Database.EnsureCreated ();

            if (context.AccountType.Any ()) {
                return; // Db has been seeded
            }

            SeedAccountType (context);
            SeedSystemLookup (context);
            SeedLedgerEntries (context);

            context.SaveChanges ();

        }

        public void SeedAccountType (AccountingDatabaseService database) {
            var accountType = new [] {
                new AccountType () { Id = 10, Type = "Asset", TypeOf = 0 },
                new AccountType () { Id = 12, Type = "Liability", TypeOf = 0 },
                new AccountType () { Id = 13, Type = "Capital", TypeOf = 0 },
                new AccountType () { Id = 14, Type = "Revenue", TypeOf = 0 },
                new AccountType () {
                Id = 15,
                Type = "Expence", TypeOf = 0,
                AccountCatagory = new [] {
                new AccountCatagory () { Id = 2, Catagory = "Cash Account", DateAdded = DateTime.Now, DateUpdated = DateTime.Now },
                new AccountCatagory () { Id = 3, Catagory = "COGE", DateAdded = DateTime.Now, DateUpdated = DateTime.Now },
                }
                },

            };

            database.AccountType.AddRange (accountType);

        }

        public void SeedSystemLookup (AccountingDatabaseService database) {

        }

        public void SeedLedgerEntries (AccountingDatabaseService database) {

            database.Save ();
        }

    }
}