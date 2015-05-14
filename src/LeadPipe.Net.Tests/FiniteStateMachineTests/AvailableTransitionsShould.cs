// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AvailableTransitionsShould.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Linq;
using LeadPipe.Net.FiniteStateMachine;
using Moq;
using NUnit.Framework;

namespace LeadPipe.Net.Tests.FiniteStateMachineTests
{
	/// <summary>
	/// AvailableTransitions property tests.
	/// </summary>
	[TestFixture]
	public class AvailableTransitionsShould
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
		/// Tests to make sure that all executable transitions are returned.
		/// </summary>
		[Test]
		public void ReturnAllExecutableTransitions()
		{
			// Act
			this.machine.RegisterState(this.openState);

			// Assert
			Assert.IsTrue(this.machine.AvailableTransitions.Contains(this.closeTransition));
		}

		/// <summary>
		/// Tests to make sure that a non-executable transition is not returned.
		/// </summary>
		[Test]
		public void NotReturnTransitionGivenTransitionNotExecutable()
		{
			// Arrange
			var mock = new Mock<IFiniteStateTransition>();

			mock.Setup(x => x.Name).Returns("AlwaysFalse");
			mock.Setup(x => x.Reason).Returns(new FiniteStateMachineTransitionReason("9", "Just Testing"));
			mock.Setup(x => x.EndState).Returns(this.closedState);
			mock.Setup(x => x.CanTransition()).Returns(false);

			this.openState.RemoveTransition(this.closeTransition);
			this.openState.RegisterTransition(mock.Object);

			this.machine.RegisterState(this.openState);

			// Assert
			Assert.IsFalse(this.machine.AvailableTransitions.Contains(mock.Object));
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