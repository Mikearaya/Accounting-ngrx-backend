/*
 * @CreateTime: Apr 30, 2019 2:00 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 4, 2019 7:58 AM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using Accounting.Application.AccountCategories.Models;
using Accounting.Application.Models;
using Accounting.Commons.QueryHelpers;
using MediatR;

namespace Accounting.Application.AccountCategories.Queries.GetAccountCategoryList {
    public class GetAccountCategoryListQuery : ApiQueryString, IRequest<FilterResultModel<AccountCategoryView>> {

    }
}