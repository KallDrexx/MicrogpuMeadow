using System.Collections.Generic;

namespace MicrogpuMeadow.Common.Operations
{
    public class GetLastMessageOperation : IOperation
    {
        public void Serialize(List<byte> bytes)
        {
            bytes.Clear();
            bytes.Add(5);
        }
    }
}