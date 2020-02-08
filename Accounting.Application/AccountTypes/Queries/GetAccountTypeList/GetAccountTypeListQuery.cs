/*
 * @CreateTime: May 14, 2019 11:16 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 14, 2019 11:16 AM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using Accounting.Application.AccountTypes.Models;
using Accounting.Application.Models;
using Accounting.Commons.QueryHelpers;
using MediatR;

namespace Accounting.Application.AccountTypes.Queries.GetAccountTypeList {
    public class GetAccountTypeListQuery : ApiQueryString, IRequest<FilterResultModel<AccountTypeView>> {

    }
}