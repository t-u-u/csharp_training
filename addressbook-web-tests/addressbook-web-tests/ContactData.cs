using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactData
    {
        public class Date
        {
            private string day;
            private string month;
            private string year;

            public Date(string day, string month, string year)
            {
                Day = day;
                Month = month;
                Year = year;
            }

            public string Day { get => day; set => day = value; }
            public string Month { get => month; set => month = value; }
            public string Year { get => year; set => year = value; }
        }
        private string firstName;
        private string middleName;
        private string lastName;
        private string nickname;
        private string photoPath;
        private string title;
        private string company;
        private string address;
        private string phoneHome;
        private string phoneMobile;
        private string phoneWork;
        private string phoneFax;
        private string email;
        private string email2;
        private string email3;
        private string homepage;
        private Date birthday;
        private Date anniversary;
        private string group;
        private string secondaryAddress;
        private string secondaryHome;
        private string notes;

        public ContactData() { }

        public string FirstName { get => firstName; set => firstName = value; }
        public string MiddleName { get => middleName; set => middleName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Nickname { get => nickname; set => nickname = value; }
        public string PhotoPath { get => photoPath; set => photoPath = value; }
        public string Title { get => title; set => title = value; }
        public string Company { get => company; set => company = value; }
        public string Address { get => address; set => address = value; }
        public string PhoneHome { get => phoneHome; set => phoneHome = value; }
        public string PhoneMobile { get => phoneMobile; set => phoneMobile = value; }
        public string PhoneWork { get => phoneWork; set => phoneWork = value; }
        public string PhoneFax { get => phoneFax; set => phoneFax = value; }
        public string Email { get => email; set => email = value; }
        public string Email2 { get => email2; set => email2 = value; }
        public string Email3 { get => email3; set => email3 = value; }
        public string Homepage { get => homepage; set => homepage = value; }
        public Date Birthday { get => birthday; set => birthday = value; }
        public Date Anniversary { get => anniversary; set => anniversary = value; }
        public string Group { get => group; set => group = value; }
        public string SecondaryAddress { get => secondaryAddress; set => secondaryAddress = value; }
        public string SecondaryHome { get => secondaryHome; set => secondaryHome = value; }
        public string Notes { get => notes; set => notes = value; }
    }
}
