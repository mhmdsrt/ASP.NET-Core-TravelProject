﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class Announcement // Announcement -> Duyuru
	{
		public int AnnouncementID { get; set; }
		public string? AnnouncementTitle { get; set; }
		public string? AnnouncementContent { get; set; }
		public DateTime AnnouncementDate { get; set; }
	}
}
