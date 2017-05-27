using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Cvb;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;

namespace FaceTracker
{
    public partial class Form1 : Form
    {
        #region private fields
        private VideoCapture _capture = null;
        private bool _captureInProgress;
        private Mat _frame;
        // private Mat _grayFrame;
        // private Mat _smallGrayFrame;
        // private Mat _smoothedGrayFrame;
        // private Mat _cannyFrame;
        #endregion
        public Form1()
        {
            InitializeComponent();
            // CvInvoke.UseOpenCL = false;
            try
            {
                _capture = new VideoCapture();
                // _capture.ImageGrabbed += ProcessFrame;
                // Application.Idle += DrawFace;
            }
            catch (NullReferenceException excpt)
            {
                MessageBox.Show(excpt.Message);
            }

            rbCapture.Checked = true;
            gbFaceRec.Enabled = false;

             _frame = new Mat();
            // _grayFrame = new Mat();
            // _smallGrayFrame = new Mat();
            // _smoothedGrayFrame = new Mat();
            // _cannyFrame = new Mat();
        }

        private void DrawFace(object sender,EventArgs e)
        {
            _frame = _capture.QueryFrame();
            var objFace = new
            {
                ArrFileName = "haarcascade_frontalface_default.xml",
                Rectangles = new List<Rectangle>(),
                Color = Color.Red
            };

            var objOthers = new List<dynamic>();
            if(ckbEyes.Checked)
                objOthers.Add(new
                {
                    ArrFileName = "haarcascade_eye.xml",
                    Rectangles = new List<Rectangle>(),
                    Color = Color.Blue
                });

            if (ckbNose.Checked)
                objOthers.Add(new
                {
                    ArrFileName = "haarcascade_nose.xml",
                    Rectangles = new List<Rectangle>(),
                    Color = Color.Green
                });

            if (ckbMouth.Checked)
                objOthers.Add(new
                {
                    ArrFileName = "haarcascade_mouth.xml",
                    Rectangles = new List<Rectangle>(),
                    Color = Color.Yellow
                });


            // recognize dynamic

            DetectFace.Detect(_frame, objFace, objOthers);

            foreach (Rectangle face in objFace.Rectangles)
            {
                CvInvoke.Rectangle(_frame, face, new Bgr(objFace.Color).MCvScalar, 2);

                if (ckbPreview.Checked)
                {
                    Mat capturedFace = new Mat(_frame, face);
                    imgPreview.Image = capturedFace;
                }
            }
            foreach (dynamic objOther in objOthers)
            {
                foreach (var objOtherRect in  objOther.Rectangles)
                {
                    CvInvoke.Rectangle(_frame, objOtherRect, new Bgr(objOther.Color).MCvScalar, 2);
                }
            }

            imgCapture.Image = _frame;
        }

        private void ProcessFrame(object sender, EventArgs arg)
        {
            if (_capture != null && _capture.Ptr != IntPtr.Zero)
            {
                _capture.Retrieve(_frame, 0);
             //   _frame = _capture.QueryFrame();
                
             //   List<Rectangle> faces = new List<Rectangle>();
             //   List<Rectangle> eyes = new List<Rectangle>();
             //   //long detectionTime;
             //   DetectFace.Detect(
             //       _frame, "haarcascade_frontalface_default.xml", "haarcascade_eye.xml",
             //       faces, eyes); /*,
             //out detectionTime);*/

             //   foreach (Rectangle face in faces)
             //       CvInvoke.Rectangle(_frame, face, new Bgr(Color.Red).MCvScalar, 2);
             //   foreach (Rectangle eye in eyes)
             //       CvInvoke.Rectangle(_frame, eye, new Bgr(Color.Blue).MCvScalar, 2);
                

                /* The Capture example codes
                // CvInvoke.CvtColor(_frame, _grayFrame, ColorConversion.Bgr2Gray);

                // CvInvoke.PyrDown(_grayFrame, _smallGrayFrame);

                // CvInvoke.PyrUp(_smallGrayFrame, _smoothedGrayFrame);

                // CvInvoke.Canny(_smoothedGrayFrame, _cannyFrame, 100, 60);
                 * */

                imgCapture.Image = _frame;

                /* The Capture example codes
                // grayscaleImageBox.Image = _grayFrame;
                // smoothedGrayscaleImageBox.Image = _smoothedGrayFrame;
                // cannyImageBox.Image = _cannyFrame;
                 */
            }
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            if (_capture != null)
            {
                if (_captureInProgress)
                {  //stop the capture
                    btnCapture.Text = @"Start";
                    _capture.Pause();
                }
                else
                {
                    //start the capture
                    btnCapture.Text = @"Stop";
                    _capture.Start();
                }

                _captureInProgress = !_captureInProgress;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (_capture != null) _capture.FlipHorizontal = !_capture.FlipHorizontal;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_capture != null) _capture.FlipVertical = !_capture.FlipVertical;
        }

        private void rbCapture_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCapture.Checked)
            {
                _capture.ImageGrabbed += ProcessFrame;
            }
            else
            {
                // stop capture
                if (_captureInProgress)
                {
                    btnCapture.PerformClick();
                }
                _capture.ImageGrabbed -= ProcessFrame;
                // show nothing
                imgCapture.Image = null;
            }

            gbCapture.Enabled = rbCapture.Checked;
        }

        private void rbFaceRec_CheckedChanged(object sender, EventArgs e)
        {
            if (!rbFaceRec.Checked)
            {
                // stop drawing
                Application.Idle -= DrawFace;
                ckbEyes.Checked = false;
                ckbMouth.Checked = false;
                ckbNose.Checked = false;

                // show nothing
                imgCapture.Image = null;
            }
            else
            {
                // start drawing
                Application.Idle += DrawFace;
            }

            gbFaceRec.Enabled = rbFaceRec.Checked;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_captureInProgress)
            {
                MessageBox.Show("It's still capturing vedio, please stop before close the form.");
                e.Cancel = true;
            }
        }

        private void ckbPreview_CheckedChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = ckbPreview.Checked;
            if (!ckbPreview.Checked)
            {
                imgPreview.Image = null;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (imgPreview.Image != null)
            {
                // save
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "faces");
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                imgPreview.Image.Save(Path.Combine(path, "face.jpg"));
            }
        }

       
    }
}
