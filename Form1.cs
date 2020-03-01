using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Cvb;
using Emgu.CV.CvEnum;
namespace sysn
{
    public partial class Form1 : Form
    {
        private VideoCapture videoCapture;
        private bool detectFire;
        private bool frameSkip = true;

        private double redThreshold = 220;
        private double whiteThreshold = 220;
        private int frameInterval = 1000 / 30;
        private Timer fpsTimer;

        public Form1()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            picPreview.SizeMode = PictureBoxSizeMode.StretchImage;
            picRedFilter.SizeMode = PictureBoxSizeMode.StretchImage;
            picFinal.SizeMode = PictureBoxSizeMode.StretchImage;

            trbSeek.Enabled = false;
        }
        private void OpenVideo(string filename)
        {
            videoCapture = new VideoCapture(filename);

            int frameCount = (int)videoCapture.GetCaptureProperty(CapProp.FrameCount);
            frameCount = 1500;
            trbSeek.Minimum = 0;
            trbSeek.Maximum = frameCount;
            trbSeek.Value = 0;
            trbSeek.Enabled = true;

            fpsTimer = new Timer();
            fpsTimer.Interval = frameInterval;
            fpsTimer.Tick += ProcessFrame;
            fpsTimer.Start();
        }
        private void OpenCamera()
        {
            videoCapture = new VideoCapture();
            trbSeek.Enabled = false;
            frameSkip = false;

            Application.Idle += ProcessFrame;
        }
        private void ProcessFrame(object sender, EventArgs e)
        {
            DateTime methodStart = DateTime.Now;

            Image<Bgr, Byte> redFiltered = null;
            Image<Bgr, Byte> ycbcrFiltered = null;
            Image<Gray, Byte> blobImage = null;

            Image<Bgr, Byte> rawFrame = videoCapture.QueryFrame().ToImage<Bgr, Byte>();
            rawFrame = rawFrame.Resize(320, 240, Emgu.CV.CvEnum.Inter.Cubic);
            rawFrame._EqualizeHist();

            if (detectFire)
            {
                redFiltered = redTreshhold(rawFrame);
                ycbcrFiltered = yCbCrThreshold(redFiltered);
                blobImage = binaryTreshold(ycbcrFiltered);

                CvBlobs blobs = new CvBlobs();
                CvBlobDetector blobDetector = new CvBlobDetector();
                uint blobCount = blobDetector.Detect(blobImage, blobs);

                int minArea = (int)(rawFrame.Width * rawFrame.Height * 0.002);

                foreach (KeyValuePair<uint, CvBlob> blobPair in blobs)
                {
                    if (blobPair.Value.Area > minArea)
                    {
                        Rectangle rect = blobPair.Value.BoundingBox;
                        rawFrame.Draw(rect, new Bgr(0, 255, 0), 5);
                    }
                }
            }

            picPreview.Image = rawFrame.Bitmap;
            if (detectFire)
            {
                picRedFilter.Image = redFiltered.Bitmap;
                picFinal.Image = blobImage.Bitmap;
            }
            else
            {
                picRedFilter.Image = null;
                picFinal.Image = null;
            }

            if (frameSkip)
            {
                int timePassed = (DateTime.Now - methodStart).Milliseconds;
                int framesToSkip = timePassed / frameInterval;
                for (int i = 0; i < framesToSkip; i++)
                    videoCapture.QueryFrame();

            }

            int currentFrame = (int)videoCapture.GetCaptureProperty(CapProp.PosFrames);
            int frameCount = (int)videoCapture.GetCaptureProperty(CapProp.FrameCount);
            if (currentFrame != -1 && frameCount != -1)
            {
                trbSeek.Value = currentFrame;
                if (currentFrame == frameCount)
                    CloseVideo();
            }
        }

