using System.Text;

namespace CommonlyUsed
{
    public static class StringComponent
    {
        /// <summary>
        /// •¶š—ñ‚ğ˜AŒ‹‚³‚¹‚éŠÖ”(Å‘å5‚Â‚Ü‚Å)
        /// </summary>
        public static string AddString(string str0, string str1, string str2 = "", string str3 = "", string str4 = "")
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(str0);
            sb.Append(str1);
            sb.Append(str2);
            sb.Append(str3);
            sb.Append(str4);
            string s = sb.ToString();
            return s;
        }

        /// <summary>
        /// •¡”‚Ì•¶š—ñ‚ğ˜AŒ‹‚³‚¹‚éŠÖ”
        /// ˆø”(string[]•¶š—ñ‚Ì”z—ñ)
        /// </summary>
        public static string AddString(string[] str)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string word in str)
            {
                sb.Append(word);
            }
            string text = sb.ToString();
            return text;
        }
    }
}
