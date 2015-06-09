// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ClearShould.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace LeadPipe.Net.Domain.Tests.DomainEventingTests
{
	/// <summary>
	/// The DomainEvents Clear method tests.
	/// </summary>
	public class ClearShould
	{
		#region Public Methods

		/// <summary>
		/// Ensures that registered callback actions are cleared.
		/// </summary>
		[Test]
		public void ClearAllCallbackActions()
		{
			DomainEvents.Register<TestDomainEvent>(x => x.NewName = "GOT IT");

			DomainEvents.Clear();

			var actions = Local.Data[DomainEvents.DomainEventActionsKey] as List<Delegate>;

			Assert.That(actions == null);
		}

		#endregion
	}
}