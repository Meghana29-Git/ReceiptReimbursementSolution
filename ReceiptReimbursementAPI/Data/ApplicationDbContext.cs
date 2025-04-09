using Microsoft.EntityFrameworkCore;
using ReceiptReimbursementAPI.Models;

namespace ReceiptReimbursementAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Receipt> Receipts { get; set; }
    }
}
