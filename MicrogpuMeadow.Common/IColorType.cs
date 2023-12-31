﻿using System.Collections.Generic;

namespace MicrogpuMeadow.Common
{
    /// <summary>
    /// Used to constrain generics to a color type
    /// </summary>
    public interface IColorType
    {
        void AppendBytes(List<byte> bytes);
    }
}