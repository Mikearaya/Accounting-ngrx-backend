/*
 * @CreateTime: May 14, 2019 10:29 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 14, 2019 10:32 AM
 * @Description: Modify Here, Please 
 */
using MediatR;

namespace Accounting.Application.AccountTypes.Commands.CreateAccountType {
    public class CreateAccountTypeCommand : IRequest<uint> {

        public uint isTypeOf { get; set; }
        public string type { get; set; }
        public sbyte isSummary { get; set; }

    }
}