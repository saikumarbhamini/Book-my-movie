using System;
using System.Collections.Generic;

namespace BookMovieTicket.Models;

public partial class AuthGroup
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<AuthGroupPermission> AuthGroupPermissions { get; set; } = new List<AuthGroupPermission>();

    public virtual ICollection<UserDataGroup> UserDataGroups { get; set; } = new List<UserDataGroup>();
}
