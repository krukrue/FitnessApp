using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessApp.BL.Model;

namespace FitnessApp.BL.Controller
{
    public class ExerciseController : ControllerBase
    {
        private readonly User user;

        private const string Exercises_FILE_NAME = "exercises.dat";
        private const string Activity_FILE_NAME = "activity.dat";
        public List <Exercise> exerciseList;
        public List<Activity> activityList;
        public ExerciseController(User user)
        {
            this.user = user ?? throw new ArgumentNullException("Incorrect user data");

            exerciseList = GetAllExercises();
            activityList= GetAllActivities();
        }

        private List<Exercise> GetAllExercises()
        {
            return Load<Exercise>() ?? new List<Exercise>();
        }



        private List<Activity> GetAllActivities()
        {
            return Load<Activity>() ?? new List<Activity>();
        }


        public void Add(Activity activity, DateTime begin, DateTime end)
        {
            var act = activityList.SingleOrDefault(f => f.Name== activity.Name);

            if (act == null)
            {
                activityList.Add(activity);
                var exercise = new Exercise(begin, end, activity, user.ID);
                exerciseList.Add(exercise);
                Save(exercise);

            }
            else
            {
                var exercise = new Exercise(begin, end, activity, user.ID);
                exerciseList.Add(exercise);
                Save(exercise);
            }
        }

        public void showAllExercises()
        {
            int count = 0;
            foreach(var a in exerciseList)
            {
                if(a.UserID == user.ID)
                {
                    count++;
                    var temp = activityList.FirstOrDefault(b => b.ID == a.ActivityId);
                    if (temp != null)
                    {
                        TimeSpan ts = a.End - a.Start;
                        Console.WriteLine( $"Spent time : {ts.TotalMinutes} minutes" +
                            $" - exercise: {temp.Name}  - date: {a.Start.ToShortDateString()}");
                    }
                }
            }
            if (count == 0)
            {
                Console.WriteLine("You haven't any exercises");
            }
        }
    }


}
