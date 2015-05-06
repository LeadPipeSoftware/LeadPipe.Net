// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GarageDoor.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

/*
 * About This Example
 * --------------------------------------------------------------------------------------------------------------------
 * This is an example of how you might use a Finite State Machine implementation in order to give something (a garage
 * door in our case) FSM characteristics and capabilities. By using the FSM implementation, we're standardizing how
 * these characteristics and capabilities are granted as well as taking advantage of features such as History. Without
 * a reasonable FSM implementation, business rules, codes, statuses, states, and so forth can become scattered and hard
 * to decipher and debug.
 * 
 * It should be noted that this particular example is moderately verbose. It isn't necessary to define all of the
 * methods, properties, enumerations, and so forth as shown here. It's also not necessary to put everything into a
 * single class. You may choose to use partial classes or even create your own FSM that the owning type holds a single
 * reference to. Ultimately, you have to decide what's right based on the circumstances.
 * 
 * Finite State Machine
 * --------------------------------------------------------------------------------------------------------------------
 * A Finite State Machine (FSM) is the mechanism by which we can model an abstract machine by defining a finite number
 * of States as well as the Transitions between those States. For example, a door may be considered an FSM in that it
 * has States (open and closed) as well as Transitions (open and close) that are triggered by Events (opened and
 * closed) that are invoked by object methods (door.Open and door.Close).
 * 
 * State
 * --------------------------------------------------------------------------------------------------------------------
 * The values of an object's attributes represent State. For example, if a door is anything more than closed then it
 * is considered to be in the open state (Door.PercentOpen > 0).
 * 
 * Transitions
 * --------------------------------------------------------------------------------------------------------------------
 * When certain Events occur, an object progresses from one State to another. For example, when a door (object) is
 * opened (Event), it changes (Transition) from closed (State) to open (State). Each State defines what is possible by
 * registering Transitions. Each Transition causes the object to arrive at a particular State. Transitions often have
 * one or more business rules that determine if the they can be executed.
 * 
 * Transition Reasons
 * --------------------------------------------------------------------------------------------------------------------
 * When a Transition occurs, we often want to know why it occurred. For example, when a door transitions from closed to
 * open, we might like to know why. The simplest form is to simply say that the reason it transitioned from closed to
 * open is because it was opened. On the other hand, if our door were perhaps the door to a bank vault, we might want
 * more explicit reasons such as "Depositing Money", "Withdrawing Money", and "Security Check".
 * 
 * Events
 * --------------------------------------------------------------------------------------------------------------------
 * When something important happens to an object, it is considered an Event. For example, when someone encounters a
 * door (object) that is closed (State), they may choose to open it (object.Method) which causes the door to be opened
 * (Event) which, in turn, causes it to change (Transition) from closed (State) to open (State).
 * 
 * A Note About Status Versus State
 * --------------------------------------------------------------------------------------------------------------------
 * It's far too common for novices to confuse State with Status. In some cases, a literal one-to-one translation is
 * just fine. For example, it may be enough to say that a door's Status is the same as its State (open or closed). More
 * often than not, however, Status is actually more than just State. For example, while a door's State is either open
 * or closed, it's Status might be open, closed and unlocked, closed and locked, and so on. In other words, Status is
 * often just a read-only representation of a combination of State with other information.
 */

namespace LeadPipe.Net.Core.Tests.FiniteStateMachineTests
{
	using System.Linq;

	using LeadPipe.Net.Core.Extensions;
	using LeadPipe.Net.Core.FiniteStateMachine;

	/// <summary>
	/// The garage door.
	/// </summary>
	public class GarageDoor
	{
		#region Constants and Fields

		/// <summary>
		/// The garage door close transition.
		/// </summary>
		private IFiniteStateTransition closeTransition;

		/// <summary>
		/// The garage door closed state.
		/// </summary>
		private IFiniteState closedState;

		/// <summary>
		/// The garage door lock transition.
		/// </summary>
		private IFiniteStateTransition lockTransition;

		/// <summary>
		/// The garage door open state.
		/// </summary>
		private IFiniteState openState;

		/// <summary>
		/// The garage door open transition.
		/// </summary>
		private IFiniteStateTransition openTransition;

		/// <summary>
		/// The finite state machine.
		/// </summary>
		private IFiniteStateMachine<FiniteStateMachineHistoryEntry> stateMachine;

		#endregion

		#region Constructors and Destructors

		/// <summary>
		/// Initializes a new instance of the <see cref="GarageDoor"/> class.
		/// </summary>
		public GarageDoor()
		{
			this.InitializeStateMachine();
		}

		#endregion

		#region Enums

		/// <summary>
		/// The garage door states.
		/// </summary>
		public enum GarageDoorState
		{
			/// <summary>
			/// The garage door is open.
			/// </summary>
			Open,

			/// <summary>
			/// The garage door is closed.
			/// </summary>
			Closed
		}

