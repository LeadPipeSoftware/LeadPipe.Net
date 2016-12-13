// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using LeadPipe.Net.Commands;

namespace LeadPipe.Net.Data
{
    /// <summary>
    /// Decorates a command handler with a Unit of Work.
    /// </summary>
    /// <typeparam name="TCommand">The command type.</typeparam>
    /// <typeparam name="TResponse">The response type.</typeparam>
    public class UnitOfWorkCommandHandlerDecorator<TCommand, TResponse> : ICommandHandler<TCommand, TResponse>
    {
        private readonly ICommandHandler<TCommand, TResponse> inner;
        private readonly IUnitOfWorkFactory unitOfWorkFactory;

        /// <summary>
        /// Initializes a new instance of the UnitOfWorkCommandHandlerDecorator.
        /// </summary>
        /// <param name="inner">The inner command handler.</param>
        /// <param name="unitOfWorkFactory">The Unit of Work factory.</param>
        public UnitOfWorkCommandHandlerDecorator(ICommandHandler<TCommand, TResponse> inner, IUnitOfWorkFactory unitOfWorkFactory)
        {
            this.inner = inner;
            this.unitOfWorkFactory = unitOfWorkFactory;
        }

        /// <summary>
        /// Decorates the command handler.
        /// </summary>
        /// <param name="command"></param>
        /// <returns>The response.</returns>
        public TResponse Handle(TCommand command)
        {
            var unitOfWork = unitOfWorkFactory.CreateUnitOfWork();

            using (unitOfWork.Start())
            {
                var response = inner.Handle(command);

                unitOfWork.Commit();

                return response;
            }
        }
    }
}