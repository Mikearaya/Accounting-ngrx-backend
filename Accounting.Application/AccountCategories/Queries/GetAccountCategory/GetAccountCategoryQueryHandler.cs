/*
 * @CreateTime: Apr 30, 2019 2:05 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 1, 2019 9:31 AM
 * @Description: Modify Here, Please 
 */
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Accounting.Application.AccountCategories.Models;
using Accounting.Application.Exceptions;
using Accounting.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Accounting.Application.AccountCategories.Queries.GetAccountCategory {
    public class GetAccountCategoryQueryHandler : IRequestHandler<GetAccountCategoryQuery, AccountCategoryView> {
        private readonly IAccountingDatabaseService _database;

        public GetAccountCategoryQueryHandler (IAccountingDatabaseService database) {
            _database = database;
        }

        public async Task<AccountCategoryView> Handle (GetAccountCategoryQuery request, CancellationToken cancellationToken) {
            var accountCategory = await _database.AccountCatagory
                .Select (AccountCategoryView.Projection)
                .FirstOrDefaultAsync (c => c.Id == request.id);

            if (accountCategory == null) {
                throw new NotFoundException ("Account category", request.id);
            }

            return accountCategory;
        }
    }
}