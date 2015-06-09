// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RegisterShould.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace LeadPipe.Net.Domain.Tests.DomainEventingTests
{
	/// <summary>
	/// The DomainEvents Register method tests.
	/// </summary>
	public class RegisterShould
	{
		#region Public Methods

		/// <summary>
		/// Ensures that registered callback actions are stored in local data.
		/// </summary>
		[Test]
		public void StoreTheCallbackActionInLocalData()
		{
			DomainEvents.Clear();

			DomainEvents.Register<TestDomainEvent>(x => x.NewName = "GOT IT");

			var actions = Local.Data[DomainEvents.DomainEventActionsKey] as List<Delegate>;

			Assert.That(actions != null);

			Assert.That(actions.Count.Equals(1));
		}

		#endregion
	}
}