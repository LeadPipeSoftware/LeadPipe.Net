// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IContextAware.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net.Configuration
{
	/// <summary>
	/// Defines an object that is context aware.
	/// </summary>
	public interface IContextAware
	{
		/// <summary>
		/// Gets the context.
		/// </summary>
		string Context { get; }
	}
}