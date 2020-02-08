/*
 * @CreateTime: May 2, 2019 7:02 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 2, 2019 7:02 PM
 * @Description: Modify Here, Please 
 */
using FluentValidation;

namespace Accounting.Application.Accounts.Commands.UpdateAccount {
    public class UpdateAccountCommandValidator : AbstractValidator<UpdateAccountCommand> {
        public UpdateAccountCommandValidator () {

            RuleFor (x => x.id).NotEmpty ().NotNull ();
            RuleFor (x => x.accountName).NotEmpty ().NotNull ();
            RuleFor (x => x.accountId).MinimumLength (4).NotEmpty ().NotNull ();

        }
    }
}