using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace GMap.Models
{
    public class MapsManager
    {
        public string error { get; private set; }
        XmlDocument xd;
        public string Lat { get; private set; }
        public string Lng { get; private set; }
        const string urlGoogle = "https://maps.google.com/maps/api/geocode/xml?address";
        const string xmlPath = "GeocodeResponse/result/geometry/location";
        public bool ParseAddress(string address)
        {
            try
            {
                xd = new XmlDocument();
                xd.Load(urlGoogle + address); // ?
                XmlNode node = xd.SelectSingleNode(xmlPath);
                if (node == null)
                    return false;
                Lat = node.ChildNodes[0].InnerText.Trim();
                Lng = node.ChildNodes[1].InnerText.Trim();
                return true;
            }
            catch(Exception ex)
            {
                this.error = ex.Message;
                Lat = "0";
                Lng = "0";
            }
            return false;
            

        }

    }
}