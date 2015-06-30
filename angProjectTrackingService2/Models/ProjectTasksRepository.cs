using angProjectTrackingService2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace angProjectTrackingService2.Models
{
    public class ProjectTasksRepository
    {

        private static ProjectTrackingDBContext dataContext = new ProjectTrackingDBContext();

        //get all userTasks 
        public static List<ProjectTask> GetAllProjectTasks()
        {

            var query = from projectTask in dataContext.ProjectTasks
                        select projectTask;
            return query.ToList();
        }

        //get single userTasks on the basis of the projectTaskId
        public static ProjectTask GetProjectTask(int ProjectTaskID)
        {
            var query = from projectTask in dataContext.ProjectTasks
                        where projectTask.ProjectTaskID == ProjectTaskID
                        select projectTask;

            return query.SingleOrDefault();
        }


        //Insert Project  
        public static List<ProjectTask> InsertProjectTask(ProjectTask p)
        {

            dataContext.ProjectTasks.Add(p);
            dataContext.SaveChanges();
            return GetAllProjectTasks();
        }


        //Update the Project  on the basis of the projectID
        public static List<ProjectTask> UpdateProject(ProjectTask p)
        {
            //get the details of the project
            var proj = (from projectTask in dataContext.ProjectTasks
                        where projectTask.ProjectTaskID == p.ProjectTaskID
                        select projectTask).SingleOrDefault();

            proj.AssignedTo = p.AssignedTo;
            proj.TaskStartDate = p.TaskStartDate;
            proj.TaskEndDate = p.TaskEndDate;
            proj.TaskCompletion = p.TaskCompletion;
            proj.UserStoryID = p.UserStoryID;
            dataContext.SaveChanges();
            return GetAllProjectTasks();
        }


        //Delete the Project on the basis of the projectID
        public static List<ProjectTask> DeleteProject(ProjectTask p)
        {
            var proj = (from projectTask in dataContext.ProjectTasks
                        where projectTask.ProjectTaskID == p.ProjectTaskID
                        select projectTask).SingleOrDefault();
            dataContext.ProjectTasks.Remove(proj);
            dataContext.SaveChanges();
            return GetAllProjectTasks();
        }

    }
}