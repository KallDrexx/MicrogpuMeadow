using System.Collections.Generic;

namespace MicrogpuMeadow.Common.Operations
{
    public class GetStatusOperation : IOperation
    {
        public void Serialize(List<byte> bytes)
        {
            bytes.Clear();
            bytes.Add(4);
        }
    }
}