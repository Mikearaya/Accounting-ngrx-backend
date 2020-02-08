/*
 * @CreateTime: Apr 24, 2019 5:54 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 7, 2019 1:32 PM
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

namespace Accounting.Application.Accounts.Queries.GetAccount {
    public class GetAccountQueryHandler : IRequestHandler<GetAccountQuery, AccountViewModel> {
        private readonly IAccountingDatabaseService _database;

        public GetAccountQueryHandler (IAccountingDatabaseService database) {
            _database = database;
        }

        public async Task<AccountViewModel> Handle (GetAccountQuery request, CancellationToken cancellationToken) {

            var account = await _database.Accounts
                .Include (x => x.CostCenter)
                .Include (x => x.Catagory)
                .Select (AccountViewModel.Projection)
                .FirstOrDefaultAsync (c => c.Id == request.id);

            if (account == null) {
                throw new NotFoundException ("Account", request.id);
            }

            return account;
        }
    }
}