using Dadata;
using Dadata.Model;

namespace StandartAddressAPI.Service
{
    public class AddressService
    {
        private readonly ILogger<AddressService> _logger;

        public AddressService(ILogger<AddressService> logger)
        {
            _logger = logger;
        }

        public async Task<Address> TransformAddressAsync(string address)
        {
            var token = Const.SECRET_TOKEN;
            var secret = Const.SECRET_KEY;
            var api = new CleanClientAsync(token, secret);
            var result = await api.Clean<Address>(address);
            _logger.LogInformation("TransformAddressAsync - address: {address} successful transformation. Time: {Date}", address, DateTime.UtcNow.ToLongTimeString());
            return result;
        }
    }
}
