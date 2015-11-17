﻿/* Copyright 2015 Realm Inc - All Rights Reserved
 * Proprietary and Confidential
 */
 
using System;
using RealmNet;

namespace IntegrationTests
{
    public class Person : RealmObject
    {
        // Automatically implemented (overridden) properties
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public float Score { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        // Property that's not persisted in Realm
        [Ignore]
        public bool IsOnline { get; set; }

        // Composite property
        [Ignore]
        public string FullName
        {
            get { return FirstName + " " + LastName; }

            set
            {
                var parts = value.Split(' ');
                FirstName = parts[0];
                LastName = parts[parts.Length - 1];
            }
        }
        
        // Re-mapped property
        [MapTo("Email")]
        private string Email_ { get; set; }

        // Wrapped version of previous property
        [Ignore]
        public string Email
        {
            get { return Email_; }
            set
            {
                if (!value.Contains("@")) throw new Exception("Invalid email address");
                Email_ = value;
            }
        }

        public bool IsInteresting { get; set; }
    }
}