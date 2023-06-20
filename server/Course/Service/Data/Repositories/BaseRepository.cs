using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RevWorld.Service
{
	public interface BaseRepository<T>
	{
		/// <summary>
		/// Create an object of type T and add it to the database.
		/// </summary>
		/// <param name="item"> Name of the object being created.</param>
		/// <returns>ID of the added object</returns>
		Task<int> Create(T item);

        /// <summary>
        /// Returns all fields in the database table.
        /// </summary>
        /// <returns>List of objects of type t</returns>
        Task<List<T>> TakeAll();
		/// <summary>
		/// Returns an object of type T with an identifier equal to id.
		/// </summary>
		/// <param name="id">Object Identifier</param>
		/// <returns>Found object of type T</returns>
		Task<T> TakeById(int id);
		/// <summary>
		/// Deletes an object with an ID equal to id.
		/// </summary>
		/// <param name="id">Object Identifier</param>
		Task DeleteById(int id);

	}
}
