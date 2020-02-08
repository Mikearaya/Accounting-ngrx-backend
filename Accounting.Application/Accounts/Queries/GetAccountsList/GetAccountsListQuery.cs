/*
 * @CreateTime: Apr 24, 2019 6:10 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Apr 24, 2019 6:14 PM
 * @Description: Modify Here, Please 
 */

using Accounting.Application.Accounts.Models;
using Accounting.Application.Models;
using Accounting.Commons.QueryHelpers;
using MediatR;

namespace Accounting.Application.Accounts.Queries.GetAccountsList {
    public class GetAccountsListQuery : ApiQueryString, IRequest<FilterResultModel<AccountViewModel>> {

    }
}