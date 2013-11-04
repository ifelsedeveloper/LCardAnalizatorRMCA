using System;
using System.Configuration;
using System.Text;
using System.Drawing;
using System.IO;
using Image = System.Drawing.Image;

namespace DW.RtfWriter
{
	/// <summary>
	/// Summary description for RtfImage
	/// </summary>
	public class RtfImage : RtfBlock
	{
        private byte[] _imgBin;
		private ImageFileType _imgType;
		private Align _alignment;
		private Margins _margins;
		private float _width;
		private float _height;
		private bool _keepAspectRatio;
		private string _blockHead;
		private string _blockTail;
		private bool _startNewPage;
        private Image _image;

		internal RtfImage(string fileName, ImageFileType type)
		{
            Image image = Image.FromFile(fileName);
            _imgType = type;
            _image = image;
            _imgBin = imageToByteArray(image);
			
			_alignment = Align.None;
			_margins = new Margins();
			_keepAspectRatio = true;
			_blockHead = @"{\pard";
			_blockTail = @"\par}";
			_startNewPage = false;
			
			
			_width = (image.Width / image.HorizontalResolution) * 72;
			_height = (image.Height / image.VerticalResolution) * 72;
		}

        internal RtfImage(System.Drawing.Image imageIn, ImageFileType type)
        {
            _imgType = type;
            _image = imageIn;
            _imgBin = imageToByteArray(imageIn);
            
            _alignment = Align.None;
            _margins = new Margins();
            _keepAspectRatio = true;
            _blockHead = @"{\pard";
            _blockTail = @"\par}";
            _startNewPage = false;

            _width = (imageIn.Width / imageIn.HorizontalResolution) * 72;
            _height = (imageIn.Height / imageIn.VerticalResolution) * 72;
        }

        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            if (_imgType == ImageFileType.Gif)
                imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            else if (_imgType == ImageFileType.Jpg)
                imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            else if (_imgType == ImageFileType.Png)
                imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            else if (_imgType == ImageFileType.Wmf)
            {
                
                WMETA8 wmfconv=new WMETA8();
                return wmfconv.getWMETA8Data(imageIn);
            }
            return ms.ToArray();
            //ImageConverter converter = new ImageConverter();
            //return (byte[])converter.ConvertTo(imageIn, typeof(byte[]));
        }






		public override Align Alignment
		{
			get
			{
				return _alignment;
			}
			set
			{
				_alignment = value;
			}
		}

		public override Margins Margins
		{
			get
			{
				return _margins;
			}
		}

		public override bool StartNewPage
		{
			get
			{
				return _startNewPage;
			}
			set
			{
				_startNewPage = value;
			}
		}

		public float Width
		{
			get
			{
				return _width;
			}
			set
			{
				if (_keepAspectRatio && _width > 0) {
					float ratio = _height / _width;
					_height = value * ratio;
				}
				_width = value;
			}
		}

		public float Heigth
		{
			get
			{
				return _height;
			}
			set
			{
				if (_keepAspectRatio && _height > 0) {
					float ratio = _width / _height;
					_width = value * ratio;
				}
				_height = value;
			}
		}
		
		public bool KeepAspectRatio
		{
			get
			{
				return _keepAspectRatio;
			}
			set
			{
				_keepAspectRatio = value;
			}
		}

		public override RtfCharFormat DefaultCharFormat
		{
			// DefaultCharFormat is meaningless for RtfImage.
			get
			{
				return null;
			}
		}

		private string extractImage()
		{	
			StringBuilder result = new StringBuilder();

            for (int i = 0; i < _imgBin.Length; i++)
            {
				if (i != 0 && i % 60 == 0) {
					result.AppendLine();
				}
                result.AppendFormat("{0:x2}", _imgBin[i]);
			}
			return result.ToString();
		}

		internal override string BlockHead
		{
			set
			{
				_blockHead = value;
			}
		}

		internal override string BlockTail
		{
			set
			{
				_blockTail = value;
			}
		}

        
		internal override string render()
		{
			StringBuilder result = new StringBuilder(_blockHead);

			if (_startNewPage) {
				result.Append(@"\pagebb");
			}

			if (_margins[Direction.Top] >= 0) {
				result.Append(@"\sb" + RtfUtility.pt2Twip(_margins[Direction.Top]));
			}
			if (_margins[Direction.Bottom] >= 0) {
				result.Append(@"\sa" + RtfUtility.pt2Twip(_margins[Direction.Bottom]));
			}
			if (_margins[Direction.Left] >= 0) {
				result.Append(@"\li" + RtfUtility.pt2Twip(_margins[Direction.Left]));
			}
			if (_margins[Direction.Right] >= 0) {
				result.Append(@"\ri" + RtfUtility.pt2Twip(_margins[Direction.Right]));
			}
			switch (_alignment) {
			case Align.Left:
				result.Append(@"\ql");
				break;
			case Align.Right:
				result.Append(@"\qr");
				break;
			case Align.Center:
				result.Append(@"\qc");
				break;
			}
			result.AppendLine();

			//result.Append(@"{\*\shppict{\pict");
            //{\*\generator Msftedit 5.41.21.2510;}\viewkind4\uc1\pard\sa200\sl240\slmult1\lang9\f0\fs22
            result.Append(@"{\pict");
			if (_imgType == ImageFileType.Jpg) {
				result.Append(@"\jpegblip");
			} else if (_imgType == ImageFileType.Png || _imgType == ImageFileType.Gif) {
				result.Append(@"\pngblip");
            }
            else if (_imgType == ImageFileType.Wmf)
            {
                result.Append(@"\wmetafile8");
            }
            else
            {
				throw new Exception("Image type not supported.");
			}
			if (_height > 0) {
                //result.Append(@"\pich" + RtfUtility.pt2Twip(_image.Height).ToString());
				result.Append(@"\pichgoal" + RtfUtility.pt2Twip(_height));
			}
			if (_width > 0) {
                //result.Append(@"\picw" + RtfUtility.pt2Twip(_image.Width).ToString());
				result.Append(@"\picwgoal" + RtfUtility.pt2Twip(_width));
			}
			result.AppendLine();
			
			result.AppendLine(extractImage());
			result.AppendLine("}");
            result.AppendLine(@"\par");
			result.AppendLine(_blockTail);
			return result.ToString();
		}
	}
}