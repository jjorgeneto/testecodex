using FluentAssertions;
using Xunit;

namespace Api.Tests;

public class HealthEndpointTests
{
    [Fact]
    public void Trivial_Test()
    {
        // Exemplo simples: só valida algo básico
        var status = 