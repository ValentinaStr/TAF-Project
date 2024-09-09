namespace API.Model.ResponseModels
{
    public class UserDataResponceModel
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public AddressResponseModel? Address { get; set; }
        public string? Phone { get; set; }
        public string? Website { get; set; }
        public CompanyResponseModel? Company { get; set; }


    }
}