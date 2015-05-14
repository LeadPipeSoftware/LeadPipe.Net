// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TransitionsShould.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Linq;
using LeadPipe.Net.FiniteStateMachine;
using NUnit.Framework;

namespace LeadPipe.Net.Tests.FiniteStateMachineTests.FiniteStateTests
{
	/// <summary>
	/// Transitions property tests.
	/// </summary>
	[TestFixture]
	public class TransitionsShould
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
		/// Tests to make sure that a registered transition is returned.
		/// </summary>
		[Test]
		public void ReturnRegisteredTransitions()
		{
			// Assert
			Assert.IsTrue(this.openState.Transitions.Contains(this.closeTransition));
		}

		/// <summary>
		/// Tests to make sure that a registered transition is returned.
		/// </summary>
		[Test]
		public void ReturnAllRegisteredTransitions()
		{
			// Assert
			Assert.IsTrue(this.openState.Transitions.Count().Equals(1));
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
			this.machine = new FiniteStateMachine.FiniteStateMachine(this.startTransition);
		}
	}
}