using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using System.Web;


namespace AddCoursesService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AddCoursesService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select AddCoursesService.svc or AddCoursesService.svc.cs at the Solution Explorer and start debugging.
    public class AddCoursesService : IAddCoursesService
    {
        public class Course
        {
            public string Code { get; set; }
            public string Name { get; set; }
            public Int32 seats { get; set; }
            public string Instructer { get; set; }
        }

        public class CourseRootObject
        {
            public Course[] courses { get; set; }
        }

        public string addCourse(string Code, string Name, Int32 seats, string Instructer)
        {
            Course newCourse = new Course();
            CourseRootObject courseObj = new CourseRootObject();
            List<Course> coursesList = new List<Course>();
            string json;
            Boolean exists = false;
            Boolean created = false;
            
            //string path2 = AppDomain.CurrentDomain.BaseDirectory;
            string path = HttpRuntime.AppDomainAppPath; 
            path = path.TrimEnd(new[] { '\\' });
            int index = path.LastIndexOf("\\");
            if (index >= 0) path = path.Substring(0, index);
            path = path + "\\courses_directory.json";
            
            string jsonData = File.ReadAllText(path);

            courseObj = JsonConvert.DeserializeObject<CourseRootObject>(jsonData);

            if (courseObj != null && courseObj.courses != null)
            {
                coursesList = courseObj.courses.ToList<Course>();
                foreach (Course course in coursesList)
                {
                    if (course.Code == Code)
                    {
                        exists = true;
                    }
                }
            }

            if (!exists)
            {
                newCourse.Code = Code; newCourse.Name = Name; newCourse.seats = seats; newCourse.Instructer = Instructer;
                coursesList.Add(newCourse);

                courseObj.courses = coursesList.ToArray<Course>();
                json = JsonConvert.SerializeObject(courseObj, Formatting.Indented);
                File.WriteAllText(path, json);

                created = true;
            }
            string ans;
            if (created)
            {
                ans = string.Format("Course {0} has been added to the directory.", Code);
            }
            else
            {
                ans = string.Format("Course {0} has already been added. Please Add different course.", Code);
            }
            return ans;
        }
    }
}
