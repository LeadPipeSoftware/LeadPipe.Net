// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CurrentTransitionsShould.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net.Core.Tests.FiniteStateMachineTests
{
	using System.Linq;

	using LeadPipe.Net.Core.FiniteStateMachine;

	using NUnit.Framework;

	/// <summary>
	/// CurrentTransitions property tests.
	/// </summary>
	[TestFixture]
	public class CurrentTransitionsShould
	{
		/// <summary>
		/// The machine.
		/// </summary>
		private IFiniteStateMachine<FiniteStateMachineHistoryEntry> machine;

		/// <summary>
		/// The start transition.
		/// </summary>
		private IFiniteStateTransition startTransition;

		/// <summary>
		/// The open transition.
		/// </summary>
		private IFiniteStateTransition openTransition;

		/// <summary>
		/// The close transition.
		/// </summary>
		private IFiniteStateTransition closeTransition;

		/// <summary>
		/// The open state.
		/// </summary>
		private IFiniteState openState;

		/// <summary>
		/// The closed state.
		/// </summary>
		private IFiniteState closedState;

		#region Public Methods

		/// <summary>
		/// Tests to make sure that all registered transitions are returned.
		/// </summary>
		[Test]
		public void ReturnAllAvailableTransitions()
		{
			// Act
			this.machine.RegisterState(this.openState);

			// Assert
			Assert.IsTrue(this.machine.CurrentTransitions.Contains(this.closeTransition));
		}

		#endregion

		/// <summary>
		/// Runs before each test.
		/// </summary>
		[SetUp]
		public void TestSetup()
		{
			// Create our states...
			this.openState = new FiniteState(0, "Open");
			this.closedState = new FiniteState(1, "Closed");

			// Create our transitions...
			this.startTransition = new FiniteStateTransition(0, "New", new FiniteStateMachineTransitionReason("0", "New"), this.openState);

			this.openTransition = new FiniteStateTransition(1, "Open", new FiniteStateMachineTransitionReason("1", "Opened"), this.closedState, this.openState);
			this.closeTransition = new FiniteStateTransition(2, "Close", new FiniteStateMachineTransitionReason("2", "Closed"), this.openState, this.closedState);

			// Add our transitions to our states...
			this.openState.RegisterTransition(this.closeTransition);
			this.closedState.RegisterTransition(this.openTransition);

			// Create our machine...
			this.machine = new FiniteStateMachine(this.startTransition);
		}
	}
}