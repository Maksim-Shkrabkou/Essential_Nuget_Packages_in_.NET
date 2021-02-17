using System;
using Xunit;
using Xunit.Abstractions;

namespace xUnitTutorial
{
    [CollectionDefinition("Guid Generator")]
    public class GuidGeneratorDefinition : ICollectionFixture<GuidGenerator> { }

    // ICollectionFixture + [CollectionDefinition("Guid Generator")] give us ability
    // to use same GuidGeneration instance (same context)
    // in all tests classes in a collection -> [Collection("Guid Generator")]
    
    [Collection("Guid Generator")]
    public class GuidGeneratorTestOne
    {
        private readonly GuidGenerator _guidGenerator;
        private readonly ITestOutputHelper _output;

        public GuidGeneratorTestOne(ITestOutputHelper output, GuidGenerator guidGenerator)
        {
            _output = output;
            _guidGenerator = guidGenerator;
        }

        [Fact]
        public void GuidTestOne()
        {
            var guid = _guidGenerator.RandomGuid;
            _output.WriteLine($"The guid was {guid}");
        }
        
        [Fact]
        public void GuidTestTwo()
        {
            var guid = _guidGenerator.RandomGuid;
            _output.WriteLine($"The guid was {guid}");
        }

        // SetUp -> in constructor
        // TearDown -> realize IDisposable interface
        
        /*public void Dispose()
        {
            _output.WriteLine("The class was dispose");
        }*/
    }
    
    
    // IClassFixture give us ability to use same GuidGeneration instance in all tests (same context)
    /*
    public class GuidGeneratorTestOne : IClassFixture<GuidGenerator>
    {
        private readonly GuidGenerator _guidGenerator;
        private readonly ITestOutputHelper _output;

        public GuidGeneratorTestOne(ITestOutputHelper output, GuidGenerator guidGenerator)
        {
            _output = output;
            _guidGenerator = guidGenerator;
        }
    */
    
    [Collection("Guid Generator")]
    public class GuidGeneratorTestTwo
    {
        private readonly GuidGenerator _guidGenerator;
        private readonly ITestOutputHelper _output;

        public GuidGeneratorTestTwo(ITestOutputHelper output, GuidGenerator guidGenerator)
        {
            _output = output;
            _guidGenerator = guidGenerator;
        }

        [Fact]
        public void GuidTestOne()
        {
            var guid = _guidGenerator.RandomGuid;
            _output.WriteLine($"The guid was {guid}");
        }
        
        [Fact]
        public void GuidTestTwo()
        {
            var guid = _guidGenerator.RandomGuid;
            _output.WriteLine($"The guid was {guid}");
        }
    }
}