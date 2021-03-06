/*
 * @CreateTime: May 14, 2019 11:12 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 14, 2019 1:47 PM
 * @Description: Modify Here, Please 
 */
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Accounting.Application.AccountTypes.Models;
using Accounting.Application.Exceptions;
using Accounting.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Accounting.Application.AccountTypes.Queries.GetAccountType {
    public class GetAccountTypeQueryHandler : IRequestHandler<GetAccountTypeQuery, AccountTypeView> {
        private readonly IAccountingDatabaseService _database;

        public GetAccountTypeQueryHandler (IAccountingDatabaseService database) {
            _database = database;
        }

        public async Task<AccountTypeView> Handle (GetAccountTypeQuery request, CancellationToken cancellationToken) {
            var accountType = await _database.AccountType
                .Select (AccountTypeView.Projection)
                .FirstOrDefaultAsync (a => a.id == request.Id && a.isTypeOf != 0);

            if (accountType == null) {
                throw new NotFoundException ("Account Type", request.Id);
            }

            return accountType;
        }
    }
}