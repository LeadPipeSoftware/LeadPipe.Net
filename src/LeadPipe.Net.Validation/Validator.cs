// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Validator.cs" company="Lead Pipe Software">
//   Copyright (c) Lead Pipe Software All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections;
using System.ComponentModel.DataAnnotations;
using LeadPipe.Net.Extensions;

namespace LeadPipe.Net.Validation
{
    /// <summary>
	/// The validator.
	/// </summary>
	public static class Validator
	{
		#region Public Methods and Operators

		/// <summary>
		/// Validates the entities.
		/// </summary>
		/// <param name="entities">
		/// The entities.
		/// </param>
		public static void ValidateEntities(IEnumerable entities)
		{
			var invalidEntitiesException = new LeadPipeNetInvalidEntitiesException("One or more entities is invalid.");

			// Validate each entity...
			foreach (var entity in entities)
			{
				var validatableEntity = entity as IValidatableObject;

				if (validatableEntity.IsNotNull())
				{
					var validationResults = validatableEntity.Validate();

					if (validationResults.Count > 0)
					{
						invalidEntitiesException.InvalidEntityExceptions.Add(new LeadPipeNetInvalidEntityException(entity.ToString().FormattedWith("The {0} entity is invalid."), entity.ToString(), validationResults));
					}
				}
			}

			// If one or more entities are invalid...
			if (invalidEntitiesException.InvalidEntityExceptions.Count > 0)
			{
				throw invalidEntitiesException;
			}
		}

		/// <summary>
		/// Validates an entity.
		/// </summary>
		/// <param name="entity">
		/// The entity.
		/// </param>
		public static void ValidateEntity(object entity)
		{
			var validatableEntity = entity as IValidatableObject;

			if (validatableEntity == null)
			{
				return;
			}

			var validationResults = validatableEntity.Validate();

			if (validationResults.Count > 0)
			{
				throw new LeadPipeNetInvalidEntityException(entity.ToString().FormattedWith("The {0} entity is invalid."), entity.ToString(), validationResults);
			}
		}

		#endregion
	}
}