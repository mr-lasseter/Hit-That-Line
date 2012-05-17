﻿using Raven.Client;
using Raven.Client.Document;
using StructureMap.Configuration.DSL;

namespace HitThatLine.Infrastructure
{
    public class RavenDBRegistry : Registry
    {
        public RavenDBRegistry()
        {
            var store = new DocumentStore { ConnectionStringName = "RavenDB" }.Initialize();
            For<IDocumentSession>().Use(store.OpenSession);
        }
    }
}