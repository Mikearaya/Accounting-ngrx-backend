/*
 * @CreateTime: Apr 24, 2019 6:16 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jun 9, 2019 3:04 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Accounting.Application.Accounts.Models;
using Accounting.Application.Interfaces;
using Accounting.Application.Models;
using Accounting.Commons.QueryHelpers;
using Accounting.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Accounting.Application.Accounts.Queries.GetAccountsList {
    public class GetAccountsListQueryHandler : IRequestHandler<GetAccountsListQuery, FilterResultModel<AccountViewModel>> {
        private readonly IAccountingDatabaseService _database;

        public GetAccountsListQueryHandler (IAccountingDatabaseService database) {
            _database = database;
        }

        public Task<FilterResultModel<AccountViewModel>> Handle (GetAccountsListQuery request, CancellationToken cancellationToken) {

            var sortBy = request.SortBy.Trim () != "" ? request.SortBy : "AccountName";
            var sortDirection = (request.SortDirection.ToUpper () == "DESCENDING") ? true : false;

            FilterResultModel<AccountViewModel> result = new FilterResultModel<AccountViewModel> ();
            var accountList = _database.Accounts
                .Where (a => a.Year == request.Year)
                .Select (AccountViewModel.Projection)

                .Select (DynamicQueryHelper.GenerateSelectedColumns<AccountViewModel> (request.SelectedColumns))
                .AsQueryable ();

            if (request.Filter.Count () > 0) {
                accountList = accountList
                    .Where (DynamicQueryHelper
                        .BuildWhere<AccountViewModel> (request.Filter)).AsQueryable ();
            }

            result.Count = accountList.Count ();

            var PageSize = (request.PageSize == 0) ? result.Count : request.PageSize;
            var PageNumber = (request.PageSize == 0) ? 1 : request.PageNumber;

            result.Items = accountList.OrderBy (sortBy, sortDirection)
                .Skip (PageNumber - 1)
                .Take (PageSize)
                .ToList ();

            return Task.FromResult<FilterResultModel<AccountViewModel>> (result);
        }
    }

}