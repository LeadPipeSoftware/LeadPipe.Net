// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IWithFinder.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net.Domain
{
	/// <summary>
	/// The interface for objects that employ a finder.
	/// </summary>
	/// <typeparam name="TFinder">
	/// The type of the finder.
	/// </typeparam>
	public interface IWithFinder<TFinder>
	{
		#region Public Properties

		/// <summary>
		/// Gets the entity finder interface.
		/// </summary>
		TFinder Find { get; }

		#endregion
	}
}