using server.Models;

namespace server.Services
{
    public class ServiceManager
    {
        private PasswordHandler passwordHandler;

        private EtherwakeHandler etherwakeHandler;

        private readonly Dictionary<InfoItemValues, string> infoItemValueColors = new Dictionary<InfoItemValues, string>();

        public ServiceManager(PasswordHandler _passwordHandler, EtherwakeHandler _etherwakeHandler) 
        { 
            passwordHandler = _passwordHandler;
            etherwakeHandler = _etherwakeHandler;

            InitializeInfoList();
        }

        public InfoList GetInfoList() 
        { 
            InfoList infoList = new InfoList();

            infoList.InfoItems.Add(new InfoItem() 
            { 
                Label = "RaspberryPi Status", 
                Value = InfoItemValues.Connected.ToString(),
                ValueColorHex = infoItemValueColors[InfoItemValues.Connected],
            });

            infoList.InfoItems.Add(new InfoItem() 
            { 
                Label = "WoL Service Status", 
            });

            infoList.InfoItems.Add(new InfoItem() 
            { 
                Label = "Service Last Updated", 
                Value = "23/07/2024"
            });

            return infoList;
        }

        public InfoItem CheckStatus(int id) 
        {
            InfoItem infoItem = new InfoItem();

            switch (id)
            {
                case 0:
                    infoItem.Label = "RaspberryPi Status";
                    infoItem.Value = InfoItemValues.Connected.ToString();
                    infoItem.ValueColorHex = infoItemValueColors[InfoItemValues.Connected];
                    break;
                case 1:
                    infoItem.Label = "WoL Service Status";
                    infoItem.Value = InfoItemValues.Unimplemented.ToString();
                    infoItem.ValueColorHex = infoItemValueColors[InfoItemValues.Unimplemented];
                    break;
                case 2:
                    infoItem.Label = "Service Last Updated";
                    infoItem.Value = "23/07/2024";
                    infoItem.ValueColorHex = infoItemValueColors[InfoItemValues.None];
                    break;
                default:
                    break;
            }


            return infoItem;
        }

        private void InitializeInfoList()
        {
            string success = "28a745";
            string warning = "ffc107";
            string danger = "dc3545";
            string info = "17a2b8";
            string none = "";

            infoItemValueColors[InfoItemValues.None] = none;
            infoItemValueColors[InfoItemValues.Connected] = success;
            infoItemValueColors[InfoItemValues.Disconnected] = danger;
            infoItemValueColors[InfoItemValues.Running] = success;
            infoItemValueColors[InfoItemValues.Uninitialized] = warning;
            infoItemValueColors[InfoItemValues.Stopped] = danger;
            infoItemValueColors[InfoItemValues.Unimplemented] = warning;
        }
    }

    public enum InfoItemValues
    {
        None,
        Connected,
        Disconnected,
        Running,
        Uninitialized,
        Stopped,
        Unimplemented,
    }
}
