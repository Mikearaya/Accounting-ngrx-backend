/*
 * @CreateTime: May 14, 2019 12:39 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 14, 2019 1:15 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Accounting.Application.AccountTypes.Models;
using Accounting.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Accounting.Application.AccountTypes.Queries.GetAccountTypeList {
    public class GetAccountTypeIndexQueryHandler : IRequestHandler<GetAccountTypeIndexQuery, IEnumerable<AccountTypeIndexView>> {
        private readonly IAccountingDatabaseService _database;

        public GetAccountTypeIndexQueryHandler (IAccountingDatabaseService database) {
            _database = database;
        }

        public async Task<IEnumerable<AccountTypeIndexView>> Handle (GetAccountTypeIndexQuery request, CancellationToken cancellationToken) {
            var accountTypeIndex = _database.AccountType
                .Where (a => a.TypeOfNavigation != null)
                .Select (AccountTypeIndexView.Projection);

            return await accountTypeIndex.ToListAsync ();
        }
    }
}