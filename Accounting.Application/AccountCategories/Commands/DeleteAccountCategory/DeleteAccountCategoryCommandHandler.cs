/*
 * @CreateTime: Apr 30, 2019 1:27 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 2, 2019 1:57 PM
 * @Description: Modify Here, Please 
 */
using System.Threading;
using System.Threading.Tasks;
using Accounting.Application.Exceptions;
using Accounting.Application.Interfaces;
using MediatR;

namespace Accounting.Application.AccountCategories.Commands.DeleteAccountCategory {
    public class DeleteAccountCategoryCommandHandler : IRequestHandler<DeleteAccountCategoryCommand, Unit> {
        private readonly IAccountingDatabaseService _database;

        public DeleteAccountCategoryCommandHandler (IAccountingDatabaseService database) {
            _database = database;
        }

        public async Task<Unit> Handle (DeleteAccountCategoryCommand request, CancellationToken cancellationToken) {
            var category = await _database.AccountCatagory.FindAsync (request.id);

            if (category == null) {
                throw new NotFoundException ("Account category", request.id);
            }

            _database.AccountCatagory.Remove (category);

            await _database.SaveAsync ();

            return Unit.Value;
        }
    }
}