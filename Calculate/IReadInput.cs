using System;
using System.Collections.Generic;
using System.Text;

namespace Calculate
{
    public interface IReadInput
    {
        List<string> ReadInputFile(string fullfilePath, out string message);
    }
}
