using System;
using System.Collections.Generic;

namespace BookMovieTicket.Models;

public partial class DjangoAdminLog
{
    public int Id { get; set; }

    public DateTimeOffset ActionTime { get; set; }

    public string? ObjectId { get; set; }

    public string ObjectRepr { get; set; } = null!;

    public short ActionFlag { get; set; }

    public string ChangeMessage { get; set; } = null!;

    public int? ContentTypeId { get; set; }

    public string UserId { get; set; } = null!;

    public virtual DjangoContentType? ContentType { get; set; }

    public virtual UserData User { get; set; } = null!;
}
