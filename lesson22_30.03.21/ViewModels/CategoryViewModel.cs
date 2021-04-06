using System.ComponentModel.DataAnnotations;
namespace lesson22_30._03._21.ViewModels
{
	public class CategoryViewModel
	{
		public int Id { get; set; }
		[Required(ErrorMessage = "Ошибка в названии")]
		[MinLength(3)]
		[MaxLength(50)]
        [Display(Name = "Название категории")]
		public string Name { get; set; }
	}
}