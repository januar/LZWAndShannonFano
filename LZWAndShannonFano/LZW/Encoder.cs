using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LZWAndShannonFano.LZW
{
    class Encoder : IDisposable
    {
        public Dictionary<string, int> dict = new Dictionary<string, int>();
        ANSI table = null;
        int codeLen = 8;
        bool disposed = false;

        public Encoder()
        {
            table = new ANSI();
            dict = table.Table;
        }

        public byte[] Apply(ref int persen, string input)
        {
            StringBuilder sb = new StringBuilder();

            int i = 0;
            string w = "";
            while (i < input.Length)
            {
                w = input[i].ToString();

                i++;
                persen = (int)Math.Ceiling((double)i / input.Length * 100);

                while (dict.ContainsKey(w) && i < input.Length)
                {
                    w += input[i];
                }

                if (dict.ContainsKey(w) == false)
                {
                    string matchKey = w.Substring(0, w.Length - 1);
                    sb.Append(Convert.ToString(dict[matchKey], 2).FillWithZero(codeLen));

                    if (Convert.ToString(dict.Count, 2).Length > codeLen)
                        codeLen++;

                    dict.Add(w, dict.Count);
                    i--;
                }
                else
                {
                    sb.Append(Convert.ToString(dict[w], 2).FillWithZero(codeLen));

                    if (Convert.ToString(dict.Count, 2).Length > codeLen)
                        codeLen++;

                }
            }

            return sb.ToString().ToByteArray();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                // Dispose managed resources
                if (disposing)
                {
                    if (this.dict != null)
                    {
                        dict.Clear();
                        dict = null;
                    }
                }

                // Dispose unmanaged resources
                disposed = true;
            }
        }

        public void Dispose()
        {
            this.Dispose(true);

            GC.SuppressFinalize(this);
        }

    }
}
