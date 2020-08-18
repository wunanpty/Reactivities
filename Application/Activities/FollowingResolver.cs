using System.Linq;
using Application.Interfaces;
using AutoMapper;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Activities
{
    public class FollowingResolver : IValueResolver<UserActivity, AttendeeDto, bool>
    {
        private readonly DataContext _context;
        private readonly IUserAccessor _userAccessor;
        // inject the stuff we need into our following resolve.
        // currently logged in user
        // check to see if the user is following this particular attendee.
        public FollowingResolver(DataContext context, IUserAccessor userAccessor)
        {
            _userAccessor = userAccessor;
            _context = context;
        }

        public bool Resolve(UserActivity source, AttendeeDto destination, bool destMember, ResolutionContext context)
        {
            var currentUser = _context.Users.SingleOrDefaultAsync(x => x.UserName == _userAccessor.GetCurrentUsername()).Result;

            // check to see if the current user is following the attendees here.
            // checking the followings of current user to see if any of the following is match the UserId of the attendee
            if (currentUser.Followings.Any(x => x.TargetId == source.AppUserId))
                return true;

            return false;
        }
    }
}