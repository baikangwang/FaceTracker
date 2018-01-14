namespace FaceTracker
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.imgCapture = new Emgu.CV.UI.ImageBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnCapture = new System.Windows.Forms.Button();
            this.gbOptions = new System.Windows.Forms.GroupBox();
            this.gbFaceRec = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ckbGray = new System.Windows.Forms.CheckBox();
            this.ckbPreview = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.imgPreview = new Emgu.CV.UI.ImageBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ckbEyes = new System.Windows.Forms.CheckBox();
            this.ckbNose = new System.Windows.Forms.CheckBox();
            this.ckbMouth = new System.Windows.Forms.CheckBox();
            this.rbFaceRec = new System.Windows.Forms.RadioButton();
            this.gbCapture = new System.Windows.Forms.GroupBox();
            this.rbCapture = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgCapture)).BeginInit();
            this.gbOptions.SuspendLayout();
            this.gbFaceRec.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgPreview)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.gbCapture.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.imgCapture);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(542, 433);
            this.panel1.TabIndex = 0;
            // 
            // imgCapture
            // 
            this.imgCapture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imgCapture.Location = new System.Drawing.Point(0, 0);
            this.imgCapture.Name = "imgCapture";
            this.imgCapture.Size = new System.Drawing.Size(540, 431);
            this.imgCapture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgCapture.TabIndex = 2;
            this.imgCapture.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(173, 15);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Flip V";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(92, 15);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Flip H";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnCapture
            // 
            this.btnCapture.Location = new System.Drawing.Point(11, 15);
            this.btnCapture.Name = "btnCapture";
            this.btnCapture.Size = new System.Drawing.Size(75, 23);
            this.btnCapture.TabIndex = 3;
            this.btnCapture.Text = "Start";
            this.btnCapture.UseVisualStyleBackColor = true;
            this.btnCapture.Click += new System.EventHandler(this.btnCapture_Click);
            // 
            // gbOptions
            // 
            this.gbOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbOptions.Controls.Add(this.gbFaceRec);
            this.gbOptions.Controls.Add(this.rbFaceRec);
            this.gbOptions.Controls.Add(this.gbCapture);
            this.gbOptions.Controls.Add(this.rbCapture);
            this.gbOptions.Location = new System.Drawing.Point(560, 13);
            this.gbOptions.Name = "gbOptions";
            this.gbOptions.Size = new System.Drawing.Size(273, 432);
            this.gbOptions.TabIndex = 4;
            this.gbOptions.TabStop = false;
            this.gbOptions.Text = "Options";
            // 
            // gbFaceRec
            // 
            this.gbFaceRec.Controls.Add(this.groupBox2);
            this.gbFaceRec.Controls.Add(this.groupBox1);
            this.gbFaceRec.Location = new System.Drawing.Point(6, 120);
            this.gbFaceRec.Name = "gbFaceRec";
            this.gbFaceRec.Size = new System.Drawing.Size(259, 298);
            this.gbFaceRec.TabIndex = 7;
            this.gbFaceRec.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ckbGray);
            this.groupBox2.Controls.Add(this.ckbPreview);
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Location = new System.Drawing.Point(11, 73);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(237, 214);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Face Detect";
            // 
            // ckbGray
            // 
            this.ckbGray.AutoSize = true;
            this.ckbGray.Location = new System.Drawing.Point(6, 42);
            this.ckbGray.Name = "ckbGray";
            this.ckbGray.Size = new System.Drawing.Size(48, 17);
            this.ckbGray.TabIndex = 6;
            this.ckbGray.Text = "Gray";
            this.ckbGray.UseVisualStyleBackColor = true;
            // 
            // ckbPreview
            // 
            this.ckbPreview.AutoSize = true;
            this.ckbPreview.Location = new System.Drawing.Point(6, 19);
            this.ckbPreview.Name = "ckbPreview";
            this.ckbPreview.Size = new System.Drawing.Size(64, 17);
            this.ckbPreview.TabIndex = 4;
            this.ckbPreview.Text = "Preview";
            this.ckbPreview.UseVisualStyleBackColor = true;
            this.ckbPreview.CheckedChanged += new System.EventHandler(this.ckbPreview_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.imgPreview);
            this.panel2.Location = new System.Drawing.Point(76, 19);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(155, 155);
            this.panel2.TabIndex = 3;
            // 
            // imgPreview
            // 
            this.imgPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imgPreview.Location = new System.Drawing.Point(0, 0);
            this.imgPreview.Name = "imgPreview";
            this.imgPreview.Size = new System.Drawing.Size(153, 153);
            this.imgPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgPreview.TabIndex = 2;
            this.imgPreview.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(77, 179);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(155, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ckbEyes);
            this.groupBox1.Controls.Add(this.ckbNose);
            this.groupBox1.Controls.Add(this.ckbMouth);
            this.groupBox1.Location = new System.Drawing.Point(11, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(237, 48);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Features";
            // 
            // ckbEyes
            // 
            this.ckbEyes.AutoSize = true;
            this.ckbEyes.Location = new System.Drawing.Point(6, 19);
            this.ckbEyes.Name = "ckbEyes";
            this.ckbEyes.Size = new System.Drawing.Size(49, 17);
            this.ckbEyes.TabIndex = 0;
            this.ckbEyes.Text = "Eyes";
            this.ckbEyes.UseVisualStyleBackColor = true;
            // 
            // ckbNose
            // 
            this.ckbNose.AutoSize = true;
            this.ckbNose.Location = new System.Drawing.Point(61, 19);
            this.ckbNose.Name = "ckbNose";
            this.ckbNose.Size = new System.Drawing.Size(51, 17);
            this.ckbNose.TabIndex = 1;
            this.ckbNose.Text = "Nose";
            this.ckbNose.UseVisualStyleBackColor = true;
            // 
            // ckbMouth
            // 
            this.ckbMouth.AutoSize = true;
            this.ckbMouth.Location = new System.Drawing.Point(118, 19);
            this.ckbMouth.Name = "ckbMouth";
            this.ckbMouth.Size = new System.Drawing.Size(56, 17);
            this.ckbMouth.TabIndex = 2;
            this.ckbMouth.Text = "Mouth";
            this.ckbMouth.UseVisualStyleBackColor = true;
            // 
            // rbFaceRec
            // 
            this.rbFaceRec.AutoSize = true;
            this.rbFaceRec.Location = new System.Drawing.Point(6, 96);
            this.rbFaceRec.Name = "rbFaceRec";
            this.rbFaceRec.Size = new System.Drawing.Size(103, 17);
            this.rbFaceRec.TabIndex = 6;
            this.rbFaceRec.TabStop = true;
            this.rbFaceRec.Text = "Face Recognize";
            this.rbFaceRec.UseVisualStyleBackColor = true;
            this.rbFaceRec.CheckedChanged += new System.EventHandler(this.rbFaceRec_CheckedChanged);
            // 
            // gbCapture
            // 
            this.gbCapture.Controls.Add(this.btnCapture);
            this.gbCapture.Controls.Add(this.button2);
            this.gbCapture.Controls.Add(this.button1);
            this.gbCapture.Location = new System.Drawing.Point(6, 42);
            this.gbCapture.Name = "gbCapture";
            this.gbCapture.Size = new System.Drawing.Size(259, 48);
            this.gbCapture.TabIndex = 5;
            this.gbCapture.TabStop = false;
            // 
            // rbCapture
            // 
            this.rbCapture.AutoSize = true;
            this.rbCapture.Location = new System.Drawing.Point(6, 19);
            this.rbCapture.Name = "rbCapture";
            this.rbCapture.Size = new System.Drawing.Size(62, 17);
            this.rbCapture.TabIndex = 4;
            this.rbCapture.TabStop = true;
            this.rbCapture.Text = "Capture";
            this.rbCapture.UseVisualStyleBackColor = true;
            this.rbCapture.CheckedChanged += new System.EventHandler(this.rbCapture_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 458);
            this.Controls.Add(this.gbOptions);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(861, 497);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgCapture)).EndInit();
            this.gbOptions.ResumeLayout(false);
            this.gbOptions.PerformLayout();
            this.gbFaceRec.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgPreview)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbCapture.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Emgu.CV.UI.ImageBox imgCapture;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnCapture;
        private System.Windows.Forms.GroupBox gbOptions;
        private System.Windows.Forms.GroupBox gbFaceRec;
        private System.Windows.Forms.CheckBox ckbMouth;
        private System.Windows.Forms.CheckBox ckbNose;
        private System.Windows.Forms.CheckBox ckbEyes;
        private System.Windows.Forms.RadioButton rbFaceRec;
        private System.Windows.Forms.GroupBox gbCapture;
        private System.Windows.Forms.RadioButton rbCapture;
        private System.Windows.Forms.CheckBox ckbPreview;
        private System.Windows.Forms.Panel panel2;
        private Emgu.CV.UI.ImageBox imgPreview;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox ckbGray;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

