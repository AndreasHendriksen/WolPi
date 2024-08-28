using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Net;
using CliWrap;
using System.Diagnostics;
using System.Net.Mail;

namespace server.Services
{
    public class WolHandler
    {
        public void Broadcast()
        {
            try
            {
                ProcessStartInfo processStartInfo = new ProcessStartInfo
                {
                    FileName = "/usr/sbin/etherwake",
                    Arguments = "00:D8:61:D7:4D:C9",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                };

                using (Process process = new Process())
                {
                    process.StartInfo = processStartInfo;
                    process.Start();

                    string output = process.StandardOutput.ReadToEnd();
                    string error = process.StandardError.ReadToEnd();

                    process.WaitForExit();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
