using System;
using System.Security.Cryptography;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Mega_Project
{
    public class BenchmarkMd5
    {
        private const int N = 10000;
        private readonly byte[] _data;

        private readonly MD5 _md5 = MD5.Create();

        public BenchmarkMd5()
        {
            _data = new byte[N];
            new Random(42).NextBytes(_data);
        }

        [Benchmark]
        public byte[] Md5() => _md5.ComputeHash(_data);
    }

    public class BenchmarkSha256
    {
        private const int N = 10000;
        private readonly byte[] _data;

        private readonly SHA256 _sha256 = SHA256.Create();


        public BenchmarkSha256()
        {
            _data = new byte[N];
            new Random(42).NextBytes(_data);
        }

        [Benchmark]
        public byte[] Sha256() => _sha256.ComputeHash(_data);

    }
}
