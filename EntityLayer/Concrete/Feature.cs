﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class Feature // Öne çıkarılan tek büyük resim, Feature -> özellik
	{
		[Key]
		public int FeatureID { get; set; }
		public string FeatureTitle { get; set; }
		public string FeatureDescription { get; set; }
		public string FeatureImage { get; set; }
		public bool FeatureStatus { get; set; }
	}
}
