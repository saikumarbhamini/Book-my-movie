using System;
using System.Collections.Generic;

namespace BookMovieTicket.Models;

public partial class UserData
{
    public string Password { get; set; } = null!;

    public DateTimeOffset? LastLogin { get; set; }

    public bool IsSuperuser { get; set; }

    public string Username { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public bool IsStaff { get; set; }

    public bool IsActive { get; set; }

    public DateTimeOffset DateJoined { get; set; }

    public string Id { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public virtual ICollection<DjangoAdminLog> DjangoAdminLogs { get; set; } = [];

    public virtual ICollection<UserDataGroup> UserDataGroups { get; set; } = [];

    public virtual ICollection<UserDataUserPermission> UserDataUserPermissions { get; set; } = [];
}
