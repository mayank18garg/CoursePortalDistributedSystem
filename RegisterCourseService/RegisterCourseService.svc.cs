using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using System.Web;

namespace RegisterCourseService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "RegisterCourseService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select RegisterCourseService.svc or RegisterCourseService.svc.cs at the Solution Explorer and start debugging.
    public class RegisterCourseService : IRegisterCourseService
    {
        public class Course
        {
            public string Code { get; set; }
            public string Name { get; set; }
            public Int32 seats { get; set; }
        }

        public class CourseRootObject
        {
            public Course[] courses { get; set; }
        }
        public string Registercourse(string courseCode, string userName)
        {
            List<Course> coursesList = new List<Course>();
            CourseRootObject courseObj = new CourseRootObject();

            string path = HttpRuntime.AppDomainAppPath;
            path = path.TrimEnd(new[] { '\\' });
            int index = path.LastIndexOf("\\");
            if (index >= 0) path = path.Substring(0, index);
            path = path + "\\courses_directory.json";

            string jsonData = File.ReadAllText(path);
            string json;
            Boolean exist = false;
            string ans;
            courseObj = JsonConvert.DeserializeObject<CourseRootObject>(jsonData);

            if (courseObj == null)
            {
                ans = string.Format("Course with courseCode: {0} not found", courseCode);
                return ans;
            }
            coursesList = courseObj.courses.ToList<Course>();
            foreach (Course course in coursesList)
            {
                if (course.Code == courseCode)
                {
                    if (course.seats == 0)
                    {
                        ans = string.Format("Course with courseCode: {0} has no seats available ", courseCode);
                        return ans;
                    }
                    course.seats = course.seats - 1;
                    courseObj.courses = coursesList.ToArray<Course>();
                    json = JsonConvert.SerializeObject(courseObj, Formatting.Indented);
                    File.WriteAllText(path, json);
                    exist = true;
                }
            }
            if (exist == true)
            {
                ans = string.Format("Course {0} has been registered for user {1}", courseCode, userName);
            }
            else
            {
                ans = string.Format("Course with courseCode: {0} not found", courseCode);
            }
            return ans;
        }
    }
}
