using System;
using System.Windows.Forms;

namespace Passwords
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new xmlForm());
        }

        /// <summary>
        /// Encode our userNames and passwords when saving to a file
        /// </summary>
        /// <param name="plainText"></param>
        /// <returns></returns>
        internal static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        /// <summary>
        /// Since the userName and passwords are encoded when they are saved, we have to decode them when we get them back
        /// </summary>
        /// <param name="base64EncodedData"></param>
        /// <returns></returns>
        internal static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }
}
