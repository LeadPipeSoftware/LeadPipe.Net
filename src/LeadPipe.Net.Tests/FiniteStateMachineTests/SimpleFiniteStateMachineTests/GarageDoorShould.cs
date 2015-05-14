// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GarageDoorShould.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using NUnit.Framework;

namespace LeadPipe.Net.Tests.FiniteStateMachineTests.SimpleFiniteStateMachineTests
{
	/// <summary>
	/// Tests using the sample GarageDoor and its states.
	/// </summary>
	[TestFixture]
	public class GarageDoorShould
	{
		/// <summary>
		/// The garage door.
		/// </summary>
		private GarageDoor door;

		#region Public Methods

		/// <summary>
		/// Tests to make sure that the door's state changes to closed if it is open and the close method is called.
		/// </summary>
		[Test]
		public void CloseGivenStateIsOpen()
		{
			// Act
			this.door.Close();

			// Assert
			Assert.IsFalse(this.door.IsOpen, "The door should NOT be open, but claims that it is.");
			Assert.IsTrue(this.door.IsClosed, "The door should be closed, but claims that it is not.");
			Assert.IsFalse(this.door.IsLocked, "The door should NOT be locked, but claims that it is.");
		}

		/// <summary>
		/// Tests to make sure that the door's state changes to open if it is closed and the open method is called.
		/// </summary>
		[Test]
		public void OpenGivenStateIsClosed()
		{
			// Act
			this.door.Close();
			this.door.Open();

			// Assert
			Assert.IsTrue(this.door.IsOpen, "The door should be open, but claims that it is not.");
			Assert.IsFalse(this.door.IsClosed, "The door should NOT be closed, but claims that it is.");
			Assert.IsFalse(this.door.IsLocked, "The door should NOT be locked, but claims that it is.");
		}

		/// <summary>
		/// Tests to make sure that the door's state changes to closed if it is open and the close method is called.
		/// </summary>
		[Test]
		public void LockGivenStateIsOpen()
		{
			// Act
			this.door.Lock();

			// Assert
			Assert.IsFalse(this.door.IsOpen, "The door should NOT be open, but claims that it is.");
			Assert.IsTrue(this.door.IsClosed, "The door should be closed, but claims that it is not.");
			Assert.IsTrue(this.door.IsLocked, "The door should be locked, but claims that it is not.");
		}

		/// <summary>
		/// Tests to make sure that the door's state changes to closed if it is open and the close method is called.
		/// </summary>
		[Test]
		public void LockGivenStateIsClosed()
		{
			// Act
			this.door.Close();
			this.door.Lock();

			// Assert
			Assert.IsFalse(this.door.IsOpen, "The door should NOT be open, but claims that it is.");
			Assert.IsTrue(this.door.IsClosed, "The door should be closed, but claims that it is not.");
			Assert.IsTrue(this.door.IsLocked, "The door should be locked, but claims that it is not.");
		}

		#endregion

		/// <summary>
		/// Runs before each test.
		/// </summary>
		[SetUp]
		public void TestSetup()
		{
			this.door = new GarageDoor();
		}
	}
}