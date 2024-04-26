using System;
using System.Collections.Generic;

namespace ApplicationCore.Entities;

public partial class LineLogininfo
{
    public int Id { get; set; }

    public string LineUserId { get; set; }

    public string Name { get; set; }

    public string PictureUrl { get; set; }

    public string Email { get; set; }

    public string Gender { get; set; }

    public DateTime? Birthdate { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
