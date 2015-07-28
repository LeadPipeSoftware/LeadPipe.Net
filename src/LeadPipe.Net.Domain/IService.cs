// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IService.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net.Domain
{
	/// <summary>
	/// A marker interface that indicates the type is a service. Usage is completely optional.
	/// </summary>
	/// <remarks>Page 104 - Evans, Eric. Domain Driven Design. 2004. Addison-Wesley. September 2010</remarks>
	public interface IService
	{
        /*
         * When a significant process or transformation in the domain is not a natural
         * responsibility of an ENTITY or VALUE OBJECT, add an operation to the model as a
         * standalone interface declared as a SERVICE. Define the interface in terms of the
         * language of the model and make sure the operation name is part of the UBIQUITOUS
         * LANGUAGE. Make the SERVICE stateless.
         * 
         * Page 106 - Evans, Eric. Domain Driven Design. 2004. Addison-Wesley. September 2010
         */
    }
}