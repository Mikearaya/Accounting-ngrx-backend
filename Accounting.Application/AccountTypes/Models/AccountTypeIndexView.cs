/*
 * @CreateTime: May 14, 2019 12:35 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 14, 2019 12:37 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Linq.Expressions;
using Accounting.Domain;

namespace Accounting.Application.AccountTypes.Models {
    public class AccountTypeIndexView {
        public uint id { get; set; }
        public string name { get; set; }
        public uint? typeOf { get; set; }

        public static Expression<Func<AccountType, AccountTypeIndexView>> Projection {
            get {
                return accountType => new AccountTypeIndexView () {
                    id = accountType.Id,
                    name = accountType.Type,
                    typeOf = accountType.TypeOf
                };
            }
        }
    }
}