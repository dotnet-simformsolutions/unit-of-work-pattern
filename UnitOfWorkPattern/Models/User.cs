using UnitOfWorkPattern.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace UnitOfWorkPattern.Models
{
	public class User : IAuditable
	{
		public int Id { get; set; }

		public string Name { get; set; }

		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }

		[DataType(DataType.Password)]
		public string Password { get; set; }
	}
}
