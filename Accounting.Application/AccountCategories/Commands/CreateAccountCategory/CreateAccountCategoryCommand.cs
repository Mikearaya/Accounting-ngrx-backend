/*
 * @CreateTime: Apr 30, 2019 8:29 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 8, 2019 4:27 AM
 * @Description: Model used while creating account
 */
using Accounting.Application.AccountCategories.Models;
using MediatR;

namespace Accounting.Application.AccountCategories.Commands.CreateAccountCategory {
    public class CreateAccountCategoryCommand : IRequest<int> {

        public string categoryName { get; set; }
        public uint accountType { get; set; }
        public int? overFlowAccount { get; set; }
    }
}