using System;
using System.Collections.Generic;

namespace BookMovieTicket.Models;

public partial class UserDataGroup
{
    public long Id { get; set; }

    public string UserdataId { get; set; } = null!;

    public int GroupId { get; set; }

    public virtual AuthGroup Group { get; set; } = null!;

    public virtual UserData Userdata { get; set; } = null!;
}
