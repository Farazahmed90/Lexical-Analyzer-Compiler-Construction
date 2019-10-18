using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lexical_Analyzer_D_Tech
{
    class Assigning_Tokens
    {
        int countnum = 0, countop = 0,countkw = 0, countch = 0, countdel =0 ,ynum = -1 ,ych =-1, ykw = -1;

        string[] keywords = { "abstract", "as", "base", "bool", "break", "by",
            "byte", "case", "catch", "char", "checked", "class", "const",
            "continue", "decimal", "default", "delegate", "do", "double",
            "descending", "explicit", "event", "extern", "else", "enum",
            "false", "finally", "fixed", "float", "for", "foreach", "from",
            "goto", "group", "if", "implicit", "in", "int", "interface",
            "internal", "into", "is", "lock", "long", "new", "null", "namespace",
            "object", "operator", "out", "override", "orderby",  "params",
            "private", "protected", "public", "readonly", "ref", "return",
            "switch", "struct", "sbyte", "sealed", "short", "sizeof",
            "stackalloc", "static", "string", "select",  "this",
            "throw", "true", "try", "typeof", "uint", "ulong", "unchecked",
            "unsafe", "ushort", "using", "var", "virtual", "volatile",
            "void", "while", "where", "yield","cout","cin","Console","WriteLine","ReadLine"};

        string[] separator = { ";", "{", "}", "\r", "\n", "\r\n", "(",")","[","]"};

        string[] operators = { "+", "-", "*", "/", "%", "&",
            "|", "^", "!", "~", "&&", "||",",",
            "++", "--", "<<", ">>", "==", "!=", "<", ">", "<=",
            ">=", "=", "+=", "-=", "*=", "/=", "%=", "&=", "|=",
            "^=", "<<=", ">>=", ".", "[]", "()", "?:", "=>", "??"};


        public string Checking_Given_String(ref string input_text)
        {
            StringBuilder stringbuilder = new StringBuilder();

            for (int i = 0; i < input_text.Length; i++)
            {
                if (Checking_Delimiter(input_text[i].ToString()))
                {
                    if (i + 1 < input_text.Length && Checking_Delimiter(input_text.Substring(i, 2)))
                    {
                        stringbuilder.Append(input_text.Substring(i, 2));
                        input_text = input_text.Remove(i, 2);
                        return Display_Answer(stringbuilder.ToString());
                    }
                    else
                    {
                        stringbuilder.Append(input_text[i]);
                        input_text = input_text.Remove(i, 1);
                        return Display_Answer(stringbuilder.ToString());
                    }
                }

                else if (Checking_Operators(input_text[i].ToString()))
                {
                    if (i + 1 < input_text.Length && (Checking_Operators(input_text.Substring(i, 2))))
                    {
                        if (i + 2 < input_text.Length && Checking_Operators(input_text.Substring(i, 3)))
                        {
                            stringbuilder.Append(input_text.Substring(i, 3));
                            input_text = input_text.Remove(i, 3);
                            return Display_Answer(stringbuilder.ToString());
                        }
                        else
                        {
                            stringbuilder.Append(input_text.Substring(i, 2));
                            input_text = input_text.Remove(i, 2);
                            return Display_Answer(stringbuilder.ToString());
                        }
                    }

                    else
                    {
                        int num;
                        if (input_text[i] == '-' && Int32.TryParse(input_text[i + 1].ToString(), out num))//yeh number check kra raha hay
                        {
                            continue;
                        }
                        stringbuilder.Append(input_text[i]);
                        input_text = input_text.Remove(i, 1);
                        return Display_Answer(stringbuilder.ToString());
                    }
                }
                else
                {
                    if (input_text[i + 1].ToString().Equals(" ")|| Checking_Delimiter(input_text[i + 1].ToString()) == true || Checking_Operators(input_text[i + 1].ToString()) == true)
                    {
                        if (Display_Answer(input_text.Substring(0, i + 1)).Contains("numerical constant") && input_text[i + 1] == '.')
                        {
                            int j = i + 2;
                            while (input_text[j].ToString().Equals(" ") == false && Checking_Delimiter(input_text[j].ToString()) == false && Checking_Operators(input_text[j].ToString()) == false)
                                j++;
                            int num;
                            if (Int32.TryParse(input_text.Substring(i + 2, j - i - 2), out num))//yeh check kr raha hay k number hay kya
                            {
                                stringbuilder.Append("(numerical constant, ").Append(input_text.Substring(0, j)).Append(") ");
                                input_text = input_text.Remove(0, j);
                                return stringbuilder.ToString();
                            }
                        }
                        stringbuilder.Append(input_text.Substring(0, i + 1));
                        input_text = input_text.Remove(0, i + 1);
                        return Display_Answer(stringbuilder.ToString());
                    }
                }

            }
            return null;
        }
        
        public string Display_Answer(string input_text)
        {
            string final_answer;
            int num;
 
            if (Int32.TryParse(input_text, out num)) //yeh check kr raha hay k number hain string main
            {
                final_answer = "'" + input_text + "' is num "+(ynum = countnum++ - ynum)+"\n";
                return final_answer;
            }

            if (Checking_Keyword(input_text) == true)
            {
                final_answer = "'" + input_text + "' is a keyword " + (ykw = countkw++ - ykw) + "\n";
                return final_answer;
            }

            if (Checking_Operators(input_text) == true)
            {
                final_answer = "'" + input_text + "' is a operator " + (countop++) + "\n";
                return final_answer;
            }
            
            if (Checking_Delimiter(input_text) == true)
            {
                final_answer = "'" + input_text + "' is a seprator " + (countdel++) + "\n";
                return final_answer;
            }

            final_answer = "'" + input_text + "' is a id " + (ych = countch++ - ych) + "\n";
            return final_answer;
        }


        private bool Checking_Operators(string input_string)
        {
            if (Array.IndexOf(operators, input_string) > -1) // yeh check operators walay array main input_string check karay ga
            {
                return true;
            }
            return false;
        }

        private bool Checking_Delimiter(string input_string) // yeh check separator walay array main input_string check karay ga
        {
            if (Array.IndexOf(separator, input_string) > -1)
            {
                return true;
            }
            return false;
        }
        private bool Checking_Keyword(string input_string) // yeh check keywords walay array main input_string check karay ga
        {
            if (Array.IndexOf(keywords, input_string) > -1)
            {
                return true;
            }
            return false;
        }
       
        
    }
}
