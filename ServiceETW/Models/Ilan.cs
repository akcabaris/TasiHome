using System;
using System.Collections.Generic;

namespace ServiceETW.Models;

public partial class Ilan
{
    public int Id { get; set; }

    public string Baslik { get; set; } = null!;

    public string Aciklama { get; set; } = null!;

    public DateTime Tarih { get; set; }

    public string Ilantipi { get; set; } = null!;

    public string Sehir { get; set; } = null!;

    public string Ilce { get; set; } = null!;

    public int? UserId { get; set; }

    public virtual User? User { get; set; }
}
