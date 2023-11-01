using UnitOfWorkPattern.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace UnitOfWorkPattern.Models
{
	public class Student : IAuditable
	{
		public int Id { get; set; }

		public string Name { get; set; }

		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }

	}
}
