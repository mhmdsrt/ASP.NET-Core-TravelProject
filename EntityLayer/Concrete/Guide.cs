﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Guide // Guide -> Rehber
    {
		[Key]
		public int GuideID { get; set; }
		public string? GuideName { get; set; }
		public string? GuideDescription { get; set; }
		public string? GuideImage { get; set; }
		public string? GuideTwitterUrl { get; set; }
		public string? GuideInstagramUrl { get; set; }
		public bool GuideStatus { get; set; }
		public ICollection<Destination> Destinations { get; set; }
	}
}
