/*
 * @CreateTime: Apr 24, 2019 4:49 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 7, 2019 4:33 PM
 * @Description: Modify Here, Please 
 */
using MediatR;

namespace Accounting.Application.Accounts.Commands.CreateAccount {
    public class CreateAccountCommand : IRequest<int> {
        public string accountId { get; set; }
        public int? parentAccount { get; set; }
        public int catagoryId { get; set; }
        public string accountName { get; set; }
        public sbyte active { get; set; }
        public int? costCenterId { get; set; }
        public float? openingBalance { get; set; }
    }
}