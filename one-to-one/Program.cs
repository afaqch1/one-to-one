using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace one_to_many
{
    public class Student
    {
        public int studentid { get; set; }
        public string student_name { get; set; }
        public int student_age { get; set; }

        public StudentAddress address { get; set; }
    }

    public class StudentAddress
    {
        public int id { get; set; }
        public string address { get; set; }

        public int studentid { get; set; }
        public Student student { get; set; }
        

    }

    public class ClassRoom : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentAddress> StudentAddresses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(@"Server=.;Database=Db3;Trusted_Connection=True;");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new ClassRoom())
            {
                var std = new Student()
                {
                    student_name = "Afaq",
                    student_age = 23
                    
                   

                };
                var std1 = new Student()
                {
                    student_name = "Yasim",
                    student_age = 24
                    
                };
                var std2 = new Student()
                {
                    student_name = "Wamik",
                    student_age = 22
                    
                };
                var std3 = new Student()
                {
                    student_name = "Umair",
                    student_age = 99
                    
                };

                var adr = new StudentAddress()
                {

                    address = "Township",
                    studentid=2
                    
                    
                };
                var adr1 = new StudentAddress()
                {
                    address = "Mughalpura",
                    studentid=1
                };
                var adr2 = new StudentAddress()
                {
                    address = "wapda town",
                    studentid=3
                };

                context.Students.Add(std);
                context.Students.Add(std1);
                context.Students.Add(std2);
                context.Students.Add(std3);


                context.StudentAddresses.Add(adr);
                context.StudentAddresses.Add(adr1);
                context.StudentAddresses.Add(adr2);



                  


                context.SaveChanges();




            }
        }
    }
}
