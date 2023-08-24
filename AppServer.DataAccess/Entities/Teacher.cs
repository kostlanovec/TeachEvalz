using System.ComponentModel.DataAnnotations;

namespace AppServer.DataAccess.Entities
{
	/// <summary>
	/// Entita učitele ukládají informace o jménu, příjemní, pohlaví a kolekci předmětu.
	/// </summary>
	public class Teacher
	{
		protected Teacher() {}

		/// <summary>
		/// Primární klíč učitele.
		/// </summary>
		[Key]
		public int Id
		{
			get;
			set;
		}

		/// <summary>
		/// Jméno učitele.
		/// </summary>
		public string FirstName
		{
			get;
			set;
		}

		/// <summary>
		/// Přijemení učitele.
		/// </summary>
		public string LastName
		{
			get;
			set;
		}

		/// <summary>
		/// Pohlaví učitele.
		/// </summary>
		public string Gender
		{
			get;
			set;
		}

		/// <summary>
		/// Kolekce předmětu.
		/// </summary>
		public virtual ICollection<Class> Classes
		{
			get;
			set;
		}
	}
}
