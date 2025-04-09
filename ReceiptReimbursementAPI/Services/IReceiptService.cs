using ReceiptReimbursementAPI.DTOs;
using System.Threading.Tasks;

namespace ReceiptReimbursementAPI.Services
{
    public interface IReceiptService
    {
        Task<ReceiptResponseDto> SubmitReceiptAsync(ReceiptRequestDto request);

        Task<IEnumerable<ReceiptResponseDto>> GetAllReceiptsAsync();
    }
}
