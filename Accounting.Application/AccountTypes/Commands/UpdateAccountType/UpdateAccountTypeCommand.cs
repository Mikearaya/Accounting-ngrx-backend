using System;

/*
 * @CreateTime: May 14, 2019 10:43 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 14, 2019 10:58 AM
 * @Description: Modify Here, Please 
 */
using MediatR;

namespace Accounting.Application.AccountTypes.Commands.UpdateAccountType {
    public class UpdateAccountTypeCommand : IRequest {
        public uint id { get; set; }
        public uint isTypeOf { get; set; }
        public string type { get; set; }
        public sbyte isSummary { get; set; }

    }
}