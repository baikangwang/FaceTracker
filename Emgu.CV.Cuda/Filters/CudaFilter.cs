﻿//----------------------------------------------------------------------------
//  Copyright (C) 2004-2017 by EMGU Corporation. All rights reserved.       
//----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Drawing;
using Emgu.CV.Features2D;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Emgu.Util;

namespace Emgu.CV.Cuda
{
    /// <summary>
    /// Base Cuda filter class
    /// </summary>
    public abstract class CudaFilter : UnmanagedObject
    {
        /*
        /// <summary>
        /// The MatType for CudaImage&lt; TColor, TDepth &gt;
        /// </summary>
        protected static int _matType;

        /// <summary>
        /// dummy code to make sure the _matType value is setup properly
        /// </summary>
        static CudaFilter()
        {
           using (CudaImage<TColor, TDepth> tmp = new CudaImage<TColor, TDepth>(4, 4))
           {
              _matType = tmp.Type;
           }
        }*/

        /// <summary>
        /// Release all the unmanaged memory associated with this gpu filter
        /// </summary>
        protected override void DisposeObject()
        {
            if (_ptr != IntPtr.Zero)
                CudaInvoke.cudaFilterRelease(ref _ptr);
        }

        /// <summary>
        /// Apply the cuda filter
        /// </summary>
        /// <param name="image">The source CudaImage where the filter will be applied to</param>
        /// <param name="dst">The destination CudaImage</param>
        /// <param name="stream">Use a Stream to call the function asynchronously (non-blocking) or null to call the function synchronously (blocking).</param>
        public void Apply(IInputArray image, IOutputArray dst, Stream stream = null)
        {
            using (InputArray iaImage = image.GetInputArray())
            using (OutputArray oaDst = dst.GetOutputArray())
                CudaInvoke.cudaFilterApply(_ptr, iaImage, oaDst, stream);
        }
    }

    public static partial class CudaInvoke
    {
        [DllImport(CvInvoke.ExternCudaLibrary, CallingConvention = CvInvoke.CvCallingConvention)]
        internal static extern void cudaFilterApply(IntPtr filter, IntPtr image, IntPtr dst, IntPtr stream);

        [DllImport(CvInvoke.ExternCudaLibrary, CallingConvention = CvInvoke.CvCallingConvention)]
        internal static extern void cudaFilterRelease(ref IntPtr filter);
    }

}
