using System;
using System.Collections.Generic;
using EstateMaster.Server.Core.Migrations.History;

namespace EstateMaster.Server.Core.Migrations
{

    public class MigrationList
    { 
        public static List<Type> Get()
        {
            return new List<Type>()
            {
               // typeof(M202204081449_CreateUsers)
            };
        }
    }
}