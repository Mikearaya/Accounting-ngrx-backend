/*
 * @CreateTime: Apr 30, 2019 10:33 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Apr 30, 2019 1:17 PM
 * @Description: Modify Here, Please 
 */
using System.Threading;
using System.Threading.Tasks;
using Accounting.Application.Exceptions;
using Accounting.Application.Interfaces;
using MediatR;

namespace Accounting.Application.AccountCategories.Commands.UpdateAccountCategory {
    public class UpdateAccountCategoryCommandHandler : IRequestHandler<UpdateAccountCategoryCommand, Unit> {
        private readonly IAccountingDatabaseService _database;

        public UpdateAccountCategoryCommandHandler (IAccountingDatabaseService database) {
            _database = database;
        }

        public async Task<Unit> Handle (UpdateAccountCategoryCommand request, CancellationToken cancellationToken) {
            var catagory = await _database.AccountCatagory.FindAsync (request.id);

            if (catagory == null) {
                throw new NotFoundException ("Account Category", request.id);
            }

            catagory.Catagory = request.categoryName;
            catagory.AccountTypeId = request.accountType;
            catagory.OverflowAccount = request.overFlowAccount;

            _database.AccountCatagory.Update (catagory);

            await _database.SaveAsync ();

            return Unit.Value;
        }
    }
}