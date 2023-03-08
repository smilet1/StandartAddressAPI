using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StandartAddressAPI.Service;

namespace StandartAddressAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly AddressService _addressService;
        private readonly ILogger<AddressController> _logger;

        public AddressController(AddressService addressService, ILogger<AddressController> logger)
        {
            _addressService = addressService;
            _logger = logger;
        }

        [HttpGet]
        public JsonResult GetAddress(string address)
        {
            if(address == null)
            {
                return new JsonResult(BadRequest());
            }

            var result = _addressService.TransformAddressAsync(address);
            _logger.LogInformation("GetAddress - address: {address} successful transformation. Time: {Date}", address, DateTime.UtcNow.ToLongTimeString());
            return new JsonResult(Ok(result.Result));
        }
    }
}
