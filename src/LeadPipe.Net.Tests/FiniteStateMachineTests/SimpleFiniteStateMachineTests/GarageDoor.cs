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

using System.Linq;
using LeadPipe.Net.FiniteStateMachine;

namespace LeadPipe.Net.Tests.FiniteStateMachineTests.SimpleFiniteStateMachineTests
{
	public enum GarageDoorStatus
	{
		Open,
		ClosedAndUnlocked,
		ClosedAndLocked
	}

	/// <summary>
	/// The garage door.
	/// </summary>
	public class GarageDoor : SimpleFiniteStateMachine<GarageDoorStatus, SimpleFiniteState<GarageDoorStatus>>
	{
		public GarageDoor()
			: base(GarageDoorStatus.Open)
		{
		}

		/// <summary>
		/// Gets a value indicating whether the garage door can close.
		/// </summary>
		public bool CanClose
		{
			get
			{
				return CanTransitionTo(GarageDoorStatus.ClosedAndUnlocked);
			}
		}

		/// <summary>
		/// Gets a value indicating whether the garage door can lock.
		/// </summary>
		public bool CanLock
		{
			get
			{
				return CanTransitionTo(GarageDoorStatus.ClosedAndLocked);
			}
		}

		/// <summary>
		/// Gets a value indicating whether the garage door can open.
		/// </summary>
		public bool CanOpen
		{
			get
			{
				return CanTransitionTo(GarageDoorStatus.Open);
			}
		}

		/// <summary>
		/// Gets a value indicating whether the garage door can be unlocked.
		/// </summary>
		public bool CanUnlock
		{
			get
			{
				return CanTransitionTo(GarageDoorStatus.ClosedAndUnlocked);
			}
		}

		/// <summary>
		/// Gets a value indicating whether the garage door is closed.
		/// </summary>
		public bool IsClosed
		{
			get
			{
				return Status == GarageDoorStatus.ClosedAndUnlocked || Status == GarageDoorStatus.ClosedAndLocked;
			}
		}

		/// <summary>
		/// Gets a value indicating whether the garage door is locked.
		/// </summary>
		public bool IsLocked
		{
			get
			{
				return Status == GarageDoorStatus.ClosedAndLocked;
			}
		}

		/// <summary>
		/// Gets a value indicating whether the garage door is open.
		/// </summary>
		public bool IsOpen
		{
			get
			{
				return Status == GarageDoorStatus.Open;
			}
		}

		/// <summary>
		/// Closes the garage door.
		/// </summary>
		public void Close()
		{
			PerformTransition(GarageDoorStatus.ClosedAndUnlocked, "Closed");
		}

		/// <summary>
		/// Locks the garage door.
		/// </summary>
		public void Lock()
		{
			// If the door isn't closed then close it...
			if (!IsClosed)
			{
				Close();
			}

			PerformTransition(GarageDoorStatus.ClosedAndLocked, "Locked");
		}

		/// <summary>
		/// Opens the garage door.
		/// </summary>
		public void Open()
		{
			PerformTransition(GarageDoorStatus.Open, "Opened");
		}

		/// <summary>
		/// Unlocks the garage door.
		/// </summary>
		public void Unlock()
		{
			PerformTransition(GarageDoorStatus.ClosedAndUnlocked, "Unlocked");
		}

		/// <summary>
		/// Initializes the states.
		/// </summary>
		protected override void InitializeStates()
		{
			var open = new SimpleFiniteState<GarageDoorStatus>(GarageDoorStatus.Open);
			var closedAndLocked = new SimpleFiniteState<GarageDoorStatus>(GarageDoorStatus.ClosedAndLocked);
			var closedAndUnlocked = new SimpleFiniteState<GarageDoorStatus>(GarageDoorStatus.ClosedAndUnlocked);

			open.AddTransition(closedAndUnlocked);

			closedAndUnlocked.AddTransition(closedAndLocked);
			closedAndUnlocked.AddTransition(open);

			closedAndLocked.AddTransition(closedAndUnlocked);

			states.Add(GarageDoorStatus.Open, open);
			states.Add(GarageDoorStatus.ClosedAndLocked, closedAndLocked);
			states.Add(GarageDoorStatus.ClosedAndUnlocked, closedAndUnlocked);
		}

		protected override SimpleFiniteStateMachineHistoryEntry<GarageDoorStatus> BuildHistoryEntry(GarageDoorStatus newStateName, string reason, string comments)
		{
			var entryNumber = 1;

			if (History.Entries.Any())
			{
				entryNumber = History.Entries.Max(x => x.EntryNumber) + 1;
			}

			var historyEntry = new SimpleFiniteStateMachineHistoryEntry<GarageDoorStatus>(entryNumber, newStateName, reason, comments);

			return historyEntry;
		}
	}
}