/*
 * @CreateTime: Apr 24, 2019 5:49 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 3, 2019 9:00 AM
 * @Description: Modify Here, Please 
 */
using System;
using System.Threading;
using System.Threading.Tasks;
using Accounting.Application.Exceptions;
using Accounting.Application.Interfaces;
using MediatR;

namespace Accounting.Application.Accounts.Commands.UpdateAccount {
    public class UpdateAccountCommandHandler : IRequestHandler<UpdateAccountCommand, Unit> {
        private readonly IAccountingDatabaseService _database;

        public UpdateAccountCommandHandler (IAccountingDatabaseService database) {
            _database = database;
        }

        public async Task<Unit> Handle (UpdateAccountCommand request, CancellationToken cancellationToken) {

            var account = await _database.Accounts.FindAsync (request.id);

            if (account == null) {
                throw new NotFoundException ("Account", request.id);
            }

            account.AccountName = request.accountName;
            account.AccountId = request.accountId;
            account.Active = request.active;
            account.ParentAccount = request.parentAccount;
            account.DateUpdated = DateTime.Now;

            if (request.parentAccount != 0) {
                account.ParentAccount = request.parentAccount;
            }

            _database.Accounts.Update (account);

            await _database.SaveAsync ();

            return Unit.Value;
        }

    }
}