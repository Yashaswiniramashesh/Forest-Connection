﻿namespace sysn
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
            this.picPreview = new System.Windows.Forms.PictureBox();
            this.picRedFilter = new System.Windows.Forms.PictureBox();
            this.picFinal = new System.Windows.Forms.PictureBox();
            this.btnCamera = new System.Windows.Forms.Button();
            this.btnVideo = new System.Windows.Forms.Button();
            this.chkDetect = new System.Windows.Forms.CheckBox();
            this.chkFrameSkip = new System.Windows.Forms.CheckBox();
            this.trbSeek = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRedFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFinal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbSeek)).BeginInit();
            this.SuspendLayout();
            // 
            // picPreview
            // 
            this.picPreview.Location = new System.Drawing.Point(46, 26);
            this.picPreview.Name = "picPreview";
            this.picPreview.Size = new System.Drawing.Size(310, 317);
            this.picPreview.TabIndex = 0;
            this.picPreview.TabStop = false;
            // 
            // picRedFilter
            // 
            this.picRedFilter.Location = new System.Drawing.Point(373, 26);
            this.picRedFilter.Name = "picRedFilter";
            this.picRedFilter.Size = new System.Drawing.Size(329, 317);
            this.picRedFilter.TabIndex = 1;
            this.picRedFilter.TabStop = false;
            // 
            // picFinal
            // 
            this.picFinal.Location = new System.Drawing.Point(725, 26);
            this.picFinal.Name = "picFinal";
            this.picFinal.Size = new System.Drawing.Size(303, 317);
            this.picFinal.TabIndex = 2;
            this.picFinal.TabStop = false;
            // 
            // btnCamera
            // 
            this.btnCamera.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnCamera.Location = new System.Drawing.Point(834, 349);
            this.btnCamera.Name = "btnCamera";
            this.btnCamera.Size = new System.Drawing.Size(146, 37);
            this.btnCamera.TabIndex = 3;
            this.btnCamera.Text = "Open Camera";
            this.btnCamera.UseVisualStyleBackColor = true;
            this.btnCamera.Click += new System.EventHandler(this.btnCamera_Click);
            // 
            // btnVideo
            // 
            this.btnVideo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnVideo.Location = new System.Drawing.Point(46, 349);
            this.btnVideo.Name = "btnVideo";
            this.btnVideo.Size = new System.Drawing.Size(146, 36);
            this.btnVideo.TabIndex = 4;
            this.btnVideo.Text = "Open Video";
            this.btnVideo.UseVisualStyleBackColor = true;
            this.btnVideo.Click += new System.EventHandler(this.btnVideo_Click);
            // 
            // chkDetect
            // 
            this.chkDetect.AutoSize = true;
            this.chkDetect.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkDetect.Location = new System.Drawing.Point(330, 358);
            this.chkDetect.Name = "chkDetect";
            this.chkDetect.Size = new System.Drawing.Size(96, 21);
            this.chkDetect.TabIndex = 5;
            this.chkDetect.Text = "Detect Fire";
            this.chkDetect.UseVisualStyleBackColor = true;
            this.chkDetect.CheckedChanged += new System.EventHandler(this.chkDetect_CheckedChanged);
            // 
            // chkFrameSkip
            // 
            this.chkFrameSkip.AutoSize = true;
            this.chkFrameSkip.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkFrameSkip.Location = new System.Drawing.Point(442, 358);
            this.chkFrameSkip.Name = "chkFrameSkip";
            this.chkFrameSkip.Size = new System.Drawing.Size(98, 21);
            this.chkFrameSkip.TabIndex = 6;
            this.chkFrameSkip.Text = "Frame Skip";
            this.chkFrameSkip.UseVisualStyleBackColor = true;
            this.chkFrameSkip.CheckedChanged += new System.EventHandler(this.chkFrameSkip_CheckedChanged);
            // 
            // trbSeek
            // 
            this.trbSeek.Location = new System.Drawing.Point(46, 428);
            this.trbSeek.Name = "trbSeek";
            this.trbSeek.Size = new System.Drawing.Size(1000, 45);
            this.trbSeek.TabIndex = 7;
            this.trbSeek.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trbSeek.Scroll += new System.EventHandler(this.trbSeek_Scroll);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1060, 496);
            this.Controls.Add(this.trbSeek);
            this.Controls.Add(this.chkFrameSkip);
            this.Controls.Add(this.chkDetect);
            this.Controls.Add(this.btnVideo);
            this.Controls.Add(this.btnCamera);
            this.Controls.Add(this.picFinal);
            this.Controls.Add(this.picRedFilter);
            this.Controls.Add(this.picPreview);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRedFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFinal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbSeek)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picPreview;
        private System.Windows.Forms.PictureBox picRedFilter;
        private System.Windows.Forms.PictureBox picFinal;
        private System.Windows.Forms.Button btnCamera;
        private System.Windows.Forms.Button btnVideo;
        private System.Windows.Forms.CheckBox chkDetect;
        private System.Windows.Forms.CheckBox chkFrameSkip;
        private System.Windows.Forms.TrackBar trbSeek;
    }
}

