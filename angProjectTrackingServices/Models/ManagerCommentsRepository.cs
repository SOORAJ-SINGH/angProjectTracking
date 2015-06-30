using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace angProjectTrackingServices.Models
{
    public class ManagerCommentsRepository
    {
        private static ProjectTrackingDBEntities dataContext = new ProjectTrackingDBEntities();

        //get all managerComments 
        public static List<ManagerComment> GetAllManagerComments()
        {

            var query = from managerComment in dataContext.ManagerComments
                        select managerComment;
            return query.ToList();
        }

        //get single managerComments on the basis of the projectId
        public static ManagerComment GetManagerComment(int ManagerCommentID)
        {
            var query = from managerComment in dataContext.ManagerComments
                        where managerComment.ManagerCommentID == ManagerCommentID
                        select managerComment;

            return query.SingleOrDefault();
        }


        //Insert ManagerComment  
        public static List<ManagerComment> InsertManagerComment(ManagerComment mc)
        {

            dataContext.ManagerComments.Add(mc);
            dataContext.SaveChanges();
            return GetAllManagerComments();
        }


        //Update the ManagerComment  on the basis of the projectID
        public static List<ManagerComment> UpdateManagerComment(ManagerComment mc)
        {
            //get the details of the managerComment
            var mComment = (from managerComment in dataContext.ManagerComments
                        where managerComment.ManagerCommentID == mc.ManagerCommentID
                        select managerComment).SingleOrDefault();

            mComment.Comments = mc.Comments;
            mComment.ProjectTaskID = mc.ProjectTaskID;
            dataContext.SaveChanges();
            return GetAllManagerComments();
        }


        //Delete the ManagerComment on the basis of the projectID
        public static List<ManagerComment> DeleteManagerComment(ManagerComment mc)
        {
            var mComment = (from managerComment in dataContext.ManagerComments
                        where managerComment.ManagerCommentID == mc.ManagerCommentID
                        select managerComment).SingleOrDefault();
            dataContext.ManagerComments.Remove(mComment);
            dataContext.SaveChanges();
            return GetAllManagerComments();
        }

    }
}