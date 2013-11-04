using System;
using System.IO;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;

namespace DW.RtfWriter
{
    public class WMETA8
    {
        // Ensures that the metafile maintains a 1:1 aspect ratio
        private const int MM_ISOTROPIC = 7;
        // Allows the x-coordinates and y-coordinates of the metafile to be adjusted
        // independently
        private const int MM_ANISOTROPIC = 8;
        // The number of hundredths of millimeters (0.01 mm) in an inch
        // For more information, see GetImagePrefix() method.
        private const int HMM_PER_INCH = 2540;
        // The number of twips in an inch
        // For more information, see GetImagePrefix() method.
        private const int TWIPS_PER_INCH = 1440;
        // Specifies the flags/options for the unmanaged call to the GDI+ method
        // Metafile.EmfToWmfBits().
        private enum EmfToWmfBitsFlags
        {
            // Use the default conversion
            EmfToWmfBitsFlagsDefault = 0x0,
            // Embedded the source of the EMF metafiel within the resulting WMF
            // metafile
            EmfToWmfBitsFlagsEmbedEmf = 0x1,
            // Place a 22-byte header in the resulting WMF file.  The header is
            // required for the metafile to be considered placeable.
            EmfToWmfBitsFlagsIncludePlaceable = 0x2,
            // Don't simulate clipping by using the XOR operator.
            EmfToWmfBitsFlagsNoXORClip = 0x4
        };

        private Graphics GraphObj;

