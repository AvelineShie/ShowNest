using System;
using System.Collections.Generic;

namespace ApplicationCore.Entities;

public partial class Fblogininfo
{
    public int Id { get; set; }

    public string FacebookId { get; set; }

    public string Name { get; set; }

    public string Email { get; set; }

    public string ProfilePictureUrl { get; set; }

    public string AccessToken { get; set; }

    public DateTime AccessTokenExpires { get; set; }

    public string RefreshToken { get; set; }

    public DateTime? LastLogin { get; set; }

    public virtual User IdNavigation { get; set; }
}
