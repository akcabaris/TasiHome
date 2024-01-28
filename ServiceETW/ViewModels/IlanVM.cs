using ServiceETW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceETW.ViewModels
{
    public partial class IlanVM
    {
        public int Id { get; set; }

        public string Baslik { get; set; } = null!;

        public string Aciklama { get; set; } = null!;

        public DateTime Tarih { get; set; }
        public string Ilantipi { get; set; } = null!;
        public string Sehir { get; set; } = null!;

        public string Ilce { get; set; } = null!;
        public string? UserTelNo { get; set; }
        public string? UserFullName { get; set; }
        public int? UserId { get; set; }

        public virtual User? User { get; set; }

    }
}
