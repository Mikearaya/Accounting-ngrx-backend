/*
 * @CreateTime: Apr 24, 2019 5:49 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 2, 2019 7:06 PM
 * @Description: Modify Here, Please 
 */
using MediatR;

namespace Accounting.Application.Accounts.Commands.UpdateAccount {
    public class UpdateAccountCommand : IRequest {
        public int id { get; set; }
        public int? parentAccount { get; set; }
        public string accountName { get; set; }
        public string accountId { get; set; }
        public sbyte active { get; set; }
    }
}