        private enum SHGetFileInfoConstants : uint
        {
            SHGFI_ICON = 0x100, // get icon
            SHGFI_DISPLAYNAME = 0x200, // get display name
            SHGFI_TYPENAME = 0x400, // get type name
            SHGFI_ATTRIBUTES = 0x800, // get attributes
            SHGFI_ICONLOCATION = 0x1000, // get icon location
            SHGFI_EXETYPE = 0x2000, // return exe type
            SHGFI_SYSICONINDEX = 0x4000, // get system icon index
            SHGFI_LINKOVERLAY = 0x8000, // put a link overlay on icon
            SHGFI_SELECTED = 0x10000, // show icon in selected state
            SHGFI_ATTR_SPECIFIED = 0x20000, // get only specified attributes
            SHGFI_LARGEICON = 0x0, // get large icon
            SHGFI_SMALLICON = 0x1, // get small icon
            SHGFI_OPENICON = 0x2, // get open icon
            SHGFI_SHELLICONSIZE = 0x4, // get shell size icon
            SHGFI_PIDL = 0x8, // pszPath is a pidl
            SHGFI_USEFILEATTRIBUTES = 0x10, // use passed dwFileAttribute
            SHGFI_ADDOVERLAYS = 0x000000020, // apply the appropriate overlays
            SHGFI_OVERLAYINDEX = 0x000000040 // Get the index of the overlay
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct SHFILEINFO
        {
            public IntPtr hIcon;
            public IntPtr iIcon;
            public uint dwAttributes;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szDisplayName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
            public string szTypeName;
        };
        [DllImport("shell32.dll")]
        private static extern IntPtr SHGetFileInfo(string pszPath,
            uint dwFileAttributes,
            ref SHFILEINFO psfi,
            uint cbSizeFileInfo,
            uint uFlags);
        /// <summary>
        /// Use the EmfToWmfBits function in the GDI+ specification to convert a 
        /// Enhanced Metafile to a Windows Metafile
        /// </summary>
        /// <param name="_hEmf">
        /// A handle to the Enhanced Metafile to be converted
        /// </param>
        /// <param name="_bufferSize">
        /// The size of the buffer used to store the Windows Metafile bits returned
        /// </param>
        /// <param name="_buffer">
        /// An array of bytes used to hold the Windows Metafile bits returned
        /// </param>
        /// <param name="_mappingMode">
        /// The mapping mode of the image.  This control uses MM_ANISOTROPIC.
        /// </param>
        /// <param name="_flags">
        /// Flags used to specify the format of the Windows Metafile returned
        /// </param>
        [DllImportAttribute("gdiplus.dll")]
        private static extern uint GdipEmfToWmfBits(IntPtr _hEmf, uint _bufferSize,
            byte[] _buffer, int _mappingMode, EmfToWmfBitsFlags _flags);
        // class constructor
        public WMETA8(Graphics GraphObj)
        {
            this.GraphObj = GraphObj;
        }
        public WMETA8()
        {
        }
        /// <summary>
        /// Creates the RTF control string that describes the image being inserted.
        /// The prefix should have the form ...
        /// <code>{\pict\wmetafile8\picw[A]\pich[B]\picwgoal[C]\pichgoal[D]</code>
        /// 
        /// where ...
        /// 
        /// A = current width of the metafile in hundredths of millimeters (0.01mm)
        ///  = Image Width in Inches * Number of (0.01mm) per inch
        ///  = (Image Width in Pixels / Graphics Context's Horizontal Resolution) * 2540
        ///  = (Image Width in Pixels / Graphics.DpiX) * 2540
        /// 
        /// B = current height of the metafile in hundredths of millimeters (0.01mm)
        ///  = Image Height in Inches * Number of (0.01mm) per inch
        ///  = (Image Height in Pixels / Graphics Context's Vertical Resolution) * 2540
        ///  = (Image Height in Pixels / Graphics.DpiX) * 2540
        /// 
        /// C = target width of the metafile in twips
        ///  = Image Width in Inches * Number of twips per inch
        ///  = (Image Width in Pixels / Graphics Context's Horizontal Resolution) * 1440
        ///  = (Image Width in Pixels / Graphics.DpiX) * 1440
        /// 
        /// D = target height of the metafile in twips
        ///  = Image Height in Inches * Number of twips per inch
        ///  = (Image Height in Pixels / Graphics Context's Horizontal Resolution) * 1440
        ///  = (Image Height in Pixels / Graphics.DpiX) * 1440
        /// 
        /// </summary>
        /// <remarks>
        /// The Graphics Context's resolution is simply the current resolution at which
        /// windows is being displayed.  Normally it's 96 dpi.
        /// 
        /// According to Ken Howe at pbdr.com, "Twips are screen-independent units
        /// used to ensure that the placement and proportion of screen elements in
        /// your screen application are the same on all display systems."
        /// 
        /// Units Used
        /// ----------
        /// 1 Twip = 1/20 Point
        /// 1 Point = 1/72 Inch
        /// 1 Twip = 1/1440 Inch
        /// 
        /// 1 Inch = 2.54 cm
        /// 1 Inch = 25.4 mm
        /// 1 Inch = 2540 (0.01)mm
        /// </remarks>
        /// <param name="_image">
        /// image which has to be inserted to RTF
        /// </param>
        /// <returns>
        /// RTF control string that describes the image
        /// <br>EXAMPLE:
        /// <code>{\pict\wmetafile8\picw[A]\pich[B]\picwgoal[C]\pichgoal[D]</code>
        /// </returns>
        private string GetImagePrefix(Image _image)
        {
            // The horizontal resolution at which the control is being displayed
            float xDpi;
            // The vertical resolution at which the control is being displayed
            float yDpi;
            String _rtf = "";

            // Get the horizontal and vertical resolutions at which the object is
            // being displayed
            Graphics _graphics = this.GraphObj;
            xDpi = _graphics.DpiX;
            yDpi = _graphics.DpiY;


            // Calculate the current width of the image in (0.01)mm
            int picw = (int)Math.Round((_image.Width / xDpi) * HMM_PER_INCH);
            // Calculate the current height of the image in (0.01)mm
            int pich = (int)Math.Round((_image.Height / yDpi) * HMM_PER_INCH);
            // Calculate the target width of the image in twips
            int picwgoal = (int)Math.Round((_image.Width / xDpi) * TWIPS_PER_INCH);
            // Calculate the target height of the image in twips
            int pichgoal = (int)Math.Round((_image.Height / yDpi) * TWIPS_PER_INCH);

            // Append values to RTF string
            _rtf = _rtf + "{\\pict\\wmetafile8" +
            "\\picw" + picw.ToString() +
            "\\pich" + pich.ToString() +
            "\\picwgoal" + picwgoal.ToString() +
            "\\pichgoal" + pichgoal.ToString() + " ";

            return _rtf;
        }

