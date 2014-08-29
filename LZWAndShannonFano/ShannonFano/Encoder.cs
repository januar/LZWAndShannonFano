using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace LZWAndShannonFano.ShannonFano
{
    class Encoder
    {
        public List<SFCode> SFCode;

        public Encoder()
        {
            SFCode = new List<SFCode>();
        }

        public void CovertPixel(Bitmap image)
        {
            for (int i = 0; i < image.Height; i++)
            {
                for (int j = 0; j < image.Width; j++)
                {
                    //red color
                    var red = (from s in SFCode
                              where s.Simbol == image.GetPixel(j, i).R
                              select s).FirstOrDefault();

                    if (red == null)
                    {
                        SFCode.Add(new SFCode { Simbol = image.GetPixel(j, i).R, Frekuensi = 1, Code = "" });
                    }
                    else {
                        red.Frekuensi++;
                    }

                    //green color
                    var green = (from s in SFCode
                               where s.Simbol == image.GetPixel(j, i).G
                               select s).FirstOrDefault();

                    if (green == null)
                    {
                        SFCode.Add(new SFCode { Simbol = image.GetPixel(j, i).G, Frekuensi = 1, Code = "" });
                    }
                    else
                    {
                        green.Frekuensi++;
                    }

                    //blue color
                    var blue = (from s in SFCode
                                 where s.Simbol == image.GetPixel(j, i).B
                                 select s).FirstOrDefault();

                    if (blue == null)
                    {
                        SFCode.Add(new SFCode { Simbol = image.GetPixel(j, i).B, Frekuensi = 1, Code = "" });
                    }
                    else
                    {
                        blue.Frekuensi++;
                    }
                }
            }
            SFCode = SFCode.OrderByDescending(s => s.Frekuensi).ToList();
        }

        public String Encoding(Bitmap Image)
        {
            this.CovertPixel(Image);

            return "";
        }
    }
}
