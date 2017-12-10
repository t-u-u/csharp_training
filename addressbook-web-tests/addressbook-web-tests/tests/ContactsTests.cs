using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            ContactData contact = new ContactData();
            contact.FirstName = "1";
            contact.MiddleName = "2";
            contact.LastName = "3";
            contact.Nickname = "4";
            contact.PhotoPath = "c:\\temp\\1.gif";
            contact.Title = "5";
            contact.Company = "6";
            contact.Address = "7";
            contact.PhoneHome = "8";
            contact.PhoneMobile = "9";
            contact.PhoneWork = "10";
            contact.PhoneFax = "11";
            contact.Email = "12";
            contact.Email2 = "13";
            contact.Email3 = "14";
            contact.Homepage = "15";
            contact.Birthday = new ContactData.Date("1", "January", "1234");
            contact.Anniversary = new ContactData.Date("1", "January", "2345");
            contact.Group = "[none]";
            contact.SecondaryAddress = "16";
            contact.Notes = "17";
            contact.SecondaryHome = "18";

            app.Contacts
                .CreateContact(contact);
            app.Navigator.OpenHomePage();
        }

        [Test]
        public void ContactRemovalTest()
        {
            ContactData contact = new ContactData();
            contact.FirstName = "1";
            contact.MiddleName = "2";

            app.Contacts
                .CreateContactIfEmpty(contact)
                .SelectContact(1)
                .DeleteContact();
            app.AcceptAlert();
        }

        [Test]
        public void ContactUpdateTest()
        {
            ContactData contact = new ContactData();
            contact.FirstName = "1";
            contact.MiddleName = "2";

            ContactData contact_mod = new ContactData();
            contact_mod.FirstName = "1 mod";
            contact_mod.MiddleName = "2 mod";

            app.Contacts
                .CreateContactIfEmpty(contact)
                .EditContact(1)
                .FillContactForm(contact_mod)
                .SubmitContactForm();
            app.Navigator.OpenHomePage();
        }
    }
}
