/*
 * @CreateTime: Apr 30, 2019 10:31 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Apr 30, 2019 1:17 PM
 * @Description: Modify Here, Please 
 */
using Accounting.Application.AccountCategories.Models;
using MediatR;

namespace Accounting.Application.AccountCategories.Commands.UpdateAccountCategory {

    public class UpdateAccountCategoryCommand : IRequest {

        public int id { get; set; }
        public uint accountType { get; set; }
        public string categoryName { get; set; }
        public int? overFlowAccount { get; set; }
    }
}