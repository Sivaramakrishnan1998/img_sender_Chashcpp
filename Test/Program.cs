using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Tester
{
	public struct ImageInfo{
        public IntPtr data;
        public int size;
    } 
    class Program
    {
    	
        static void Main(string[] args){
        	Image image = Image.FromFile("/home/deeplearningcv/Desktop/sky.jpeg");
        	sub_Program sub_Prog_obj = new sub_Program();
        	Image out_image = sub_Prog_obj.passingChashtoCpp(image);
        	out_image.Save("home/deeplearningcv/Desktop/passingChashtoCpp.jpg", ImageFormat.Jpeg);

        }
    }
    public class sub_Program{

    class AlgoCpp{
		[DllImport("libimg_converter.so",CallingConvention = CallingConvention.Cdecl)]
		public static extern void imagePassChashtoCpp(byte[] data, int dataLen, ref ImageInfo imTemplate);

		[DllImport("libimg_converter.so", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ReleaseMemoryFromC(IntPtr buf);
    }

	    public Image passingChashtoCpp(Image image){
	    	MemoryStream convertedImageMemoryStream;
	    	using (MemoryStream sourceImageStream = new MemoryStream()){
	            image.Save(sourceImageStream, System.Drawing.Imaging.ImageFormat.Png);
	            byte[] sourceImagePixels = sourceImageStream.ToArray();
	            ImageInfo imInfo = new ImageInfo();
	            AlgoCpp.imagePassChashtoCpp(sourceImagePixels, sourceImagePixels.Count(), ref imInfo);

	            byte[] imagePixels = new byte[imInfo.size];
	            Marshal.Copy(imInfo.data, imagePixels, 0, imInfo.size);
	            if (imInfo.data != IntPtr.Zero)
	                AlgoCpp.ReleaseMemoryFromC(imInfo.data);
	            convertedImageMemoryStream = new MemoryStream(imagePixels);
	        }
	        Image processed = new Bitmap(convertedImageMemoryStream);
	        return processed;
	    }
	}


}
