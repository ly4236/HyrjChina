using System;
namespace HyrjChina.Web.Session
{
    [Serializable]
    public class CustomerSession
    {
        public string Name { get; set; }

        public string LoginIpAddress { get; set; }

        public DateTime LoginDateTime { get; set; }
    }
}