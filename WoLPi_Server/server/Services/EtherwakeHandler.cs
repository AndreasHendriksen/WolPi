namespace server.Services
{
    public class EtherwakeHandler
    {
        public void Broadcast()
        {
            string strCmdText;
            strCmdText = "/C etherwake -b 192.168.1.255 00:21:70:c2:c1:88";
            System.Diagnostics.Process.Start("CMD.exe", strCmdText);
        }
    }
}
