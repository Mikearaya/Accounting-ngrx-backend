/*
 * @CreateTime: Jul 16, 2019 8:08 AM 
 * @Author:  Mikael Araya 
 * @Contact: MikaelAraya12@gmail.com 
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jul 16, 2019 8:19 AM
 * @Description: Modify Here, Please  
 */
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Accounting.Application.Exceptions;
using Accounting.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Accounting.Application.Accounts.Commands.DeleteAccount {
    public class DeleteAccoutingYearCommandHandler : IRequestHandler<DeleteAccoutingYearCommand, Unit> {
        private readonly IAccountingDatabaseService _database;

        public DeleteAccoutingYearCommandHandler (IAccountingDatabaseService dataase) {
            _database = dataase;
        }

        public async Task<Unit> Handle (DeleteAccoutingYearCommand request, CancellationToken cancellationToken) {
            var lastYear = await _database.Accounts.MaxAsync (b => b.Year);

            if (await _database.Accounts.Where (a => a.Year == lastYear).AnyAsync (l => l.LedgerEntry.Count () != 0)) {
                throw new NotFoundException ("Account Has entries made", 3);
            }

            var accounts = await _database.Accounts.Where (a => a.Year == lastYear).ToListAsync ();

            _database.Accounts.RemoveRange (accounts);

            await _database.SaveAsync ();

            return Unit.Value;
        }
    }
}