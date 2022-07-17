using System;
using Auction.Domain.Convertors;

namespace Auction.Application.Generator
{
    public class Generator
    {
        public static string GenerateUniqCode()
        {
            return Guid.NewGuid().ToString().Replace("-", "");
        }
        public static string GenerateRandom()
        {
            int _min = 1;
            int _max = 9;
            Random rdm = new Random();
            string step1 = rdm.Next(_min, _max).ToString();
            string step2 = rdm.Next(_min, _max).ToString();

            Random r = new Random();
            string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "l", "n", "p", "q", "r", "s", "s", "z", "t", "v", "w", "x" };
            string[] vowels = { "a", "e", "i", "o", "u", "a", "y" };
            string name = "";
            name += consonants[r.Next(consonants.Length)].ToUpper();
            name += vowels[r.Next(vowels.Length)];
            int b = 2; //b tells how many times a new letter has been added. It's 2 right now because the first two letters are already in the name.
            while (b < 2)
            {
                name += consonants[r.Next(consonants.Length)];
                b++;
                name += vowels[r.Next(vowels.Length)];
                b++;
            }

            return step1 + name + step2;
        }
        public static string GenerateCode()
        {
            int _min = 1111;
            int _max = 9999;
            Random rdm = new Random();
            return rdm.Next(_min, _max).ToString();
        }
        public static int GenerateCodeRefId()
        {
            var dateTime = int.Parse(DateTime.Now.ToShamsi().Replace("/", "").Substring(2, 6));

            int _min = 11;
            int _max = 99;
            Random rdm = new Random();
            string step2 = rdm.Next(_min, _max).ToString();
            string res = dateTime + step2;
            int r = int.Parse(res);
            return r;
        }
        public static string IssueTracking(int id)
        {
            return DateTime.Now.ToShamsi().Replace("/", "").Substring(2, 6) + (id.ToString("00000"));
        }
    }

}
