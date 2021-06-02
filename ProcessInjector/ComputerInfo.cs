using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace ProcessInjector
{
    class ComputerInfo
    {
        /// <summary>
        /// 获取 cpu 序列号   
        /// </summary>
        /// <returns></returns>
        public string GetCPUInfo()
        {
            string cpuInfo = string.Empty;
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("Select * from Win32_Processor");
            foreach (ManagementObject obj in searcher.Get())
            {
                cpuInfo += obj["Name"].ToString() + ",";
            }
            searcher.Dispose();
            return ("CPU：" + cpuInfo.TrimEnd(new char[] { ',' }));
        }

        public string GetGPUInfo()
        {
            string gpuInfo = string.Empty;
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("Select * from Win32_VideoController");
            foreach (ManagementObject obj in searcher.Get())
            {
                gpuInfo += obj["Name"].ToString() + ",";
            }
            searcher.Dispose();
            return ("显卡：" + gpuInfo.TrimEnd(new char[] { ',' }));
        }

        public string GetHDInfo()
        {
            string hdInfo = "硬盘：";
            ManagementClass mc = new ManagementClass("win32_DiskDrive");
            ManagementObjectCollection moc = mc.GetInstances();
            double diskSize = 0.0;
            foreach (ManagementObject obj in moc)
            {
                diskSize += ((long.Parse(obj.Properties["Size"].Value.ToString()) / 1024) / 1024) / 1024;
            }
            moc.Dispose();
            mc.Dispose();
            return (hdInfo + diskSize.ToString() + "G");
        }

        public string GetMACInfo()
        {
            string macInfo = null;
            foreach (ManagementObject obj in new ManagementClass("Win32_NetworkAdapterConfiguration").GetInstances())
            {
                if (Convert.ToBoolean(obj["IPEnabled"]))
                {
                    macInfo = obj["MacAddress"].ToString().Replace(':', '-');
                }
                obj.Dispose();
            }
            return macInfo;
        }

        public string GetMEMInfo()
        {
            string memInfo = "内存：";
            ManagementClass mc = new ManagementClass("Win32_PhysicalMemory");
            ManagementObjectCollection moc = mc.GetInstances();
            double capacity = 0.0;
            foreach (ManagementObject obj in moc)
            {
                capacity += Math.Round((double)(((double)((long.Parse(obj.Properties["Capacity"].Value.ToString()) / 1024) / 1024)) / 1024), 1);
            }
            moc.Dispose();
            mc.Dispose();
            return (memInfo + capacity.ToString() + "G");
        }
    }
}
