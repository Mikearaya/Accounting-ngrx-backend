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
        public uint Id { get; set; }
        public uint? IsTypeOf { get; set; }
        public string Type { get; set; }
        public sbyte IsSummary { get; set; }
        public string Parent { get; set; }

        public static Expression<Func<AccountType, AccountTypeView>> Projection {
            get {
                return accountType => new AccountTypeView () {
                    Id = accountType.Id,
                    Type = accountType.Type,
                    IsSummary = accountType.IsSummery,
                    Parent = accountType.TypeOfNavigation.Type,
                    IsTypeOf = accountType.TypeOf,
                };
            }
        }
    }
}