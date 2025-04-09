using Microsoft.AspNetCore.Mvc;
using ReceiptReimbursementAPI.DTOs;
using ReceiptReimbursementAPI.Services;

namespace ReceiptReimbursementAPI.Controllers
{
    [ApiController]
    [Route("api/receipt")]
    public class ReceiptController : ControllerBase
    {
        private readonly IReceiptService _receiptService;

        public ReceiptController(IReceiptService receiptService)
        {
            _receiptService = receiptService;
        }

        // POST: api/receipt/submit
        [HttpPost("submit")]
        public async Task<ActionResult<ReceiptResponseDto>> SubmitReceipt([FromForm] ReceiptRequestDto request)
        {
            try
            {
                var result = await _receiptService.SubmitReceiptAsync(request);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        // GET: api/receipt/all
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<ReceiptResponseDto>>> GetAllReceipts()
        {
            var receipts = await _receiptService.GetAllReceiptsAsync();
            return Ok(receipts);
        }
    }
}
