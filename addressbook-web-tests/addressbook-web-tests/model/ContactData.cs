﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
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
        private string allPhones;
        private string email;
        private string email2;
        private string email3;
        private string allEmails;
        private string homepage;
        private Date birthday;
        private Date anniversary;
        private string group;
        private string secondaryAddress;
        private string secondaryHome;
        private string notes;
        private string fullDetails;

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
        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(PhoneHome) + CleanUp(PhoneMobile) + CleanUp(PhoneWork) + CleanUp(SecondaryHome)).Trim();
                }
            }

            set
            {
                allPhones = value;
            }
        }

        public string AllEmails {
            get
            {
                if (allEmails != null)
                    return allEmails;
                else
                {
                    return (CleanUp(Email) + CleanUp(Email2) + CleanUp(Email3)).Trim();
                }
            }
            set => allEmails = value; }

        public string FullDetails {
            get
            {
                if (fullDetails != null)
                {
                    return fullDetails;
                }
                else
                {
                    string sPhones = "";
                    if (PhoneHome != null && !PhoneHome.Equals(""))
                    {
                        sPhones += "H: " + CleanUp(PhoneHome);
                    }
                    if (PhoneMobile != null && !PhoneMobile.Equals(""))
                    {
                        sPhones += "M: " + CleanUp(PhoneMobile);
                    }
                    if (PhoneWork != null && !PhoneWork.Equals(""))
                    {
                        sPhones += "W: " + CleanUp(PhoneWork);
                    }
                    if (PhoneFax != null && !PhoneFax.Equals(""))
                    {
                        sPhones += "F: " + CleanUp(PhoneFax);
                    }

                    string sHomepage = "";
                    if (Homepage != null && !Homepage.Equals(""))
                    {
                        sHomepage = "Homepage:\r\n" + CleanUp(Homepage);
                    }

                    string sBirthday = "";
                    if (Birthday.Day != null)
                        sBirthday += Birthday.Day + ". ";
                    if (Birthday.Month != null)
                        sBirthday += Birthday.Month + " ";
                    if (Birthday.Year != null)
                        sBirthday += Birthday.Year;
                    if (!sBirthday.Equals(""))
                        sBirthday = "Birthday " + sBirthday + "\r\n";

                    string sAnniversary = "";
                    if (Anniversary.Day != null)
                        sAnniversary += Anniversary.Day + ". ";
                    if (Anniversary.Month != null)
                        sAnniversary += Anniversary.Month + " ";
                    if (Anniversary.Year != null)
                        sAnniversary += Anniversary.Year;
                    if (!sAnniversary.Equals(""))
                        sAnniversary = "Anniversary " + sAnniversary + "\r\n";

                    string sSecondaryPhone = "";
                    if (SecondaryHome != null && !SecondaryHome.Equals(""))
                    {
                        sSecondaryPhone = "P: " + CleanUp(SecondaryHome) + "\r\n";
                    }

                    string str = CleanUp(FirstName, false) + " " + CleanUp(MiddleName, false) + " " + CleanUp(LastName, false) + "\r\n"
                        + CleanUp(Nickname) + "\r\n"
                        + CleanUp(Title) + CleanUp(Company) + CleanUp(Address) + "\r\n"
                        + sPhones + "\r\n"
                        + AllEmails + "\r\n" + sHomepage + "\r\n"
                        + sBirthday + sAnniversary + "\r\n"
                        + CleanUp(SecondaryAddress) + "\r\n"
                        + sSecondaryPhone + Notes
                        ;

                    return str;
                }
            }

            set => fullDetails = value; }

        private string CleanUp(string str, bool withNewLine = true)
        {
            if (str == null || str.Equals(""))
                return "";
            string[] wasteSymbols = new string[] { " ", "+", "-", "(", ")" };
            foreach (string sym in wasteSymbols)
            {
                str.Replace(sym, "");
            }
            if (withNewLine)
                return str + "\r\n";
            return str;
        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return (FirstName == other.FirstName)&&(LastName == other.LastName);
        }

        public override int GetHashCode()
        {
            return FirstName.GetHashCode() + LastName.GetHashCode();
        }

        public override string ToString()
        {
            return FirstName + " " + LastName;
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return this.ToString().CompareTo(other.ToString());
        }
    }
}
