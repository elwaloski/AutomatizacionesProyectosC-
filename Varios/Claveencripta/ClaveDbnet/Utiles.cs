using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaveDbnet
{
     class Utiles
    {
        public static string dese_vari(string string_encrip)
        {
            string str = string_encrip;
            try
            {
                string str2 = "";
                int num = 0;
                int num2 = 0;
                int num3 = 0;
                int index = 1;
                int num5 = 1;
                string[] strArray = new string[0x40];
                int length = string_encrip.Length;
                string str3 = string_encrip.Substring(1, length - 2);
                int num7 = str3.Length;
                int num8 = 0;
                if (num7 > 0)
                {
                    int num9;
                    for (num9 = 0x30; num9 <= 0x39; num9++)
                    {
                        num8++;
                        strArray[num8] = Convert.ToString((char)num9);
                    }
                    for (num9 = 0x41; num9 <= 90; num9++)
                    {
                        num8++;
                        strArray[num8] = Convert.ToString((char)num9);
                    }
                    num9 = 0x61;
                    while (num9 <= 0x7a)
                    {
                        num8++;
                        strArray[num8] = Convert.ToString((char)num9);
                        num9++;
                    }
                    int num10 = num8 + 1;
                    strArray[num10] = "*";
                    while ((num2 == 0) && (index < num10))
                    {
                        if (string_encrip.Substring(0, 1) == strArray[index])
                        {
                            num2 = 1;
                        }
                        else
                        {
                            index++;
                        }
                    }
                    while ((num3 == 0) && (num5 < num10))
                    {
                        if (string_encrip.Substring(length - 1, 1) == strArray[num5])
                        {
                            num3 = 1;
                        }
                        else
                        {
                            num5++;
                        }
                    }
                    if ((num2 == 1) && (num3 == 1))
                    {
                        int num11;
                        int num12;
                        if ((num7 % 3) == 0)
                        {
                            num11 = (num10 - 1) - index;
                            num12 = num5 - num11;
                        }
                        else if ((num7 % 2) == 0)
                        {
                            num12 = (num10 - 1) - index;
                            num11 = num12 - num5;
                        }
                        else
                        {
                            num12 = index;
                            num11 = ((num10 - 1) - num5) - num12;
                        }
                        int num13 = num12 - num11;
                        int num14 = 1;
                        while ((num14 < (num7 + 1)) && (num == 0))
                        {
                            num9 = 1;
                            while ((num == 0) && (num9 < num10))
                            {
                                int num15 = num9;
                                int num16 = ((num14 % 3) != 0) ? (((num14 % 2) != 0) ? (((num15 + num11) + num14) % num10) : (((num15 + num12) + num14) % num10)) : (((num15 + num13) + num14) % num10);
                                if (num16 == 0)
                                {
                                    num16 = num10;
                                }
                                if (str3.Substring(num14 - 1, 1) == strArray[num16])
                                {
                                    num = 1;
                                }
                                else
                                {
                                    num9++;
                                }
                            }
                            if (num == 1)
                            {
                                str2 = str2 + strArray[num9];
                                num = 0;
                                num14++;
                            }
                            else
                            {
                                num = 2;
                            }
                        }
                        if (num == 2)
                        {
                        }
                    }
                }
                return str2;
            }
            catch (Exception)
            {
                return str;
            }
        }

        public static string encr_vari(string string_original)
        {
            string str = null;
            int num7;
            int num12;
            int num13;
            int num = 12;
            int num2 = 10;
            int num3 = num - num2;
            int num4 = 0;
            int length = string_original.Length;
            string[] strArray = new string[length + 1];
            string[] strArray2 = new string[length + 1];
            string[] strArray3 = new string[0x40];
            int index = 0;
            if (length <= 0)
            {
                return null;
            }
            for (num7 = 0x30; num7 <= 0x39; num7++)
            {
                index++;
                strArray3[index] = Convert.ToString((char)num7);
            }
            for (num7 = 0x41; num7 <= 90; num7++)
            {
                index++;
                strArray3[index] = Convert.ToString((char)num7);
            }
            num7 = 0x61;
            while (num7 <= 0x7a)
            {
                index++;
                strArray3[index] = Convert.ToString((char)num7);
                num7++;
            }
            int num8 = index + 1;
            strArray3[num8] = "*";
            int num9 = 1;
            while ((num9 < (length + 1)) && (num4 == 0))
            {
                strArray[num9] = string_original.Substring(num9 - 1, 1);
                num7 = 1;
                while ((num4 == 0) && (num7 <= (num8 - 1)))
                {
                    if (strArray[num9] == strArray3[num7])
                    {
                        num4 = 1;
                    }
                    else
                    {
                        num7++;
                    }
                }
                if (num4 == 1)
                {
                    int num10 = num7;
                    int num11 = ((num9 % 3) != 0) ? (((num9 % 2) != 0) ? (((num10 + num2) + num9) % num8) : (((num10 + num) + num9) % num8)) : (((num10 + num3) + num9) % num8);
                    if (num11 == 0)
                    {
                        num11 = num8;
                    }
                    strArray2[num9] = strArray3[num11];
                    str = str + strArray2[num9];
                    num4 = 0;
                    num9++;
                }
                else
                {
                    num4 = 2;
                }
            }
            if (num4 == 2)
            {
                return null;
            }
            if ((length % 3) == 0)
            {
                num12 = (num8 - 1) - num2;
                num13 = num + num2;
            }
            else if ((length % 2) == 0)
            {
                num12 = (num8 - 1) - num;
                num13 = num - num2;
            }
            else
            {
                num12 = num;
                num13 = (num8 - 1) - (num + num2);
            }
            string str2 = strArray3[num12];
            string str3 = strArray3[num13];
            return (str2 + str + str3);
        }
        public bool validarNum(string strnum)
        {
            int result = 0;
            return int.TryParse(strnum, out result);
        }
    }
}
