using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Configuration;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    class NetWork
    {
        List<SubNet> subNets = new List<SubNet>();
        List<Router> routers = new List<Router>();

        public NetWork()
        {

        }

        public bool Check(uint addressRange, uint mask, List<int> hostsNumber)
        {
            uint count = 0;
            foreach (var item in hostsNumber)
            {
                count += (uint)1 << NearPow2(item + 4);
            }
            uint maxValue = (~mask) + 1;
            if (maxValue < count) return false;
            return true;
        }

        public bool Build(uint addressRange, uint mask, List<int> hostsHumber)
        {
            if ((addressRange & mask) != addressRange) return false;
            bool ok = Check(addressRange, mask, hostsHumber);
            if (!ok) return false;
            List<int> revIndex = new List<int>(), used = new List<int>();
            for (int i = 0; i < hostsHumber.Count; i++)
            {
                revIndex.Add(i);
                used.Add(0);
            }
            for (int i = 0; i < hostsHumber.Count; ++i)
            {
                int index = -1;
                for (int j = 0; j < hostsHumber.Count; j++)
                {
                    if (used[j] == 1) continue;
                    if (used[j] == 0 && index == -1) index = j;
                    if (hostsHumber[j] > hostsHumber[index]) index = j;
                }
                used[index] = 1;
                revIndex[i] = index;
            }
            uint currentAdressRange = addressRange;
            for (int i = 0; i < revIndex.Count; ++i)
            {
                int item = hostsHumber[revIndex[i]];
                uint count = (uint)1 << NearPow2(item + 4);
                uint currentMask = ~(count - 1);
                int value = 1;
                if (revIndex[i] != 0) value++;
                this.subNets.Add(new SubNet(currentAdressRange, currentMask, (uint)item, "SubNet " + ((revIndex[i]) + 1), value));
                currentAdressRange += count;
            }
            ReSort(this.subNets);
            this.subNets.Add(new SubNet(3722182656, 4294901760, 0, "Internet", 1));
            int numberOfRouters = this.subNets.Count - 1;
            for (int i = 0; i < numberOfRouters; ++i)
            {
                Router currentRouter = new Router();
                for (int j = i + 1; j < this.subNets.Count; j++)
                {
                    Entry entry = new Entry();
                    entry.NetworkDestination = this.subNets[j].Address;
                    entry.Netmask = this.subNets[j].Mask;
                    entry.Interface = subNets[i+1].gateways[0];
                    entry.Gateway = 0;
                    if (i + 1 != subNets.Count - 1 && j != i + 1)
                    {
                        entry.Gateway = subNets[i+1].gateways[1];
                    }
                    entry.Metric = (uint)(j - i - 1);
                    currentRouter.AddEntry(entry);
                }
                for (int j = i; j >= 0; j--)
                {
                    Entry entry = new Entry();
                    entry.NetworkDestination = this.subNets[j].Address;
                    entry.Netmask = this.subNets[j].Mask;
                    if (i == 0) entry.Interface = subNets[i].gateways[0];
                    else entry.Interface = subNets[i].gateways[1];
                    entry.Gateway = 0;
                    if (i != 0 && i != j)
                    {
                        entry.Gateway = subNets[i].gateways[0];
                    }
                    entry.Metric = (uint)(i - j);
                    currentRouter.AddEntry(entry);
                }
                this.routers.Add(currentRouter);
            }
            return true;
        }

        public int NearPow2(int value)
        {
            int answer = 0;
            while (((uint)1 << answer) < value) answer++;
            return answer;
        }

        public string ShowInfoAboutSubNets()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("Сеть состоит из " + this.subNets.Count + " подсетей:\n\n\n");
            for (int i = 0; i < subNets.Count; i++)
            {
                var item = subNets[i];
                builder.Append(item.GetInfo() + "\n\n");
                if (i != subNets.Count - 1)
                {
                    builder.Append("Таблица маршрутизации роутера:\n");
                    builder.Append(routers[i].GetTable() + "\n\n");
                }
            }
            return builder.ToString();
        }

        public Router GetRouter(int index)
        {
            return this.routers[index];
        }

        public string GetAllPath()
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < subNets.Count; ++i)
            {
                for (int j = 0; j < subNets.Count; ++j)
                {
                    if (i == j) continue;
                    int dir = j - i;
                    if (dir < 0) dir = -1;
                    else dir = 1;
                    for (int cur = i; cur != j; cur+= dir)
                    {
                        if (dir == 1) builder.Append(subNets[cur].SubnetName + " (via " + Converter.AddressToString(routers[cur].GetInterface(subNets[j].Address))  + ") " + " --> ");
                        else builder.Append(subNets[cur].SubnetName + " (via " + Converter.AddressToString(routers[cur - 1].GetInterface(subNets[j].Address)) + ") " + " --> ");
                    }
                    builder.Append(subNets[j].SubnetName);
                    builder.Append("\n\n");
                }
            }
            return builder.ToString();
        }

        public int CountRouter
        {
            get { return this.routers.Count; }
            set { }
        }

        public void ReSort(List<SubNet> subNets)
        {
            for(int i=0; i<subNets.Count; ++i)
                for (int j = i + 1; j < subNets.Count; ++j)
                {
                    if (subNets[i].SubnetName.CompareTo(subNets[j].SubnetName) > 0)
                    {
                        SubNet buffer = subNets[i];
                        subNets[i] = subNets[j];
                        subNets[j] = buffer;
                    }
                }
        }
    }
}
