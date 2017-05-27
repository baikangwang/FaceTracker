﻿//----------------------------------------------------------------------------
//  Copyright (C) 2004-2017 by EMGU Corporation. All rights reserved.       
//----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using Emgu.CV;
using Emgu.CV.Structure;
#if !(__IOS__ || NETFX_CORE)
using Emgu.CV.Cuda;
#endif

namespace FaceTracker
{
   public static class DetectFace
   {
      public static void Detect(
         IInputArray image, String faceFileName, String eyeFileName,
         List<Rectangle> faces, List<Rectangle> eyes)/*,
         out long detectionTime)*/
      {
         // Stopwatch watch;

         using (InputArray iaImage = image.GetInputArray())
         {

#if !(__IOS__ || NETFX_CORE)
             
            if (iaImage.Kind == InputArray.Type.CudaGpuMat && CudaInvoke.HasCuda)
            {
               using (CudaCascadeClassifier face = new CudaCascadeClassifier(faceFileName))
               using (CudaCascadeClassifier eye = new CudaCascadeClassifier(eyeFileName))
               {
                  face.ScaleFactor = 1.1;
                  face.MinNeighbors = 10;
                  face.MinObjectSize = Size.Empty;
                  eye.ScaleFactor = 1.1;
                  eye.MinNeighbors = 10;
                  eye.MinObjectSize = Size.Empty;
                  // watch = Stopwatch.StartNew();
                  using (CudaImage<Bgr, Byte> gpuImage = new CudaImage<Bgr, byte>(image))
                  using (CudaImage<Gray, Byte> gpuGray = gpuImage.Convert<Gray, Byte>())
                  using (GpuMat region = new GpuMat())
                  {
                     face.DetectMultiScale(gpuGray, region);
                     Rectangle[] faceRegion = face.Convert(region);
                     faces.AddRange(faceRegion);
                     foreach (Rectangle f in faceRegion)
                     {
                        using (CudaImage<Gray, Byte> faceImg = gpuGray.GetSubRect(f))
                        {
                           //For some reason a clone is required.
                           //Might be a bug of CudaCascadeClassifier in opencv
                           using (CudaImage<Gray, Byte> clone = faceImg.Clone(null))
                           using (GpuMat eyeRegionMat = new GpuMat())
                           {
                              eye.DetectMultiScale(clone, eyeRegionMat);
                              Rectangle[] eyeRegion = eye.Convert(eyeRegionMat);
                              foreach (Rectangle e in eyeRegion)
                              {
                                 Rectangle eyeRect = e;
                                 eyeRect.Offset(f.X, f.Y);
                                 eyes.Add(eyeRect);
                              }
                           }
                        }
                     }
                  }
                  // watch.Stop();
               }
            }
            else
#endif
            {
               //Read the HaarCascade objects
               using (CascadeClassifier face = new CascadeClassifier(faceFileName))
               using (CascadeClassifier eye = new CascadeClassifier(eyeFileName))
               {
                  //watch = Stopwatch.StartNew();

                  using (UMat ugray = new UMat())
                  {
                     CvInvoke.CvtColor(image, ugray, Emgu.CV.CvEnum.ColorConversion.Bgr2Gray);

                     //normalizes brightness and increases contrast of the image
                     CvInvoke.EqualizeHist(ugray, ugray);

                     //Detect the faces  from the gray scale image and store the locations as rectangle
                     //The first dimensional is the channel
                     //The second dimension is the index of the rectangle in the specific channel                     
                     Rectangle[] facesDetected = face.DetectMultiScale(
                        ugray,
                        1.1,
                        10,
                        new Size(20, 20));

                     faces.AddRange(facesDetected);

                     foreach (Rectangle f in facesDetected)
                     {
                        //Get the region of interest on the faces
                        using (UMat faceRegion = new UMat(ugray, f))
                        {
                           Rectangle[] eyesDetected = eye.DetectMultiScale(
                              faceRegion,
                              1.1,
                              10,
                              new Size(20, 20));

                           foreach (Rectangle e in eyesDetected)
                           {
                              Rectangle eyeRect = e;
                              eyeRect.Offset(f.X, f.Y);
                              eyes.Add(eyeRect);
                           }
                        }
                     }
                  }
                  //watch.Stop();
               }
            }
            //detectionTime = watch.ElapsedMilliseconds;
         }
      }

