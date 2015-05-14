// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TransitionShould.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Linq;
using LeadPipe.Net.Extensions;
using LeadPipe.Net.FiniteStateMachine;
using NUnit.Framework;

namespace LeadPipe.Net.Tests.FiniteStateMachineTests.FiniteStateTransitionTests
{
	/// <summary>
	/// Transition method tests.
	/// </summary>
	[TestFixture]
	public class TransitionShould
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
		public void TransitionToState()
		{
			// Act
			var resultingState = this.closeTransition.Transition();

			// Assert
			Assert.IsTrue(resultingState == this.closedState);
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

		/// <summary>
		/// Tests to make sure that blank transition constructs with the transition success equal to false.
		/// </summary>
		[Test]
		public void ConstructWithTransitionSucceededEqualToFalse()
		{
			// Act
			var transition = new FiniteStateTransition(1, "TEST", new FiniteStateMachineTransitionReason("0", "BLARG"), this.openState);

			// Assert
			Assert.That(transition.TransitionSucceeded.IsFalse());
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