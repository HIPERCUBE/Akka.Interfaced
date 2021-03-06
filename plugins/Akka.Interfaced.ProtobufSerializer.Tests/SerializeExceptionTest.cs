﻿using System;
using ProtoBuf;
using TypeAlias;
using Xunit;

namespace Akka.Interfaced.ProtobufSerializer.Tests
{
    public class SerializeExceptionTest
    {
        [Fact]
        public void TestBuiltinException()
        {
            var serializer = new ProtobufSerializer(null);

            var exception = new ArgumentException("Test");
            var obj = new ResponseMessage { Exception = exception };
            var bytes = serializer.ToBinary(obj);

            var obj2 = (ResponseMessage)serializer.FromBinary(bytes, null);
            Assert.Equal(obj.Exception.GetType(), obj2.Exception.GetType());
        }

        [ProtoContract, TypeAlias]
        private class TestException : Exception
        {
            [ProtoMember(1)] public int ErrorCode;
            [ProtoMember(2)] public string ErrorDetail;
        }

        [Fact]
        public void TestTypeAliasException()
        {
            var serializer = new ProtobufSerializer(null);

            var exception = new TestException { ErrorCode = 1000, ErrorDetail = "Test" };
            var obj = new ResponseMessage { Exception = exception };
            var bytes = serializer.ToBinary(obj);

            var obj2 = (ResponseMessage)serializer.FromBinary(bytes, null);
            Assert.Equal(obj.Exception.GetType(), obj2.Exception.GetType());

            var exception2 = (TestException)obj2.Exception;
            Assert.Equal(exception.ErrorCode, exception2.ErrorCode);
            Assert.Equal(exception.ErrorDetail, exception2.ErrorDetail);
        }
    }
}
