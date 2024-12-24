namespace BackendApi.Contracts.User
{
    public class UpdateUserRequest
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly? BirthDate { get; set; }
        public string Username { get; set; }
        public string Pass { get; set; }
        public string Email { get; set; }
    }
}
