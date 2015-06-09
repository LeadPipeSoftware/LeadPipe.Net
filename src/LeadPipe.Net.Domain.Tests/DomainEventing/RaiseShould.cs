// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RaiseShould.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using NUnit.Framework;

namespace LeadPipe.Net.Domain.Tests.DomainEventing
{
	/// <summary>
	/// The DomainEvents Raise method tests.
	/// </summary>
	public class RaiseShould
	{
		#region Public Methods

		/// <summary>
		/// Ensures that registered callback actions are stored in local data.
		/// </summary>
		[Test]
		public void RaiseRegisteredCallbackActions()
		{
			var testEntity = new TestEntity("FOO", "PEANUT");

			var newName = string.Empty;

			DomainEvents.Register<TestDomainEvent>(x => newName = x.NewName);

			testEntity.ChangeName("BAR");

			Assert.That(newName.Equals("BAR"));
		}

		#endregion
	}
}