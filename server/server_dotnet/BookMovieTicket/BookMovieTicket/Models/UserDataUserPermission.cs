using System;
using System.Collections.Generic;

namespace BookMovieTicket.Models;

public partial class UserDataUserPermission
{
    public long Id { get; set; }

    public string UserdataId { get; set; } = null!;

    public int PermissionId { get; set; }

    public virtual AuthPermission Permission { get; set; } = null!;

    public virtual UserData Userdata { get; set; } = null!;
}
