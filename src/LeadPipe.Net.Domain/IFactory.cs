// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IFactory.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net.Domain
{
	/// <summary>
	/// A marker interface that indicates the type is a factory. Usage is completely optional.
	/// </summary>
	/// <remarks>Page 136 - Evans, Eric. Domain Driven Design. 2004. Addison-Wesley. September 2010</remarks>
	public interface IFactory
	{
        /*
         * Shift the responsibility for creating instances of complex objects and AGGREGATES to a
         * separate object, which may itself have no responsibility in the domain model but is
         * still part of the domain design. Provide an interface that encapsulates all complex
         * assembly and that does not require the client to reference the concrete classes of the
         * objects being instantiated. Create entire AGGREGATES as a piece, enforcing their
         * invariants.
         * 
         * Page 138 - Evans, Eric. Domain Driven Design. 2004. Addison-Wesley. September 2010
         */
    }
}