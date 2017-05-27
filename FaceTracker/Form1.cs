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
        #endregion
        public Form1()
        {
            InitializeComponent();
            CvInvoke.UseOpenCL = false;
            try
            {
                _capture = new VideoCapture();

            }
            catch (NullReferenceException excpt)
            {
                MessageBox.Show(excpt.Message);
            }

            rbCapture.Checked = true;
            gbFaceRec.Enabled = false;

        }

        private void DrawFace(object sender,EventArgs e)
        {
            var frame = _capture.QueryFrame();

            var objFace = new
            {
                ArrFileName = "haarcascade_frontalface_default.xml",
                Rectangles = new List<Rectangle>(),
                Color = Color.Yellow
            };

            var objOthers = new List<dynamic>();
            if(ckbEyes.Checked)
                objOthers.Add(new
                {
                    ArrFileName = "haarcascade_eye.xml",
                    Rectangles = new List<Rectangle>(),
                    Color = Color.Red
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
                    Color = Color.Blue
                });


            // recognize dynamic

            DetectFace.Detect(frame, objFace, objOthers);

            foreach (Rectangle face in objFace.Rectangles)
            {
                CvInvoke.Rectangle(frame, face, new Bgr(objFace.Color).MCvScalar, 2);

                if (ckbPreview.Checked)
                {
                    Mat capturedFace = new Mat(frame, face);
                    if (ckbGray.Checked)
                    {
                        var gray = new Mat();
                        CvInvoke.CvtColor(capturedFace, gray, ColorConversion.Bgr2Gray);
                        capturedFace = gray;
                    }
                    imgPreview.Image = capturedFace;
                }
            }
            foreach (dynamic objOther in objOthers)
            {
                foreach (var objOtherRect in  objOther.Rectangles)
                {
                    CvInvoke.Rectangle(frame, objOtherRect, new Bgr(objOther.Color).MCvScalar, 2);
                }
            }

            if (ckbGray.Checked)
            {
                var grayFrame = new Mat();
                CvInvoke.CvtColor(frame, grayFrame, ColorConversion.Bgr2Gray);
                /* The Capture example codes
                // CvInvoke.CvtColor(_frame, _grayFrame, ColorConversion.Bgr2Gray);

                // CvInvoke.PyrDown(_grayFrame, _smallGrayFrame);

                // CvInvoke.PyrUp(_smallGrayFrame, _smoothedGrayFrame);

                // CvInvoke.Canny(_smoothedGrayFrame, _cannyFrame, 100, 60);
                 * */

                frame = grayFrame;
            }
            imgCapture.Image = frame;
        }

        private void ProcessFrame(object sender, EventArgs arg)
        {
            if (_capture != null && _capture.Ptr != IntPtr.Zero)
            {
                var frame=new Mat();
                _capture.Retrieve(frame, 0);
                imgCapture.Image = frame;
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
