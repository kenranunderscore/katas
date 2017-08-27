namespace Logic
{
    using System.Security.Cryptography;
    using System.Text;

    public class Day5 : DayWithInput<string>
    {
        public Day5(string input)
            : base(input)
        {
        }

        public string DecodePassword()
        {
            string password = string.Empty;
            int i = 0;
            while (password.Length < 8)
            {
                string hash = HexMD5Hash($"{input}{i}");
                if (hash.StartsWith("00000"))
                {
                    password += hash[5];
                }
                ++i;
            }

            return password;
        }

        private static string HexMD5Hash(string value)
        {
            using (var md5 = MD5.Create())
            {
                var buf = Encoding.UTF8.GetBytes(value);
                var hash = md5.ComputeHash(buf);

                var builder = new StringBuilder();
                for (int i = 0; i < hash.Length; ++i)
                {
                    builder.Append(hash[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }
    }
}