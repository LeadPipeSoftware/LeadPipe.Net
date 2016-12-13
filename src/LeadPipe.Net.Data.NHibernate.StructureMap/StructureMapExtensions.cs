// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using LeadPipe.Net.Commands;
using StructureMap.Graph;

namespace LeadPipe.Net.Data.NHibernate.StructureMap
{
    /// <summary>
    /// StructureMap registration extensions.
    /// </summary>
    public static class StructureMapExtensions
    {
        /// <summary>
        /// Registers all of the command and query handlers.
        /// </summary>
        /// <param name="assemblyScanner"></param>
        public static void RegisterAllLeadPipeCommandAndQueryHandlers(this IAssemblyScanner assemblyScanner)
        {
            assemblyScanner.ConnectImplementationsToTypesClosing(typeof(ICommandHandler<>));
            assemblyScanner.ConnectImplementationsToTypesClosing(typeof(ICommandHandler<,>));
            assemblyScanner.ConnectImplementationsToTypesClosing(typeof(IQueryHandler<,>));
        }
    }
}