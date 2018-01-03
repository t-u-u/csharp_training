using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class GroupData : IEquatable<GroupData>, IComparable<GroupData>
    {
        private string group_name;
        private string group_header;
        private string group_footer;
        private string id;

        public GroupData(string group_name)
        {
            this.Group_name = group_name;
        }

        public GroupData(string group_name, string group_header, string group_footer)
        {
            this.Group_name = group_name;
            this.Group_header = group_header;
            this.Group_footer = group_footer;
        }

        public string Group_name { get => group_name; set => group_name = value; }
        public string Group_header { get => group_header; set => group_header = value; }
        public string Group_footer { get => group_footer; set => group_footer = value; }
        public string Id { get => id; set => id = value; }

        public int CompareTo(GroupData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return Group_name.CompareTo(other.Group_name);
        }

        public bool Equals(GroupData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Group_name == other.Group_name; 
        }

        public override int GetHashCode()
        {
            return Group_name.GetHashCode();
        }

        public override string ToString()
        {
            return Group_name + "\n" + Group_header + "\n" + Group_footer;
        }
    }
}
