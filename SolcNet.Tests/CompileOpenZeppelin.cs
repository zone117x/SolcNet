﻿using SolcNet.CompileErrors;
using SolcNet.DataDescription.Input;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace SolcNet.Tests
{
    public class CompileOpenZeppelin
    {
        [Fact]
        public void CompileAll()
        {
            var contractFiles = Directory.GetFiles("OpenZeppelin", "*.sol", SearchOption.AllDirectories);
            var solc = new SolcLib();
            var output = solc.Compile(contractFiles, OutputTypes.All, CompileErrorHandling.ThrowOnError);
        }
    }
}
