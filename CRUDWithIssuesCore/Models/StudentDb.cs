using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDWithIssuesCore.Models
{
    public static class StudentDb
    {
        public static async Task<Student> AddAsync(Student p, SchoolContext db)
        {
            //Add student to context
            await db.Students.AddAsync(p);
            await db.SaveChangesAsync();
            return p;
        }

        public static async Task<List<Student>> GetStudents(SchoolContext context)
        {
            return await (from s in context.Students
                    select s).ToListAsync();
        }

        public static async Task<Student> GetStudent(SchoolContext context, int id)
        {
            Student p2 = await context
                            .Students
                            .Where(s => s.StudentId == id)
                            .SingleAsync();
            return p2;
        }

        public static async void Delete(SchoolContext context, Student p)
        {
            context.Students.Update(p);
            context.Entry(p).State = EntityState.Deleted;
            await context.SaveChangesAsync();
        }

        public static async void Update(SchoolContext context, Student p)
        {
            //Mark the object as deleted
            context.Update(p);
            await context.SaveChangesAsync();
        }
    }
}
