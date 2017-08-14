using System;
using System.Security.Cryptography;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Mega_Project
{
    public class BenchmarkMD5
    {
        private const int N = 10000;
        private readonly byte[] data;

        private readonly MD5 md5 = MD5.Create();

        public BenchmarkMD5()
        {
            data = new byte[N];
            new Random(42).NextBytes(data);
        }

        [Benchmark]
        public byte[] Md5() => md5.ComputeHash(data);
    }

    public class BenchmarkSha256
    {
        private const int N = 10000;
        private readonly byte[] data;

        private readonly SHA256 sha256 = SHA256.Create();


        public BenchmarkSha256()
        {
            data = new byte[N];
            new Random(42).NextBytes(data);
        }

        [Benchmark]
        public byte[] Sha256() => sha256.ComputeHash(data);

    }
}
