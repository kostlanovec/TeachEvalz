using System.ComponentModel.DataAnnotations;

namespace AppServer.DataAccess.Entities
{
	/// <summary>
	/// Třída se jménem.
	/// </summary>
	public class Class
	{

		protected Class(){}
		/// <summary>
		/// Primární klíč.
		/// </summary>
		[Key]
		public int Id
		{
			get;
			set;
		}

		/// <summary>
		/// Jméno třídy.
		/// </summary>
		public string Name
		{
			get;
			set;
		}

		/// <summary>
		/// Vytváří novou instanci třídy třídy.
		/// </summary>
		public static Class Create(string name)
		{

			var newclass = new Class()
			{
				Name = name
			};

			return newclass;
		}
	}
}
