/*
 * @CreateTime: May 14, 2019 12:38 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 14, 2019 1:14 PM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using Accounting.Application.AccountTypes.Models;
using MediatR;

namespace Accounting.Application.AccountTypes.Queries.GetAccountTypeList {
    public class GetAccountTypeIndexQuery : IRequest<IEnumerable<AccountTypeIndexView>> {
        public bool main { get; set; }
        public uint typeOf { get; set; }
    }
}