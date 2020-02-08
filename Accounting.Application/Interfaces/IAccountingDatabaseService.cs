/*
 * @CreateTime: Apr 26, 2019 9:29 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 8, 2019 9:41 AM
 * @Description: Modify Here, Please 
 */
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Accounting.Application.Accounts.Models;
using Accounting.Domain;
using Microsoft.EntityFrameworkCore;

namespace Accounting.Application.Interfaces {
    public interface IAccountingDatabaseService {

        DbSet<AccountCatagory> AccountCatagory { get; set; }
        DbSet<AccountType> AccountType { get; set; }
        DbSet<Account> Accounts { get; set; }

        void Save ();
        Task SaveAsync ();

    }
}