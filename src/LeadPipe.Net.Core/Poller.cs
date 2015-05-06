// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Poller.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace LeadPipe.Net.Core
{
	using System;
	using System.Diagnostics;
	using System.Threading;

	using LeadPipe.Net.Core.Extensions;

	/// <summary>
	/// Provides polling capabilities.
	/// </summary>
	public class Poller
	{
		#region Constants and Fields

		/// <summary>
		/// The timer.
		/// </summary>
		private static Timer timer;

		/// <summary>
		/// The maximum number of times to poll.
		/// </summary>
		private int maximumRetries;

		/// <summary>
		/// The poll function.
		/// </summary>
		private Func<bool> pollFunction;

		#endregion

		/// <summary>
		/// The poller state.
		/// </summary>
		public enum PollerState
		{
			/// <summary>
			/// The poller is polling.
			/// </summary>
			Polling,

			/// <summary>
			/// The polling finished (the poll function returned true).
			/// </summary>
			Finished,

			/// <summary>
			/// The polling timed out.
			/// </summary>
			TimedOut,

			/// <summary>
			/// The poller was reset (Start was called again).
			/// </summary>
			Reset
		}

		#region Public Properties

		/// <summary>
		/// Gets a value indicating whether this instance is polling.
		/// </summary>
		public bool IsPolling
		{
			get
			{
				return this.State == PollerState.Polling;
			}
		}

		/// <summary>
		/// Gets or sets the poll count.
		/// </summary>
		public int PollCount { get; protected set; }

		/// <summary>
		/// Gets or sets the polling result.
		/// </summary>
		public PollerState State { get; protected set; }

		#endregion

		#region Public Methods and Operators

		/// <summary>
		/// Starts the specified poll function.
		/// </summary>
		/// <param name="pollFunction">The poll function.</param>
		/// <param name="dueTime">The due time.</param>
		/// <param name="period">The milliseconds between polls.</param>
		/// <param name="maximumRetries">The maximum retries.</param>
		public void Start(Func<bool> pollFunction, int dueTime = 0, int period = 3000, int maximumRetries = 5)
		{
			Guard.Will.ProtectAgainstNullArgument(() => pollFunction);

			Debug.WriteLine(DateTime.Now.ToString().FormattedWith("POLL START: {0}"));

			if (dueTime < 0)
			{
				return;
			}

			this.pollFunction = pollFunction;

			this.maximumRetries = maximumRetries;

			var timerCallback = new TimerCallback(this.TimerCallback);

			var autoResetEvent = new AutoResetEvent(false);

			timer = new Timer(timerCallback, autoResetEvent, dueTime, period);

			this.State = PollerState.Polling;

			autoResetEvent.WaitOne();
		}

		#endregion

		#region Methods

		/// <summary>
		/// Stops the polling.
		/// </summary>
		/// <param name="state">The state.</param>
		/// <param name="pollerState">The poll result.</param>
		private void Stop(object state, PollerState pollerState)
		{
			Debug.WriteLine(pollerState.ToString().FormattedWith("POLL STOP: {0}"));

			var autoResetEvent = (AutoResetEvent)state;

			this.State = pollerState;

			this.PollCount = 0;

			autoResetEvent.Set();

			if (timer != null)
			{
				timer.Dispose();
				timer = null;
			}
		}

		/// <summary>
		/// The timer callback.
		/// </summary>
		/// <param name="state">The state.</param>
		private void TimerCallback(object state)
		{
			Debug.WriteLine(DateTime.Now.ToString().FormattedWith("POLLING: {0}"));

			// Increment the poll count...
			++this.PollCount;

			if (this.PollCount == this.maximumRetries)
			{
				this.Stop(state, PollerState.TimedOut);
			}
			else
			{
				// If the poll function returns true (indicating we're done)...
				if (this.pollFunction())
				{
					this.Stop(state, PollerState.Finished);
				}
			}
		}

		#endregion
	}
}