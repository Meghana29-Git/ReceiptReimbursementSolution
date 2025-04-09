using ReceiptReimbursementAPI.DTOs;
using ReceiptReimbursementAPI.Models;
using ReceiptReimbursementAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace ReceiptReimbursementAPI.Services
{
    public class ReceiptService : IReceiptService
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ReceiptService(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<ReceiptResponseDto> SubmitReceiptAsync(ReceiptRequestDto request)
        {
            if (request.File == null || request.File.Length == 0)
                throw new ArgumentException("File is required.");

            var uploadsFolder = Path.Combine(_env.WebRootPath ?? Path.Combine(Directory.GetCurrentDirectory(), "wwwroot"), "uploads");
            Directory.CreateDirectory(uploadsFolder);

            var filePath = Path.Combine(uploadsFolder, request.File.FileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await request.File.CopyToAsync(stream);
            }

            var receipt = new Receipt
            {
                Date = request.Date,
                Amount = request.Amount,
                Description = request.Description,
                FilePath = filePath
            };

            await _context.Receipts.AddAsync(receipt);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving to database: " + ex.Message);
                throw;
            }

            return new ReceiptResponseDto
            {
                Id = receipt.Id,
                Date = receipt.Date,
                Amount = receipt.Amount,
                Description = receipt.Description,
                FilePath = receipt.FilePath
            };
        }

        public async Task<IEnumerable<ReceiptResponseDto>> GetAllReceiptsAsync()
        {
            var receipts = await _context.Receipts.ToListAsync();

            return receipts.Select(r => new ReceiptResponseDto
            {
                Id = r.Id,
                Date = r.Date,
                Amount = r.Amount,
                Description = r.Description,
                FilePath = r.FilePath
            }).ToList();
        }
    }
}