        /// <summary>
        /// Wraps the image in an Enhanced Metafile by drawing the image onto the
        /// graphics context, then converts the Enhanced Metafile to a Windows
        /// Metafile, and finally appends the bits of the Windows Metafile in HEX
        /// to a string and returns the string.
        /// </summary>
        /// <param name="_image">
        /// image which has to be converted
        /// </param>
        /// <returns>
        /// A string containing the bits of a Windows Metafile in HEX
        /// </returns>
        private string GetRtfImage(Image _image)
        {
            String _rtf = "";
            // Used to store the enhanced metafile
            MemoryStream _stream = null;
            // Used to create the metafile and draw the image
            Graphics _graphics = null;
            // The enhanced metafile
            Metafile _metaFile = null;
            // Handle to the device context used to create the metafile
            IntPtr _hdc;

            try
            {
                //_rtf = new StringBuilder();
                _stream = new MemoryStream();

                // Get a graphics context from the RichTextBox
                using (_graphics = this.GraphObj)
                {
                    // Get the device context from the graphics context
                    _hdc = _graphics.GetHdc();
                    // Create a new Enhanced Metafile from the device context
                    _metaFile = new Metafile(_stream, _hdc);
                    // Release the device context
                    _graphics.ReleaseHdc(_hdc);
                }

                // Get a graphics context from the Enhanced Metafile
                using (_graphics = Graphics.FromImage(_metaFile))
                {
                    // Draw the image on the Enhanced Metafile
                    _graphics.DrawImage(_image, new Rectangle(0, 0, _image.Width, _image.Height));
                }

                // Get the handle of the Enhanced Metafile
                IntPtr _hEmf = _metaFile.GetHenhmetafile();
                // A call to EmfToWmfBits with a null buffer return the size of the
                // buffer need to store the WMF bits.  Use this to get the buffer
                // size.
                uint _bufferSize = GdipEmfToWmfBits(_hEmf, 0, null, MM_ANISOTROPIC,
                    EmfToWmfBitsFlags.EmfToWmfBitsFlagsDefault);
                // Create an array to hold the bits
                byte[] _buffer = new byte[_bufferSize];
                // A call to EmfToWmfBits with a valid buffer copies the bits into the
                // buffer an returns the number of bits in the WMF.  
                uint _convertedSize = GdipEmfToWmfBits(_hEmf, _bufferSize, _buffer, MM_ANISOTROPIC,
                    EmfToWmfBitsFlags.EmfToWmfBitsFlagsDefault);
                // Append the bits to the RTF string
                for (int i = 0; i < _buffer.Length; ++i)
                {
                    _rtf = _rtf + String.Format("{0:X2}", _buffer[i]);
                }

                return _rtf;
            }
            finally
            {
                if (_graphics != null)
                    _graphics.Dispose();
                if (_metaFile != null)
                    _metaFile.Dispose();
                if (_stream != null)
                    _stream.Close();
            }
        }


