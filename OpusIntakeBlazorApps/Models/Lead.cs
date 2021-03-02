﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpusIntakeBlazorApps.Models
{
    public class Lead : LeadCampaignDetail
    {
        public Guid OpusLeadId { get; set; }
        public string CampaignId { get; set; }
        public DateTime SubmitDate { get; set; }
        public string LeadId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Phone PhoneNumber { get; set; }
        public Email Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string SSN { get; set; }
        public Address MailingAddress { get; set; }

        public Lead()
        {
            OpusLeadId = Guid.NewGuid();
            MailingAddress = new Address();
            CampaignAttributes = new List<KeyValue>();
            LeadResponses = new List<KeyValue>();
        }
    }

    public class LeadCampaignDetail
    {
        public string AccountName { get; set; }
        public string CampaignName { get; set; }
        public DateTime CampaignStart { get; set; }

        public List<KeyValue> CampaignAttributes { get; set; }
        public List<KeyValue> LeadResponses { get; set; }
    }

    public class KeyValue
    {
        public KeyValue()
        {
        }
        public KeyValue(string key, string value)
        {
            Key = key;
            Value = value;
        }

        public string Key { get; set; }
        public string Value { get; set; }
    }
    public class Phone
    {
        public bool IsPrimary { get; set; }
        public string PhoneNumber { get; set; }
        public PhoneTypeEnum PhoneType { get; set; }
        //public bool IsValid { get; set; }
    }
    public class Email
    {
        public Email(string emailAdrress)
        {
            EmailAddress = emailAdrress;
        }
        public Email()
        {
        }

        public bool IsPrimary { get; set; }
        public string EmailAddress { get; set; }
        public bool IsValid { get; set; }
    }
    public class Address
    {
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
    }
    public enum PhoneTypeEnum
    {
        Mobile,
        Home,
        Work,
        Other
    }

}