		/// <summary>
		/// The garage door transitions.
		/// </summary>
		private enum GarageDoorTransition
		{
			/// <summary>
			/// Open the garage door.
			/// </summary>
			Open,

			/// <summary>
			/// Close the garage door.
			/// </summary>
			Close,

			/// <summary>
			/// Lock the garage door.
			/// </summary>
			Lock
		}

		#endregion

		#region Public Properties

		/// <summary>
		/// Gets a value indicating whether the garage door can close.
		/// </summary>
		public bool CanClose
		{
			get
			{
				return this.stateMachine.CurrentState.Equals(this.openState);
			}
		}

		/// <summary>
		/// Gets a value indicating whether the garage door can lock.
		/// </summary>
		public bool CanLock
		{
			get
			{
				return !this.stateMachine.CurrentState.Equals(this.IsLocked);
			}
		}

		/// <summary>
		/// Gets a value indicating whether the garage door can open.
		/// </summary>
		public bool CanOpen
		{
			get
			{
				return this.stateMachine.CurrentState.Equals(this.closedState) && this.IsLocked.IsFalse();
			}
		}

		/// <summary>
		/// Gets a value indicating whether the garage door can be unlocked.
		/// </summary>
		public bool CanUnlock
		{
			get
			{
				return this.IsClosed && this.IsLocked;
			}
		}

		/// <summary>
		/// Gets a value indicating whether the garage door is closed.
		/// </summary>
		public bool IsClosed
		{
			get
			{
				return this.stateMachine.CurrentState.Equals(this.closedState);
			}
		}

		/// <summary>
		/// Gets or sets a value indicating whether the garage door is locked.
		/// </summary>
		public bool IsLocked { get; protected set; }

		/// <summary>
		/// Gets a value indicating whether the garage door is open.
		/// </summary>
		public bool IsOpen
		{
			get
			{
				return this.stateMachine.CurrentState.Equals(this.openState);
			}
		}

		/// <summary>
		/// Gets the number of times the garage door has been opened.
		/// </summary>
		public int OpenCount
		{
			get
			{
				return this.stateMachine.History.Entries.Count(x => x.StateCode.Equals(this.openState.Code));
			}
		}

		/// <summary>
		/// Gets the current state of the garage door.
		/// </summary>
		public GarageDoorState CurrentState
		{
			get
			{
				return (GarageDoorState)this.stateMachine.CurrentState.Code;
			}
		}

		#endregion

		#region Public Methods and Operators

		/// <summary>
		/// Closes the garage door.
		/// </summary>
		public void Close()
		{
			this.stateMachine.PerformTransition(this.closeTransition);
		}

		/// <summary>
		/// Locks the garage door.
		/// </summary>
		public void Lock()
		{
			// If the door isn't closed then close it...
			if (!this.IsClosed)
			{
				this.stateMachine.PerformTransition(this.closeTransition);
			}

			this.stateMachine.PerformTransition(this.lockTransition);

			this.IsLocked = true;
		}

		/// <summary>
		/// Opens the garage door.
		/// </summary>
		public void Open()
		{
			this.stateMachine.PerformTransition(this.openTransition);
		}

		/// <summary>
		/// Unlocks the garage door.
		/// </summary>
		public void Unlock()
		{
			if (this.CanUnlock)
			{
				this.IsLocked = false;
			}
		}

		#endregion

		#region Methods

		/// <summary>
		/// Initializes the garage door state machine.
		/// </summary>
		private void InitializeStateMachine()
		{
			// Create the garage door states...
			this.openState = new FiniteState((int)GarageDoorState.Open, "Open");
			this.closedState = new FiniteState((int)GarageDoorState.Closed, "Closed");

			// Create the garage door transitions...
			this.openTransition = new FiniteStateTransition(
				(int)GarageDoorTransition.Open,
				"Open",
				new FiniteStateMachineTransitionReason("Opened"),
				this.openState,
				() => this.openState,
				() => this.CanOpen);

			this.lockTransition = new FiniteStateTransition(
				(int)GarageDoorTransition.Lock,
				"Lock",
				new FiniteStateMachineTransitionReason("Closed and Locked"),
				this.closedState,
				() => this.closedState,
				() => this.CanLock);

			this.closeTransition = new FiniteStateTransition(
				(int)GarageDoorTransition.Close,
				"Close",
				new FiniteStateMachineTransitionReason("Closed"),
				this.closedState,
				() => this.closedState,
				() => this.CanClose);

			// Register the garage door transitions with their respective garage door states...
			this.openState.RegisterTransition(this.closeTransition);
			this.openState.RegisterTransition(this.lockTransition);
			this.closedState.RegisterTransition(this.openTransition);
			this.closedState.RegisterTransition(this.lockTransition);

			// Create the garage door state machine...
			this.stateMachine = new FiniteStateMachine(this.openState);

			// Register the garage door states with the garage door state machine...
			this.stateMachine.RegisterState(this.openState);
			this.stateMachine.RegisterState(this.closedState);
		}

		#endregion
	}
}