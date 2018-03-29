using System;
namespace ClassifiedApp2.Models
{
    public class FacebookUser
    {
        public FacebookUser(string id, 
                            string token, 
                            string firstName, 
                            string lastName, 
                            string email, 
                            string imageUrl,
                            string gender,
                            string birthday,
                            string location)
        {
            Id = id;
            Token = token;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Picture = imageUrl;
            Gender = gender;
            Birthday = birthday;
            Location = location;
        }

        public string Id { get; set; }

        public string Token { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Picture { get; set; }

        public string Location { get; set; }

        public string Gender { get; set; }

        public string Birthday { get; set; }
    }
}
