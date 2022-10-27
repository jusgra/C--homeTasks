using System;
using System.Text.RegularExpressions;

namespace CaesarCipher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please input a message you want to encrypt (do not use special characters/symbols or numbers)");
            string secretMessage = Console.ReadLine();

            Console.WriteLine("Please input a secret shift parameter 1-26");
            string shiftParameter = Console.ReadLine();

            switch (checkInputs(secretMessage, shiftParameter))
            {
                case 0:
                    Console.WriteLine("Wrong message input");
                    break;
                case 1:
                    Console.WriteLine("Wrong shift parameter input");
                    break;
                default:
                    string encryptedMessage = encrypt(secretMessage, Int32.Parse(shiftParameter));
                    Console.WriteLine("Your encrypted message is: ");
                    Console.WriteLine(encryptedMessage);
                    break;
            }
        }
        
        public static int checkInputs(string msg, string shift)
        {
            if (msg == "") return 0;
            else if (!Regex.IsMatch(msg, @"^[a-zA-Z ]+$")) return 0;

            if (!Regex.IsMatch(shift, @"^[0-9]+$")) return 1;
            else if (Int32.Parse(shift) < 1) return 1;

            return 2;
        }
        public static string encrypt (string msg, int shift)
        {
            char[] alphU = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            char[] alphL = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            char[] singleChar = msg.ToCharArray();

            char[] msgChar = new char[msg.Length];

            for (int i = 0; i < singleChar.Length; i++)
            {
                if (singleChar[i] == ' ') msgChar[i] = ' ';
                else if (Array.IndexOf(alphU, singleChar[i]) != -1)
                {
                    int currentPosition = Array.IndexOf(alphU, singleChar[i]);
                    int newPosition = (currentPosition + shift) % 26;
                    char newLetter = alphU[newPosition];
                    msgChar[i] = newLetter;
                }
                else if (Array.IndexOf(alphL, singleChar[i]) != -1)
                {
                    int currentPosition = Array.IndexOf(alphL, singleChar[i]);
                    int newPosition = (currentPosition + shift) % 26;
                    char newLetter = alphL[newPosition];
                    msgChar[i] = newLetter;
                }
            }
            return new string(msgChar);
        }
    }
}