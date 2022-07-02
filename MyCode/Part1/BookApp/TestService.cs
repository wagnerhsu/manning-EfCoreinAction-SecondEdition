// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Linq;
using DataLayer.EfCode;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace BookApp
{
    public class TestService : ITestService
    {
        private readonly ILogger<TestService> _logger;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public TestService(ILogger<TestService> logger, IServiceScopeFactory serviceScopeFactory)
        {
            _logger = logger;
            _serviceScopeFactory = serviceScopeFactory;
        }

        public void Test()
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var dbContext = scope.ServiceProvider.GetService<EfCoreContext>();
            _logger.LogInformation("Books:{Count}", dbContext.Books.Count());
        }
    }
}
