﻿using System.ComponentModel.DataAnnotations;

namespace Housing_21_test.Models
{
	public class Person
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "Name is required.")]
		[StringLength(50, ErrorMessage = "Name must be at most 50 characters.")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Date of Birth is required.")]
		[DataType(DataType.Date)]
		public DateTime DateOfBirth { get; set; }

		[Required(ErrorMessage = "Telephone Number is required.")]
		[StringLength(20, ErrorMessage = "Telephone Number must be at most 20 characters.")]
		public string TelephoneNumber { get; set; }

		[Required(ErrorMessage = "Email is required.")]
		[EmailAddress(ErrorMessage = "Invalid email address.")]
		public string Email { get; set; }
	}
}
 