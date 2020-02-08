/*
 * @CreateTime: May 14, 2019 10:51 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 14, 2019 12:33 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Linq.Expressions;
using Accounting.Domain;

namespace Accounting.Application.AccountTypes.Models {
    public class AccountTypeView {
        public uint id { get; set; }
        public uint? isTypeOf { get; set; }
        public string type { get; set; }
        public sbyte isSummary { get; set; }
        public string parent { get; set; }

        public static Expression<Func<AccountType, AccountTypeView>> Projection {
            get {
                return accountType => new AccountTypeView () {
                    id = accountType.Id,
                    type = accountType.Type,
                    isSummary = accountType.IsSummery,
                    parent = accountType.TypeOfNavigation.Type,
                    isTypeOf = accountType.TypeOf,
                };
            }
        }
    }
}