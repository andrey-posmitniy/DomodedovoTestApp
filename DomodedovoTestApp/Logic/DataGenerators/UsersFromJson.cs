using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DomodedovoTestApp.Logic.DataGenerators
{
    // Классы для десериализации JSON.
    // Названия свойств не менять - сломается десериализация!

    public class UsersFromJson
    {
        public IList<UserFromJson> results { get; set; }
    }

    public class UserFromJson
    {
        public string results { get; set; }
        public UserNameFromJson name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public UserLoginFromJson login { get; set; }
        public UserDateOfBirthdayFromJson dob { get; set; }
        public UserPictureFromJson picture { get; set; }
    }

    public class UserNameFromJson
    {
        public string first { get; set; }
        public string last { get; set; }
    }
 
    public class UserLoginFromJson
    {
        public string password { get; set; }
    }
    
    public class UserDateOfBirthdayFromJson
    {
        [JsonConverter(typeof (IsoDateTimeConverter))]

        public DateTime date { get; set; }
    }

    public class UserPictureFromJson
    {
        public string large { get; set; }
        public string medium { get; set; }
        public string thumbnail { get; set; }
    }
}