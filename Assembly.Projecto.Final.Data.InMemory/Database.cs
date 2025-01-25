using Assembly.Projecto.Final.Domain.Models;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Data.InMemory
{
     public class Database
    {
        
        public List<Address> Addresses {  get; set; }
        public List<Account> Accounts { get; set; }
        public List<Agent> Agents { get; set; }
        public List<Appointment> Appointments { get; set; }
        public List<Contact> Contacts { get; set; }
        public List<Favorite> Favorites { get; set; }
        public List<FeedBack> FeedBacks { get; set; }
        public List<Listing> Listings { get; set; }
        public List<PersonalContact> PersonalContacts { get; set; }
        public List<Reassign> Reassigns { get; set; }
        public List<Staff> Staff { get; set; }
        public List<User> Users { get; set; }

        public Database() 
        {
            Accounts = [];
            Agents = [];
            Appointments = [];
            Contacts = [];
            Favorites = [];
            FeedBacks = [];
            Listings = [];
            PersonalContacts = [];
            Reassigns = [];
            Staff = [];
            Users = [];
        }
    }
}
