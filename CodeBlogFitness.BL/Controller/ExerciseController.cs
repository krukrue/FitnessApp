using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeBlogFitness.BL.Model;

namespace CodeBlogFitness.BL.Controller
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
            activityList= GetAllActivity();
        }

        private List<Exercise>? GetAllExercises()
        {
            return Load<List<Exercise>>(Exercises_FILE_NAME) ?? new List<Exercise>(); 
        }

        private List<Activity>? GetAllActivity()
        {
            return Load<List<Activity>>(Activity_FILE_NAME) ?? new List<Activity>();
        }

        private void Save()
        {
            Save(Exercises_FILE_NAME, exerciseList);
            Save(Activity_FILE_NAME, activityList);
        }

        public void Add(Activity activity, DateTime begin, DateTime end)
        {
            var act = activityList.SingleOrDefault(f => f.Name== activity.Name);

            if (act == null)
            {
                activityList.Add(activity);
                var exercise = new Exercise(begin, end, activity, user);
                exerciseList.Add(exercise);
            }
            else
            {
                var exercise = new Exercise(begin, end, activity, user);
                exerciseList.Add(exercise);
            }
            Save();
        }
    }


}
