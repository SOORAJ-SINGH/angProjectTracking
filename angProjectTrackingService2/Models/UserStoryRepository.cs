using angProjectTrackingService2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace angProjectTrackingService2.Models
{
	public class UserStoryRepository
	{
        private static ProjectTrackingDBContext dataContext = new ProjectTrackingDBContext();

        //get all userStories 
        public static List<UserStory> GetAllUserStories()
        {

            var query = from userStory in dataContext.UserStories
                        select userStory;
            return query.ToList();
        }

        //public static List<Project> SearchProjectsByName(string projectName)
        //{
        //    var query = from userStory in dataContext.UserStories
        //                where userStory.ProjectName.Contains(projectName)
        //                select userStory;
        //    return query.ToList();
        //}

        //get single userStories on the basis of the userStoryId
        public static UserStory GetUserStory(int UserStoryID)
        {
            var query = from userStory in dataContext.UserStories
                        where userStory.UserStoryID == UserStoryID
                        select userStory;

            return query.SingleOrDefault();
        }


        //Insert UserStory  
        public static List<UserStory> InsertUserStory(UserStory s)
        {

            dataContext.UserStories.Add(s);
            dataContext.SaveChanges();
            return GetAllUserStories();
        }


        //Update the UserStory  on the basis of the userStoryID
        public static List<UserStory> UpdateUserStory(UserStory s)
        {
            //get the details of the userStory
            var us = (from userStory in dataContext.UserStories
                        where userStory.UserStoryID == s.UserStoryID
                        select userStory).SingleOrDefault();

            us.Story = s.Story;
            us.ProjectID = s.ProjectID;
            
            dataContext.SaveChanges();
            return GetAllUserStories();
        }


        //Delete the UserStory on the basis of the userStoryID
        public static List<UserStory> DeleteUserStory(UserStory s)
        {
            var us = (from userStory in dataContext.UserStories
                        where userStory.UserStoryID == s.UserStoryID
                        select userStory).SingleOrDefault();
            dataContext.UserStories.Remove(us);
            dataContext.SaveChanges();
            return GetAllUserStories();
        }

	}
}