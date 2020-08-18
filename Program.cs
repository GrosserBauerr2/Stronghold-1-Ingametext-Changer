using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net.Security;

namespace Tex_Converter
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                BinaryWriter bw = new BinaryWriter(File.Create("sh.tex"));
                string[] inp = File.ReadAllLines("sh.txt", Encoding.Default);
                byte bytes = 0x0;
                int Pluszahl = 0;
                int Integerzahl = 0;
                int[] Zahlen = new int[251];
                for (int i = 0; i < 251; i++)
                {
                    Zahlen[i] = Integerzahl;
                    Integerzahl = Integerzahl + 4;

                }
                int Start = 1000;
                int Zahl = 0;
                int J = 0;


                for (int i = 3; i < inp.Length - 2; i++)
                {
                    if (inp[i].Contains(">") & inp[i + 1] == (""))
                    {
                        Pluszahl = i + 2;
                    }
                    else
                    {
                        Pluszahl = i;
                        if (inp[i].Contains(">") == false)
                        {

                            char[] value = inp[i].ToCharArray();

                            foreach (char L in value)
                            {

                                Zahl = Zahl + 1;

                            }

                            Zahl = Zahl + 2;

                        }
                    }


                    if (inp[i].Contains(">"))
                    {
                        Zahl = Zahl + 1;
                        J = J + 1;
                        bw.BaseStream.Position = Zahlen[J];
                        bw.Write(Zahl);
                    }
                    i = Pluszahl;

                }
                UnicodeEncoding Unicode = new UnicodeEncoding();
                bw.BaseStream.Position = Start;
                for (int i = 3; i < inp.Length - 2; i++)
                {
                    if (inp[i].Contains(">") & inp[i + 1] == (""))
                    {
                        Pluszahl = i + 2;
                        bw.Write(bytes);
                        bw.Write(bytes);
                    }
                    else
                    {
                        Pluszahl = i;
                        if (inp[i].Contains(">") == false)
                        {
                            byte[] Linebytes = Unicode.GetBytes(inp[i]);
                            bw.Write(Linebytes);
                            bw.Write(bytes);
                            bw.Write(bytes);
                            bw.Write(bytes);
                            bw.Write(bytes);
                        }
                        else
                        {
                            bw.Write(bytes);
                            bw.Write(bytes);
                        }
                    }
                    i = Pluszahl;
                }
            }
        }
    }
}

