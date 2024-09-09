namespace API.Model.ResponseModels
{
    public class AddressResponseModel
    {
        public string? Street { get; set; }
        public string? Suite { get; set; }
        public string? City { get; set; }
        public string? Zipcode { get; set; }
        public GeolocationResponseModel? Geo { get; set; }
    }
}