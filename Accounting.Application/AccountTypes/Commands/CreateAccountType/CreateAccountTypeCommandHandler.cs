/*
 * @CreateTime: May 14, 2019 10:33 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 14, 2019 10:36 AM
 * @Description: Modify Here, Please 
 */
using System.Threading;
using System.Threading.Tasks;
using Accounting.Application.Interfaces;
using Accounting.Domain;
using MediatR;

namespace Accounting.Application.AccountTypes.Commands.CreateAccountType {
    public class CreateAccountTypeCommandHandler : IRequestHandler<CreateAccountTypeCommand, uint> {
        private readonly IAccountingDatabaseService _database;

        public CreateAccountTypeCommandHandler (IAccountingDatabaseService database) {
            _database = database;

        }

        public async Task<uint> Handle (CreateAccountTypeCommand request, CancellationToken cancellationToken) {

            AccountType newAccountType = new AccountType () {
                Type = request.type,
                IsSummery = request.isSummary,
                TypeOf = request.isTypeOf
            };
            _database.AccountType.Add (newAccountType);

            await _database.SaveAsync ();

            return newAccountType.Id;

        }
    }
}