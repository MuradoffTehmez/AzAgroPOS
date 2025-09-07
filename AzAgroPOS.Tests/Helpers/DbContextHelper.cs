using AzAgroPOS.Verilenler.Kontekst;
using Microsoft.EntityFrameworkCore;
using System;

namespace AzAgroPOS.Tests.Helpers
{
    public static class DbContextHelper
    {
        public static AzAgroPOSDbContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<AzAgroPOSDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            return new AzAgroPOSDbContext(options);
        }
    }
}