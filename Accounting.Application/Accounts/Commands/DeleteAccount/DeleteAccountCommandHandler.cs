/*
 * @CreateTime: Apr 24, 2019 5:48 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 7, 2019 4:47 PM
 * @Description: Modify Here, Please 
 */
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Accounting.Application.Accounts.Models;
using Accounting.Application.Exceptions;
using Accounting.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Accounting.Application.Accounts.Commands.DeleteAccount {
    public class DeleteAccountCommandHandler : IRequestHandler<DeleteAccountCommand, Unit> {
        private readonly IAccountingDatabaseService _database;

        public DeleteAccountCommandHandler (IAccountingDatabaseService database) {
            _database = database;
        }

        public async Task<Unit> Handle (DeleteAccountCommand request, CancellationToken cancellationToken) {
            var account = await _database.Accounts
                .FindAsync (request.Id);

            if (account == null) {
                throw new NotFoundException ("Account", request.Id);
            }

            _database.Accounts.Remove (account);

            await _database.SaveAsync ();

            return Unit.Value;
        }
    }
}