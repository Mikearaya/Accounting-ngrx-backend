/*
 * @CreateTime: Apr 24, 2019 4:50 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 7, 2019 12:17 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Accounting.Application.Interfaces;
using Accounting.Commons;
using Accounting.Domain;
using MediatR;

namespace Accounting.Application.Accounts.Commands.CreateAccount {
    public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, int> {
        private readonly IAccountingDatabaseService _database;

        public CreateAccountCommandHandler (IAccountingDatabaseService database) {
            _database = database;
        }

        public async Task<int> Handle (CreateAccountCommand request, CancellationToken cancellationToken) {
            var currentYear = _database.Accounts.Max (a => a.Year);

            var account = new Account () {
                AccountName = request.accountName,
                Active = request.active,
                CatagoryId = request.catagoryId,
                AccountId = request.accountId,
                Year = currentYear,
                OpeningBalance = request.openingBalance,
                DateAdded = DateTime.Now,
                DateUpdated = DateTime.Now
            };

            if (request.parentAccount != 0) {
                account.ParentAccount = request.parentAccount;
            }

            if (request.costCenterId != 0) {
                account.CostCenterId = request.costCenterId;
            }
            _database.Accounts.Add (account);

            await _database.SaveAsync ();

            return account.Id;
        }
    }
}