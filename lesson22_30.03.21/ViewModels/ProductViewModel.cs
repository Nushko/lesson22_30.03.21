using System.Collections.Generic;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace lesson22_30._03._21.ViewModels
{
	public class ProductViewModel
	{
		public int Id { get; set; }
		[Required(ErrorMessage = "Ошибка в названии")]
		[MinLength(3)]
		[MaxLength(50)]
		[Display(Name = "Название продукта")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Ошибка в цене")]
		[Display(Name = "Цена")]
		public decimal Price { get; set; }
		[Required(ErrorMessage = "Ошибка в категории")]
		[Display(Name = "Категория")]
		public int CategoryId { get; set; }
		// [Display(Name = "Категория")]
		public List<SelectListItem> Categories { get; set; } = new List<SelectListItem>();
	}
}