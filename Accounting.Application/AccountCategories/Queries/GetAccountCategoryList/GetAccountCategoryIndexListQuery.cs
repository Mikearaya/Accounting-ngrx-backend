/*
 * @CreateTime: May 4, 2019 10:04 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 4, 2019 10:11 AM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using Accounting.Application.AccountCategories.Models;
using Accounting.Commons.QueryHelpers;
using MediatR;

namespace Accounting.Application.AccountCategories.Queries.GetAccountCategoryList {
    public class GetAccountCategoryIndexListQuery : ApiQueryString, IRequest<IEnumerable<AccountCategoryIndexView>> {

    }
}