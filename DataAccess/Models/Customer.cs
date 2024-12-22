using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string Username { get; set; } = null!;

    public string Pass { get; set; } = null!;

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Bio { get; set; }

    public string? Gender { get; set; }

    public string Email { get; set; } = null!;

    public DateOnly? BirthDate { get; set; }

    public string? CountryCode { get; set; }

    public short RoleId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public int? DeletedBy { get; set; }

    public string? Avatar { get; set; }

    public string? Banner { get; set; }

    public virtual Country? CountryCodeNavigation { get; set; }

    public virtual Customer? CreatedByNavigation { get; set; }

    public virtual Customer? DeletedByNavigation { get; set; }

    public virtual ICollection<Friendship> FriendshipAddressees { get; set; } = new List<Friendship>();

    public virtual ICollection<Friendship> FriendshipRequesters { get; set; } = new List<Friendship>();

    public virtual ICollection<FriendshipStatus> FriendshipStatuses { get; set; } = new List<FriendshipStatus>();

    public virtual ICollection<Customer> InverseCreatedByNavigation { get; set; } = new List<Customer>();

    public virtual ICollection<Customer> InverseDeletedByNavigation { get; set; } = new List<Customer>();

    public virtual ICollection<Customer> InverseUpdatedByNavigation { get; set; } = new List<Customer>();

    public virtual ICollection<Movie> MovieCreatedByNavigations { get; set; } = new List<Movie>();

    public virtual ICollection<Movie> MovieDeletedByNavigations { get; set; } = new List<Movie>();

    public virtual ICollection<Movie> MovieUpdatedByNavigations { get; set; } = new List<Movie>();

    public virtual ICollection<Review> ReviewCreatedByNavigations { get; set; } = new List<Review>();

    public virtual ICollection<Review> ReviewCustomers { get; set; } = new List<Review>();

    public virtual ICollection<Review> ReviewDeletedByNavigations { get; set; } = new List<Review>();

    public virtual ICollection<Review> ReviewUpdatedByNavigations { get; set; } = new List<Review>();

    public virtual Role Role { get; set; } = null!;

    public virtual Customer? UpdatedByNavigation { get; set; }

    public virtual ICollection<UserList> UserListCreatedByNavigations { get; set; } = new List<UserList>();

    public virtual ICollection<UserList> UserListCustomers { get; set; } = new List<UserList>();

    public virtual ICollection<UserList> UserListDeletedByNavigations { get; set; } = new List<UserList>();

    public virtual ICollection<UserList> UserListUpdatedByNavigations { get; set; } = new List<UserList>();
}
