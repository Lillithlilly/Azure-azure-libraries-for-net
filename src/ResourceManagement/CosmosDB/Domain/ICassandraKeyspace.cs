// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.CosmosDB.Fluent
{
    using Microsoft.Azure.Management.CosmosDB.Fluent.Models;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    /// <summary>
    /// A Cassandra keyspace.
    /// </summary>
    public interface ICassandraKeyspace :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.CassandraKeyspaceGetResultsInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IExternalChildResource<ICassandraKeyspace, ICosmosDBAccount>
    {
        /// <summary>
        /// Gets name of the Cosmos DB Cassandra keyspace.
        /// </summary>
        string CassandraKeyspaceId { get; }

        /// <summary>
        /// Gets a system generated property. A unique identifier.
        /// </summary>
        string _rid { get; }

        /// <summary>
        /// Gets a system generated property that denotes the last
        /// updated timestamp of the resource.
        /// </summary>
        object _ts { get; }

        /// <summary>
        /// Gets a system generated property representing the resource
        /// etag required for optimistic concurrency control.
        /// </summary>
        string _etag { get; }

        /// <returns>The throughput settings of the Cassandra keyspace.</returns>
        ThroughputSettingsGetPropertiesResource GetThroughputSettings();

        /// <returns>The throughput settings of the Cassandra keyspace.</returns>
        Task<ThroughputSettingsGetPropertiesResource> GetThroughputSettingsAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <returns>All Cassandra tables in the DB.</returns>
        IEnumerable<ICassandraTable> ListCassandraTables();

        /// <returns>All Cassandra tables in the DB.</returns>
        Task<IEnumerable<ICassandraTable>> ListCassandraTablesAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <param name="name">The name of the Cassandra table.</param>
        /// <returns>The specific Cassandra table.</returns>
        ICassandraTable GetCassandraTable(string name);

        /// <param name="name">The name of the Cassandra table.</param>
        /// <returns>The specific Cassandra table.</returns>
        Task<ICassandraTable> GetCassandraTableAsync(string name, CancellationToken cancellationToken = default(CancellationToken));
    }
}
