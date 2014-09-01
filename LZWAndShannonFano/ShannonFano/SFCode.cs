using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LZWAndShannonFano.ShannonFano
{
    class SFCode
    {
        public byte Simbol { get; set; }
        public int Frekuensi { get; set; }
        public string Code { get; set; }

        public static int BMP = 1;
        public static int JPG = 2;
        public static int JPEG = 3;
        public static int PNG = 4;
        public static int GIF = 5;
        public static int TIFF = 6;
    }
}
