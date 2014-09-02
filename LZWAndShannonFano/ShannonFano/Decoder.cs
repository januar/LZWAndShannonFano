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

        public byte[] Decoding(String code, ref int persen)
        {
            int i = 0;
            int j = 1;
            tempImage = new List<byte>();
            while (i < code.Length)
            {
                try
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
                catch (Exception e)
                {
                    i += j;
                    j = 1;
                }
            }
            return tempImage.ToArray();
        }

        public void getResolution(ref int width, ref int height, int widthLeng, int heightLeng, byte[] encodingByte)
        {
            byte[] temp = new byte[widthLeng];
            for (int i = 0; i < widthLeng; i++)
            {
                temp[i] = encodingByte[i + 3];
            }
            width = BitConverter.ToInt32(temp, 0);

            temp = new byte[heightLeng];
            for (int i = 0; i < heightLeng; i++)
            {
                temp[i] = encodingByte[i + widthLeng + 3];
            }
            height = BitConverter.ToInt32(temp, 0);
        }
    }
}
