using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question_04
{
    class Methods
    {
        IplImage src, gray, bp1, bp2, bp3, bp4, bp5, bp6, bp7, bp8, CombinedImage;

        public void loadOriginalImage()
        {
            src = Cv.LoadImage("220px-Lenna_(test_image).png", LoadMode.Color);            
        }

        public void convertToGray()
        {
            gray = Cv.CreateImage(src.Size, BitDepth.U8, 1);
            Cv.CvtColor(src, gray, ColorConversion.RgbToGray);
            Cv.SaveImage("gray.jpg", gray);
        }

        public void SeperateBitPlanes()
        {
            int Pixel = 0;
            string BinaryPixel = "";
            for(int y=0; y < gray.Height; y++)
            {
                for(int x=0; x < gray.Width; x++)
                {
                    Pixel = (int)Cv.GetReal2D(gray,y,x);
                    BinaryPixel = convertToBinary(Pixel);

                    Cv.SetReal2D(bp8, y, x, ( char.GetNumericValue(BinaryPixel[0])) * 255 );
                    Cv.SetReal2D(bp7, y, x, ( char.GetNumericValue(BinaryPixel[1])) * 255 );
                    Cv.SetReal2D(bp6, y, x, ( char.GetNumericValue(BinaryPixel[2])) * 255 );
                    Cv.SetReal2D(bp5, y, x, ( char.GetNumericValue(BinaryPixel[3])) * 255 );
                    Cv.SetReal2D(bp4, y, x, ( char.GetNumericValue(BinaryPixel[4])) * 255 );
                    Cv.SetReal2D(bp3, y, x, ( char.GetNumericValue(BinaryPixel[5])) * 255 );
                    Cv.SetReal2D(bp2, y, x, ( char.GetNumericValue(BinaryPixel[6])) * 255 );
                    Cv.SetReal2D(bp1, y, x, ( char.GetNumericValue(BinaryPixel[7])) * 255 );
                } 
            }

            Cv.SaveImage("Bit Plane 8.jpg", bp8);
            Cv.SaveImage("Bit Plane 7.jpg", bp7);
            Cv.SaveImage("Bit Plane 6.jpg", bp6);
            Cv.SaveImage("Bit Plane 5.jpg", bp5);
            Cv.SaveImage("Bit Plane 4.jpg", bp4);
            Cv.SaveImage("Bit Plane 3.jpg", bp3);
            Cv.SaveImage("Bit Plane 2.jpg", bp2);
            Cv.SaveImage("Bit Plane 1.jpg", bp1);
        }

    
        public void createEmptyPlanes()
        {
            bp1 = Cv.CreateImage(gray.Size, BitDepth.U8, 1);
            bp2 = Cv.CreateImage(gray.Size, BitDepth.U8, 1);
            bp3 = Cv.CreateImage(gray.Size, BitDepth.U8, 1);
            bp4 = Cv.CreateImage(gray.Size, BitDepth.U8, 1);
            bp5 = Cv.CreateImage(gray.Size, BitDepth.U8, 1);
            bp6 = Cv.CreateImage(gray.Size, BitDepth.U8, 1);
            bp7 = Cv.CreateImage(gray.Size, BitDepth.U8, 1);
            bp8 = Cv.CreateImage(gray.Size, BitDepth.U8, 1);
        }


        public void combinePlanes()
        {
            CombinedImage = Cv.CreateImage(gray.Size, BitDepth.U8, 1);
            int Pixel = 0;
            double CombinedVal = 0.0;
            string BinaryPixel = "";

            for (int y=0;y<src.Height;y++)
            {
                for(int x=0;x<src.Width;x++)
                {
                    Pixel = (int)Cv.GetReal2D(gray, y, x);
                    BinaryPixel = convertToBinary(Pixel);

                    CombinedVal = ((char.GetNumericValue(BinaryPixel[0])*128) + 
                                   (char.GetNumericValue(BinaryPixel[1])*64) + 
                                   (char.GetNumericValue(BinaryPixel[2])*32) + 
                                   (char.GetNumericValue(BinaryPixel[3])*16));

                    Cv.SetReal2D(CombinedImage, y, x, CombinedVal);            
                }
            }
    
            Cv.SaveImage("CombinedImage.jpg", CombinedImage);
        }

        

        public string convertToBinary(int PixelValue)
        {
            var no = PixelValue;
            var bin = "";

            if (no == 1)
            {
                bin = "10";
            }
            else
            {
                while (no != 1)
                {

                    bin = bin + (no % 2);
                    no = no / 2;
                    if (no == 1)
                    {
                        bin = bin + no;
                    }
                }
            }

            char[] binary = new char[8];
            for (int c = 0; c < binary.Length; c++)
            {
                binary[c] = '0';
            }

            for (int x = 0; x <= bin.Length - 1; x++)
            {
                binary[x] = bin[x];
            }

            char[] FinalBinary = new char[binary.Length];
            for (int z = 0; z < binary.Length; z++)
            {
                FinalBinary[z] = binary[(binary.Length - 1) - z];
            }

            string val = new string(FinalBinary);
            Console.WriteLine(val);
            return val;
        }
    }
}
