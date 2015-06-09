// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IActiveDataSessionManager.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net.Data
{
	/// <summary>
	/// The active data session manager.
	/// </summary>
	/// <remarks>
	/// The ActiveSessionManager's job is to provide Singleton-style access to the active DataSession.
	/// </remarks>
	/// <typeparam name="T">The data session type.</typeparam>
	public interface IActiveDataSessionManager<T>
	{
		#region Public Properties

		/// <summary>
		/// Gets the current data session.
		/// </summary>
		/// <value>The current data session.</value>
		T Current { get; }

		/// <summary>
		/// Gets a value indicating whether an active data session exists.
		/// </summary>
		bool HasActiveDataSession { get; }

		/// <summary>
		/// Gets or sets the session key.
		/// </summary>
		string SessionKey { get; set; }

		#endregion

		#region Public Methods and Operators

		/// <summary>
		/// Clears the active data session.
		/// </summary>
		void ClearActiveDataSession();

		/// <summary>
		/// Sets the active data session.
		/// </summary>
		/// <param name="dataSession">The data session to set as active.</param>
		void SetActiveDataSession(T dataSession);

		#endregion
	}
}