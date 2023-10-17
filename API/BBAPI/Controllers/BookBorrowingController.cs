using BBAPI.Helper;
using BBAPI.Wrappers;
using BBCommon.Contracts;
using BBCommon.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookBorrowingController : ControllerBase
    {
        private readonly ILogger<BookBorrowingController> _logger;
        private readonly IBookBorrowingService _bookBorrowingService;
        private readonly IConfiguration _config;
        private readonly int  finePerday;
        public BookBorrowingController(ILogger<BookBorrowingController> logger, IBookBorrowingService bookBorrowingService, IConfiguration configuration)
        {
            _logger = logger;
            _bookBorrowingService = bookBorrowingService;
            _config = configuration;
            finePerday = int.Parse(_config["Configurations:FinePerDay"]);

        }
        [HttpPost]
        public async Task<IActionResult> CreateBookBorrowing([FromBody] BookBorrowingRequest request)
        {
            try
            {

                _logger.LogInformation($"Created Book Borrowing:{request.BorrowerName + "," + request.BorrowingDate}");

                if (request == null)
                {
                    return BadRequest(Response<string>.Fail("The Book Borrowing is empty "));
                }


                bool isInserted = await _bookBorrowingService.AddBookBorrowing(request);
                if (isInserted)
                {
                    return Ok(Response<string>.Success("The Book Borrowing is created."));
                }
                else
                {
                    return BadRequest(Response<string>.Fail("Create operation failed "));

                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside the CreateBookBorrowing action: {ex}");

                return StatusCode(500, Response<string>.Fail("Error on Add operation"));

            }
        }
        [HttpGet("{bookBorrowingId}/{countryId}/penalty")]
        public async Task<IActionResult> CalculatePenaltyAmount(int bookBorrowingId,int countryId)
        {
            try
            {
                _logger.LogInformation($"Returned all GetBookBorrowings and GetCountry from the memory database.");
                IBookBorrowing bookBorrowing = await _bookBorrowingService.GetBookBorrowings(bookBorrowingId);
                ICountry country=await _bookBorrowingService.GetCountry(countryId);
                int daysOverdue = Math.Max(0, (int)(DateTime.Now - bookBorrowing.DueDate).TotalDays);
                decimal penaltyAmount = Utilities.CalculatePenalty(daysOverdue, country.StartDay, country.EndDay, finePerday);
                return Ok(Response<decimal>.Success(penaltyAmount));

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside the CalculatePenaltyAmount action: {ex}");
                return StatusCode(500, Response<string>.Fail("Error retrieving data from the memory database"));

            }
        }
    }
}