        private void CloseVideo()
        {
            fpsTimer.Stop();
            picPreview.Image = null;
            picRedFilter.Image = null;
            picFinal.Image = null;
        }
        Image<Gray, Byte> binaryTreshold(Image<Bgr, Byte> originalImage)
        {
            Image<Gray, Byte> newImage = new Image<Gray, byte>(originalImage.Width, originalImage.Height);

            Bgr black = new Bgr(0, 0, 0);
            for (int y = 0; y < originalImage.Height; y++)
            {
                for (int x = 0; x < originalImage.Width; x++)
                {
                    if (originalImage[y, x].Equals(black))
                        newImage[y, x] = new Gray(0);
                    else
                        newImage[y, x] = new Gray(255);
                }
            }

            return newImage;
        }

        Image<Bgr, Byte> redTreshhold(Image<Bgr, Byte> originalImage)
        {
            Image<Bgr, Byte> newImage = new Image<Bgr, byte>(originalImage.Width, originalImage.Height);

            for (int y = 0; y < originalImage.Height; y++)
            {
                for (int x = 0; x < originalImage.Width; x++)
                {
                    double r = originalImage[y, x].Red;
                    double g = originalImage[y, x].Green;
                    double b = originalImage[y, x].Blue;

                    bool isFire = false;

                    if (r > g && r > b)
                        if (r > redThreshold)
                            isFire = true;

                    if (r > whiteThreshold && g > whiteThreshold && b > whiteThreshold)
                        isFire = true;

                    if (isFire)
                        newImage[y, x] = originalImage[y, x];
                    else
                        newImage[y, x] = new Bgr(0, 0, 0);
                }
            }

            return newImage;
        }

        Image<Bgr, Byte> yCbCrThreshold(Image<Bgr, Byte> originalImage)
        {
            Image<Bgr, Byte> newImage = new Image<Bgr, byte>(originalImage.Width, originalImage.Height);

            for (int Y = 0; Y < originalImage.Height; Y++)
            {
                for (int X = 0; X < originalImage.Width; X++)
                {
                    double rRaw = originalImage[Y, X].Red;
                    double gRaw = originalImage[Y, X].Green;
                    double bRaw = originalImage[Y, X].Blue;

                    double r = rRaw / 255;
                    double g = gRaw / 255;
                    double b = bRaw / 255;

                    double y = 0.299 * r + 0.587 * g + 0.114 * b;
                    double cB = -0.168736 * r + -0.331264 * g + 0.500 * b;
                    double cR = 0.500 * r + -0.418688 * g + -0.081312 * b;

                    bool isFire = false;

                    if (y >= cR && cR >= cB)
                    {
                        double crcb = cR - cB;
                        double ycb = y - cB;
                        if (!((crcb >= -0.1 && ycb >= -0.1 && ycb <= 0.3) || (crcb >= 0 && crcb <= 0.4 && ycb >= 0 && ycb <= 0.8)))
                            isFire = true;
                    }

                    if (isFire)
                        isFire = !(cR - cB > -0.1 && y - cB > -0.1 && y - cB <= 0.6);

                    if (isFire)
                        newImage[Y, X] = originalImage[Y, X];
                    else
                        newImage[Y, X] = new Bgr(0, 0, 0);
                }
            }

            return newImage;
        }


        private void btnCamera_Click(object sender, EventArgs e)
        {
            OpenCamera();
        }

        private void btnVideo_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            DialogResult result = dialog.ShowDialog();
            if (result.Equals(DialogResult.OK))
                if (dialog.FileName != null)
                    OpenVideo(dialog.FileName);
        }

        private void trbSeek_Scroll(object sender, EventArgs e)
        {
            int frameIndex = trbSeek.Value;
            videoCapture.SetCaptureProperty(CapProp.PosFrames, frameIndex);
        }

        private void chkDetect_CheckedChanged(object sender, EventArgs e)
        {
            detectFire = chkDetect.Checked;
        }

        private void chkFrameSkip_CheckedChanged(object sender, EventArgs e)
        {
            frameSkip = chkFrameSkip.Checked;
        }

       

       
    }
}