      public static void Detect(IInputArray image, dynamic objFace, List<dynamic> objOthers )
      {
          // Stopwatch watch;

          using (InputArray iaImage = image.GetInputArray())
          {
            //Read the HaarCascade objects
            using (CascadeClassifier face = new CascadeClassifier(objFace.ArrFileName))
            {
                using (UMat ugray = new UMat())
                {
                    CvInvoke.CvtColor(image, ugray, Emgu.CV.CvEnum.ColorConversion.Bgr2Gray);

                    //normalizes brightness and increases contrast of the image
                    CvInvoke.EqualizeHist(ugray, ugray);

                    //Detect the faces  from the gray scale image and store the locations as rectangle
                    //The first dimensional is the channel
                    //The second dimension is the index of the rectangle in the specific channel                     
                    Rectangle[] facesDetected = face.DetectMultiScale(
                        ugray,
                        1.1,
                        10,
                        new Size(20, 20));

                    objFace.Rectangles.AddRange(facesDetected);

                    foreach (Rectangle f in facesDetected)
                    {
                        //Get the region of interest on the faces
                        using (UMat faceRegion = new UMat(ugray, f))
                        {
                            foreach (dynamic objOther in objOthers)
                            {
                                using (CascadeClassifier other = new CascadeClassifier(objOther.ArrFileName))
                                {
                                    Rectangle[] othersDetected = other.DetectMultiScale(
                                        faceRegion,
                                        1.1,
                                        10,
                                        new Size(20, 20));

                                    foreach (Rectangle e in othersDetected)
                                    {
                                        Rectangle otherRect = e;
                                        otherRect.Offset(f.X, f.Y);
                                        objOther.Rectangles.Add(otherRect);
                                    }
                                }

                            }
                        }
                    }
                }
              }
          }
      }

      public static void All(
  IInputArray image, String faceFileName, String eyeFileName,string mouthFileName,string noseFileName,
  List<Rectangle> faces, List<Rectangle> eyes,List<Rectangle> mouthes,List<Rectangle> noses)/*,
         out long detectionTime)*/
      {
          // Stopwatch watch;

          using (InputArray iaImage = image.GetInputArray())
          {

            //Read the HaarCascade objects
            using (CascadeClassifier face = new CascadeClassifier(faceFileName))
            using (CascadeClassifier eye = new CascadeClassifier(eyeFileName))
            using (CascadeClassifier mouth = new CascadeClassifier(mouthFileName))
            using (CascadeClassifier nose = new CascadeClassifier(noseFileName))
            {
                //watch = Stopwatch.StartNew();

                using (UMat ugray = new UMat())
                {
                    CvInvoke.CvtColor(image, ugray, Emgu.CV.CvEnum.ColorConversion.Bgr2Gray);

                    //normalizes brightness and increases contrast of the image
                    CvInvoke.EqualizeHist(ugray, ugray);

                    //Detect the faces  from the gray scale image and store the locations as rectangle
                    //The first dimensional is the channel
                    //The second dimension is the index of the rectangle in the specific channel                     
                    Rectangle[] facesDetected = face.DetectMultiScale(
                        ugray,
                        1.1,
                        10,
                        new Size(20, 20));

                    faces.AddRange(facesDetected);

                    foreach (Rectangle f in facesDetected)
                    {
                        //Get the region of interest on the faces
                        using (UMat faceRegion = new UMat(ugray, f))
                        {
                            Rectangle[] eyesDetected = eye.DetectMultiScale(
                                faceRegion,
                                1.1,
                                10,
                                new Size(20, 20));

                            foreach (Rectangle e in eyesDetected)
                            {
                                Rectangle eyeRect = e;
                                eyeRect.Offset(f.X, f.Y);
                                eyes.Add(eyeRect);
                            }

                            Rectangle[] nosesDetected = nose.DetectMultiScale(
                                faceRegion,
                                1.1,
                                10,
                                new Size(20, 20));

                            foreach (Rectangle n in nosesDetected)
                            {
                                Rectangle noseRect = n;
                                noseRect.Offset(f.X, f.Y);
                                noses.Add(noseRect);
                            }

                            Rectangle[] mouthesDetected = mouth.DetectMultiScale(
                                faceRegion,
                                1.1,
                                10,
                                new Size(20, 20));

                            foreach (Rectangle n in mouthesDetected)
                            {
                                Rectangle mouthRect = n;
                                mouthRect.Offset(f.X, f.Y);
                                mouthes.Add(mouthRect);
                            }


                        }
                    }
                }
                //watch.Stop();
            }
        }
        //detectionTime = watch.ElapsedMilliseconds;
          
      }
   }
}
