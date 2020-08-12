using System.Collections.Generic;
using Domain;

namespace Application.Profiles
{
   //properties that we want to return for a user's profile.
    public class Profile
    {
        public string DisplayName { get; set; }
        public string Username { get; set; }
        public string Image { get; set; }
        public string Bio { get; set; }   
        public ICollection<Photo> Photos { get; set; }
    }
}