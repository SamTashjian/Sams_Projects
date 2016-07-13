using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HRPortal.Models.Data;

namespace HRPortal.Models.Repositories
{
    public static class JobRepository
    {
        private static List<Job> _jobs;

        static JobRepository()
        {
            _jobs = new List<Job>
            {
                new Job {JobId = 1, JobTitle = "Practice Squad Goalkeeper", Department = "Athletics", Salary = 25000m},
                new Job {JobId = 2, JobTitle = "Assistant Trainer", Department = "Medical/Training", Salary = 60000m},
                new Job {JobId = 3, JobTitle = "Director of Team Travel", Department = "Travel", Salary = 50000m},
                new Job {JobId = 4, JobTitle = "Equiptment Manager", Department ="Athletics", Salary = 25000}
            };
        }

        public static IEnumerable<Job> GetAll()
        {
            return _jobs;
        }

        public static Job Get(int jobId)
        {
            return _jobs.FirstOrDefault(j => j.JobId == jobId);
        }
    }
}