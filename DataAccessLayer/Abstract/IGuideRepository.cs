﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
	public interface IGuideRepository : IGenericRepository<Guide>
	{
		void ChangeToFalse(int id);
		void ChangeToTrue(int id);
		int GetGuideCount(); // toplam rehber sayısını getir
	}
}
