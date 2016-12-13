// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using LeadPipe.Net.FiniteStateMachine;
using Moq;
using NUnit.Framework;
using System.Linq;

namespace LeadPipe.Net.Tests.FiniteStateMachineTests
{
    /// <summary>
    /// AvailableTransitions property tests.
    /// </summary>
    [TestFixture]
    public class AvailableTransitionsShould
    {
        /// <summary>
        /// The closed state.
        /// </summary>
        private IFiniteState closedState;

        /// <summary>
        /// The close transition.
        /// </summary>
        private IFiniteStateTransition closeTransition;

        /// <summary>
        /// The machine.
        /// </summary>
        private IFiniteStateMachine<FiniteStateMachineHistoryEntry> machine;

        /// <summary>
        /// The open state.
        /// </summary>
        private IFiniteState openState;

        /// <summary>
        /// The open transition.
        /// </summary>
        private IFiniteStateTransition openTransition;

        /// <summary>
        /// The start transition.
        /// </summary>
        private IFiniteStateTransition startTransition;

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