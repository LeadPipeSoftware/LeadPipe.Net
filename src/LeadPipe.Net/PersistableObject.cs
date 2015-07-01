// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PersistableObject.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

namespace LeadPipe.Net
{
	using System;
	using System.Diagnostics.CodeAnalysis;

	/// <summary>
	/// The abstract base persistable object.
	/// </summary>
	/// <typeparam name="TSurrogateIdentity">
	/// The type of the surrogate identity.
	/// </typeparam>
	[SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass",
		Justification = "Reviewed. Suppression is OK here because we're merely building off a base type.")]
	public abstract class PersistableObject<TSurrogateIdentity> : IPersistable<TSurrogateIdentity, int>,
																  IEquatable<PersistableObject<TSurrogateIdentity>>
		where TSurrogateIdentity : IComparable
	{
		/*
		 * Alas, persistence is a leaky abstraction. However, just because something is an entity doesn't mean that we
		 * have to clutter it up with persistence concerns. Here we're keeping the notion of entity and an object that
		 * is persistable separate for what I hope are obvious reasons.
		 * 
		 * Many O/RM frameworks require a unique identifier for persistence purposes. Of course, you can use the domain
		 * identity for this purpose. However, it is often advisable to use a surrogate identity for this purpose. This
		 * identity has no meaning to the business, however, and effectively decouples what is ultimately just a
		 * persistence concern from the business concern and, therefore, shouldn't be leaked outside of the data layer.
		 */
		#region Public Properties

		/// <summary>
		/// Gets or sets the identity that created the object.
		/// </summary>
		public virtual string CreatedBy { get; set; }

		/// <summary>
		/// Gets or sets the date and time the instance was created.
		/// </summary>
		public virtual DateTime CreatedOn { get; set; }

		/// <summary>
		/// Gets a value indicating whether this instance is transient (no surrogate id has been set).
		/// </summary>
		/// <value>
		/// 	<c>true</c> if this instance is transient; otherwise, <c>false</c>.
		/// </value>
		public virtual bool IsTransient
		{
			get
			{
				return Equals(this.Sid, default(TSurrogateIdentity));
			}
		}

		/// <summary>
		/// Gets or sets the persistence version.
		/// </summary>
		public virtual int PersistenceVersion { get; set; }

		/// <summary>
		/// Gets or sets the surrogate (persistence) id.
		/// </summary>
		/// <value>
		/// The surrogate id.
		/// </value>
		public virtual TSurrogateIdentity Sid { get; set; }

		/// <summary>
		/// Gets or sets the identity that last updated the instance.
		/// </summary>
		public virtual string UpdatedBy { get; set; }

		/// <summary>
		/// Gets or sets the date and time the instance was last updated.
		/// </summary>
		public virtual DateTime? UpdatedOn { get; set; }

		#endregion

		#region Public Methods and Operators

		/// <summary>
		/// Implements the operator ==.
		/// </summary>
		/// <param name="persistableObject1">The persistableObject1.</param>
		/// <param name="persistableObject2">The persistableObject2.</param>
		/// <returns>
		/// The result of the operator.
		/// </returns>
		public static bool operator ==(PersistableObject<TSurrogateIdentity> persistableObject1, PersistableObject<TSurrogateIdentity> persistableObject2)
		{
			object obj1 = persistableObject1;
			object obj2 = persistableObject2;

			// If both objects are null then they are equal...
			if (obj1 == null && obj2 == null)
			{
				return true;
			}

			// If one of the objects is null then they are not equal...
			if (obj1 == null || obj2 == null)
			{
				return false;
			}

			// If both objects have a surrogate id then compare those...
			if (persistableObject1.Sid.Equals(default(TSurrogateIdentity)) == false && persistableObject2.Sid.Equals(default(TSurrogateIdentity)) == false)
			{
				return persistableObject1.Sid.CompareTo(persistableObject2.Sid) == 0;
			}

			// If either object has an empty surrogate id then try to compare the keys...
			if (persistableObject1.Sid.Equals(default(TSurrogateIdentity)) || persistableObject2.Sid.Equals(default(TSurrogateIdentity)))
			{
				var keyedObject1 = persistableObject1 as IKeyed;
				var keyedObject2 = persistableObject2 as IKeyed;

				if (keyedObject1 != null && keyedObject2 != null)
				{
					return String.Compare(keyedObject1.Key, keyedObject2.Key, StringComparison.Ordinal) == 0;
				}
			}

			// If the objects are of different types then they are not equal...
			if (persistableObject1.GetType() != persistableObject2.GetType())
			{
				//// TODO: If two objects are different, but have a sid collision (unlikely) we'll falsely report them as identical. Fix!
				return false;
			}

			// If we can't compare the surrogate id or the key then all we can do is compare the two objects straight-up...
			return obj1 == obj2;
		}

		/// <summary>
		/// Implements the operator !=.
		/// </summary>
		/// <param name="persistableObject1">The persistableObject1.</param>
		/// <param name="persistableObject2">The persistableObject2.</param>
		/// <returns>
		/// The result of the operator.
		/// </returns>
		public static bool operator !=(PersistableObject<TSurrogateIdentity> persistableObject1, PersistableObject<TSurrogateIdentity> persistableObject2)
		{
			return !(persistableObject1 == persistableObject2);
		}

		/// <summary>
		/// Indicates whether the current object is equal to another object of the same type.
		/// </summary>
		/// <param name="other">
		/// An object to compare with this object.
		/// </param>
		/// <returns>
		/// true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.
		/// </returns>
		public virtual bool Equals(PersistableObject<TSurrogateIdentity> other)
		{
			if (other == null)
			{
				return false;
			}

			return this == other;
		}

		/// <summary>
		/// Compares two persistable objects for equality.
		/// </summary>
		/// <param name="persistableObject">
		/// The persistable object to compare against.
		/// </param>
		/// <returns>
		/// True if the persistable objects are equal.
		/// </returns>
		public override bool Equals(object persistableObject)
		{
			if (persistableObject == null || !(persistableObject is PersistableObject<TSurrogateIdentity>))
			{
				return false;
			}

			return this == (PersistableObject<TSurrogateIdentity>)persistableObject;
		}

		/// <summary>
		/// Gets the hash code for the persistable object.
		/// </summary>
		/// <returns>
		/// The hash code.
		/// </returns>
		public override int GetHashCode()
		{
			// If we have a surrogate id then return its hash...
            if (EqualityComparer<TSurrogateIdentity>.Default.Equals(Sid, default(TSurrogateIdentity)) == false)
			{
				return Sid.GetHashCode();
			}

			// Cast ourselves as a keyed object...
			var keyedObject = this as IKeyed;

			// If we are keyed then return the key hash...
			if (keyedObject != null && string.IsNullOrEmpty(keyedObject.Key) == false)
			{
				return keyedObject.Key.GetHashCode();
			}

			return base.GetHashCode();
		}

		/// <summary>
		/// Returns a <see cref="System.String"/> that represents this instance.
		/// </summary>
		/// <returns>
		/// A <see cref="System.String"/> that represents this instance.
		/// </returns>
		public override string ToString()
		{
			// Cast ourselves as a keyed object...
			var keyedObject = this as IKeyed;

			// If we are keyed then return the key...
			if (keyedObject != null)
			{
				return keyedObject.Key;
			}

			// If we have a surrogate id then return its hash otherwise return our base hash...
			return this.Sid.Equals(default(TSurrogateIdentity)) == false
				? this.Sid.ToString()
				: base.ToString();
		}

		#endregion
	}
}