﻿using System;
using System.Threading.Tasks;
using Akka.Interfaced;
using Xunit;
using Xunit.Abstractions;

namespace CodeGenerator
{
    public interface IGreeter : IInterfacedActor
    {
        Task<string> Greet(string name);
        Task<int> GetCount();
    }

    public enum TestEnum
    {
        Yes = 1,
        No = 2,
    }

    public interface IDefaultValues : IInterfacedActor
    {
        Task Bool(bool a = false, bool b = true);
        Task Integer(byte a = 1, short b = 2, int c = 3, long d = 4);
        Task Float(float a = 3.14f, double b = 3.141592);
        Task String(char a = '\0', string b = "abc\t");
        Task Enum(TestEnum a = TestEnum.Yes);
        Task Null(object a = null);
    }

    public interface IGeneric<T> : IInterfacedActor
        where T : new()
    {
        Task<T> Create();
        Task<T> Echo(T value);
        Task<U> Echo<U>(U value);
        Task<bool> Equal<U>(U value1, U value2)
            where U : IEquatable<U>;
    }

    public class InterfacedActorCodeGeneratorTest
    {
        private readonly ITestOutputHelper _output;

        public InterfacedActorCodeGeneratorTest(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void GenerateActorCode()
        {
            var compilation = TestUtility.Generate(new Options(), new[] { typeof(IGreeter) }, _output);
            Assert.Equal(
                new[]
                {
                    "IGreeter_PayloadTable",
                    "GetCount_Invoke",
                    "GetCount_Return",
                    "Greet_Invoke",
                    "Greet_Return",
                    "IGreeter_NoReply",
                    "GreeterRef",
                    "IGreeterSync",
                },
                compilation.GetTypeSymbolNames());
        }

        [Fact]
        public void GenerateActorCode_WithUseSlimClient()
        {
            var compilation = TestUtility.Generate(new Options { UseSlimClient = true }, new[] { typeof(IGreeter) }, _output);
            Assert.Equal(
                new[]
                {
                    "IGreeter_PayloadTable",
                    "GetCount_Invoke",
                    "GetCount_Return",
                    "Greet_Invoke",
                    "Greet_Return",
                    "IGreeter_NoReply",
                    "GreeterRef",
                },
                compilation.GetTypeSymbolNames());
        }

        [Fact]
        public void GenerateActorCode_WithDefaultValues()
        {
            var compilation = TestUtility.Generate(new Options { UseSlimClient = true }, new[] { typeof(IDefaultValues) }, _output);
            Assert.NotEmpty(compilation.GetTypeSymbolNames());
        }

        [Fact]
        public void GenerateActorCode_WithGeneric()
        {
            var compilation = TestUtility.Generate(new Options(), new[] { typeof(IGeneric<>) }, _output);
            Assert.Equal(
                new[]
                {
                    "IGeneric_PayloadTable",
                    "Create_Invoke",
                    "Create_Return",
                    "Echo_Invoke",
                    "Echo_Return",
                    "Echo_2_Invoke",
                    "Echo_2_Return",
                    "Equal_Invoke",
                    "Equal_Return",
                    "IGeneric_NoReply",
                    "GenericRef",
                    "IGenericSync",
                },
                compilation.GetTypeSymbolNames());
        }
    }
}