        public byte[] getWMETA8Data(Image _image)
        {
            Graphics g = Graphics.FromImage(_image);
            this.GraphObj = g;
            // Used to store the enhanced metafile
            MemoryStream _stream = null;
            // Used to create the metafile and draw the image
            Graphics _graphics = null;
            // The enhanced metafile
            Metafile _metaFile = null;
            // Handle to the device context used to create the metafile
            IntPtr _hdc;

            try
            {
                //_rtf = new StringBuilder();
                _stream = new MemoryStream();

                // Get a graphics context from the RichTextBox
                using (_graphics = this.GraphObj)
                {
                    // Get the device context from the graphics context
                    _hdc = _graphics.GetHdc();
                    // Create a new Enhanced Metafile from the device context
                    _metaFile = new Metafile(_stream, _hdc);
                    // Release the device context
                    _graphics.ReleaseHdc(_hdc);
                }

                // Get a graphics context from the Enhanced Metafile
                using (_graphics = Graphics.FromImage(_metaFile))
                {
                    // Draw the image on the Enhanced Metafile
                    _graphics.DrawImage(_image, new Rectangle(0, 0, _image.Width, _image.Height));
                }

                // Get the handle of the Enhanced Metafile
                IntPtr _hEmf = _metaFile.GetHenhmetafile();
                // A call to EmfToWmfBits with a null buffer return the size of the
                // buffer need to store the WMF bits.  Use this to get the buffer
                // size.
                uint _bufferSize = GdipEmfToWmfBits(_hEmf, 0, null, MM_ANISOTROPIC,
                    EmfToWmfBitsFlags.EmfToWmfBitsFlagsDefault);
                // Create an array to hold the bits
                byte[] _buffer = new byte[_bufferSize];
                // A call to EmfToWmfBits with a valid buffer copies the bits into the
                // buffer an returns the number of bits in the WMF.  
                uint _convertedSize = GdipEmfToWmfBits(_hEmf, _bufferSize, _buffer, MM_ANISOTROPIC,
                    EmfToWmfBitsFlags.EmfToWmfBitsFlagsDefault);

                return _buffer;
            }
            finally
            {
                if (_graphics != null)
                    _graphics.Dispose();
                if (_metaFile != null)
                    _metaFile.Dispose();
                if (_stream != null)
                    _stream.Close();
            }
        }
        /// <summary>
        /// returns a string which contains a wmetafile8-Icon string.
        /// The image is wrapped in a Windows Format Metafile
        /// </summary>
        /// <param name="_image">
        /// image which has to be converted to wmetafile8
        /// </param>
        /// <returns>
        /// A string which contains a wmetafile8-Icon string.
        /// </returns>
        public string getWMeta8Image(Image _image)
        {
            String _rtf = "";

            // Create the image control string and append it to the RTF string
            _rtf = _rtf + GetImagePrefix(_image);
            // Create the Windows Metafile and append its bytes in HEX format
            _rtf = _rtf + GetRtfImage(_image) + "}";

            return _rtf;
        }

        /// <summary>
        /// This Method is used to return the windows file type icon in rtf form
        /// </summary>
        /// <param name="fileName">
        /// Out of fileName-extenion the file type icon is extracted
        /// <br>EXAMPLE:
        /// fileName = "Hello.doc" ---> Result will be the icon for MS Word document
        /// </param>
        /// <returns>
        /// A String containing a icon in WMeta8 Icon format (RTF Control string).
        /// </returns>
        public string getRTFIcon(string fileName)
        {
            String rtfString = "";
            SHFILEINFO shinfo;
            Icon FTypeIcon;
            Image imgIcon;

            shinfo = new SHFILEINFO();
            SHGetFileInfo(fileName, 0, ref shinfo,
                (uint)Marshal.SizeOf(shinfo),
                (uint)(SHGetFileInfoConstants.SHGFI_ICON |
                SHGetFileInfoConstants.SHGFI_LARGEICON |
                SHGetFileInfoConstants.SHGFI_USEFILEATTRIBUTES));

            FTypeIcon = Icon.FromHandle(shinfo.hIcon);
            imgIcon = FTypeIcon.ToBitmap();
            rtfString = this.getWMeta8Image(imgIcon);

            return rtfString;
        }
    }
}