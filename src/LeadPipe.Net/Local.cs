// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Local.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Web;

namespace LeadPipe.Net
{
	using System;
	using System.Collections;

	/// <summary>
	/// Provides a thread-safe storage mechanism that works in both HTTP and traditional contexts.
	/// </summary>
	/// <remarks>
	/// <para>
	/// In a web app we have the Http context for each request. Multiple requests from different clients can run at the
	/// same time but each of them runs on a different thread and has its own context. In this situation, this class
	/// will store the data in the context of the request.
	/// </para>
	/// <para>
	/// In a windows client app we have a single client that might run on different threads at the same time. In this
	/// situation we store the data in a so-called "thread-static" field. A thread-static field is not shared between
	/// different threads in the same application. To make a static field thread-static we decorate it with the
	/// [ThreadStatic] attribute.
	/// </para>
	/// </remarks>
	public static class Local
	{
		#region Constants and Fields

		/// <summary>
		/// Local data.
		/// </summary>
		private static readonly ILocalData data = new LocalData();

		#endregion

		#region Public Properties

		/// <summary>
		/// Gets the local data.
		/// </summary>
		public static ILocalData Data
		{
			get
			{
				return data;
			}
		}

		#endregion

		/// <summary>
		/// Represents local application data.
		/// </summary>
		private class LocalData : ILocalData
		{
			#region Constants and Fields

			/// <summary>
			/// The local data hash table key.
			/// </summary>
			private static readonly object LocalDataHashtableKey = new object();

			/// <summary>
			/// Local data.
			/// </summary>
			[ThreadStatic]
			private static Hashtable localData;

			#endregion

			#region Public Properties

			/// <summary>
			/// Gets a count of the local data items.
			/// </summary>
			public int Count
			{
				get
				{
					return LocalHashtable.Count;
				}
			}

			#endregion

			#region Properties

			/// <summary>
			/// Gets the local hash table.
			/// </summary>
			/// <remarks>
			/// We have to encapsulate initialization of localData in a property otherwise any thread
			/// other than main will see localData as always null.
			/// </remarks>
			private static Hashtable LocalHashtable
			{
				get
				{
					if (!RunningInWeb)
					{
						return localData ?? (localData = new Hashtable());
					}

					var webHashtable = HttpContext.Current.Items[LocalDataHashtableKey] as Hashtable;

					if (webHashtable == null)
					{
						webHashtable = new Hashtable();
						HttpContext.Current.Items[LocalDataHashtableKey] = webHashtable;
					}

					return webHashtable;
				}
			}

			/// <summary>
			/// Gets a value indicating whether the application is running in the web context.
			/// </summary>
			private static bool RunningInWeb
			{
				get
				{
					return HttpContext.Current != null;
				}
			}

			#endregion

			#region Public Indexers

			/// <summary>
			/// Gets or sets local data.
			/// </summary>
			/// <param name="key">The local data key.</param>
			/// <returns>The local data.</returns>
			public object this[object key]
			{
				get
				{
					return LocalHashtable[key];
				}

				set
				{
					LocalHashtable[key] = value;
				}
			}

			#endregion

			#region Public Methods and Operators

			/// <summary>
			/// Clears all local data.
			/// </summary>
			public void Clear()
			{
				LocalHashtable.Clear();
			}

			#endregion
		}
	}
}