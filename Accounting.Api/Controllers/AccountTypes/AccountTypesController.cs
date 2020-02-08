using System.Linq;
/*
 * @CreateTime: May 14, 2019 12:47 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 19, 2019 10:13 AM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using System.Threading.Tasks;
using Accounting.Application.AccountTypes.Commands.CreateAccountType;
using Accounting.Application.AccountTypes.Commands.DeleteAccountType;
using Accounting.Application.AccountTypes.Commands.UpdateAccountType;
using Accounting.Application.AccountTypes.Models;
using Accounting.Application.AccountTypes.Queries.GetAccountType;
using Accounting.Application.AccountTypes.Queries.GetAccountTypeList;
using Accounting.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Accounting.Api.Controllers.AccountTypes {

    /// <summary>
    /// Handles account type related CRUD Operations
    /// </summary>
    [Route ("api")]
    public class AccountTypesController : Controller {
        private readonly IMediator _Mediator;

        /// <summary>
        /// initializes account type object by injecting mediator instance
        /// </summary>
        /// <param name="mediator"></param>
        public AccountTypesController (IMediator mediator) {
            _Mediator = mediator;
        }

        /// <summary>
        /// returns list of account types by filtering them using the parameters provided in the query string
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet ("accounttypes")]
        public async Task<ActionResult<IEnumerable<AccountTypeView>>> GetAccountTypesList ([FromQuery] GetAccountTypeListQuery query) {
            var accountType = await _Mediator.Send (query);
            return Ok (accountType.Items);
        }

        /// <summary>
        /// returns a single instance of account type based on the id provided in the url
        /// or return not found status code if the account type doesnt exist
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet ("accounttype/{id}")]
        public async Task<ActionResult<AccountTypeView>> FindAccountTypeById (uint id) {
            var accountTypeList = await _Mediator.Send (new GetAccountTypeQuery () { Id = id });
            return Ok (accountTypeList);
        }

        /// <summary>
        /// creates new account type and return the newly created account type appending the id generated
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost ("accounttype")]
        public async Task<ActionResult<AccountTypeView>> CreateAccountType ([FromBody] CreateAccountTypeCommand command) {
            var newAccountTypeId = await _Mediator.Send (command);
            var newAccountType = await _Mediator.Send (new GetAccountTypeQuery () { Id = newAccountTypeId });

            return StatusCode (201, newAccountType);
        }
        /// <summary>
        /// updates single instance of account type based on the id provided in the url  and body of the request
        /// or return 404 status code in the case the account type could not be found
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut ("accounttype/{id}")]
        public async Task<ActionResult> UpdateAccountType (uint id, [FromBody] UpdateAccountTypeCommand command) {

            await _Mediator.Send (command);
            return NoContent ();
        }

        /// <summary>
        /// deletes a single instance of account type based on the id provided in the url or
        /// returns 404 status code in the case the account type is not found
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete ("accounttype/{id}")]
        public async Task<ActionResult> DeleteAccountType (uint id) {
            await _Mediator.Send (new DeleteAccountTypeCommand () { Id = id });
            return NoContent ();
        }

    }
}