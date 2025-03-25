using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class SubAbout // Hakkımızda kısmın alt alanı için
    {
		[Key]
		public int SubAboutID { get; set; }
		public string SubAbouttTitle { get; set; }
		public string SubAboutDescription { get; set; }
	}
}
