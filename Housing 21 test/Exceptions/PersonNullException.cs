namespace Housing_21_test.Exceptions
{
	public class PersonNullException : Exception
	{
		public PersonNullException()
		{
			
		}

		public PersonNullException(string message) : base(message)
		{
			
		}

		public PersonNullException(string message, Exception innerException) : base(message, innerException)
		{
			
		}
	}
}
