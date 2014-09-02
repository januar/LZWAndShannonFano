using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace LZWAndShannonFano.ShannonFano
{
    class Decoder
    {
        public List<SFCode> SFCode;
        private List<byte> tempImage;

        public Decoder()
        {
            SFCode = new List<SFCode>();
            tempImage = new List<byte>();
        }

        public void SetSFCode(String sf)
        {
            string[] listcode = sf.Split(';');
            foreach (String item in listcode)
            {
                string[] code = item.Split('#');
                if (code.Length < 2)
                    continue;

                SFCode.Add(new SFCode()
                {
                    Simbol = Convert.ToByte(Convert.ToInt32(code[0])),
                    Code = code[1]
                });
            }
        }

        public Bitmap Decoding(String code, int width, int height, ref int persen)
        {
            Bitmap image = new Bitmap(width, height);
            int i = 0;
            int j = 1;
            while (i < code.Length)
            {
                persen = (int)Math.Ceiling((double)i / code.Length * 100);
                String binary = "";
                binary = code.Substring(i, j);
                var sfitem = (from sf in SFCode
                              where sf.Code == binary
                              select sf).FirstOrDefault();
                if (sfitem == null)
                {
                    j++;
                }
                else
                {
                    tempImage.Add(sfitem.Simbol);
                    i += j;
                    j = 1;
                }
            }

            int temp = 0;
            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    image.SetPixel(x, y, Color.FromArgb(tempImage[temp], tempImage[temp + 1], tempImage[temp + 2]));
                    temp += 3;
                }
            }
            return image;
        }
    }
}
