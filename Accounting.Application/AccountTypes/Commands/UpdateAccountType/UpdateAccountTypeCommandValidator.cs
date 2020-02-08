/*
 * @CreateTime: May 14, 2019 10:49 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 14, 2019 10:49 AM
 * @Description: Modify Here, Please 
 */
using FluentValidation;

namespace Accounting.Application.AccountTypes.Commands.UpdateAccountType {
    public class UpdateAccountTypeCommandValidator : AbstractValidator<UpdateAccountTypeCommand> {
        public UpdateAccountTypeCommandValidator () {
            RuleFor (x => x.id).NotEmpty ().NotNull ();
            RuleFor (x => x.isTypeOf).NotEmpty ().NotNull ();
            RuleFor (x => x.type).NotEmpty ().NotNull ();
        }
    }
}