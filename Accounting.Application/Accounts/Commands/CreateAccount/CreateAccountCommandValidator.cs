/*
 * @CreateTime: Apr 24, 2019 6:48 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 3, 2019 2:58 PM
 * @Description: Modify Here, Please 
 */
using FluentValidation;

namespace Accounting.Application.Accounts.Commands.CreateAccount {
    public class CreateAccountCommandValidator : AbstractValidator<CreateAccountCommand> {
        public CreateAccountCommandValidator () {
            RuleFor (x => x.accountId).MinimumLength (4).NotEmpty ().NotNull ();
            RuleFor (x => x.active).NotNull ().NotNull ();
            RuleFor (x => x.accountName).NotNull ().NotEmpty ();

            RuleFor (x => x.catagoryId).NotEmpty ().NotNull ();
        }
    }
}