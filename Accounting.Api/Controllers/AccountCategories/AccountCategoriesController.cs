/*
 * @CreateTime: Apr 30, 2019 3:47 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 4, 2019 10:20 AM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Accounting.Application.AccountCategories.Commands.CreateAccountCategory;
using Accounting.Application.AccountCategories.Commands.DeleteAccountCategory;
using Accounting.Application.AccountCategories.Commands.UpdateAccountCategory;
using Accounting.Application.AccountCategories.Models;
using Accounting.Application.AccountCategories.Queries.GetAccountCategory;
using Accounting.Application.AccountCategories.Queries.GetAccountCategoryList;
using Accounting.Application.Exceptions;
using Accounting.Application.Models;
using Accounting.API.Commons;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Accounting.Api.Controllers.AccountCategories {

    /// <summary>
    /// exposes api functions that will allow the reading adding, editing and deleteing of account categories
    /// </summary>

    [Route ("api")]
    public class AccountCategoriesController : Controller {
        private readonly IMediator _Mediator;

        /// <summary>
        /// used to initialize account category controller at the time of creation
        /// </summary>
        public AccountCategoriesController (IMediator mediator) {
            _Mediator = mediator;
        }

        /// <summary>
        /// gets single account category from  database based on the id provided in the url
        /// or returns not found status code in the event the category doesnt exist
        /// </summary>
        /// <param name="id"></param>
        /// <returns>AccountCategoryView</returns>
        [HttpGet ("accountcategory/{id}")]
        public async Task<ActionResult<AccountCategoryView>> FindAccountCategoryById (int id) {

            try {
                var result = await _Mediator.Send (new GetAccountCategoryQuery () { Id = id });
                return Ok (result);
            } catch (NotFoundException e) {
                return NotFound (e.Message);
            }

        }

        /// <summary>
        /// gets list of account categories list based on the filter criterias provided by query string
        /// </summary>
        /// <returns>AccountCategoryView</returns>
        [HttpGet ("accountcategories")]
        public async Task<ActionResult<FilterResultModel<AccountCategoryView>>> GetAccountCategoryList ([FromQuery] GetAccountCategoryListQuery query) {

            var result = await _Mediator.Send (query);
            return Ok (result);

        }

        /// <summary>
        /// creates new account category passed through its parameter
        /// </summary>
        /// <param name="model"></param>
        /// <returns>int</returns>
        [HttpPost ("accountcategory")]
        public async Task<ActionResult<AccountCategoryView>> CreateAccountCategory ([FromBody] CreateAccountCategoryCommand model) {

            var result = await _Mediator.Send (model);
            var category = await _Mediator.Send (new GetAccountCategoryQuery () { Id = result });
            return StatusCode (201, category);

        }

        /// <summary>
        /// Updates a given account category based on the id provided
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>

        [HttpPut ("accountcategory/{id}")]
        public async Task<ActionResult> UpdateAccountCategory (int id, [FromBody] UpdateAccountCategoryCommand model) {

            try {

                var result = await _Mediator.Send (model);
                return NoContent ();
            } catch (NotFoundException e) {
                return NotFound (e.Message);

            }

        }

        /// <summary>
        /// deletes a single account category based on the id passed in the url
        /// or returns not found if account category is not found
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpDelete ("accountcategory/{id}")]
        public async Task<ActionResult> DeleteAccountCategory (int id) {

            try {

                var result = await _Mediator.Send (new DeleteAccountCategoryCommand () { Id = id });
                return NoContent ();
            } catch (NotFoundException e) {
                return NotFound (e.Message);
            }
        }

    }
}