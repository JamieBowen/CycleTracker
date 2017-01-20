using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using CycleTracker.Data.Models;
using CycleTracker.Data.Models.EnumTypes;
using Microsoft.AspNetCore.Mvc;

namespace CycleTracker.API.Controllers
{
	[Route("api/[controller]")]
	public class ListController
    {
	    [HttpGet("parttype")]
	    public List<ListItem> GetPartTypes()
	    {
			return Enum.GetValues(typeof(PartType))
				.Cast<PartType>()
				.Select(x => new ListItem
				{
					Value = (int)x,
					Text = Regex.Replace(x.ToString(), @"(\B[A-Z]+?(?=[A-Z][^A-Z])|\B[A-Z]+?(?=[^A-Z]))", " $1")
				})
				.OrderBy(x => x.Text)
				.ToList();
	    }
    }
}
