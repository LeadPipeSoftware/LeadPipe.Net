// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUseSchema.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net.Data
{
	/// <summary>
	/// The interface for objects that use schema.
	/// </summary>
	public interface IUseSchema
	{
		/// <summary>
		/// Gets the name of the schema.
		/// </summary>
		string SchemaName { get; }
	}
}