// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PollerShould.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using LeadPipe.Net.Extensions;
using NUnit.Framework;

namespace LeadPipe.Net.Tests.PollerTests
{
	/// <summary>
	/// The poller tests.
	/// </summary>
	[TestFixture]
	public class PollerShould
	{
		/// <summary>
		/// The number of times to run the polling function before returning true.
		/// </summary>
		private int functionRunLimit = 5;

		/// <summary>
		/// The number of times the polling function has run.
		/// </summary>
		private int functionRunCount;

		#region Public Methods

		/// <summary>
		/// Tests to ensure that the poller finishes when the polling function returns true.
		/// </summary>
		[Test]
		public void ReturnFinishedGivenPollingFunctionReturnsTrue()
		{
			this.functionRunLimit = 3;

			var poller = new Poller();

			poller.Start(() => true);

			Assert.That(poller.State == Poller.PollerState.Finished);
		}

		/// <summary>
		/// Tests to ensure that the poller times out when the polling function returns false.
		/// </summary>
		[Test]
		public void ReturnTimedOutGivenPollingFunctionReturnsFalse()
		{
			this.functionRunLimit = 3;

			var poller = new Poller();

			poller.Start(() => false);

			Assert.That(poller.State == Poller.PollerState.TimedOut);
		}

		/// <summary>
		/// Tests to ensure that the poller finishes when the polling function returns true after multiple attempts.
		/// </summary>
		[Test]
		public void ReturnFinishedGivenPollingFunctionReturnsTrueAfterMultipleAttempts()
		{
			this.functionRunLimit = 3;

			var poller = new Poller();

			poller.Start(this.PollingFunction);

			Assert.That(poller.State == Poller.PollerState.Finished);
		}

		#endregion

		#region Methods

		/// <summary>
		/// A little polling function that will return true after (n) attempts.
		/// </summary>
		/// <returns>True when complete.</returns>
		private bool PollingFunction()
		{
			++this.functionRunCount;

			Debug.WriteLine(DateTime.Now.ToString().FormattedWith("Polling function called at {0}."));

			Debug.WriteLine((this.functionRunCount >= this.functionRunLimit).ToString().FormattedWith("Polling function returning {0}."));

			return this.functionRunCount >= this.functionRunLimit;
		}

		#endregion
	}
}