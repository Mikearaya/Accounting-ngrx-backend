/*
 * @CreateTime: Apr 30, 2019 2:04 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Apr 30, 2019 2:04 PM
 * @Description: Modify Here, Please 
 */
using Accounting.Application.AccountCategories.Models;
using MediatR;

namespace Accounting.Application.AccountCategories.Queries.GetAccountCategory {
    public class GetAccountCategoryQuery : IRequest<AccountCategoryView> {
        public int id { get; set; }
    }
}