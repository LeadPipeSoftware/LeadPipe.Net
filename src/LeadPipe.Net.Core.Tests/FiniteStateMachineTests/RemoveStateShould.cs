// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RemoveStateShould.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net.Core.Tests.FiniteStateMachineTests
{
	using System.Linq;

	using LeadPipe.Net.Core.FiniteStateMachine;

	using NUnit.Framework;

	/// <summary>
	/// RemoveState method tests.
	/// </summary>
	[TestFixture]
	public class RemoveStateShould
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
		/// Tests to make sure that a state that is not currently used is removed.
		/// </summary>
		[Test]
		public void RemoveState()
		{
			// Act
			this.machine.RemoveState(this.closedState);

			// Assert
			Assert.IsFalse(this.machine.States.Contains(this.closedState));
		}

		/// <summary>
		/// Tests to make sure that an exception is thrown when trying to remove a state that is in use.
		/// </summary>
		[Test]
		[ExpectedException(typeof(StateInUseException))]
		public void ThrowExceptionGivenStateInUse()
		{
			// Act
			this.machine.RemoveState(this.openState);
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

			// Add our states...
			this.machine.RegisterState(this.openState);
			this.machine.RegisterState(this.closedState);
		}
	}
}