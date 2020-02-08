/*
 * @CreateTime: Apr 26, 2019 9:27 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 9, 2019 7:57 AM
 * @Description: Modify Here, Please 
 */

using System.Threading.Tasks;
using Accounting.Application.Interfaces;
using Accounting.Domain;
using Microsoft.EntityFrameworkCore;

namespace Accounting.Persistance {
    public class AccountingDatabaseService : DbContext, IAccountingDatabaseService {

        public AccountingDatabaseService (DbContextOptions<AccountingDatabaseService> options) : base (options) { }

        public AccountingDatabaseService () { }

        public DbSet<AccountCatagory> AccountCatagory { get; set; }
        public DbSet<AccountType> AccountType { get; set; }
        public DbSet<Account> Accounts { get; set; }

        public void Save () {
            this.SaveChanges ();
        }

        public Task SaveAsync () {
            return this.SaveChangesAsync ();
        }

        protected override void OnConfiguring (DbContextOptionsBuilder optionBuilder) {
            if (!optionBuilder.IsConfigured) {
                optionBuilder.UseMySql ("server=localhost;user=admin;password=admin;port=3306;database=smart_accounting_ecafco;");
            }

        }

        protected override void OnModelCreating (ModelBuilder builder) {

            builder.ApplyConfigurationsFromAssembly (typeof (AccountingDatabaseService).Assembly);

        }

    }
}