using System;
using System.Collections.Generic;

namespace ServiceETW.Models;

public partial class User
{
    public int Id { get; set; }

    public string FullName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public virtual ICollection<Ilan> Ilans { get; set; } = new List<Ilan>();
}
