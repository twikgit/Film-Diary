﻿namespace BackendApi.Contracts.User
{
    public class GetUserResponse
    {
        public int CustomerId { get; set; }
        public string Username { get; set; } = null!;
        public string Pass { get; set; } = null!;
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string Email { get; set; } = null!;
        public DateOnly? BirthDate { get; set; }
    }
}