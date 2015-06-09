// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPersistable.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net
{
	/// <summary>
	/// Defines an instance that is persistable.
	/// </summary>
	/// <typeparam name="TSurrogateIdentity">The type of the surrogate identity.</typeparam>
	/// <remarks>
	/// This is an implementation of the P of EAA Identity Field pattern. For more information, please visit
	/// http://www.martinfowler.com/eaaCatalog/identityField.html
	/// </remarks>
	public interface IPersistable<TSurrogateIdentity> : IAuditable
	{
		/// <summary>
		/// Gets or sets the surrogate id.
		/// </summary>
		TSurrogateIdentity Sid { get; set; }
	}

	/// <summary>
	/// Defines an instance that is persistable.
	/// </summary>
	/// <remarks>
	/// <para>
	/// This implementation of the IPersistable interface allows for the assignment of a persistence version. These are
	/// intended to make implementing an optimistic concurrency model based on version fairly easy.
	/// </para>
	/// </remarks>
	/// <typeparam name="TSurrogateIdentity">The type of the surrogate identity.</typeparam>
	/// <typeparam name="TVersion">The type of the version.</typeparam>
	public interface IPersistable<TSurrogateIdentity, TVersion> : IPersistable<TSurrogateIdentity>
	{
		/// <summary>
		/// Gets or sets the persistence version.
		/// </summary>
		TVersion PersistenceVersion { get; set; }
	}
}