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

        public void CovertPixel(byte[] image, ref int persen)
        {
            for (int i = 0; i < image.Length; i++)
            {
                persen = (int)Math.Ceiling(((double)i / image.Length * 100) * 0.3);
                var item = (from s in SFCode
                            where s.Simbol == image[i]
                            select s).FirstOrDefault();
                if (item == null)
                {
                    SFCode.Add(new SFCode { Simbol = image[i], Frekuensi = 1, Code = "" });
                }
                else
                {
                    item.Frekuensi++;
                }
            }
            SFCode = SFCode.OrderByDescending(s => s.Frekuensi).ToList();
        }

        public String Encoding(byte[] image, ref int persen)
        {
            this.CovertPixel(image, ref persen);
            Console.WriteLine("Convert Pixel = " + persen);
            ShannonFanoCode();
            int temp = persen += 30;
            Console.WriteLine("ShannonFanoCode = " + persen);

            String bit = "";
            for (int i = 0; i < image.Length; i++)
            {
                int persen2 = (int)Math.Ceiling(((double)i / image.Length * 100) * 0.4);
                persen = persen2 + temp;
                var encod = (from s in SFCode
                             where s.Simbol == image[i]
                             select s.Code).FirstOrDefault();
                bit += encod;
            }

            persen = 100;
            return bit;
        }

        public void ShannonFanoCode()
        {
            if (SFCode.Count == 1)
            {
                SFCode[0].Code = "0";
            }
            else
            {
                int midFrekuensi = SFCode.Sum(sf => sf.Frekuensi) / 2;
                List<SFCode> S1 = new List<SFCode>();
                List<SFCode> S2 = new List<SFCode>();
                SplitList(ref S1, ref S2, SFCode, midFrekuensi);
                ShannonFanoCode(S1, "0");
                ShannonFanoCode(S2, "1");
            }
        }

        public void ShannonFanoCode(List<SFCode> sf, string codebit)
        {
            if (sf.Count == 1)
            {
                ShannonFano.SFCode code = (from s in SFCode
                                           where s.Simbol == sf[0].Simbol
                                           select s).FirstOrDefault();
                code.Code = codebit;
            }
            else
            {
                int midFrekuensi = sf.Sum(s => s.Frekuensi) / 2;
                List<SFCode> S1 = new List<SFCode>();
                List<SFCode> S2 = new List<SFCode>();
                SplitList(ref S1, ref S2, sf, midFrekuensi);
                ShannonFanoCode(S1, codebit + "0");
                ShannonFanoCode(S2, codebit + "1");
            }
        }

        private void SplitList(ref List<SFCode> S1, ref List<SFCode> S2, List<SFCode> list, int frekuensi)
        {
            int sum = 0;
            foreach (var item in list)
            {
                if (sum < frekuensi)
                {
                    S1.Add(item);
                }
                else
                {
                    S2.Add(item);
                }
                sum += item.Frekuensi;
            }
        }

        public String GetSFCode()
        {
            String sf = "";
            foreach (var item in SFCode)
            {
                sf += item.Simbol + "#" + item.Code + ";";
            }

            return sf;
        }
    }
}
